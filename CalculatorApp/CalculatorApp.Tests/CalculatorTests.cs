using NUnit.Framework;
using CalculatorApp;
using System;

namespace CalculatorApp.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator = null!; // fixes warning too

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_WhenCalled_ReturnsCorrectSum()
        {
            int result = calculator.Add(10, 5);
            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void Subtract_WhenCalled_ReturnsCorrectResult()
        {
            int result = calculator.Subtract(10, 3);
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Multiply_WhenCalled_ReturnsCorrectResult()
        {
            int result = calculator.Multiply(4, 5);
            Assert.That(result, Is.EqualTo(20));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
        }
    }
}
