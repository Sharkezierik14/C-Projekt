using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contracts;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Tests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void ValidBook_WithTitleAuthorAndPublisher_Success()
        {
            // Arrange
            var book = new Book
            {
                Title = "Tiz kicsi neger",
                Author = "Agatha Christie",
                Publisher = "Alexandira",
                YearOfPublication = 1939
            };

            // Act
            // Nothing

            // Assert
            Assert.IsNotNull(book);
            Assert.AreEqual("Tiz kicsi neger", book.Title);
            Assert.AreEqual("Agatha Christie", book.Author);
            Assert.AreEqual("Alexandira", book.Publisher);
            Assert.AreEqual(1939, book.YearOfPublication);
        }

        [TestMethod]
        public void Book_WithMissingTitle_ValidationFailure()
        {
            // Arrange
            var book = new Book
            {
                Author = "Agatha Christie",
                Publisher = "Alexandira",
                YearOfPublication = 1939
            };

            // Act
            // No specific action required for this test case

            // Assert
            var validationContext = new ValidationContext(book);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(book, validationContext, validationResults, true);
            Assert.IsFalse(isValid);
            Assert.IsTrue(validationResults.Any(result => result.MemberNames.Contains("Title")));
        }
    }
}
