namespace TestCQRS.Server
{
	using TestCQRS.Server.Commands;
	using TestCQRS.Server.Queries;

	public interface IServer : ICommandService, IQueryService
	{
	}
}
