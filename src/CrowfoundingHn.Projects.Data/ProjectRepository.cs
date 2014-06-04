using CrowfoundingHn.Common.Data;
using CrowfoundingHn.Projects.Domain;

using MongoDB.Bson;
using MongoDB.Driver;

namespace CrowfoundingHn.Projects.Data
{
    public class ProjectRepository: MongoRepository<Project>, IProjectRepository
    {
        public ProjectRepository(MongoCollection collection):base(collection)
        {
            
        }
    }
}