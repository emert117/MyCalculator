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

        public OperatorController(IDictionary<string, IOperator<double>> allOperators)
        {
            _allOperators = allOperators;
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
            return _allOperators[request.Operator].Calculate(request.Operands);
        }

    }
}
