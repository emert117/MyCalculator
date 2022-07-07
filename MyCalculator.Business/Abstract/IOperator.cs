using MyCalculator.Business.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Business.Abstract
{
    public interface IOperator<T> where T : new()
    {
        string OperatorSymbol { get; }
        string OperatorName { get; }
        public CalculationResult<T> Calculate(T[] inputs);
    }
}
