using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace CrowfoundingHn.Common.Data
{
    public class MongoRepository<TEntity> where TEntity:IEntity
    {
        readonly MongoCollection _collection;

        

        public MongoRepository(MongoCollection collection)
        {
            _collection = collection;
        }

        public TEntity Create(TEntity project)
        {
            _collection.Insert(project);
            
            return project;
        }

        public TEntity Get(Guid id)
        {
            return _collection.FindOneByIdAs<TEntity>(id);
        }
    }
}