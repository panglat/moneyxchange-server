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
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyManager _currencyManager;

        public CurrencyController(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager ?? throw new ArgumentNullException(nameof(currencyManager));
        }

        // GET: api/Currency
        [HttpGet]
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

        // GET: api/Currency/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Currency
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Currency/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
