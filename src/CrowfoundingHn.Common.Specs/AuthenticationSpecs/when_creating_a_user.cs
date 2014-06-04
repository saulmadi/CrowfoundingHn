using System;

using AcklenAvenue.Testing.Moq.ExpectedObjects;

using CrowfoundingHn.Common.Authentication;
using CrowfoundingHn.Common.Authentication.CommandHandlers;
using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Common.Authentication.Events;

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

        static IEvent _userCreated;

        static IPasswordEncryptor _passwordEncryptor;

        static EncryptedPassword _encryptedPassword;

        static Guid _id;

        Establish context = () =>
            {
                _createUser = Builder<CreateUser>.CreateNew().Build();
                _userRepository = Mock.Of<IUserRepository>();
                _domainEvent = Mock.Of<IDomainEvent>();
                _passwordEncryptor = Mock.Of<IPasswordEncryptor>();
                _handler = new UserCreator(_userRepository, _domainEvent, _passwordEncryptor);

                _encryptedPassword = new EncryptedPassword("encryptedPassordd");

                Mock.Get(_passwordEncryptor)
                    .Setup(encryptor => encryptor.EncryptPassword(_createUser.Password))
                    .Returns(_encryptedPassword);

                _id = Guid.NewGuid();
                SystemGuid.New = () => _id;

                _user =
                    Builder<User>.CreateNew()
                                 .With(user => user.Name, _createUser.Name)
                                 .With(user => user.Id, _id)
                                 .With(user => user.Address, _createUser.Address)
                                 .With(user => user.Email, _createUser.Email)
                                 .With(user => user.Ocupation, _createUser.Ocupation)
                                 .With(user => user.EncryptedPassword, _encryptedPassword.Password)
                                 .With(user => user.Phone, _createUser.Phone)
                                 .Build();

                _userCreated = Builder<UserCreated>.CreateNew().With(created => created.CreatedUser, _user).Build();
                Mock.Get(_userRepository)
                    .Setup(repository => repository.Create(WithExpected.Object(_user)))
                    .Returns(_user);
            };

        Because of = () => _handler.Handle(_createUser);

        It should_create_the_user =
            () => Mock.Get(_userRepository).Verify(repository => repository.Create(WithExpected.Object(_user)));

        It should_raise_user_created_event =
            () => Mock.Get(_domainEvent).Verify(domain => domain.Raise(WithExpected.Object(_userCreated)));
    }
}