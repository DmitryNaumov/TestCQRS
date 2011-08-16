namespace TestCQRS.Server
{
	using System;
	using TestCQRS.Server.Commands;
	using TestCQRS.Server.Events;
	using TestCQRS.Server.Queries;

	public interface IServer : ICommandService, IQueryService
	{
		/// <summary>
		/// Raised when event occurs.
		/// </summary>
		event Action<IEvent> EventOccured;
	}
}
