namespace TestCQRS.BusinessLogic.Builders
{
	public interface IOrderBuilder
	{
		IOrderBuilder Buy(Security security);

		IOrderBuilder Buy(ISecurityBuilder security);

		IOrderBuilder Quantity(decimal quantity);
	}
}
