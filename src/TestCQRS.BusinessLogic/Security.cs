namespace TestCQRS.BusinessLogic
{
	using TestCQRS.BusinessLogic.Builders;
	using TestCQRS.BusinessLogic.Builders.Impl;
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Security : AggregateRoot<Security>
	{
		internal Security()
		{
		}

		public static ISecurityBuilder New()
		{
			return new SecurityBuilder();
		}
	}
}
