using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Reclutamiento_NET.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reclutamiento_NET.Controllers
{
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {
        // GET api/values
        [HttpGet("getheaders")]
        public IActionResult OperationGet()
        {
            var number1 = double.Parse(Request.Headers["number1"].ToString());
            var number2 = double.Parse(Request.Headers["number2"].ToString());
            var operation = Request.Headers["operation"].ToString();

            if (operation == null)
                return BadRequest("Invalid request");

            var compareInfo = CultureInfo.CurrentCulture.CompareInfo;

            if (compareInfo.Compare(operation,"suma", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                var result = number1 + number2;
                return Ok(result);
            }

            if (compareInfo.Compare(operation, "resta", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                var result = number1 - number2;
                return Ok(result);
            }

            if (compareInfo.Compare(operation, "multiplicacion", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                var result = number1 * number2;
                return Ok(result);
            }

            if (compareInfo.Compare(operation, "division", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                if (number2 == 0)
                    return BadRequest("Cannot divide by zero");

                var result = number1 / number2;
                return Ok(result);
            }

            return NoContent();
        }

        // POST api/values
        [HttpPost]
        public IActionResult OperationPost(Operation operation)
        {
            if (operation == null)
                return BadRequest("Invalid request");

            var compareInfo = CultureInfo.CurrentCulture.CompareInfo;

            if (compareInfo.Compare(operation.Operations, "suma", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                var result = operation.Number1 + operation.Number2;
                return Ok(result);
            }

            if (compareInfo.Compare(operation.Operations, "resta", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                var result = operation.Number1 - operation.Number2;
                return Ok(result);
            }

            if (compareInfo.Compare(operation.Operations, "multiplicacion", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                var result = operation.Number1 * operation.Number2;
                return Ok(result);
            }

            if (compareInfo.Compare(operation.Operations, "division", CompareOptions.IgnoreCase | CompareOptions.IgnoreNonSpace) == 0)
            {
                if (operation.Number2 == 0)
                    return BadRequest("Cannot divide by zero");

                var result = operation.Number1 / operation.Number2;
                return Ok(result);
            }

            return NoContent();
        }

    }
}

