namespace TestCQRS.Server.DomainModel.Impl
{
	internal sealed class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork Create(IDomainModelState model)
		{
			return new UnitOfWork(model);
		}
	}
}
