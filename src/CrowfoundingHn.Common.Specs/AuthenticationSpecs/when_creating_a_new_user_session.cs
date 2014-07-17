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

        Establish context = () =>
            {
                _domainEvent = Mock.Of<IDomainEvent>();
                _userSessionRepository = Mock.Of<IUserSessionRepository>();

                _userRepository = Mock.Of<IUserRepository>();
                _handler = new UserSessionCreator(_userRepository, _userSessionRepository, _domainEvent);

                _command = Builder<CreateUserSession>.CreateNew().Build();
                _user = Builder<User>.CreateNew().Build();
                _startDate = DateTime.Now;

                SystemDateTime.Now = () => _startDate;

                _expecteUserSession =
                    Builder<UserSession>.CreateNew()
                                        .With(session => session.User, _user)
                                        .With(session => session.Id, _command.Id)
                                        .With(session => session.StartDate, _startDate)
                                        .Build();
            };

        Because of = () => _handler.Handle(_command);

        It should_create_the_session_with_the_token =
            () =>
            Mock.Get(_userSessionRepository)
                .Verify(repository => repository.Create(WithExpected.Object(_expecteUserSession)));
    }
}