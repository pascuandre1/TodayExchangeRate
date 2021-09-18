

namespace TodayExchangeRate.Interface
{
    public interface  IMessageBuilder
    {
        /// <summary>
        /// Builds the exchange message.
        /// </summary>
        /// <param name="apiRate">The API rate.</param>
        /// <param name="marketRate">The market rate.</param>
        /// <returns>message string</returns>
        string BuildExchangeMessage(decimal apiRate, decimal marketRate);
    }
}
