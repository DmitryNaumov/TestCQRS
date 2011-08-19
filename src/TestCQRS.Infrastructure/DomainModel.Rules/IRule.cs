namespace TestCQRS.Infrastructure.DomainModel.Rules
{
	public interface IRule<in TEntity> where TEntity : IEntity
	{
		void Validate(TEntity entity);
	}
}
