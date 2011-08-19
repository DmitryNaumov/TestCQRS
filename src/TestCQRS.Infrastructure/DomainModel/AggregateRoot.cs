namespace TestCQRS.Infrastructure.DomainModel
{
	using System;
	using System.Collections.Generic;
	using TestCQRS.Infrastructure.Messaging.Events;

	public abstract class AggregateRoot<TRoot> : IAggregateRoot where TRoot : IAggregateRoot
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

			if (args.Root != this)
			{
				throw new InvalidOperationException("Invalid aggregate root specified.");
			}

			_events.Add(Event.New(args));
		}

		#region IEventSource Members

		IEnumerable<IEvent> IEventSource.GetEvents()
		{
			return _events.AsReadOnly();
		}

		#endregion

		#region IEntity Members

		IAggregateRoot IEntity.Root
		{
			get
			{
				return this;
			}
		}

		#endregion
	}
}
