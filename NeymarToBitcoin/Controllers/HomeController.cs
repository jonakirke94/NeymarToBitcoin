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

            //showing USD as default
            string defaultCurrency = "USD";

            double unformatedCurrency = client.GetValue(defaultCurrency) * 1000000;
            string symbol = GetSymbol(defaultCurrency);

            string formattedCurrency = String.Format("{0:N2}", unformatedCurrency) + " " + symbol;

            double bitcoinPrice = client.GetPrice(defaultCurrency) * 1000000;
            string bitcoinPriceFormatted = bitcoinPrice + " " + "\u0243";

            var model = new Price()
            {
                PlayerName = "Neymar Jr.",
                Currency = defaultCurrency,
                CurrencyPrice = formattedCurrency,
                BitcoinPrice = bitcoinPriceFormatted,
            };


            return View(model);
        }
    

        [HttpGet, ActionName("Index")]
        public IActionResult IndexCurrency(int currency)
        {
            Currencies enumDisplayStatus = (Currencies)currency;
            string selectedCurrency = enumDisplayStatus.ToString();

            double unformatedCurrency = client.GetValue(selectedCurrency) * 1000000;
            string symbol = GetSymbol(selectedCurrency);

            string formattedCurrency = String.Format("{0:N2}", unformatedCurrency) + " " + symbol;

            double bitcoinPrice = client.GetPrice(selectedCurrency) * 1000000;
            string bitcoinPriceFormatted = bitcoinPrice + " " + "\u0243";



            var model = new Price()
            {
                PlayerName = "Neymar Jr.",
                Currency = selectedCurrency,
                CurrencyPrice = formattedCurrency,
                BitcoinPrice = bitcoinPriceFormatted,
            };    
            

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GetSymbol(string currency)
        {
            string symbol = string.Empty;

            switch (currency)
            {
                case "USD":
                    symbol = "$";
                    break;
                case "EUR":
                    symbol = "€";
                    break;
                case "GBP":
                    symbol = "£";
                    break;
                case "DKK":
                    symbol = "kr.";
                    break;
                default:
                    symbol = "$";
                    break;
            }

            return symbol;
        }
    }
}
