namespace TestCQRS.Infrastructure.DomainModel.Impl
{
	using System;
	using System.Threading;

	internal sealed class DomainModelStateManager : IDomainModelStateManager, IDisposable
	{
		private readonly ReaderWriterLockSlim _stateLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

		private DomainModelState _currentState;
		private DomainModelState _nextState;

		public DomainModelStateManager(DomainModelState initialState)
		{
			_currentState = initialState;
		}

		public void Dispose()
		{
			_stateLock.Dispose();
		}

		public IDomainModelState AcquireReadModel(AcquireReason acquireReason)
		{
			switch (acquireReason)
			{
				case AcquireReason.ForQuery:
					_stateLock.EnterReadLock();
					break;

				case AcquireReason.ForCommand:
					_stateLock.EnterUpgradeableReadLock();
					break;

				default:
					throw new ArgumentException(
						string.Format("Invalid acquire reason '{0}' specified.", acquireReason), "acquireReason");
			}

			return DomainModelStateProxy.Wrap(_currentState, acquireReason);
		}

		public IDomainModelState PromoteToWriteModel(IDomainModelState model)
		{
			var proxy = DomainModelStateProxy.Unwrap(model);
			if (_currentState != proxy.Model)
			{
				throw new InvalidOperationException("Attempt to override current state detected.");
			}

			if (proxy.AcquireReason != AcquireReason.ForCommand)
			{
				throw new InvalidOperationException("Model acquired for query execution could not be promoted to writable mode.");
			}

			// TODO: create new state
			var nextState = new DomainModelState();

			_stateLock.EnterWriteLock();

			_nextState = nextState;
			return DomainModelStateProxy.Wrap(nextState, AcquireReason.ForCommand);
		}

		public void ReleaseModel(IDomainModelState model, ReleaseAction releaseAction)
		{
			var proxy = DomainModelStateProxy.Unwrap(model);

			switch (releaseAction)
			{
				case ReleaseAction.AcceptChanges:
					if (_nextState != proxy.Model)
					{
						throw new InvalidOperationException("Attempt to override current state detected.");
					}

					_currentState = _nextState;
					_nextState = null;

					_stateLock.ExitWriteLock();
					break;

				case ReleaseAction.DiscardChanges:
					break;

				default:
					throw new ArgumentException(
						string.Format("Invalid release action '{0}' specified.", releaseAction), "releaseAction");
			}

			proxy.Detach();

			_stateLock.ExitReadLock();
		}
	}
}
