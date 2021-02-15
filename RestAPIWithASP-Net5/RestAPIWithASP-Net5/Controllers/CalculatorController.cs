using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIWithASP_Net5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = decimal.Parse(firstNumber, CultureInfo.InvariantCulture) + decimal.Parse(secondNumber, CultureInfo.InvariantCulture);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sub = decimal.Parse(firstNumber, CultureInfo.InvariantCulture) - decimal.Parse(secondNumber, CultureInfo.InvariantCulture);
                return Ok(sub.ToString());
            }
            else
            {
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var div = decimal.Parse(firstNumber, CultureInfo.InvariantCulture) / decimal.Parse(secondNumber, CultureInfo.InvariantCulture);
                return Ok(div.ToString());
            }
            else
            {
                return BadRequest("Invalid Input");
            }
        }

        [HttpGet("med/{firstNumber}/{secondNumber}")]
        public IActionResult Med(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var med = (decimal.Parse(firstNumber, CultureInfo.InvariantCulture) + decimal.Parse(secondNumber, CultureInfo.InvariantCulture)) / 2;
                return Ok(med.ToString());
            }
            else
            {
                return BadRequest("InvalidInput");
            }
        }

        [HttpGet("raiz/{Number}")]
        public IActionResult Raiz(string Number)
        {
            if (IsNumeric(Number))
            {
                var number = decimal.Parse(Number);
                var resultRaiz = Math.Sqrt((double)number);

                return Ok(resultRaiz.ToString());
            } else
            {
                return BadRequest("Invalid Input");
            }
        }

        private bool IsNumeric(string strNumber)
        {
            double Number;
            bool Isnumber = double.TryParse(strNumber, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out Number);
            return Isnumber;

        }
    }
}
