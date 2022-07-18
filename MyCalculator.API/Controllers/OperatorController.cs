using Microsoft.AspNetCore.Mvc;
using MyCalculator.Business.Abstract;
using MyCalculator.Business.Concrete;

namespace MyCalculator.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IDictionary<string, IOperator<double>> _allOperators;
        private ICalculationRequestHandler<double> _calculationRequestHandler;

        public OperatorController(IDictionary<string, IOperator<double>> allOperators, ICalculationRequestHandler<double> calculationRequestHandler)
        {
            _allOperators = allOperators;
            _calculationRequestHandler = calculationRequestHandler;
        }

        [Route("GetOperatorList")]
        [HttpGet]
        public IEnumerable<string> GetOperatorList()
        {
            return _allOperators.Select(o => o.Key).ToList();
        }

        [HttpPost("Calculate")]
        public CalculationResult<double> Calculate([FromBody] CalculationRequest request)
        {
            return _calculationRequestHandler.Calculate(request, _allOperators);
        }

    }
}
