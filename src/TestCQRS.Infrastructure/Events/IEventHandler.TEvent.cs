namespace TestCQRS.Infrastructure.Messaging
{
	public interface IMessageHandler<in TMessage> : IMessageHandler where TMessage : IMessage
	{
		/// <summary>
		/// Handles message.
		/// </summary>
		/// <param name="message">Message to handle.</param>
		void Handle(TMessage message);
	}
}
