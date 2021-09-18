using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayExchangeRate.Models;

namespace TodayExchangeRate.Interface
{
    public interface IExchangeRates
    {
        Task<ApiLayerModel> GetApiLayerRatesAsync();
        Task<OpenMarketModel> GetOpenMarketRatesAsync();
    }
}
