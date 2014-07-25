using System;
using AcklenAvenue.Testing.ExpectedObjects;
using CrowfoundingHn.Presentation.Api.Modules;
using CrowfoundingHn.Presentation.Api.Responses;
using CrowfoundingHn.Projects.Domain;
using FizzWare.NBuilder;
using Machine.Specifications;
using Moq;
using Nancy.Testing;
using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.ProjectSpecs
{
    [Subject(typeof(ProjectsModuleQuery))]
    public class when_get_a_NonExisting_project
    {
        static Browser _browser;

        private static Guid _id;
        static ProjectResponse _projectNullResponseExpected;
        static ProjectResponse _projectResponse;


        private Establish context = () =>
        {
            _id = Guid.NewGuid();
           
            

            var repository = Mock.Of<IProjectRepository>();
           

            _browser = new Browser(x =>
            {
                x.Module<ProjectsModuleQuery>();
                x.Dependencies(repository);
            });



        };

        private Because of = () =>
        {
            _projectResponse =
                _browser.GetSecureJson("/projects/" + _id)
                    .Body.DeserializeJson<ProjectResponse>();
        };

        It should_get_project = () => _projectResponse.IsExpectedToBeSimilar(_projectNullResponseExpected);

       



    }
}