using MongoDB.Driver;

namespace CrowfoundingHn.Common
{
    public interface IMongoCollectionFactory
    {
        MongoCollection CreateCollection(string collectionName);
    }
}