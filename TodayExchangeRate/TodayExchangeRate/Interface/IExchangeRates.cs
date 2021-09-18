using System.Threading.Tasks;
using TodayExchangeRate.Models;

namespace TodayExchangeRate.Interface
{
    public interface IExchangeRates
    {
        /// <summary>
        /// Gets the API layer rates asynchronous.
        /// </summary>
        /// <returns>ApiLayerModel</returns>
        Task<ApiLayerModel> GetApiLayerRatesAsync();

        /// <summary>
        /// Gets the open market rates asynchronous.
        /// </summary>
        /// <returns>OpenMarketModel</returns>
        Task<OpenMarketModel> GetOpenMarketRatesAsync();
    }
}
