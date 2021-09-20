using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodayExchangeRate.Interface
{
    /// <summary>
    /// Gets the exchange rate 
    /// </summary>
    public interface IGetRates
    {
        /// <summary>
        /// Gets the API layer exchange rate.
        /// </summary>
        /// <returns>decimal value of exchange rate</returns>
        decimal GetApiLayerExchangeRate();

        /// <summary>
        /// Gets the open market exchange rate.
        /// </summary>
        /// <returns>decimal value of exchange rate</returns>
        decimal GetOpenMarketExchangeRate();
    }
}
