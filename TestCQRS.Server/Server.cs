namespace TestCQRS.Server
{
	using System;
	using TestCQRS.Server.Commands;
	using TestCQRS.Server.DomainModel;
	using TestCQRS.Server.Events;
	using TestCQRS.Server.Queries;

	internal sealed class Server : IServer
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IStateManager _stateManager;
		private readonly ICommandProcessorFactory _commandProcessorFactory;
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;

		public Server(IEventPublisher eventPublisher, IStateManager stateManager, ICommandProcessorFactory commandProcessorFactory, IUnitOfWorkFactory unitOfWorkFactory)
		{
			_eventPublisher = eventPublisher;
			_stateManager = stateManager;
			_commandProcessorFactory = commandProcessorFactory;
			_unitOfWorkFactory = unitOfWorkFactory;
		}

		/// <summary>
		/// Raised when event occurs.
		/// </summary>
		public event Action<IEvent> EventOccured;

		/// <summary>
		/// Executes command.
		/// </summary>
		/// <param name="command">Command to execute.</param>
		public void ExecuteCommand(ICommand command)
		{
			// TODO: should be asynchronous
			try
			{
				// get model in the read-only (upgradable) mode
				var model = _stateManager.Acquire(AcquireReason.ForCommand);

				var releaseAction = ReleaseAction.DiscardChanges;
				try
				{
					using (var unitOfWork = _unitOfWorkFactory.Create())
					{
						// create processor for the command
						var processor = _commandProcessorFactory.Create(unitOfWork, command);

						// validate command against the model
						processor.PreValidate(model);

						// promote model to writable (exclusive) mode
						_stateManager.Promote(model);

						// execute command to mutate the model state
						processor.Execute(model);

						// validate the new model state
						processor.PostValidate(model);

						// commit all events raised during the command execution
						unitOfWork.Commit();
					}

					// accept new state
					releaseAction = ReleaseAction.AcceptChanges;
				}
				finally
				{
					// release model
					_stateManager.Release(model, releaseAction);
				}

				_eventPublisher.Publish(Event.New(new CommandCompletedEventArgs(command)));
			}
			catch (Exception ex)
			{
				_eventPublisher.Publish(Event.New(new CommandFailedEventArgs(command, ex)));
			}
		}

		/// <summary>
		/// Executes query.
		/// </summary>
		/// <param name="query">Query to execute.</param>
		public void ExecuteQuery(IQuery query)
		{
			// TODO: should be asynchronous
			try
			{
				// get model in the read-only (shared) mode
				var model = _stateManager.Acquire(AcquireReason.ForQuery);

				try
				{
					// TODO: perform query
				}
				finally
				{
					// release model
					_stateManager.Release(model, ReleaseAction.DiscardChanges);
				}

				_eventPublisher.Publish(Event.New(new QueryCompletedEventArgs(query)));
			}
			catch (Exception ex)
			{
				_eventPublisher.Publish(Event.New(new QueryFailedEventArgs(query, ex)));
			}
		}
	}
}
