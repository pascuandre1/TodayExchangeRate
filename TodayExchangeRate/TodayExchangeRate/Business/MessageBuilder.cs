using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayExchangeRate.Interface;

namespace TodayExchangeRate.Business
{
    /// <summary>
    /// Builds the message for the user
    /// </summary>
    /// <seealso cref="TodayExchangeRate.Interface.IMessageBuilder" />
    public class MessageBuilder : IMessageBuilder
    {
        /// <summary>
        /// Builds the exchange message.
        /// </summary>
        /// <param name="apiRate">The API rate.</param>
        /// <param name="marketRate">The market rate.</param>
        /// <returns>string message</returns>
        public string BuildExchangeMessage(decimal apiRate, decimal marketRate)
        {
            var additionalMessage = string.Empty;
            var exchangeMessageBase =
                $"Exchange rate from api layer: {apiRate.ToString(CultureInfo.InvariantCulture)}" +
                $"\nExchange rate from open market: {marketRate.ToString(CultureInfo.InvariantCulture)} \n";
            if (apiRate > marketRate)
                additionalMessage = "You should exchange from api rate";
            if (apiRate == marketRate)
                additionalMessage = "The rates are the same, you can exchange from any market";
            if (apiRate < marketRate)
                additionalMessage = "You should exchange from open market rate";
            return string.Concat(exchangeMessageBase, additionalMessage);
        }
    }
}
