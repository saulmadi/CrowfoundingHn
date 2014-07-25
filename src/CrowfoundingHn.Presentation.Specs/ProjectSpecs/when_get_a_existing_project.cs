using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowfoundingHn.Common;
using CrowfoundingHn.Presentation.Api.Modules;
using CrowfoundingHn.Presentation.Api.Requests;
using CrowfoundingHn.Presentation.Api.Responses;
using CrowfoundingHn.Projects.Application.Commands;
using CrowfoundingHn.Projects.Domain;
using AcklenAvenue.Testing.ExpectedObjects;
using FizzWare.NBuilder;
using Machine.Specifications;
using Moq;
using Nancy.Testing;
using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.ProjectSpecs
{
    [Subject(typeof (ProjectsModuleQuery))]
    public class when_get_a_existing_project
    {
        static Browser _browser;


        static ProjectResponse _projectResponseExpected;
        static ProjectResponse _projectResponse;

     
        private Establish context = () =>
        {
            var projectFromDatabase = Builder<Project>.CreateNew().With(project => project.Id, Guid.NewGuid()).Build();
            _projectResponseExpected = getProjectResponse(projectFromDatabase);

            var repository = Mock.Of<IProjectRepository>();
            Mock.Get(repository).Setup(x => x.Get(projectFromDatabase.Id)).Returns(projectFromDatabase);

            _browser = new Browser(x =>
            {
                x.Module<ProjectsModuleQuery>();
                x.Dependencies(repository);
            });



        };

        private Because of = () =>
        {
            _projectResponse =
                _browser.GetSecureJson("/projects/" + _projectResponseExpected.IdGuid)
                    .Body.DeserializeJson<ProjectResponse>();
        };

        It should_get_project = () => _projectResponse.IsExpectedToBeSimilar(_projectResponseExpected);

        private static ProjectResponse getProjectResponse(Project project)
        {
            return new ProjectResponse()
            {
                Abstract = project.Abstract,
                DeadLine = project.DeadLine,
                Description = project.Description,
                IdGuid = project.Id,
                ImagesUrls = project.ImageUrls,
                Name = project.Name,
                PredefinedAmounts = project.PredefinedAmounts,
                projectState = project.State.State,
                TargetAmount = project.TargetAmount,
                VideosUrls = project.VideoUrls
            };
        }


       
    }
}
