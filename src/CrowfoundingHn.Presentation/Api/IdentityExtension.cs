using System;

using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Presentation.Api.Infrastructure;

using Nancy;

namespace CrowfoundingHn.Presentation.Api
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