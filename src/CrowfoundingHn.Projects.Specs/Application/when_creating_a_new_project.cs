using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common;
using CrowfoundingHn.Projects.Application.CommandHandlers;
using CrowfoundingHn.Projects.Application.Commands;
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

        Establish context = () =>
            {
                _projectRepository = Mock.Of<IProjectRepository>();
                _domainEvents = Mock.Of<IDomainEvent>();
                _commandHandler = new CreateProjectHandler(_projectRepository, _domainEvents);

                _expectedProject = new Project();
                _createProject = Builder<CreateProject>.CreateNew().Build();
            };

        Because of = () => _commandHandler.Handle(_createProject);

        It should_create_the_new_project =
            () =>
            Mock.Get(_projectRepository).Verify(repository => repository.Create(WithExpected.Object(_expectedProject)));
    }
}