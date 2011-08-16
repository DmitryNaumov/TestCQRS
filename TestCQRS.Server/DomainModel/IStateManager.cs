namespace TestCQRS.Server.DomainModel
{
	public interface IStateManager
	{
		/// <summary>
		/// Acquires the current <see cref="IDomainModelState"/> in the read-only mode.
		/// </summary>
		/// <param name="reason">Specifies the intention of the caller.</param>
		/// <returns>Returns read-only <see cref="IDomainModelState"/></returns>
		IDomainModelState Acquire(AcquireReason reason);

		/// <summary>
		/// Promotes <see cref="IDomainModelState"/> to writable mode that could accept changes.
		/// </summary>
		/// <param name="model">Model to promote.</param>
		void Promote(IDomainModelState model);

		/// <summary>
		/// Releases the <see cref="IDomainModelState"/>.
		/// </summary>
		/// <param name="model">Model to release.</param>
		/// <param name="releaseAction">Determines whether to accept new state of the model or not.</param>
		void Release(IDomainModelState model, ReleaseAction releaseAction);
	}
}
