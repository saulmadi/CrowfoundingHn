using CrowfoundingHn.Common;
using CrowfoundingHn.Presentation.Api.Requests;
using CrowfoundingHn.Projects.Application.Commands;

using Nancy;
using Nancy.ModelBinding;

namespace CrowfoundingHn.Presentation.Api.Modules
{
    public class ProjectsModule : NancyModule
    {
        public ProjectsModule(ICommandDispatcher commandDispatcher)
            : base("/projects")

        {
           

            Post["/"] = x =>
                {
                    var session = this.UserSession();

                    var request = this.Bind<ProjectRequest>();

                    var command = new CreateProject(
                        request.Name,
                        request.Abstract,
                        request.Description,
                        request.ImagesUrls,
                        request.VideosUrls,
                        request.TargetAmount,
                        request.PredefinedAmounts);

                    commandDispatcher.Dispatch(command);
                    return null;
                };
        }
    }
}