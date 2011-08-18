namespace TestCQRS.Server.Queries
{
	using System;

	public sealed class QueryFailedEventArgs : QueryEventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="QueryFailedEventArgs"/> class.
		/// </summary>
		/// <param name="query">Original query.</param>
		/// <param name="exception">Failure exception.</param>
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
