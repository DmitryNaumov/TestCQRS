namespace TestCQRS.BusinessLogic.DomainModel
{
	using System.Collections.Generic;
	using TestCQRS.BusinessLogic.DomainModel.Builders;
	using TestCQRS.BusinessLogic.DomainModel.Builders.Impl;
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Order : AggregateRoot<Order>
	{
		private readonly List<Ticket> _tickets = new List<Ticket>();

		internal Order()
		{
		}

		public OrderStatus Status { get; private set; }

		public Security Security { get; private set; }

		public decimal Quantity { get; private set; }

		public static IOrderBuilder New()
		{
			return new OrderBuilder();
		}

		public Ticket AddTicket()
		{
			var ticket = new Ticket(this);
			_tickets.Add(ticket);
			return ticket;
		}

		public void Book()
		{
			// TODO:
		}
	}
}
