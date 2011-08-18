namespace TestCQRS.Server.DomainModel.Impl
{
	using System;
	using System.Threading;

	internal sealed class DomainModelStateProxy : IDomainModelState
	{
		private readonly IDomainModelState _model;
		private readonly AcquireReason _acquireReason;
		private readonly int _originalThreadId;
		private bool _detached;

		private DomainModelStateProxy(IDomainModelState model, AcquireReason acquireReason)
		{
			_model = model;
			_acquireReason = acquireReason;
			_originalThreadId = Thread.CurrentThread.ManagedThreadId;
		}

		public IDomainModelState Model
		{
			get
			{
				return _model;
			}
		}

		public AcquireReason AcquireReason
		{
			get
			{
				return _acquireReason;
			}
		}

		public void Detach()
		{
			_detached = true;
		}

		public static DomainModelStateProxy Wrap(IDomainModelState model, AcquireReason acquireReason)
		{
			if (model == null)
			{
				throw new ArgumentNullException("model");
			}

			var proxy = model as DomainModelStateProxy;
			if (proxy != null)
			{
				throw new InvalidOperationException("Attempt to wrap already wrapped model detected.");
			}

			return new DomainModelStateProxy(model, acquireReason);
		}

		public static DomainModelStateProxy Unwrap(IDomainModelState model)
		{
			if (model == null)
			{
				throw new ArgumentNullException("model");
			}

			var proxy = model as DomainModelStateProxy;
			if (proxy == null)
			{
				throw new InvalidOperationException("Attempt to unwrap not-wrapped model detected.");
			}

			return proxy;
		}

		#region IDomainModelState Members

		long IDomainModelState.Version
		{
			get
			{
				ThrowIfNotValid();
				return _model.Version;
			}
		}

		#endregion

		#region IRepository Members

		TAggregateRoot IRepository.Get<TAggregateRoot>(long objectId)
		{
			ThrowIfNotValid();
			return _model.Get<TAggregateRoot>(objectId);
		}

		#endregion

		private void ThrowIfNotValid()
		{
			if (_detached)
			{
				throw new InvalidOperationException("Attempt to access domain model state through detached proxy detected.");
			}

			if (_originalThreadId != Thread.CurrentThread.ManagedThreadId)
			{
				throw new InvalidOperationException("Attempt to access domain model state from multiple threads detected.");
			}
		}
	}
}
