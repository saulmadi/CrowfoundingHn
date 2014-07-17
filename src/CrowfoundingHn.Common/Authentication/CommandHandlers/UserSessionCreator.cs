using System;

using CrowfoundingHn.Common.Authentication.Commands;

namespace CrowfoundingHn.Common.Authentication.CommandHandlers
{
    public class UserSessionCreator : ICommandHandler<CreateUserSession>
    {
        public UserSessionCreator(IUserRepository sessionRepository, IUserSessionRepository userSessionRepository, IDomainEvent domainEvent)
        {
                
        }

        public void Handle(CreateUserSession command)
        {
            throw new NotImplementedException();
        }
    }
}