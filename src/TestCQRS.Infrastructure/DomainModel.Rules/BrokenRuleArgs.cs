namespace TestCQRS.Infrastructure.DomainModel.Rules
{
	public sealed class BrokenRuleArgs
	{
		public BrokenRuleArgs(string ruleId)
		{
			RuleId = ruleId;
		}

		public string RuleId { get; private set; }
	}
}
