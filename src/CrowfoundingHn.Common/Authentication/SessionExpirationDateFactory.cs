using System;

namespace CrowfoundingHn.Common.Authentication
{
    public class SessionExpirationDateFactory : ISessionExpirationDateFactory
    {
        readonly int _durationDays;

        public SessionExpirationDateFactory(int durationDays)
        {
            _durationDays = durationDays;
        }

        public DateTime Create(DateTime startDate)
        {
            return startDate.AddDays(_durationDays);

        }
    }
}