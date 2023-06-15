using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Tests
{
    [TestClass]
    public class MemberTests
    {
        [TestMethod]
        public void ValidMember_WithValidNameAddressAndYearOfBirth_Success()
        {
            // Arrange
            var member = new Member
            {
                Name = "Demko Feri",
                Address = "123 Segner ter",
                YearOfBirth = 2001
            };

            // Act
            // No specific action required for this test case

            // Assert
            Assert.IsNotNull(member);
            Assert.AreEqual("Demko Feri", member.Name);
            Assert.AreEqual("123 Segner ter", member.Address);
            Assert.AreEqual(2001, member.YearOfBirth);
        }

        [TestMethod]
        public void Member_WithInvalidName_ValidationFailure()
        {
            // Arrange
            var member = new Member
            {
                Name = "Feri 123", // Contains digits, which is not allowed
                Address = "123 Segner ter",
                YearOfBirth = 2001
            };

            // Act
            // No specific action required for this test case

            // Assert
            var validationContext = new ValidationContext(member);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(member, validationContext, validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(result => result.MemberNames.Contains("Name")));
        }

        [TestMethod]
        public void Member_WithMissingAddress_ValidationFailure()
        {
            // Arrange
            var member = new Member
            {
                Name = "Demko Feri",
                // Address is missing
                YearOfBirth = 2001
            };

            // Act
            // No specific action required for this test case

            // Assert
            var validationContext = new ValidationContext(member);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(member, validationContext, validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(result => result.MemberNames.Contains("Address")));
        }
    }
}
