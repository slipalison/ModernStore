using FluentValidator.Validation;
using ModernStore.Shared.Entities;


namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {

        protected User()
        {

        }
        public User(string username, string password, string confirmPassword)
        {
            Username = username;
            Password = password;
            Active = false;

            _validate = new ValidationContract<User>(this);
            _validate.AreEquals(x => x.Password, confirmPassword, "As senhas não conhecidem");
        }

        private ValidationContract<User> _validate { get; set; }

        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool Active { get; private set; }
        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        private string EncryptPassword(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            var sbString = new System.Text.StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
