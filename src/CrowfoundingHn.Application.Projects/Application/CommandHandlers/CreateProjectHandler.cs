using CrowfoundingHn.Common;
using CrowfoundingHn.Projects.Application.Commands;
using CrowfoundingHn.Projects.Domain;

namespace CrowfoundingHn.Projects.Application.CommandHandlers
{
    public class CreateProjectHandler:ICommandHandler<CreateProject>
    {
        readonly IProjectRepository _projectRepository;

        public CreateProjectHandler(IProjectRepository projectRepository, IDomainEvent domainEvents)
        {
            _projectRepository = projectRepository;
        }

        public void Handle(CreateProject command)
        {
            
        }
    }
}