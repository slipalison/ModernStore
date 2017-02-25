using System;

namespace ModernStore.Domain.Entities
{
    public class Custumer
    {
        public Custumer(string firstName, string lastName, User user, string email)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;
        }

        public Guid Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        public string Email { get; private set; }

        public void Upadte(DateTime birthDate, string firstName, string lastName) {
            BirthDate = birthDate;
            FirstName = FirstName;
            LastName = lastName;
        }
    }
}
