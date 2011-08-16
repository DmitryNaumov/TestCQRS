namespace TestCQRS.Server.Events
{
	public interface IEventDispatcher
	{
		void Dispatch(IEvent @event, params object[] parameters);
	}
}
