using System;

using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Authentication.CommandHandlers;
using CrowfoundingHn.Common.Authentication.Commands;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Common.Specs.AuthenticationSpecs
{
    public class when_creating_a_new_user_session
    {
        static UserSessionCreator _handler;

        static CreateUserSession _command;

        static IDomainEvent _domainEvent;

        static IUserSessionRepository _userSessionRepository;

        static UserSession _expecteUserSession;

        static IUserRepository _userRepository;

        static User _user;

        static DateTime _startDate;

        static ISessionExpirationDateFactory _sessionExpirationDateFactory;

        static DateTime _expirationDate;

        Establish context = () =>
            {
                _domainEvent = Mock.Of<IDomainEvent>();
                _userSessionRepository = Mock.Of<IUserSessionRepository>();

                _userRepository = Mock.Of<IUserRepository>();
                _sessionExpirationDateFactory = Mock.Of<ISessionExpirationDateFactory>();
                _handler = new UserSessionCreator(
                    _userRepository, _userSessionRepository, _sessionExpirationDateFactory, _domainEvent);

                _command = Builder<CreateUserSession>.CreateNew().Build();
                _user = Builder<User>.CreateNew().Build();
                _startDate = DateTime.Now;
                _expirationDate = _startDate.AddDays(6);
                SystemDateTime.Now = () => _startDate;

                Mock.Get(_userRepository).Setup(repository => repository.GetById(_command.UserId)).Returns(_user);
                Mock.Get(_sessionExpirationDateFactory)
                    .Setup(factory => factory.Create(_startDate))
                    .Returns(_expirationDate);
                 
                _expecteUserSession =
                    Builder<UserSession>.CreateNew()
                                        .With(session => session.User, _user)
                                        .With(session => session.Id, _command.Id)
                                        .With(session => session.StartDate, _startDate)
                                        .With(session => session.ExpirationDate, _expirationDate)
                                        .Build();
            };

        Because of = () => _handler.Handle(_command);

        It should_create_the_session_with_the_token =
            () =>
            Mock.Get(_userSessionRepository)
                .Verify(repository => repository.Create(WithExpected.Object(_expecteUserSession)));
    }
}