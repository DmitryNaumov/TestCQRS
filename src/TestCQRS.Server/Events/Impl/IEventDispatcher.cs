namespace TestCQRS.Server.Events.Impl
{
	internal interface IEventDispatcher
	{
		void Dispatch(IEvent @event, params object[] parameters);
	}
}
