namespace TestCQRS.BusinessLogic.DomainModel.Builders
{
	public interface IOrderBuilder
	{
		IOrderBuilder Buy(Security security);

		IOrderBuilder Buy(ISecurityBuilder security);

		IOrderBuilder Quantity(decimal quantity);
	}
}
