namespace TestCQRS.Server.Events
{
	using System;

	public interface IEventHandlerFactory
	{
		/// <summary>
		/// Registers handler type.
		/// </summary>
		/// <param name="handlerType">Handler type.</param>
		void RegisterType(Type handlerType);

		/// <summary>
		/// Creates a new handler instance to handle an event.
		/// </summary>
		/// <param name="eventType">Event type to handle.</param>
		/// <param name="parameters">Handler parameters.</param>
		/// <returns>Returns new handler instance.</returns>
		IEventHandler Create(Type eventType, params object[] parameters);
	}
}
