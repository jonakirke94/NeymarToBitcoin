using Newtonsoft.Json;
using NeymarToBitcoin.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NeymarToBitcoin
{
    public class BitcoinAPI
    {

        private static string BuildURL(string currency, long value)
        {
            return "https://blockchain.info/tobtc?currency=" + currency + "&value=" + value;
        }

        private static string MakeRequest(string link)
        {
            var client = new HttpClient();
            string responseString = "Unknown";

            //accepting json
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.GetAsync(link).Result;
                var tmpresult = result.Content.ReadAsStringAsync().Result;
                var checkRes = JsonConvert.DeserializeObject<string>(tmpresult);

                if (!string.IsNullOrEmpty(checkRes))
                {
                    responseString = checkRes;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Something went wrong in getrequest..: " + e.Message);
            }


            return responseString;
        }

        public string GetPrice(string currency)
        {
            long value = GetValue(currency);

            var url = BuildURL(currency, value);
            return MakeRequest(url);
        }

        public long GetValue(string currency)
        {
            long value = 0;
            switch (currency)
            {
                case "USD":
                    value = 263000000;
                    break;
                case "EUR":
                    value = 223877424;
                    break;
                case "JPY":
                    value = 29672975000;
                    break;
                case "GBP":
                    value = 197776000;
                    break;
                case "DKK":
                    value = 1666065550;
                    break;
                default:
                    value = 263000000;
                    break;
            }

            return value;
        }
    }
}
