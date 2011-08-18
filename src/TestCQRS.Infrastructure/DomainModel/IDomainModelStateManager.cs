namespace TestCQRS.Infrastructure.DomainModel
{
	public interface IDomainModelStateManager
	{
		/// <summary>
		/// Acquires the current <see cref="IDomainModelState"/> in the read-only mode.
		/// </summary>
		/// <param name="acquireReason">Specifies the intention of the caller.</param>
		/// <returns>Returns read-only <see cref="IDomainModelState"/>.</returns>
		IDomainModelState AcquireReadModel(AcquireReason acquireReason);

		/// <summary>
		/// Promotes <see cref="IDomainModelState"/> to writable mode that could accept changes.
		/// </summary>
		/// <param name="model">Model to promote.</param>
		/// <returns>Returns writable <see cref="IDomainModelState"/>.</returns>
		IDomainModelState PromoteToWriteModel(IDomainModelState model);

		/// <summary>
		/// Releases the <see cref="IDomainModelState"/>.
		/// </summary>
		/// <param name="model">Model to release.</param>
		/// <param name="releaseAction">Determines whether to accept new state of the model or not.</param>
		void ReleaseModel(IDomainModelState model, ReleaseAction releaseAction);
	}
}
