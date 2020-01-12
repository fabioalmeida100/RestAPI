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
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Soma", "Subtração", "Divisão", "Multiplicação" };
        }

        // GET api/values/5/5
        [HttpGet("soma/{firstNumber}/{secondNumber}")]
        public IActionResult Soma(string firstNumber, string secondNumber)
        {
            decimal soma;

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                soma = Convert.ToDecimal(firstNumber) + Convert.ToDecimal(secondNumber);
                return Ok(soma.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/5/5
        [HttpGet("subtracao/{firstNumber}/{secondNumber}")]
        public IActionResult Subtracao(string firstNumber, string secondNumber)
        {
            decimal subtracao;

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                subtracao = Convert.ToDecimal(firstNumber) - Convert.ToDecimal(secondNumber);
                return Ok(subtracao.ToString());
            }

            return BadRequest("Invalid Input");
        }

        // GET api/values/5/5
        [HttpGet("multiplicacao/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplicacao(string firstNumber, string secondNumber)
        {
            decimal multiplicacao;

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                multiplicacao = Convert.ToDecimal(firstNumber) * Convert.ToDecimal(secondNumber);
                return Ok(multiplicacao.ToString());
            }

            return BadRequest("Invalid Input");
        }


        // GET api/values/5/5
        [HttpGet("divisao/{firstNumber}/{secondNumber}")]
        public IActionResult Divisao(string firstNumber, string secondNumber)
        {
            decimal divisao;

            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                divisao = Convert.ToDecimal(firstNumber) / Convert.ToDecimal(secondNumber);
                return Ok(divisao.ToString());
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
