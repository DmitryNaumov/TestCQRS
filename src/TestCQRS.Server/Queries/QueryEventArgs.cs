namespace TestCQRS.Server.Queries
{
	public abstract class QueryEventArgs
	{
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
