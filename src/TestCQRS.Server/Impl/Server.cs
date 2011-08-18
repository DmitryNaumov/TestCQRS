namespace TestCQRS.Server.Impl
{
	using System;
	using TestCQRS.Infrastructure.Commands;
	using TestCQRS.Infrastructure.DomainModel;
	using TestCQRS.Infrastructure.Events;
	using TestCQRS.Infrastructure.Queries;

	internal sealed class Server : IServer
	{
		private readonly IEventPublisher _eventPublisher;
		private readonly IDomainModelStateManager _stateManager;
		private readonly ICommandProcessorFactory _commandProcessorFactory;
		private readonly IUnitOfWorkFactory _unitOfWorkFactory;

		public Server(IEventPublisher eventPublisher, IDomainModelStateManager stateManager, ICommandProcessorFactory commandProcessorFactory, IUnitOfWorkFactory unitOfWorkFactory)
		{
			_eventPublisher = eventPublisher;
			_stateManager = stateManager;
			_commandProcessorFactory = commandProcessorFactory;
			_unitOfWorkFactory = unitOfWorkFactory;
		}

		/// <summary>
		/// Executes command.
		/// </summary>
		/// <param name="command">Command to execute.</param>
		public void ExecuteCommand(ICommand command)
		{
			// TODO: should be asynchronous
			try
			{
				_eventPublisher.Publish(Event.New(new CommandPostedEventArgs(command)));

				// get model in the read-only (upgradable) mode
				var model = _stateManager.AcquireReadModel(AcquireReason.ForCommand);

				var releaseAction = ReleaseAction.DiscardChanges;
				try
				{
					using (var unitOfWork = _unitOfWorkFactory.Create(model))
					{
						// create processor for the command
						var processor = _commandProcessorFactory.Create(command);

						// validate command against the model
						processor.PreValidate(model);

						// promote model to writable (exclusive) mode
						_stateManager.PromoteToWriteModel(model);

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
					_stateManager.ReleaseModel(model, releaseAction);
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
				_eventPublisher.Publish(Event.New(new QueryPostedEventArgs(query)));

				// get model in the read-only (shared) mode
				var model = _stateManager.AcquireReadModel(AcquireReason.ForQuery);

				try
				{
					// TODO: perform query
				}
				finally
				{
					// release model
					_stateManager.ReleaseModel(model, ReleaseAction.DiscardChanges);
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
