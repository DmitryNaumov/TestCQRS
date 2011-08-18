namespace TestCQRS.Infrastructure.DomainModel
{
	public enum ReleaseAction
	{
		/// <summary>
		/// Specifies that all changes should be discarded.
		/// </summary>
		DiscardChanges,

		/// <summary>
		/// Specifies that all changes should be accepted as a new model state.
		/// </summary>
		AcceptChanges,
	}
}
