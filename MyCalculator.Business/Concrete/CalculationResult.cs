using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCalculator.Business.Concrete
{
    public class CalculationResult<T> where T : new()
    {
        public bool IsSuccessful { get; set; }

        public T Result { get; set; }
    }
}
