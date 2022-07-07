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
    public class AdditionOperatorTests
    {
        [DataTestMethod]
        [DataRow(new double[]{5, 6}, 11)]
        [DataRow(new double[] { 5, 6, 4 }, 15)]
        [DataRow(new double[] { 1.1d, 5.2d }, 6.300000000000001d)]
        [DataRow(new double[] { -5, -6 }, -11)]

        public void CalculateTest(double[] inputs, double expected)
        {
            // arrange
            AdditionOperator additionOperator = new AdditionOperator();

            // act
            CalculationResult<double> result = additionOperator.Calculate(inputs);

            // assert
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(expected, result.Result);
        }
    }
}