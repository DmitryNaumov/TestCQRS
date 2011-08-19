namespace TestCQRS.BusinessLogic.DomainModel
{
	using TestCQRS.BusinessLogic.DomainModel.Builders;
	using TestCQRS.BusinessLogic.DomainModel.Builders.Impl;
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
