namespace TestCQRS.BusinessLogic
{
	using System;
	using System.Collections.Generic;
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Ticket : Entity<Order, Ticket>
	{
		private readonly List<Execution> _executions = new List<Execution>();
		private readonly List<Allocation> _allocations = new List<Allocation>();

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
