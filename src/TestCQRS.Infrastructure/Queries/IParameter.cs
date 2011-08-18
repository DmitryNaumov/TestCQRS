namespace TestCQRS.Infrastructure.Queries
{
	public interface IParameter
	{
		/// <summary>
		/// Gets the parameter name.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the parameter value.
		/// </summary>
		object Value { get; }
	}
}
