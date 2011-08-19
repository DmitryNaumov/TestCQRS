namespace TestCQRS.Infrastructure.DomainModel.Rules
{
	public static class RuleAssertionExtensions
	{
		public static void IsFalse(this IRuleAssertion assert, string message, bool condition)
		{
			if (condition)
			{
				assert.Fail(message);
			}
		}

		public static void IsTrue(this IRuleAssertion assert, string message, bool condition)
		{
			if (!condition)
			{
				assert.Fail(message);
			}
		}
	}
}
