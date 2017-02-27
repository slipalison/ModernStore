using FluentValidator.Validation;

namespace ModernStore.Shared.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email()
        {

        }
        public Email(string address)
        {
            Address = address;

            _validate = new ValidationContract<Email>(this);
            _validate.IsRequired(x => x.Address)
                .IsEmail(x => x.Address)
                .HasMaxLenght(x => x.Address, 60)
                .HasMinLenght(x => x.Address, 5);
        }

        private readonly ValidationContract<Email> _validate;
        public string Address { get; private set; }
    }
}
