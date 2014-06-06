using CrowfoundingHn.Common.Authentication;

using MongoDB.Driver;

namespace CrowfoundingHn.Common.Data.Authentication
{
    public class UserRepository :MongoRepository<User>, IUserRepository
    {
        public UserRepository(MongoCollection collection)
            : base(collection)
        {
        }

        
    }
}
