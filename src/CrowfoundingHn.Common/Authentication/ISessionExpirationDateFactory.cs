using System;

namespace CrowfoundingHn.Common.Authentication
{
    public interface ISessionExpirationDateFactory
    {
        DateTime Create(DateTime startDate);
    }
}