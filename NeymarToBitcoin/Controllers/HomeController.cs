using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeymarToBitcoin.Models;

namespace NeymarToBitcoin.Controllers
{
    public class HomeController : Controller
    {
        private BitcoinAPI client = new BitcoinAPI();

        public IActionResult Index()
        {
            string defaultCurrency = "USD";
            var model = new Price()
            {
                PlayerName = "Neymar",
                Currency = defaultCurrency,
                CurrencyPrice = client.GetValue(defaultCurrency),
            };            
            model.BitcoinPrice = client.GetPrice(defaultCurrency);

            return View(model);
        }

        [HttpGet, ActionName("Index")]
        public IActionResult IndexCurrency(int currency)
        {
            Currencies enumDisplayStatus = (Currencies)currency;
            string selectedCurrency = enumDisplayStatus.ToString();

            var model = new Price()
            {
                PlayerName = "Neymar",
                Currency = selectedCurrency,
                CurrencyPrice = client.GetValue(selectedCurrency),
            };    
            model.BitcoinPrice = client.GetPrice(selectedCurrency);

            return View(model);

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
