using CrowfoundingHn.Common.Authentication;

using MongoDB.Driver;

namespace CrowfoundingHn.Common.Data.Authentication
{
    public class UserSessionRepository :MongoRepository<UserSession>,IUserSessionRepository
    {
        public UserSessionRepository(MongoCollection collection)
            : base(collection)
        {
        }
    }
}