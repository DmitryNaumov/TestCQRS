namespace TestCQRS.Infrastructure.Queries
{
	using System.Collections.ObjectModel;

	public interface IQuery
	{
		/// <summary>
		/// Gets the query specification.
		/// </summary>
		ISpecification Specification { get; }

		/// <summary>
		/// Gets the query parameters.
		/// </summary>
		ReadOnlyCollection<IParameter> Parameters { get; }
	}
}
