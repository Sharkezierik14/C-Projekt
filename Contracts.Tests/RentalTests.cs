using Microsoft.VisualStudio.TestTools.UnitTesting;
using Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Tests
{
    [TestClass]
    public class RentalTests
    {
        [TestMethod]
        public void ValidRental_WithValidData_Success()
        {
            // Arrange
            var member = new Member
            {
                Id = 1,
                Name = "John Doe",
                Address = "123 Main St",
                YearOfBirth = 1990
            };

            var book = new Book
            {
                Id = 1,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                Publisher = "Little, Brown and Company",
                YearOfPublication = 1951
            };

            var rental = new Rental
            {
                DateOfRental = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14),
                MemberId = member.Id,
                Member = member,
                BookId = book.Id,
                Book = book
            };

            // Act
            // No specific action required for this test case

            // Assert
            Assert.IsNotNull(rental);
            Assert.AreEqual(DateTime.Now.Date, rental.DateOfRental.Date);
            Assert.AreEqual(DateTime.Now.AddDays(14).Date, rental.ReturnDate.Date);
            Assert.AreEqual(member.Id, rental.MemberId);
            Assert.AreEqual(member, rental.Member);
            Assert.AreEqual(book.Id, rental.BookId);
            Assert.AreEqual(book, rental.Book);
        }

    }
}
