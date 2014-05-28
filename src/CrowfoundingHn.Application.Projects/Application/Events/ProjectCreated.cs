using CrowfoundingHn.Common;
using CrowfoundingHn.Projects.Domain;

namespace CrowfoundingHn.Projects.Application.Events
{
    public class ProjectCreated : IEvent
    {
        readonly Project _createdProject;

        public ProjectCreated(Project createdProject)
        {
            _createdProject = createdProject;
        }
    }
}