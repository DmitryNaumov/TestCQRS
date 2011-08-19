namespace TestCQRS.BusinessLogic.DomainModel
{
	using System;
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Execution : Entity<Order, Execution>
	{
		[Obsolete("Persistence constructor - do not use", true)]
		internal Execution()
		{
		}

		internal Execution(Order order)
			: base(order)
		{
		}
	}
}
