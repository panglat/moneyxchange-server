using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyXChangeServer.Core.Manager.Abstract;

namespace MoneyXChangeServer.Controllers
{
    [Produces("application/json")]
    [Route("/api/currency")]
    public class ApiController : Controller
    {
        private readonly ICurrencyManager _currencyManager;

        public ApiController(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager));
        }

        [HttpGet("symbols", Name = "GetCurrencies")]
        public IActionResult GetCurrencies()
        {
            try
            {
                var currencies = _currencyManager.GetAllCurrency();

                return Ok(currencies);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("latest", Name = "GetExchangeRates")]
        public IActionResult GetExchangeRates([FromQuery] string @base, [FromQuery] string symbols)
        {
            try
            {
                var conversionRate = _currencyManager.GetConversionRate(@base, symbols);
                return Ok(conversionRate);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
