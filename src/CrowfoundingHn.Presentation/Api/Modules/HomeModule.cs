using Nancy;

namespace CrowfoundingHn.Presentation.Api.Modules
{
    public class HomeModule:NancyModule
    {
        public HomeModule()
        {
            Get["/"] = r => View["index.html"];
        }
    }
}