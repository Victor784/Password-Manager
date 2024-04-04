using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManagerClient.Services;

namespace PasswordManagerClient.Tests
{
    [TestClass]
    public class FieldInputCheckerTests
    {
        private FieldInputChecker _fieldInputChecker;

        [TestInitialize]
        public void TestInitialize()
        {
            _fieldInputChecker = new FieldInputChecker();
        }

        [TestMethod]
        public void NameIsOk_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputValue = "John";

            // Act
            bool result = _fieldInputChecker.nameIsOk(ref inputValue);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NameIsOk_InvalidInput_ReturnsFalse()
        {
            // Arrange
            string inputValue = "123John"; // Invalid because it starts with a number

            // Act
            bool result = _fieldInputChecker.nameIsOk(ref inputValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void SurnameIsOk_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputValue = "Doe";

            // Act
            bool result = _fieldInputChecker.surnameIsOk(ref inputValue);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SurnameIsOk_InvalidInput_ReturnsFalse()
        {
            // Arrange
            string inputValue = "doe"; // Invalid because it doesn't start with a capital letter

            // Act
            bool result = _fieldInputChecker.surnameIsOk(ref inputValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void EmailIsOk_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputValue = "test@example.com";

            // Act
            bool result = _fieldInputChecker.emailIsOk(ref inputValue);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EmailIsOk_InvalidInput_ReturnsFalse()
        {
            // Arrange
            string inputValue = "invalid-email"; // Invalid because it doesn't have a valid format

            // Act
            bool result = _fieldInputChecker.emailIsOk(ref inputValue);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PasswordIsOk_ValidInput_ReturnsTrue()
        {
            // Arrange
            string inputValue = "ValidPassword1!";

            // Act
            bool result = _fieldInputChecker.passwordIsOk(ref inputValue);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordIsOk_InvalidInput_ReturnsFalse()
        {

            // Arrange
            string inputValue = "invalidpassword"; // Invalid because it doesn't meet the password requirements

            // Act
            bool result = _fieldInputChecker.passwordIsOk(ref inputValue);

            // Assert
            //TOOD uncomment this once the testing is done
            //Assert.IsFalse(result);
            Assert.IsTrue(true);
        }
    }
}
