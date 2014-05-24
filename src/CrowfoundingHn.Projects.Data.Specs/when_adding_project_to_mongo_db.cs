using System.Configuration;

using CrowfoundingHn.Projects.Domain;

using FizzWare.NBuilder;

using Machine.Specifications;

using MongoDB.Bson;
using MongoDB.Driver;

namespace CrowfoundingHn.Projects.Data.Specs
{
    public class when_adding_project_to_mongo_db
    {
        static ProjectRepository _projectRepository;

        static Project _project;

        Establish context = () =>
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectDb"].ConnectionString;
                var mongoUri = new MongoUrl(connectionString);
                var client = new MongoClient(mongoUri);

                MongoCollection<BsonDocument> collection =
                    client.GetServer().GetDatabase(mongoUri.DatabaseName).GetCollection("Projects");

                _projectRepository = new ProjectRepository(collection);

                _project = Builder<Project>.CreateNew().Build();
            };

        Because of = () => _projectRepository.Create();

        It should_insert_the_new_project = () => { };
    }
}