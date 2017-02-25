using FluentValidator.Validation;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string password)
        {
            Username = username;
            Password = password;
            Active = false;
            Validate = new ValidationContract<User>(this);
        }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        private ValidationContract<User> Validate { get; set; }

        public void Activate() => Active = true;

        public void Deactivate() => Active = false;

    }
}
