namespace TestCQRS.Infrastructure.Queries
{
	public abstract class QueryEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryEventArgs"/> class.
		/// </summary>
		/// <param name="query">Original query.</param>
		protected QueryEventArgs(IQuery query)
		{
			Query = query;
		}

		/// <summary>
		/// Gets the original query.
		/// </summary>
		public IQuery Query { get; private set; }
	}
}
