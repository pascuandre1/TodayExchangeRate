using System;
using System.Configuration;
using System.Net.Http;
using System.Windows.Forms;
using TodayExchangeRate.Business;

namespace TodayExchangeRate
{
    class Program
    {
        private static string printMode = ConfigurationManager.AppSettings["PrintMode"];
        private static HttpClient httpClient = new HttpClient();
        private static ExchangeRates exchangeRates = new ExchangeRates(httpClient);
        private static MessageBuilder messageBuilder = new MessageBuilder();

        static void Main(string[] args)
        {
            var apiRate = GetApiLayerExchangeRate();
            var openMarketRate = GetOpenMarketExchangeRate();
            var message = messageBuilder.BuildExchangeMessage(apiRate, openMarketRate);

            switch (printMode)
            {
                case "Console":
                    Console.WriteLine(message);
                    Console.ReadLine();
                    break;
                case "MessageBox":
                    MessageBox.Show(message);
                    break;
                default:
                    Console.WriteLine(message);
                    Console.ReadLine();
                    break;
            }
        }

        #region private methods

        private static decimal GetApiLayerExchangeRate()
        {
            var apiExchangeResult = exchangeRates.GetApiLayerRatesAsync().Result;
            var usdEurRate = apiExchangeResult.Quotes["USDEUR"];
            return usdEurRate;
        }

        private static decimal GetOpenMarketExchangeRate()
        {
            var openMarketResult = exchangeRates.GetOpenMarketRatesAsync().Result;
            var euroRate = openMarketResult.Rates["EUR"];
            return euroRate;
        }

        #endregion private methods
    }
}
