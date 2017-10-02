using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace NeymarToBitcoin.Models
{
    public class Price
    {
        public string id { get; set; }
        public string PlayerName { get; set; }

        public string BitcoinPrice { get; set; }
        public string Currency { get; set; }
        public string CurrencyPrice { get; set; }
    }
}
