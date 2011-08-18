namespace TestCQRS.Server.Events.Impl
{
	using System;
	using System.Collections.Generic;

	internal sealed class EventHandlerFactory : IEventHandlerFactory
	{
		private readonly Dictionary<Type, Type> _eventTypeToHandlerTypeMap = new Dictionary<Type, Type>();

		public void RegisterType(Type handlerType)
		{
			if (handlerType == null)
			{
				throw new ArgumentNullException("handlerType");
			}

			var eventTypes = GetSupportedEventTypes(handlerType);
			Array.ForEach(eventTypes, eventType => _eventTypeToHandlerTypeMap.Add(eventType, handlerType));
		}

		public IEventHandler Create(Type eventType, params object[] parameters)
		{
			if (eventType == null)
			{
				throw new ArgumentNullException("eventType");
			}

			Type handlerType;
			if (!_eventTypeToHandlerTypeMap.TryGetValue(eventType, out handlerType))
			{
				throw new ArgumentException(
					string.Format("Unsupported event type: {0}.", eventType.FullName),
					"eventType");
			}

			// TODO: use container-aware factory
			return (IEventHandler)Activator.CreateInstance(handlerType, parameters);
		}

		private static Type[] GetSupportedEventTypes(Type handlerType)
		{
			// TODO:
			throw new NotImplementedException();
		}
	}
}
