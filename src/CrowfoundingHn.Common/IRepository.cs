using System;
using System.Linq.Expressions;

namespace CrowfoundingHn.Common
{
    public interface IRepository<TEntity> where TEntity :IEntity
    {
        TEntity Create(TEntity user);

        TEntity First(Expression<Func<TEntity, bool>> query);
    }
}