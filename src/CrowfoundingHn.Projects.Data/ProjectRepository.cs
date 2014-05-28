using CrowfoundingHn.Projects.Domain;

using MongoDB.Bson;
using MongoDB.Driver;

namespace CrowfoundingHn.Projects.Data
{
    public class ProjectRepository:IProjectRepository
    {
        readonly MongoCollection _collection;

        public ProjectRepository(MongoCollection collection)
        {
            _collection = collection;
        }

        public Project Create(Project project)
        {
             _collection.Insert(project);
            
            return project;
        }
    }
}