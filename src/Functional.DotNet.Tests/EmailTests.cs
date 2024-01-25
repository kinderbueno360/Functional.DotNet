using Functional.DotNet.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.DotNet.Tests
{
    public class EmailTests
    {
        [Fact]
        public void Create_ValidEmail_ReturnsEmailObject()
        {
            // Arrange
            var localPart = "carlos";
            var domain = "sapo.pt";

            // Act
            var email = Email.Create(localPart, domain);
            var (emailLocalPart, emailDomain) = email;

            // Assert
            Assert.Equal("carlos", emailLocalPart);
            Assert.Equal("sapo.pt", emailDomain);
            Assert.Equal($"{localPart}@{domain}", email.Address);
        }

        [Fact]
        public void ImplicitConversion_ValidStringEmail_ReturnsEmailObject()
        {
            // Arrange
            var emailAddress = "carlos@sapo.pt";

            // Act
            Email email = emailAddress;
            var (localPart, domain) = email;

            // Assert
            Assert.Equal("carlos", localPart);
            Assert.Equal("sapo.pt", domain);
        }

        [Fact]
        public void ImplicitConversion_InvalidStringEmail_ThrowsArgumentException()
        {
            // Arrange
            var invalidEmail = "invalidemail";

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => (Email)invalidEmail);
            Assert.Equal("Invalid email address format.", exception.Message);
        }

        [Fact]
        public void Deconstruct_ReturnsLocalPartAndDomain()
        {
            // Arrange
            var email = new Email("carlos", "sapo.pt");

            // Act
            var (localPart, domain) = email;

            // Assert
            Assert.Equal("carlos", localPart);
            Assert.Equal("sapo.pt", domain);
        }

        [Fact]
        public void None_ReturnsEmptyEmail()
        {
            // Act
            var email = Email.None;

            // Assert
            Assert.Equal(string.Empty, email.Address);
        }

        [Fact]
        public void CompareTwoNoneEmails_AreEqual()
        {
            // Arrange
            var email1 = Email.None;
            var email2 = Email.None;

            // Act & Assert
            Assert.Equal(email1, email2);
        }
    }
}
