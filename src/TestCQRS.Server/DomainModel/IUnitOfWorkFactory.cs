namespace TestCQRS.Server.DomainModel
{
	public interface IUnitOfWorkFactory
	{
		/// <summary>
		/// Creates a new instance of the <see cref="IUnitOfWork"/> class.
		/// </summary>
		IUnitOfWork Create(IDomainModelState model);
	}
}
