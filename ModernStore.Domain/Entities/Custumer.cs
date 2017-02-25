using FluentValidator.Validation;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Custumer : Entity
    {
        public Custumer(string firstName, string lastName, User user, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;
            Validate = new ValidationContract<Custumer>(this);
           
            //validate
            Validate.IsRequired(x => x.FirstName).HasMaxLenght(x => x.FirstName, 60).HasMinLenght(x => x.FirstName, 3);
            Validate.IsRequired(x => x.LastName).HasMaxLenght(x => x.LastName, 60).HasMinLenght(x => x.LastName, 3);
            Validate.IsRequired(x => x.Email).IsEmail(x=>x.Email).HasMaxLenght(x => x.Email, 60).HasMinLenght(x => x.Email, 3);
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        public string Email { get; private set; }

        private ValidationContract<Custumer> Validate { get; set; }

        public void Upadte(DateTime birthDate, string firstName, string lastName)
        {
            BirthDate = birthDate;
            FirstName = FirstName;
            LastName = lastName;
        }
    }
}
