namespace TestCQRS.BusinessLogic
{
	using System;
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Allocation : Entity<Order, Allocation>
	{
		[Obsolete("Persistence constructor - do not use", true)]
		internal Allocation()
		{
		}

		internal Allocation(Order order)
			: base(order)
		{
		}
	}
}
