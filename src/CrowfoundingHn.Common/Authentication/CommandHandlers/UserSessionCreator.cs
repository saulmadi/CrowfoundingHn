using System;

using CrowfoundingHn.Common.Authentication.Commands;

namespace CrowfoundingHn.Common.Authentication.CommandHandlers
{
    public class UserSessionCreator : ICommandHandler<CreateUserSession>
    {
        readonly IUserRepository _userRepository;

        readonly IUserSessionRepository _userSessionRepository;

        readonly ISessionExpirationDateFactory _sessionExpirationDateFactory;

        readonly IDomainEvent _domainEvent;

        public UserSessionCreator(
            IUserRepository userRepository,
            IUserSessionRepository userSessionRepository,
            ISessionExpirationDateFactory sessionExpirationDateFactory,
            IDomainEvent domainEvent)
        {
            _userRepository = userRepository;
            _userSessionRepository = userSessionRepository;
            _sessionExpirationDateFactory = sessionExpirationDateFactory;
            _domainEvent = domainEvent;
        }

        public void Handle(CreateUserSession command)
        {
            var user = _userRepository.GetById(command.UserId);
            var startDate = SystemDateTime.Now();
            var expirationDate = _sessionExpirationDateFactory.Create(startDate);



            var session = new UserSession(command.Id, user, startDate, expirationDate);

            _userSessionRepository.Create(session);



        }
    }
}