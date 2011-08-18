namespace TestCQRS.BusinessLogic.Builders.Impl
{
	internal sealed class OrderBuilder : IOrderBuilder
	{
		private Order _order;
		private ISecurityBuilder _security;
		private decimal _quantity;

		public OrderBuilder()
		{
		}

		public OrderBuilder(Order order)
		{
			_order = order;
		}

		public IOrderBuilder Buy(Security security)
		{
			_security = new SecurityBuilder(security);
			return this;
		}

		public IOrderBuilder Buy(ISecurityBuilder security)
		{
			_security = security;
			return this;
		}

		public IOrderBuilder Quantity(decimal quantity)
		{
			_quantity = quantity;
			return this;
		}
	}
}
