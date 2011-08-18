namespace TestCQRS.BusinessLogic
{
	using System;
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Ticket : Entity<Order, Ticket>
	{
		[Obsolete("Persistence constructor - do not use", true)]
		internal Ticket()
		{
		}

		internal Ticket(Order order)
			: base(order)
		{
		}
	}
}
