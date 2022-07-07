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
    public class MultiplicationOperatorTests
    {
        [DataTestMethod]
        [DataRow(new double[] { 5.2d, 1.1d }, 5.720000000000001d)]
        [DataRow(new double[] { 5, 6 }, 30)]
        [DataRow(new double[] { 5, 6, 4 }, 120)]
        [DataRow(new double[] { -5, -6 }, 30)]

        public void CalculateTest(double[] inputs, double expected)
        {
            // arrange
            MultiplicationOperator multiplicationOperator = new MultiplicationOperator();

            // act
            CalculationResult<double> result = multiplicationOperator.Calculate(inputs);

            // assert
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(expected, result.Result);
        }
    }
}