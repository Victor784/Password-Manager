using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManagerClient.ApiReturnTypes;

namespace PasswordManagerClient.Tests
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void Constructor_WithParameters_SetsPropertiesCorrectly()
        {
            // Arrange
            int id = 1;
            int userId = 123;
            string associatedWebsite = "example.com";
            string associatedEmail = "user@example.com";
            string passwordValue = "securepassword123";
            string timeOfCreation = "2024-04-01";
            string timeOfLastUpdate = "2024-04-01";
            string monthsUntilExpired = "6";

            // Act
            var password = new Password(id, userId, associatedWebsite, associatedEmail, passwordValue, timeOfCreation, timeOfLastUpdate, monthsUntilExpired);

            // Assert
            Assert.AreEqual(id, password.id);
            Assert.AreEqual(userId, password.user_id);
            Assert.AreEqual(associatedWebsite, password.associated_website);
            Assert.AreEqual(associatedEmail, password.associated_email);
            Assert.AreEqual(passwordValue, password.password_value);
            Assert.AreEqual(timeOfCreation, password.time_of_creation);
            Assert.AreEqual(timeOfLastUpdate, password.time_of_last_update);
            Assert.AreEqual(monthsUntilExpired, password.months_until_expired);
        }

        [TestMethod]
        public void Constructor_WithDefaultId_SetsIdToZero()
        {
            // Arrange
            int userId = 123;
            string associatedWebsite = "example.com";
            string associatedEmail = "user@example.com";
            string passwordValue = "securepassword123";
            string timeOfCreation = "2024-04-01";
            string timeOfLastUpdate = "2024-04-01";
            string monthsUntilExpired = "6";

            // Act
            var password = new Password(userId, associatedWebsite, associatedEmail, passwordValue, timeOfCreation, timeOfLastUpdate, monthsUntilExpired);

            // Assert
            Assert.AreEqual(0, password.id);
            Assert.AreEqual(userId, password.user_id);
            Assert.AreEqual(associatedWebsite, password.associated_website);
            Assert.AreEqual(associatedEmail, password.associated_email);
            Assert.AreEqual(passwordValue, password.password_value);
            Assert.AreEqual(timeOfCreation, password.time_of_creation);
            Assert.AreEqual(timeOfLastUpdate, password.time_of_last_update);
            Assert.AreEqual(monthsUntilExpired, password.months_until_expired);
        }
    }
}
