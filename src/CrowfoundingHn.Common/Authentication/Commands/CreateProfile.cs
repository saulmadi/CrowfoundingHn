namespace CrowfoundingHn.Common.Authentication.Commands
{
    public class CreateProfile : ICommand
    {
        protected CreateProfile()
        {
            
        }
        public CreateProfile(
            string email, string password, string name, string ocuapation, string address, string phone)
        {
            Phone = phone;
            Address = address;
            Ocuapation = ocuapation;
            Name = name;
            Password = password;
            Email = email;
        }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public string Name { get; private set; }

        public string Ocuapation { get; private set; }

        public string Address { get; private set; }

        public string Phone { get; private set; }
    }
}