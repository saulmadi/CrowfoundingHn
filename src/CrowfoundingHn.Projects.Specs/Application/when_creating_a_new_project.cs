using System;
using System.Linq;

using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common;
using CrowfoundingHn.Projects.Application.CommandHandlers;
using CrowfoundingHn.Projects.Application.Commands;
using CrowfoundingHn.Projects.Application.Events;
using CrowfoundingHn.Projects.Domain;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Projects.Specs.Application
{
    public class when_creating_a_new_project
    {
        static CreateProjectHandler _commandHandler;

        static IProjectRepository _projectRepository;

        static IDomainEvent _domainEvents;

        static Project _expectedProject;

        static CreateProject _createProject;

        static ProjectCreated _expectedEProjectCreated;

        Establish context = () =>
            {
                _projectRepository = Mock.Of<IProjectRepository>();
                _domainEvents = Mock.Of<IDomainEvent>();
                _commandHandler = new CreateProjectHandler(_projectRepository, _domainEvents);

                _createProject = Builder<CreateProject>.CreateNew()
                                                       .With(project => project.PredefinedAmounts, new[]{12.12}.ToList())
                                                       .With(project => project.ImagesUrls, new[]{"dd"}.ToList())
                                                       .With(project => project.VideoUrls, new[]{"dd"}.ToList())
                                                       .Build();

                var id = Guid.NewGuid();
                SystemGuid.New = () => id;
                _expectedProject =
                    Builder<Project>.CreateNew()
                                    .With(project => project.Id, id)
                                    .With(project => project.Name, _createProject.Name)
                                    .With(project => project.Abstract, _createProject.Abstract)
                                    .With(project => project.Description, _createProject.Description)
                                    .With(project => project.ImageUrls, _createProject.ImagesUrls)
                                    .With(project => project.VideoUrls, _createProject.VideoUrls)
                                    .With(project => project.TargetAmount, _createProject.TargetAmount)
                                    .With(project => project.PredefinedAmounts, _createProject.PredefinedAmounts)
                                    .With(project => project.VideoUrls, _createProject.VideoUrls)
                                    .Build();
                _expectedEProjectCreated = new ProjectCreated(_expectedProject) ;
            };

        Because of = () => _commandHandler.Handle(_createProject);

        It should_create_the_new_project =
            () =>
            Mock.Get(_projectRepository).Verify(repository => repository.Create(WithExpected.Object(_expectedProject)));

        It should_raise_project_created_event =
            () => Mock.Get(_domainEvents).Verify(domain => domain.Raise(WithExpected.Object(_expectedEProjectCreated)));
    }
}