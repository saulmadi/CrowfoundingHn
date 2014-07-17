using System;
using System.Linq;
using System.Linq.Expressions;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
namespace CrowfoundingHn.Common.Data
{
    public class MongoRepository<TEntity> :IRepository<TEntity>
        where TEntity:IEntity
    {
        readonly MongoCollection _collection;

        

        public MongoRepository(MongoCollection collection)
        {
            _collection = collection;
        }

        public TEntity Create(TEntity entity)
        {
            _collection.Insert(entity);
            
            return entity;
        }

        public TEntity First(Expression<Func<TEntity, bool>> query)
        {
            var entity = _collection.AsQueryable<TEntity>().FirstOrDefault(query);
            if (entity == null)
            {
                throw new EntityNotFoundException<TEntity>();
            }
            return entity;
        }
    }
}