using Microsoft.VisualStudio.TestTools.UnitTesting;
using PasswordManagerClient.Services;

namespace PasswordManagerClient.Tests
{
    [TestClass]
    public class ExpirationCalculatorTests
    {
        [TestMethod]
        public void CalculateDaysUntilExpiration_ReturnsExpired_WhenEndDateIsBeforeStartDate()
        {
            // Arrange
            var expirationCalculator = new ExpirationCalculator();
            string startDate = "2024-04-01";
            string endDate = "2024-03-31";
            string monthsUntilExpiration = "1 month";

            // Act
            string result = expirationCalculator.CalculateDaysUntilExpiration(startDate, endDate, monthsUntilExpiration);

            // Assert
            Assert.AreEqual("1 month 3 days", result);
        }

        [TestMethod]
        public void CalculateDaysUntilExpiration_ReturnsNumberOfDays_WhenWithin28Days()
        {
            // Arrange
            var expirationCalculator = new ExpirationCalculator();
            string startDate = "2024-04-01";
            string endDate = "2024-04-20";
            string monthsUntilExpiration = "11 days";

            // Act
            string result = expirationCalculator.CalculateDaysUntilExpiration(startDate, endDate, monthsUntilExpiration);

            // Assert
            Assert.AreEqual("11 days", result);
        }

        [TestMethod]
        public void CalculateDaysUntilExpiration_ReturnsOneMonthAndRemainingDays_WhenWithinTwoMonths()
        {
            // Arrange
            var expirationCalculator = new ExpirationCalculator();
            string startDate = "2024-04-01";
            string endDate = "2024-05-30";
            string monthsUntilExpiration = "1 month";

            // Act
            string result = expirationCalculator.CalculateDaysUntilExpiration(startDate, endDate, monthsUntilExpiration);

            // Assert
            Assert.AreEqual("Expired", result);
        }
    }
}
