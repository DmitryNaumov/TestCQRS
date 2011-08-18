namespace TestCQRS.Server.DomainModel.Impl
{
	internal sealed class UnitOfWork : IUnitOfWork
	{
		private readonly IDomainModelState _model;

		public UnitOfWork(IDomainModelState model)
		{
			_model = model;
		}

		public void Commit()
		{
			// TODO:
		}

		public void Dispose()
		{
			// TODO:
		}
	}
}
