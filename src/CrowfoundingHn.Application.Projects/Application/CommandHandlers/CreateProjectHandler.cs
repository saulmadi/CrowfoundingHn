using CrowfoundingHn.Common;
using CrowfoundingHn.Projects.Application.Commands;
using CrowfoundingHn.Projects.Application.Events;
using CrowfoundingHn.Projects.Domain;

namespace CrowfoundingHn.Projects.Application.CommandHandlers
{
    public class CreateProjectHandler:ICommandHandler<CreateProject>
    {
        readonly IProjectRepository _projectRepository;

        readonly IDomainEvent _domainEvents;

        public CreateProjectHandler(IProjectRepository projectRepository, IDomainEvent domainEvents)
        {
            _projectRepository = projectRepository;
            _domainEvents = domainEvents;
        }

        public void Handle(CreateProject command)
        {
            var project = new Project(SystemGuid.New(),command.Name);

            project.SetAbstract(command.Abstract);
            project.SetDescription(command.Description);
            project.SetTargetAmount(command.TargetAmount);
            project.SetPredefinedAmounts(command.PredefinedAmounts);
            project.SetImageUrls(command.ImagesUrls);
            project.SetVideoUrls(command.VideoUrls);
            project.SetFirstState();
            
                

            var createdProject =_projectRepository.Create(project);

            _domainEvents.Raise(new ProjectCreated(createdProject));

        }
    }
}