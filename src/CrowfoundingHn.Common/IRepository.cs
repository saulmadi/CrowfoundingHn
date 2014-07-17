using System;
using System.Linq.Expressions;

namespace CrowfoundingHn.Common
{
    public interface IRepository<TEntity> where TEntity :IEntity
    {
        TEntity Create(TEntity entity);

        TEntity First(Expression<Func<TEntity, bool>> query);
    }
}