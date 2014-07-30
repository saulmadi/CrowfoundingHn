using System;

using Nancy.Security;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public interface IUserMapper
    {
        IUserIdentity GetUserIdentity(Guid token);
    }
}