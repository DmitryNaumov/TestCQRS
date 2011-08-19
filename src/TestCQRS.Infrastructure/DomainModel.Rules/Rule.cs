namespace TestCQRS.Infrastructure.DomainModel.Rules
{
	public abstract class Rule<TEntity> : IRule<TEntity> where TEntity : IEntity
	{
		protected Rule(string ruleId, IRuleAssertion assert)
		{
			RuleId = ruleId;
			Assert = assert;
		}

		public string RuleId { get; private set; }

		public IRuleAssertion Assert { get; private set; }

		public abstract void Validate(TEntity entity);
	}
}
