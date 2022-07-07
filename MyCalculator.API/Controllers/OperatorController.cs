using Microsoft.AspNetCore.Mvc;
using MyCalculator.Business.Abstract;
using MyCalculator.Business.Concrete;

namespace MyCalculator.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly IAdditionOperator _additionService;
        private readonly IDivisionOperator _divisionService;
        private readonly IMultiplicationOperator _multiplicationService;
        private readonly ISubtractionOperator _subtractionService;

        public OperatorController(IAdditionOperator additionService, IDivisionOperator divisionService, 
            IMultiplicationOperator multiplicationService, ISubtractionOperator subtractionService)
        {
            _additionService = additionService;
            _divisionService = divisionService;
            _multiplicationService = multiplicationService;
            _subtractionService = subtractionService;
        }


        [HttpGet(Name = "GetOperatorList")]
        public IEnumerable<string> GetOperatorList()
        {
            return new List<string>() {""};
        }

        [HttpPost("Addition")]
        public CalculationResult<double> Addition([FromBody] double[] operands)
        {
            return _additionService.Calculate(operands);
        }

        [HttpPost("Division")]
        public CalculationResult<double> Division([FromBody] double[] operands)
        {
            return _divisionService.Calculate(operands);
        }

        [HttpPost("Multiplication")]
        public CalculationResult<double> Multiplication([FromBody] double[] operands)
        {
            return _multiplicationService.Calculate(operands);
        }

        [HttpPost("Substraction")]
        public CalculationResult<double> Substraction([FromBody] double[] operands)
        {
            return _subtractionService.Calculate(operands);
        }
    }
}
