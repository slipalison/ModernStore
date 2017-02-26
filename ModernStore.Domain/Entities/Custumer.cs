using FluentValidator.Validation;
using ModernStore.Shared.Entities;
using ModernStore.Shared.ValueObjects;
using System;

namespace ModernStore.Domain.Entities
{
    public class Custumer : Entity
    {
        public Custumer(Name name, User user, Email email,Document document)
        {
            Name = name; ;
            BirthDate = null;
            Email = email;
            User = user;
            Document = document;
            Validate = new ValidationContract<Custumer>(this);
            AddNotifications(Name.Notifications);
            AddNotifications(Email.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Name Name { get; private set; }

        public Document Document { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public User User { get; private set; }
        public Email Email { get; private set; }

        private ValidationContract<Custumer> Validate { get; set; }

        public void Upadte(DateTime birthDate, string firstName, string lastName)
        {
            BirthDate = birthDate;
        }
    }
}
