namespace TestCQRS.Infrastructure.Messaging.Impl
{
	internal interface IMessageDispatcher
	{
		void Dispatch(IMessage message, params object[] parameters);
	}
}
