using System;
using System.Collections.Generic;
using System.Linq;

using CrowfoundingHn.Common;

namespace CrowfoundingHn.Projects.Domain
{
    public class Project : IEntity
    {
        IEnumerable<string> _imageUrls = new List<string>();

        IEnumerable<double> _predefinedAmounts = new List<double>();

        IEnumerable<string> _videoUrls = new List<string>();

        public Project()
        {
        }

        public Project(Guid id, string name)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }

        public string Abstract { get; private set; }

        public string Description { get; private set; }

        public IEnumerable<string> ImageUrls
        {
            get
            {
                return _imageUrls;
            }
            private set
            {
                _imageUrls = value;
            }
        }

        public IEnumerable<string> VideoUrls
        {
            get
            {
                return _videoUrls;
            }
            private set
            {
                _videoUrls = value;
            }
        }

        public double TargetAmount { get; private set; }

        public IEnumerable<double> PredefinedAmounts
        {
            get
            {
                return _predefinedAmounts;
            }
            private set
            {
                _predefinedAmounts = value;
            }
        }

        public Guid Id { get; private set; }

        public void SetAbstract(string @abstract)
        {
            Abstract = @abstract;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetTargetAmount(double targetAmount)
        {
            TargetAmount = targetAmount;
        }

        public void SetPredefinedAmounts(IEnumerable<double> predefinedAmounts)
        {
            _predefinedAmounts = predefinedAmounts.ToList();
        }

        public void SetImageUrls(IEnumerable<string> imagesUrls)
        {
            _imageUrls = imagesUrls.ToList();
        }

        public void SetVideoUrls(IEnumerable<string> videoUrls)
        {
            _videoUrls = videoUrls.ToList();
        }
    }
}