using FluentValidator.Validation;
using ModernStore.Shared.Entities;
using ModernStore.Shared.ValueObjects;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {

        protected Customer()
        {

        }

        public Customer(Name name, User user, Email email, Document document)
        {
            Name = name; ;
            BirthDate = null;
            Email = email;
            User = user;
            Document = document;
            Validate = new ValidationContract<Customer>(this);
            AddNotifications(Name.Notifications);
            AddNotifications(Email.Notifications);
            AddNotifications(Document.Notifications);
        }

        public Name Name { get; private set; }

        public string FirstName
        {
            get { return Name == null ? "" : Name.FirstName; }
            private set
            {
                Name = new Name(value, LastName);
                AddNotifications(Name.Notifications);
            }
        }
        public string LastName
        {
            get { return Name == null ? "" : Name.LastName; }
            private set
            {
                Name = new Name(FirstName, value);
                AddNotifications(Name.Notifications);
            }
        }

        public Document Document { get; private set; }

        public string Document_Number
        {
            get
            {
                return Document.Number;
            }
            private set
            {
                Document = new Document(value);
                AddNotifications(Document.Notifications);
            }
        }


        public DateTime? BirthDate { get; private set; }
        public virtual User User { get; private set; }


        public Email Email { get; private set; }

        public string Email_Address
        {
            get
            {
                return Email.Address;
            }
            private set
            {
                Email = new Email(value);
                AddNotifications(Email.Notifications);
            }
        }



        private ValidationContract<Customer> Validate { get; set; }

        public void Upadte(DateTime birthDate, string firstName, string lastName)
        {
            BirthDate = birthDate;
        }
    }
}
