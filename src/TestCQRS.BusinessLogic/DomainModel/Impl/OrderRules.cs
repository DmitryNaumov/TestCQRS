namespace TestCQRS.BusinessLogic.DomainModel.Impl
{
	using TestCQRS.Infrastructure.DomainModel.Rules;

	internal static class OrderRules
	{
		#region BookingRules

		public sealed class ShouldBeReleased : Rule<Order>
		{
			public ShouldBeReleased(IRuleAssertion assert)
				: base("BookingRules.ShouldBeReleased", assert)
			{
			}

			public override void Validate(Order order)
			{
				Assert.IsTrue("Only released orders could be booked.", order.Status == OrderStatus.Released);
			}
		}

		public sealed class ShouldBeFullyExecuted : Rule<Order>
		{
			public ShouldBeFullyExecuted(IRuleAssertion assert)
				: base("BookingRules.ShouldBeFullyExecuted", assert)
			{
			}

			public override void Validate(Order order)
			{
				Assert.IsTrue("Only executed orders could be booked.", order.ExecutedQuantity == order.Quantity);
			}
		}

		#endregion
	}
}
