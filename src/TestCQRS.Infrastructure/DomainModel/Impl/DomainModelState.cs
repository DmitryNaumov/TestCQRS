namespace TestCQRS.Server.DomainModel.Impl
{
	using System;
	using System.Collections.Generic;

	internal sealed class DomainModelState : IDomainModelState
	{
		private readonly Dictionary<Tuple<Type, long>, IAggregateRoot> _identityMap = new Dictionary<Tuple<Type, long>, IAggregateRoot>();

		public long Version { get; private set; }

		public TAggregateRoot Get<TAggregateRoot>(long objectId) where TAggregateRoot : IAggregateRoot
		{
			IAggregateRoot instance;
			if (!_identityMap.TryGetValue(Tuple.Create(typeof(TAggregateRoot), objectId), out instance))
			{
				throw new ArgumentException(
					string.Format("Invalid object identifier '{0} #{1}' specified. Object not found.", typeof(TAggregateRoot).Name, objectId),
					"objectId");
			}

			return (TAggregateRoot)instance;
		}
	}
}
