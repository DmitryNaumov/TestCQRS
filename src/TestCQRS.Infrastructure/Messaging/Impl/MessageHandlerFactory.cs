namespace TestCQRS.Infrastructure.Messaging.Impl
{
	using System;
	using System.Collections.Generic;

	internal sealed class MessageHandlerFactory : IMessageHandlerFactory
	{
		private readonly Dictionary<Type, Type> _messageTypeToHandlerTypeMap = new Dictionary<Type, Type>();

		public void Register(Type handlerType)
		{
			if (handlerType == null)
			{
				throw new ArgumentNullException("handlerType");
			}

			var messageTypes = GetSupportedMessageTypes(handlerType);
			Array.ForEach(messageTypes, messageType => _messageTypeToHandlerTypeMap.Add(messageType, handlerType));
		}

		public IMessageHandler Create(Type messageType, params object[] parameters)
		{
			if (messageType == null)
			{
				throw new ArgumentNullException("messageType");
			}

			Type handlerType;
			if (!_messageTypeToHandlerTypeMap.TryGetValue(messageType, out handlerType))
			{
				throw new ArgumentException(
					string.Format("Unsupported message type: {0}.", messageType.FullName),
					"messageType");
			}

			// TODO: use container-aware factory
			return (IMessageHandler)Activator.CreateInstance(handlerType, parameters);
		}

		private static Type[] GetSupportedMessageTypes(Type handlerType)
		{
			// TODO:
			throw new NotImplementedException();
		}
	}
}
