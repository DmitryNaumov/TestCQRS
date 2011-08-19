namespace TestCQRS.BusinessLogic.DomainModel.Builders
{
	public interface ISecurityBuilder
	{
		ISecurityBuilder Equity();

		ISecurityBuilder Name(string name);

		ISecurityBuilder CUSIP(string cusip);
	}
}
