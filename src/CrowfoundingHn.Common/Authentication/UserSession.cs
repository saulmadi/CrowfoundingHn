using System;

namespace CrowfoundingHn.Common.Authentication
{
    public class UserSession : IEntity
    {
        public Guid Id { get; private set; }

        public User User { get; private set; }

        public DateTime StartDate { get; private set; }
    }
}