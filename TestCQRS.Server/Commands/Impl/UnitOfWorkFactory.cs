namespace TestCQRS.Server.Commands.Impl
{
	internal sealed class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		public IUnitOfWork Create()
		{
			// TODO: create nested container bound to unit-of-work
			return new UnitOfWork();
		}
	}
}
