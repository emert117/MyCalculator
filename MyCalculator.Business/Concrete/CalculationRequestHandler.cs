using MyCalculator.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Business.Concrete
{
    public class CalculationRequestHandler : ICalculationRequestHandler<double>
    {
        public CalculationResult<double> Calculate(CalculationRequest request, IDictionary<string, IOperator<double>> allOperators)
        {
            var indexOfMaxPrecedenceOperator = FindIndexOfMaxPrecedenceOperator(request, allOperators);

            double[] currentOperands = new double[] { request.Operands[indexOfMaxPrecedenceOperator], request.Operands[indexOfMaxPrecedenceOperator + 1] };
            CalculationResult<double>  result = allOperators[request.Operators[indexOfMaxPrecedenceOperator]].Calculate(currentOperands);

            if (request.Operators.Length > 1)
            {
                CalculationRequest newRequest = new CalculationRequest();
                CopyOperatorsToNewRequest(request, newRequest, indexOfMaxPrecedenceOperator);
                CopyOperandsToNewRequest(request, newRequest, indexOfMaxPrecedenceOperator, result);

                return Calculate(newRequest, allOperators);
            }

            result.IsSuccessful = true;
            return result;
        }

        private void CopyOperandsToNewRequest(CalculationRequest request, CalculationRequest newRequest,
            int indexOfMaxPrecedenceOperator, CalculationResult<double> result)
        {
            newRequest.Operands = new double[request.Operands.Length - 1];
            int j = 0;
            for (int i = 0; i < request.Operands.Length; i++)
            {
                if (i == indexOfMaxPrecedenceOperator)
                {
                    // place the calculated result
                    newRequest.Operands[j] = result.Result;
                    i++; // skip next operand because we processed this operand
                }
                else
                {
                    newRequest.Operands[j] = request.Operands[i];
                }

                j++;
            }
        }

        private void CopyOperatorsToNewRequest(CalculationRequest request, CalculationRequest newRequest,
            int indexOfMaxPrecedenceOperator)
        {
            newRequest.Operators = new string[request.Operators.Length - 1];
            int k = 0;
            for (int i = 0; i < request.Operators.Length; i++)
            {
                if (i == indexOfMaxPrecedenceOperator)
                    continue; // skip this operator because we already processed this
                newRequest.Operators[k] = request.Operators[i];
                k++;
            }
        }

        private int FindIndexOfMaxPrecedenceOperator(CalculationRequest request, IDictionary<string, IOperator<double>> allOperators)
        {
            var maxPrecedenceOperatorInRequest = allOperators.Where(o => request.Operators.Contains(o.Key)).MaxBy(o => o.Value.Precedence);
            int indexOfMaxPrecedenceOperator = Array.IndexOf(request.Operators, maxPrecedenceOperatorInRequest.Key);
            
            // check if the first operator has the same precedence value of maximum precedence
            if (allOperators[request.Operators[0]].Precedence == maxPrecedenceOperatorInRequest.Value.Precedence)
            {
                // place the first operator because we calculate from left to right direction
                indexOfMaxPrecedenceOperator = 0;
            }

            return indexOfMaxPrecedenceOperator;
        }
    }
}
