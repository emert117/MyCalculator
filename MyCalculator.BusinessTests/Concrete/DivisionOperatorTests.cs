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
    public class DivisionOperatorTests
    {
        [DataTestMethod]
        [DataRow(new double[] { 12, 6 }, 2)]
        [DataRow(new double[] { 75, 5, 3 }, 5)]
        [DataRow(new double[] { 19.38d, 5.7d }, 3.4d)]
        [DataRow(new double[] { -5, -6 }, 0.8333333333333334d)]

        public void CalculateTest(double[] inputs, double expected)
        {
            // arrange
            DivisionOperator divisionOperator = new DivisionOperator();

            // act
            CalculationResult<double> result = divisionOperator.Calculate(inputs);

            // assert
            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(expected, result.Result);
        }
    }
}