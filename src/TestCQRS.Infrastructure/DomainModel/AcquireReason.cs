namespace TestCQRS.Infrastructure.DomainModel
{
	public enum AcquireReason
	{
		/// <summary>
		/// Specifies that caller intention is to read the model state. Multiple queries are allowed to execute at one time.
		/// </summary>
		ForQuery,

		/// <summary>
		/// Specifies that caller intention is to update the model state. Only single command is allowed to execute at one time.
		/// </summary>
		ForCommand,
	}
}
