using System;

namespace CrowfoundingHn.Common.Authentication
{
    public class UserSession : IEntity
    {
        protected UserSession()
        {
        }

        public UserSession(Guid id, User user, DateTime startDate, DateTime expirationDate)
        {
            Id = id;
            User = user;
            StartDate = startDate;
            ExpirationDate = expirationDate;
        }

        public User User { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public Guid Id { get; private set; }
    }
}