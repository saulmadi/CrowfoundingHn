using System;

namespace CrowfoundingHn.Projects.Domain
{
    public interface IProjectRepository
    {
        Project Create(Project project);
        Project Get(Guid id);

    }
}