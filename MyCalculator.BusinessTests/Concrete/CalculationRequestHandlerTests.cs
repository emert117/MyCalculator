using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCalculator.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalculator.Business.Abstract;

namespace MyCalculator.Business.Concrete.Tests
{
    [TestClass()]
    public class CalculationRequestHandlerTests
    {
        [TestMethod]
        public void CalculateTest()
        {
            CalculationRequestHandler handler = new CalculationRequestHandler();

            CalculationRequest request = new CalculationRequest();
            // 11+22-33/44+55*66+77 = 3739.25
            request.Operators = new string[] {"+", "-", "/", "+", "*", "+" };
            request.Operands = new double[] { 11, 22, 33, 44, 55, 66, 77};

            IDictionary<string, IOperator<double>> allOperators = new Dictionary<string, IOperator<double>>();
            allOperators.Add("+", new AdditionOperator());
            allOperators.Add("/", new DivisionOperator());
            allOperators.Add("*", new MultiplicationOperator());
            allOperators.Add("-", new SubtractionOperator());

            var result = handler.Calculate(request, allOperators);

            Assert.IsTrue(result.IsSuccessful);
            Assert.AreEqual(result.Result, 3739.25d);
        }
    }
}