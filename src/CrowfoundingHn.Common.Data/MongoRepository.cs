using MongoDB.Driver;

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
    }
}