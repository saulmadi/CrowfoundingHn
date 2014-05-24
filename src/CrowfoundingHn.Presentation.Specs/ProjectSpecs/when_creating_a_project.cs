using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common;
using CrowfoundingHn.Presentation.Api.Modules;
using CrowfoundingHn.Presentation.Api.Requests;
using CrowfoundingHn.Projects.Application.Commands;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using Nancy.Testing;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Presentation.Specs.ProjectSpecs
{
    public class when_creating_a_project
    {
        static Browser _browser;

        static ICommandDispatcher _commandDispatcher;

        static ProjectRequest _projectRequest = new ProjectRequest();

        static CreateProject _createProject;

        Establish context = () =>
            {
                _commandDispatcher = Mock.Of<ICommandDispatcher>();
                _browser = new Browser(
                    x =>
                        {
                            x.Module<ProjectsModule>();
                            x.Dependency(_commandDispatcher);
                        });

                _projectRequest = Builder<ProjectRequest>.CreateNew().Build();
                _createProject = new CreateProject(
                    _projectRequest.Name,
                    _projectRequest.Abstract,
                    _projectRequest.Description,
                    _projectRequest.ImagesUrls,
                    _projectRequest.VideosUrls,
                    _projectRequest.TargetAmount,
                    _projectRequest.PredefinedAmounts);
            };

        Because of = () => _browser.PostSecureJson("/projects", _projectRequest);

        It should_dispatch_the_command_create_project =
            () =>
            Mock.Get(_commandDispatcher).Verify(
                dispatcher => dispatcher.Dispatch(WithExpected.Object(_createProject)));
    }
}