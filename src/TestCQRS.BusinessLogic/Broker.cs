namespace TestCQRS.BusinessLogic
{
	using TestCQRS.Infrastructure.DomainModel;

	public sealed class Broker : AggregateRoot<Broker>
	{
		internal Broker()
		{
		}
	}
}
