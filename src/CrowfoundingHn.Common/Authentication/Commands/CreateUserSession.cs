using System;

namespace CrowfoundingHn.Common.Authentication.Commands
{
    public class CreateUserSession : ICommand
    {
        protected CreateUserSession()
        {
            
        }
        public CreateUserSession(Guid id, Guid userId)
        {
            UserId = userId;
            Id = id;
        }

        public Guid Id { get; private set; }

        public Guid UserId { get; private set; }
    }
}