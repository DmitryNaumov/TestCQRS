namespace TestCQRS.Server.DomainModel
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork Create(IDomainModelState model);
	}
}
