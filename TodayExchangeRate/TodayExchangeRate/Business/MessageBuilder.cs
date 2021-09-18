using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodayExchangeRate.Interface;

namespace TodayExchangeRate.Business
{
    public class MessageBuilder : IMessageBuilder
    {
        public string BuildExchangeMessage(decimal apiRate, decimal marketRate)
        {
            string additionalMessage = "";
            string exchangeMessageBase =
                $"Exchange rate from api layer: {apiRate.ToString(CultureInfo.InvariantCulture)}" +
                $" \n Exchange rate from open market: {marketRate.ToString(CultureInfo.InvariantCulture)} \n";


            if (apiRate > marketRate)
                additionalMessage = "You should exchange from api rate";
            if (apiRate == marketRate)
                additionalMessage = "The rates are the same, you can exchange from any market";
            if (apiRate < marketRate)
                additionalMessage = "You should exchange from open market rate";
            return exchangeMessageBase + additionalMessage;
        }
    }
}
