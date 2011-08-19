namespace TestCQRS.Infrastructure.Messaging
{
	using System;

	public interface IMessageHandlerFactory
	{
		/// <summary>
		/// Registers handler.
		/// </summary>
		/// <param name="handlerType">Handler type.</param>
		void Register(Type handlerType);

		/// <summary>
		/// Creates a new handler instance to handle an message.
		/// </summary>
		/// <param name="messageType">Message type to handle.</param>
		/// <param name="parameters">Handler parameters.</param>
		/// <returns>Returns new handler instance.</returns>
		IMessageHandler Create(Type messageType, params object[] parameters);
	}
}
