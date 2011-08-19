namespace TestCQRS.Server
{
	using TestCQRS.Infrastructure.Messaging.Commands;
	using TestCQRS.Infrastructure.Queries;

	public interface IServer : ICommandService, IQueryService
	{
	}
}
