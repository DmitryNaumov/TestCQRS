namespace TestCQRS.BusinessLogic.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using TestCQRS.BusinessLogic.DomainModel;

	[TestClass]
	public sealed class BuildersTest
	{
		[TestMethod]
		public void ShouldCreateSecurity()
		{
			var security = Security.New()
				.Equity()
				.Name("Microsoft Equity")
				.CUSIP("MSFT");
		}

		[TestMethod]
		public void ShouldCreateOrder()
		{
			var order = Order.New()
				.Buy((Security)null)
				.Quantity(100);
		}
	}
}
