namespace TestCQRS.Infrastructure.Events.Impl
{
	internal interface IEventDispatcher
	{
		void Dispatch(IEvent @event, params object[] parameters);
	}
}
