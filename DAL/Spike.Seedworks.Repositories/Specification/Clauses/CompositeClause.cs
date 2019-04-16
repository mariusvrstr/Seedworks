namespace Spike.Seedworks.Repositories.Specification.Clauses
{
    public abstract class CompositeClause<TEntity> : Clause<TEntity> where TEntity : class
    {
        public abstract IClause<TEntity> LeftSideSpecification
        {
            get;
        }

        public abstract IClause<TEntity> RightSideSpecification
        {
            get;
        }
    }
}
