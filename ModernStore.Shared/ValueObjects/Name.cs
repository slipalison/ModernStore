using FluentValidator.Validation;

namespace ModernStore.Shared.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            _validate = new ValidationContract<Name>(this);
            _validate.IsRequired(x => x.FirstName).HasMaxLenght(x => x.FirstName, 60).HasMinLenght(x => x.FirstName, 3);
            _validate.IsRequired(x => x.LastName).HasMaxLenght(x => x.LastName, 60).HasMinLenght(x => x.LastName, 3);

        }

        private readonly ValidationContract<Name> _validate;
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"";
        }

    }
}
