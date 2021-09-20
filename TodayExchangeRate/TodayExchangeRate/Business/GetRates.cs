using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodayExchangeRate.Interface;

namespace TodayExchangeRate.Business
{
    /// <summary>
    /// Gets the exchange rate 
    /// </summary>
    /// <seealso cref="TodayExchangeRate.Interface.IGetRates" />
    public class GetRates : IGetRates
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private readonly ExchangeRates exchangeRates = new ExchangeRates(httpClient);

        /// <summary>
        /// Gets the API layer exchange rate.
        /// </summary>
        /// <returns>decimal value of exchange rate</returns>
        public decimal GetApiLayerExchangeRate()
        {
            var apiExchangeResult = exchangeRates.GetApiLayerRatesAsync().Result;
            var usdEurRate = apiExchangeResult.Quotes["USDEUR"];
            return usdEurRate;
        }

        /// <summary>
        /// Gets the open market exchange rate.
        /// </summary>
        /// <returns>decimal value of exchange rate</returns>
        public decimal GetOpenMarketExchangeRate()
        {
            var openMarketResult = exchangeRates.GetOpenMarketRatesAsync().Result;
            var euroRate = openMarketResult.Rates["EUR"];
            return euroRate;
        }
    }
}
