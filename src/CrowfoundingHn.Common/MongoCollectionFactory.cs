using System.Configuration;

using MongoDB.Driver;

namespace CrowfoundingHn.Common
{
    public class MongoCollectionFactory :IMongoCollectionFactory 
    {
        readonly string _key;

        public MongoCollectionFactory(string key)
        {
            _key = key;
        }

        public MongoCollection CreateCollection(string collectionName)
        {
            
            var connectionString = ConfigurationManager.ConnectionStrings[_key].ConnectionString;
            var mongoUri = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUri);

            return client.GetServer().GetDatabase(mongoUri.DatabaseName).GetCollection(collectionName);
        }
    }
}