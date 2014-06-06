using CrowfoundingHn.Common.Authentication.Commands;
using CrowfoundingHn.Common.Authentication.Events;

namespace CrowfoundingHn.Common.Authentication.CommandHandlers
{
    public class UserCreator : ICommandHandler<CreateUser>
    {
        readonly IDomainEvent _domainEvent;

        readonly IPasswordEncryptor _passwordEncryptor;

        readonly IUserRepository _userRepository;

        public UserCreator(IUserRepository userRepository, IDomainEvent domainEvent, IPasswordEncryptor passwordEncryptor)
        {
            _userRepository = userRepository;
            _domainEvent = domainEvent;
            _passwordEncryptor = passwordEncryptor;
        }

        public void Handle(CreateUser command)
        {
            var password = command.Password;
            var encryptedPassword = _passwordEncryptor.EncryptPassword(password);

            var user = new User(SystemGuid.New(), command.Name, command.Email, encryptedPassword.Password);

            user.SetAddress(command.Address);
            user.SetOcupation(command.Ocupation);
            user.SetPhone(command.Phone);

            var createdUser = _userRepository.Create(user);

            _domainEvent.Raise(new UserCreated(createdUser));

        }
    }
}