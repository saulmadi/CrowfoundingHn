using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Authentication.CommandHandlers;
using CrowfoundingHn.Common.Authentication.Commands;

using FizzWare.NBuilder;

using Machine.Specifications;

using Moq;

using It = Machine.Specifications.It;

namespace CrowfoundingHn.Common.Specs.AuthenticationSpecs
{
    public class when_creating_a_user
    {
        static ICommandHandler<CreateUser> _handler;

        static CreateUser _createUser;

        static IUserRepository _userRepository;

        static IDomainEvent _domainEvent;

        static User _user;

        Establish context = () =>
            {
                _userRepository = Mock.Of<IUserRepository>();
                _domainEvent = Mock.Of<IDomainEvent>();
                _handler = new UserCreator(_userRepository, _domainEvent);
                _user = Builder<User>.CreateNew()
                                     .With(user => user.Name, _createUser.Name)
                                     
                                     .Build();
            };

        Because of = () => _handler.Handle(_createUser);

        It should_create_the_user = () => Mock.Get(_userRepository).Verify(repository => repository.Create(_user));
    }
}