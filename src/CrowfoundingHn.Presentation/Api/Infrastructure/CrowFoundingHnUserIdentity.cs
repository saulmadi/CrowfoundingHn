using System.Collections.Generic;

using CrowfoundingHn.Common.Authentication;

using Nancy.Security;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public class CrowFoundingHnUserIdentity : IUserIdentity
    {
        readonly UserSession _session;

        public CrowFoundingHnUserIdentity(UserSession session)
        {
            _session = session;
        }

        public string UserName
        {
            get
            {
                return _session.User.Email;
            }
        }

        public IEnumerable<string> Claims
        {
            get
            {
                return new string[] { };
            }
        }
    }
}