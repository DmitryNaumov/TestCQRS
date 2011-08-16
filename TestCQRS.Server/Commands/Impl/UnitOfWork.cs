namespace TestCQRS.Server.Commands.Impl
{
	using TestCQRS.Server.Events;

	internal sealed class UnitOfWork : IUnitOfWork
	{
		public void RaiseEvent(IEvent @event)
		{
			// TODO:
		}

		public void Commit()
		{
			// TODO:
		}

		public void Dispose()
		{
			// TODO:
		}
	}
}
