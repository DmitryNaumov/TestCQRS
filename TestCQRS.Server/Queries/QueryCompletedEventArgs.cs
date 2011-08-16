namespace TestCQRS.Server.Queries
{
	public sealed class QueryCompletedEventArgs : QueryEventArgs
	{
		public QueryCompletedEventArgs(IQuery query)
			: base(query)
		{
		}
	}
}
