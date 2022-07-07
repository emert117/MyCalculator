using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Business.Concrete.Tests
{
    [TestClass()]
    public class SubtractionOperatorTests
    {
        [DataTestMethod]
        [DataRow(new double[] { 5.2d, 1.1d }, 4.1d)]
        [DataRow(new double[] { 5, 6 }, -1)]
        [DataRow(new double[] { 5, 6, 4 }, -5)]
        [DataRow(new double[] { -5, -6 }, 1)]

        public void CalculateTest(double[] inputs, double expected)
        {
            // arrange
            SubtractionOperator subtractionOperator = new SubtractionOperator();

            // act
            CalculationResult<double> result = subtractionOperator.Calculate(inputs);

            // assert
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(expected, result.Result);
        }
    }
}