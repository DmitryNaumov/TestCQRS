namespace TestCQRS.Server.Queries
{
	using System;

	public sealed class QueryFailedEventArgs : QueryEventArgs
	{
		public QueryFailedEventArgs(IQuery query, Exception exception)
			: base(query)
		{
			Exception = exception;
		}

		/// <summary>
		/// Gets the failure exception.
		/// </summary>
		public Exception Exception { get; private set; }
	}
}
