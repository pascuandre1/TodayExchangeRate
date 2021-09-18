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

        /// <summary>
        /// Gets the API layer rates asynchronous.
        /// </summary>
        /// <returns>ApiLayerModel</returns>
        public async Task<ApiLayerModel> GetApiLayerRatesAsync()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Sources.json");

            var configuration = builder.Build();
            var apiLayerUrl = configuration["ApiLayerUrl"];
            
            try
            {
                var response = await httpClient.GetAsync(apiLayerUrl).ConfigureAwait(false);
                var content = response.Content.ReadAsStringAsync().Result;
                apiLayerModel = JsonConvert.DeserializeObject<ApiLayerModel>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Sources.json");
            var configuration = builder.Build();
            var openMarketUrl = configuration["OpenMarketUrl"];

            try
            {
                var response = await httpClient.GetAsync(openMarketUrl).ConfigureAwait(false);
                var content = response.Content.ReadAsStringAsync().Result;
                openMarketModel = JsonConvert.DeserializeObject<OpenMarketModel>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return openMarketModel;
        }

    }
}
