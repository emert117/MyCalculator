using MyCalculator.Business.Concrete;

namespace MyCalculator.Business.Abstract
{
    public interface ICalculationRequestHandler<T> where T : new()
    {
        public CalculationResult<double> Calculate(CalculationRequest request, IDictionary<string, IOperator<double>> _allOperators);
    }
}