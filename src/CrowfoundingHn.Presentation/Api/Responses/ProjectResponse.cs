using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrowfoundingHn.Presentation.Api.Responses
{
    public class ProjectResponse
    {
        public string Name { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> ImagesUrls { get; set; }

        public IEnumerable<string> VideosUrls { get; set; }

        public DateTime DeadLine { get; set; }

        public double TargetAmount { get; set; }

        public IEnumerable<Double> PredefinedAmounts { get; set; }

        public Guid IdGuid { get; set; }

        public string projectState { get; set; }

        public ProjectResponse()
        {
            ImagesUrls = new List<string>();
            PredefinedAmounts = new List<double>();
            VideosUrls = new List<string>();
            PredefinedAmounts = new List<Double>();
        }

    }
}