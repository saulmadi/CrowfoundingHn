using System;
using System.Configuration;

using AcklenAvenue.Testing.ExpectedObjects;

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

        static Project _expectedProject;

        static MongoCollection<BsonDocument> _collection;

        Establish context = () =>
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ProjectDb"].ConnectionString;
                var mongoUri = new MongoUrl(connectionString);
                var client = new MongoClient(mongoUri);

                _collection = client.GetServer().GetDatabase(mongoUri.DatabaseName).GetCollection("Projects");

                _projectRepository = new ProjectRepository(_collection);

                _expectedProject = Builder<Project>.CreateNew().With(project => project.Id, Guid.NewGuid()).Build();
            };

        Because of = () => _projectRepository.Create(_expectedProject);

        It should_insert_the_new_project =
            () => _collection.FindOneByIdAs<Project>(_expectedProject.Id).IsExpectedToBeSimilar(_expectedProject);
    }
}