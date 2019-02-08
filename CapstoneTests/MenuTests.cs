using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class MenuTests
    {
        [DataTestMethod]
        [DataRow("10", (double)10, "10 string should return 10 dollars")]
        public void GetDecimalTest(string decimalString, double expected, string message)
        {
            //Arrange
            Menu unitTest = new Menu();

            //Act - public decimal FeedMoney(decimal balance)
            decimal actual = unitTest.GetDecimal(decimalString);
            double actualDouble = (double)actual;

            //Assert
            Assert.AreEqual(expected, actualDouble, message);

        }
    }
}
