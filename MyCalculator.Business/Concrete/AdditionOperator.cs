using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalculator.Business.Abstract;

namespace MyCalculator.Business.Concrete
{
    public class AdditionOperator : IAdditionOperator
    {
        public string OperatorSymbol => "+";

        public string OperatorName => "Addition";

        public int Precedence => 1;

        public CalculationResult<double> Calculate(double[] inputs)
        {
            CalculationResult<double> result = new CalculationResult<double>();
            try
            {
                result.Result = inputs.Sum();
                result.IsSuccessful = true;
            }
            catch (Exception e)
            {
                result.IsSuccessful = false;
            }

            return result;
        }
    }
}
