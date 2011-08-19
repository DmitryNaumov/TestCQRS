namespace TestCQRS.Infrastructure.DomainModel.Rules.Impl
{
	using TestCQRS.Infrastructure.ComponentModel;

	internal sealed class RuleAssertion : IRuleAssertion
	{
		private readonly string _ruleId;

		public RuleAssertion(string ruleId)
		{
			_ruleId = ruleId;
		}

		public void Fail(string message)
		{
			throw new Exception<BrokenRuleArgs>(new BrokenRuleArgs(_ruleId), message);
		}
	}
}
