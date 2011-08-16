namespace TestCQRS.Server.Commands
{
	using System;
	using TestCQRS.Server.Events;

	public interface IUnitOfWork : IEventPublisher, IDisposable
	{
		/// <summary>
		/// Commits all events made in the current <see cref="IUnitOfWork"/> to the <see cref="IEventStore"/>.
		/// </summary>
		void Commit();
	}
}
