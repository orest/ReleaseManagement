using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReleaseManagement.Core.Junk;

namespace ReleaseManagement.Test {
    [TestClass]
    public class CalculatorTest {
        [TestMethod]
        public void AddTwoNumberSuccess() {
            //Arrange
            var calculator = new Calculator();

            var a = 1;
            var b = 3;

            //Act
            var result = calculator.Add(a, b);

            //Assert
            Assert.AreEqual(result, 4);
            Assert.IsTrue(result == 4);

        }
    }
}
