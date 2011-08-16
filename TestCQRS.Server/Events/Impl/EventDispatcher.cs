﻿namespace TestCQRS.Server.Events.Impl
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	internal sealed class EventDispatcher : IEventDispatcher
	{
		private readonly Dictionary<Type, Action<IEventHandler, IEvent>> _dispatchers = new Dictionary<Type, Action<IEventHandler, IEvent>>();
		private readonly IEventHandlerFactory _eventHandlerFactory;

		public EventDispatcher(IEventHandlerFactory eventHandlerFactory)
		{
			_eventHandlerFactory = eventHandlerFactory;
		}

		public void Dispatch(IEvent @event, params object[] parameters)
		{
			if (@event == null)
			{
				throw new ArgumentNullException("event");
			}

			var handler = _eventHandlerFactory.Create(@event.GetType(), parameters);
			var dynamicDispatcher = GetDynamicDispatcher(@event.GetType());

			dynamicDispatcher(handler, @event);
		}

		private Action<IEventHandler, IEvent> GetDynamicDispatcher(Type eventType)
		{
			lock (_dispatchers)
			{
				Action<IEventHandler, IEvent> dispatcher;
				if (!_dispatchers.TryGetValue(eventType, out dispatcher))
				{
					dispatcher = CompileDynamicDispatcher(eventType);
					_dispatchers.Add(eventType, dispatcher);
				}

				return dispatcher;
			}
		}

		private static Action<IEventHandler, IEvent> CompileDynamicDispatcher(Type eventType)
		{
			var handlerParameter = Expression.Parameter(typeof(IEventHandler), "handler");
			var eventParameter = Expression.Parameter(eventType, "event");

			var castExpr = Expression.Convert(handlerParameter, typeof(IEventHandler<>).MakeGenericType(eventType));
			var invokeExpr = Expression.Call(castExpr, "HandleEvent", null, eventParameter);
			var lambdaExpr = Expression.Lambda<Action<IEventHandler, IEvent>>(invokeExpr, handlerParameter, eventParameter);

			return lambdaExpr.Compile();
		}
	}
}