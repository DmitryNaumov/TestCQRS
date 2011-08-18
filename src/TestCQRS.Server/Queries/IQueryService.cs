namespace TestCQRS.Server.Queries
{
	public interface IQueryService
	{
		/// <summary>
		/// Executes query.
		/// </summary>
		/// <param name="query">Query to execute.</param>
		void ExecuteQuery(IQuery query);
	}
}
