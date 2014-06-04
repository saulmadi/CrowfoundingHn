using System;

namespace CrowfoundingHn.Common.Authentication
{
    public class User : IEntity
    {
        protected User()
        {
        }

        public User(Guid id, string name, string email, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new MissingUserFieldException("name");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new MissingUserFieldException("password");
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new MissingUserFieldException("email");
            }

            Id = id;
            EncryptedPassword = password;
            Email = email;
            Name = name;
        }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public string Email { get; private set; }

        public string Ocupation { get; private set; }

        public string EncryptedPassword { get; private set; }

        public string Phone { get; private set; }

        public Guid Id { get; private set; }

        public void SetAddress(string address)
        {

            Address = address;
        }

        public void SetOcupation(string ocupation)
        {
            Ocupation = ocupation;
        }

        public void SetPhone(string phone)
        {
            Phone = phone;
        }
    }
}