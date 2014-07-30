using System;

using CrowfoundingHn.Common;
using CrowfoundingHn.Common.Authentication;

using Nancy.Security;

namespace CrowfoundingHn.Presentation.Api.Infrastructure
{
    public class ApiUserMapper : IUserMapper
    {
        readonly IUserSessionRepository _repository;

        public ApiUserMapper(IUserSessionRepository repository)
        {
            _repository = repository;
        }

        public IUserIdentity GetUserIdentity(Guid token)
        {
            UserSession session = _repository.GetById(token);

            session.CheckAvility(SystemDateTime.Now());

            return new CrowFoundingHnUserIdentity(session);
        }
    }
}