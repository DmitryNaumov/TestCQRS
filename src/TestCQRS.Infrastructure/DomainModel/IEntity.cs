namespace TestCQRS.Infrastructure.DomainModel
{
	public interface IEntity
	{
		IAggregateRoot Root { get; }
	}
}
