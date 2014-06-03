using CrowfoundingHn.Common.Authentication.Commands;

namespace CrowfoundingHn.Common.Authentication.CommandHandlers
{
    public class UserCreator : ICommandHandler<CreateUser>
    {
        readonly IUserRepository _userRepository;

        public UserCreator(IUserRepository userRepository, IDomainEvent domainEvent)
        {
            _userRepository = userRepository;
        }

        public void Handle(CreateUser command)
        {
            
        }
    }
}