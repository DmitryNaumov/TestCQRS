﻿namespace TestCQRS.Server.DomainModel
{
	using System;
	using System.Collections.Generic;
	using TestCQRS.Server.Events;

	public abstract class AggregateRoot : IAggregateRoot
	{
		private readonly List<IEvent> _events = new List<IEvent>();

		/// <summary>
		/// Gets the unique identifier.
		/// </summary>
		public long Id { get; private set; }

		/// <summary>
		/// Raises domain event with the specified arguments.
		/// </summary>
		/// <typeparam name="T">Event type.</typeparam>
		/// <param name="args">Event arguments.</param>
		protected void RaiseEvent<T>(T args) where T : DomainEventArgs
		{
			if (args == null)
			{
				throw new ArgumentNullException("args");
			}

			if (args.AggregateRoot != this)
			{
				throw new InvalidOperationException("Invalid aggregate root specified.");
			}

			_events.Add(Event.New(args));
		}

		#region IEventSource Members

		IEnumerable<IEvent> IEventSource.FlushEvents()
		{
			var events = _events.ToArray();
			_events.Clear();
			return events;
		}

		#endregion
	}
}
