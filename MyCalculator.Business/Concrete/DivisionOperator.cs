using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCalculator.Business.Abstract;

namespace MyCalculator.Business.Concrete
{
    public class DivisionOperator : IDivisionOperator
    {
        public string OperatorSymbol => "/";

        public string OperatorName => "Division";

        public CalculationResult<double> Calculate(double[] inputs)
        {
            CalculationResult<double> result = new CalculationResult<double>();
            try
            {
                result.Result = inputs[0];
                for (int i = 0; i < inputs.Length - 1; i++)
                {
                    result.Result = result.Result / inputs[i + 1];
                }
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
