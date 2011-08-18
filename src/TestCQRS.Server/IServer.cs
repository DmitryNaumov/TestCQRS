namespace TestCQRS.Server
{
	using TestCQRS.Infrastructure.Commands;
	using TestCQRS.Infrastructure.Queries;

	public interface IServer : ICommandService, IQueryService
	{
	}
}
