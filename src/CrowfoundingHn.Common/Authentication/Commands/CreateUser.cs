namespace CrowfoundingHn.Common.Authentication.Commands
{
    public class CreateUser : ICommand
    {
        protected CreateUser()
        {
            
        }
        public CreateUser(
            string email, string password, string name, string ocuapation, string address, string phone)
        {
            Phone = phone;
            Address = address;
            Ocupation = ocuapation;
            Name = name;
            Password = password;
            Email = email;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Name { get; private set; }

        public string Ocupation { get; private set; }

        public string Address { get; private set; }

        public string Phone { get; private set; }
    }
}