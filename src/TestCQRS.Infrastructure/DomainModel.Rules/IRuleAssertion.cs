namespace TestCQRS.Infrastructure.DomainModel.Rules
{
	public interface IRuleAssertion
	{
		void Fail(string message);
	}
}
