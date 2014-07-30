using System;

using CrowfoundingHn.Common.Authentication;

using Nancy;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public static class IdentityExtension
    {
      

        public static UserSession UserSession(this NancyModule module)
        {
            var user = module.Context.CurrentUser as CrowFoundingHnUserIdentity;
            if (user == null ) throw new UnauthorizedAccessException();
            return user.Session;
        }
    }
}