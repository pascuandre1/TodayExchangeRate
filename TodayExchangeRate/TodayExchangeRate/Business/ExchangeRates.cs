using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using TodayExchangeRate.Models;

namespace TodayExchangeRate.Business
{
    /// <summary>
    /// ExchangeRates business
    /// </summary>
    public class ExchangeRates
    {
        private HttpClient httpClient = new HttpClient();
        private ApiLayerModel apiLayerModel = new ApiLayerModel();
        private OpenMarketModel openMarketModel = new OpenMarketModel();

        public ExchangeRates(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets the API layer rates asynchronous.
        /// </summary>
        /// <returns>ApiLayerModel</returns>
        public async Task<ApiLayerModel> GetApiLayerRatesAsync()
        {
            var apiLayerUrl = GetUrlFromSources("ApiLayerUrl");
            
            try
            {
                var response = await httpClient.GetAsync(apiLayerUrl).ConfigureAwait(false);
                var content = response.Content.ReadAsStringAsync().Result;
                apiLayerModel = JsonConvert.DeserializeObject<ApiLayerModel>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return apiLayerModel;
        }

        /// <summary>
        /// Gets the open market rates asynchronous.
        /// </summary>
        /// <returns>OpenMarketModel</returns>
        public async Task<OpenMarketModel> GetOpenMarketRatesAsync()
        {
            var openMarketUrl = GetUrlFromSources("OpenMarketUrl");

            try
            {
                var response = await httpClient.GetAsync(openMarketUrl).ConfigureAwait(false);
                var content = response.Content.ReadAsStringAsync().Result;
                openMarketModel = JsonConvert.DeserializeObject<OpenMarketModel>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return openMarketModel;
        }

        private string GetUrlFromSources(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Sources.json");

            var configuration = builder.Build();
            return configuration[key];
        }

    }
}
