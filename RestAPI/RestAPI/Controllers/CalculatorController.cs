using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {


        // GET api/values/5/5
        [HttpGet("{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            decimal soma;

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                soma = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                return Ok(soma.ToString());
            }

            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string firstNumber)
        {
            double number;
            bool isNumber = 
                double.TryParse(
                    firstNumber, System.Globalization.NumberStyles.Any, 
                    System.Globalization.NumberFormatInfo.InvariantInfo, out number);
            return isNumber;
        }
    }
}
