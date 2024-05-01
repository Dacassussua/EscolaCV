using System.Text.RegularExpressions;

namespace EscolaCV.Core.Domain.ValueObjects
{
    public partial class Email
    {
        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public string? Address { get; }

        protected Email()
        {

        }

        public static implicit operator string(Email email) => email.ToString();
        public static implicit operator Email(string address) => new Email(address);

        public override string ToString() => Address!;
        public Email(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new Exception("Email Invalido");
            Address = address.Trim().ToLower();

            if (Address.Length < 5)
                throw new Exception("Email Invalido");

            if (!EmailRegex().IsMatch(Address))
                throw new Exception("Email Invalido");
        }


        [GeneratedRegex(Pattern)]
        public static partial Regex EmailRegex();
    }
}
