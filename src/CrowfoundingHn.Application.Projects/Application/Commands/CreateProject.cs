using System.Collections.Generic;

using CrowfoundingHn.Common;

namespace CrowfoundingHn.Projects.Application.Commands
{
    public class CreateProject : ICommand
    {
        protected   CreateProject()
        {
            
        }
        public CreateProject(
            string name,
            string @abstract,
            string description,
            IEnumerable<string> imagesUrls,
            IEnumerable<string> videosUrls,
            double targetAmount,
            IEnumerable<double> predefinedAmounts)
        {
            Name = name;
            Abstract = @abstract;
            Description = description;
            ImagesUrls = imagesUrls;
            VideoUrls = videosUrls;
            TargetAmount = targetAmount;
            PredefinedAmounts = predefinedAmounts;
        }

        public string Name { get; private set; }

        public string Abstract { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<string> ImagesUrls { get; private set; }

        public IEnumerable<string> VideoUrls { get; private set; }

        public double TargetAmount { get; set; }

        public IEnumerable<double> PredefinedAmounts { get; private set; }
    }
}