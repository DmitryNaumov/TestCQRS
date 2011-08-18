namespace TestCQRS.BusinessLogic.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public sealed class BuildersTest
	{
		public void ShouldCreateSecurity()
		{
			var security = Security.New()
				.Equity()
				.Name("Microsoft Equity")
				.CUSIP("MSFT");
		}

		public void ShouldCreateOrder()
		{
			var order = Order.New()
				.Buy((Security)null)
				.Quantity(100);
		}
	}
}
