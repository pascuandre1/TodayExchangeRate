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
        private static GetRates getRates = new GetRates();
        private static MessageBuilder messageBuilder = new MessageBuilder();

        static void Main(string[] args)
        {
            var apiRate = getRates.GetApiLayerExchangeRate();
            var openMarketRate = getRates.GetOpenMarketExchangeRate();
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
    }
}
