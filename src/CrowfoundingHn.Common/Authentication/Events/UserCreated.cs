namespace CrowfoundingHn.Common.Authentication.Events
{
    public class UserCreated : IEvent
    {
        public readonly User CreatedUser;

        protected UserCreated()
        {
        }

        public UserCreated(User createdUser)
        {
            CreatedUser = createdUser;
        }
    }
}