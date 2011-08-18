namespace TestCQRS.Infrastructure.Queries
{
	public sealed class QueryCompletedEventArgs : QueryEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryCompletedEventArgs"/> class.
		/// </summary>
		/// <param name="query">Original query.</param>
		public QueryCompletedEventArgs(IQuery query)
			: base(query)
		{
		}
	}
}
