namespace TestCQRS.Infrastructure.Messaging.Impl
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Reflection;

	internal sealed class MessageDispatcher : IMessageDispatcher
	{
		private readonly Dictionary<Type, Action<IMessageHandler, IMessage>> _dispatchers = new Dictionary<Type, Action<IMessageHandler, IMessage>>();
		private readonly IMessageHandlerFactory _messageHandlerFactory;

		public MessageDispatcher(IMessageHandlerFactory messageHandlerFactory)
		{
			_messageHandlerFactory = messageHandlerFactory;
		}

		public void Dispatch(IMessage @message, params object[] parameters)
		{
			if (@message == null)
			{
				throw new ArgumentNullException("message");
			}

			var handler = _messageHandlerFactory.Create(@message.GetType(), parameters);
			var dynamicDispatcher = GetDynamicDispatcher(@message.GetType());

			dynamicDispatcher(handler, @message);
		}

		private Action<IMessageHandler, IMessage> GetDynamicDispatcher(Type messageType)
		{
			lock (_dispatchers)
			{
				Action<IMessageHandler, IMessage> dispatcher;
				if (!_dispatchers.TryGetValue(messageType, out dispatcher))
				{
					dispatcher = CompileDynamicDispatcher(messageType);
					_dispatchers.Add(messageType, dispatcher);
				}

				return dispatcher;
			}
		}

		private static Action<IMessageHandler, IMessage> CompileDynamicDispatcher(Type messageType)
		{
			var handlerParameter = Expression.Parameter(typeof(IMessageHandler), "handler");
			var messageParameter = Expression.Parameter(messageType, "message");

			var handlerType = typeof(IMessageHandler<>).MakeGenericType(messageType);
			var handleMethod = handlerType.GetMethod("Handle", BindingFlags.Public | BindingFlags.Instance);

			var castExpr = Expression.Convert(handlerParameter, handlerType);
			var invokeExpr = Expression.Call(castExpr, handleMethod, messageParameter);
			var lambdaExpr = Expression.Lambda<Action<IMessageHandler, IMessage>>(invokeExpr, handlerParameter, messageParameter);

			return lambdaExpr.Compile();
		}
	}
}
