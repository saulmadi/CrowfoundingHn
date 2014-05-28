using System;
using System.Collections.Generic;

namespace CrowfoundingHn.Presentation.Api.Requests
{
    public class ProjectRequest
    {
        public ProjectRequest()
        {
            ImagesUrls =new List<string>();
            PredefinedAmounts = new List<double>();
            VideosUrls = new List<string>();
        }
        public string Name { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> ImagesUrls { get; set; }

        public IEnumerable<string> VideosUrls { get; set; }

        public DateTime DeadLine { get; set; }

        public double TargetAmount { get; set; }

        public IEnumerable<Double> PredefinedAmounts { get; set; }
        
    }
}