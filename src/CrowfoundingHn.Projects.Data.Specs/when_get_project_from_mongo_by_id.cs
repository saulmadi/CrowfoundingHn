using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcklenAvenue.Testing.ExpectedObjects;
using CrowfoundingHn.Common.Data;
using CrowfoundingHn.Projects.Domain;
using FizzWare.NBuilder;
using Machine.Specifications;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrowfoundingHn.Projects.Data.Specs
{
    [Subject(typeof (MongoRepository<>))]
    public class when_get_project_from_mongo_by_id
    {
        static ProjectRepository _projectRepository;

        static Project _expectedProject;
        static Project _resultProject;

        static MongoCollection<BsonDocument> _collection;

        private Establish context = () =>
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ProjectDb"].ConnectionString;
            var mongoUri = new MongoUrl(connectionString);
            var client = new MongoClient(mongoUri);

            _collection = client.GetServer().GetDatabase(mongoUri.DatabaseName).GetCollection("Projects");

            _projectRepository = new ProjectRepository(_collection);
            _expectedProject = Builder<Project>.CreateNew().With(project => project.Id, Guid.NewGuid()).Build();

            _projectRepository.Create(_expectedProject);

        };

        private Because of = () =>
        {
            _resultProject = _projectRepository.Get(_expectedProject.Id);
        };

        It should_get_project = () => _resultProject.IsExpectedToBeSimilar(_expectedProject);
    }
}
