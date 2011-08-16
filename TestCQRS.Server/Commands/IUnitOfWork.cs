namespace TestCQRS.Server.Commands
{
	using System;
	using TestCQRS.Server.Events;

	public interface IUnitOfWork : IDisposable
	{
		void RaiseEvent(IEvent @event);

		void Commit();
	}
}
