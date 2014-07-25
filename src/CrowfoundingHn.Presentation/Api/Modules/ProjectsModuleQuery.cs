using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrowfoundingHn.Presentation.Api.Responses;
using CrowfoundingHn.Projects.Domain;
using Nancy;

namespace CrowfoundingHn.Presentation.Api.Modules
{
    public class ProjectsModuleQuery:NancyModule
    {
        public ProjectsModuleQuery(IProjectRepository repository):base("/projects")
        {
            Get["/{id:guid}"] = parameters =>
            {
                var project = repository.Get(parameters.id);
                return getProjectResponse(project);
            };

       
        }

        private ProjectResponse getProjectResponse(Project project)
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