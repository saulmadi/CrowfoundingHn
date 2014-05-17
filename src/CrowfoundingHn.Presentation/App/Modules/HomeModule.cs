using Nancy;

namespace CrowfoundingHn.Presentation.App.Modules
{
    public class HomeModule:NancyModule
    {
        public HomeModule()
        {
            Get["/"] = r => View["index.html"];
        }
    }
}