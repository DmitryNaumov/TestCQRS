namespace TestCQRS.Infrastructure.DomainModel
{
	public abstract class Entity<TRoot, TEntity> : IEntity
		where TRoot : IAggregateRoot
		where TEntity : IEntity
	{
		protected Entity()
		{
			// persistence constructor
		}

		protected Entity(TRoot root)
		{
			Root = root;
		}

		public TRoot Root { get; private set; }

		#region IEntity Members

		IAggregateRoot IEntity.Root
		{
			get
			{
				return Root;
			}
		}

		#endregion
	}
}
