using System;
using System.Linq.Expressions;

using CrowfoundingHn.Common.Authentication;

namespace CrowfoundingHn.Common
{
    public interface IRepository<TEntity> where TEntity :IEntity
    {
        TEntity Create(TEntity entity);

        TEntity First(Expression<Func<TEntity, bool>> query);

        TEntity GetById(Guid id);
    }
}