using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManagerClient.Services;
using System;

namespace PasswordManagerClient.Tests
{
    [TestClass]
    public class PasswordGeneratorTests
    {
        [TestMethod]
        public void GenerateRandomPassword_ReturnsPasswordWithExpectedLength()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();

            // Act
            string password = passwordGenerator.generateRandomPassword();

            // Assert
            Assert.AreEqual(20, password.Length);
        }

        [TestMethod]
        public void GenerateRandomPassword_ReturnsDifferentPasswordsEachTime()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();

            // Act
            string password1 = passwordGenerator.generateRandomPassword();
            string password2 = passwordGenerator.generateRandomPassword();

            // Assert
            Assert.AreNotEqual(password1, password2);
        }
    }
}
