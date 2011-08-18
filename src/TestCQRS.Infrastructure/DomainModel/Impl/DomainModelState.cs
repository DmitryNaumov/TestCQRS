namespace TestCQRS.Infrastructure.DomainModel.Impl
{
	using System;
	using System.Collections.Generic;

	internal sealed class DomainModelState : IDomainModelState
	{
		private readonly Dictionary<Tuple<Type, long>, IAggregateRoot> _identityMap = new Dictionary<Tuple<Type, long>, IAggregateRoot>();

		public long Version { get; private set; }

		public TRoot Get<TRoot>(long objectId) where TRoot : IAggregateRoot
		{
			IAggregateRoot instance;
			if (!_identityMap.TryGetValue(Tuple.Create(typeof(TRoot), objectId), out instance))
			{
				throw new ArgumentException(
					string.Format("Invalid object identifier '{0} #{1}' specified. Object not found.", typeof(TRoot).Name, objectId),
					"objectId");
			}

			return (TRoot)instance;
		}
	}
}
