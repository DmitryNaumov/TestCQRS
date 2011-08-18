namespace TestCQRS.Server.Queries
{
	public sealed class QueryPostedEventArgs : QueryEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryPostedEventArgs"/> class.
		/// </summary>
		/// <param name="query">Original query.</param>
		public QueryPostedEventArgs(IQuery query)
			: base(query)
		{
		}
	}
}
