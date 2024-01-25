using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.ValueObject
{
    using System.Text.RegularExpressions;


    public record struct Email
    {
        private string localPart { get; init; }
        private string domain { get; init; }

        public static Email None => new Email(string.Empty, string.Empty);


        public Email(string localPart = "", string domain = "")
        {
            this.localPart = localPart;
            this.domain = domain;
        }

        public static Email Create(string localPart = "", string domain = "") =>
            new Email(localPart, domain);

        public static Email Empty => new();

        public string Address => string.IsNullOrEmpty(localPart)
            ? string.Empty
            : $"{localPart}@{domain}";

        public void Deconstruct(out string localPart, out string domain)
        {
            localPart = this.localPart;
            domain = this.domain;
        }

        public static explicit operator (string LocalPart, string Domain)(Email email) =>
            (email.localPart, email.domain);

        public static implicit operator Email(string emailAddress)
        {
            if (IsValid(emailAddress))
            {
                var parts = emailAddress.Split('@');
                return new Email(parts[0], parts[1]);
            }
            else
            {
                throw new ArgumentException("Invalid email address format.");
            }
        }

        public static bool IsValid(string emailAddress) =>
            Regex.IsMatch(emailAddress, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");

    }
}
