namespace TestCQRS.Server.Commands
{
	public interface IUnitOfWorkFactory
	{
		IUnitOfWork Create();
	}
}
