using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodayExchangeRate.Business;

namespace TodayExchangeRate.Tests
{
    [TestClass]
    public class MessageBuilderTests
    {
        private MessageBuilder messageBuilder = new MessageBuilder();

        [TestMethod]
        public void Given_ApiRate_Bigger_That_MarketRate_When_MessageBuiler_Is_Called_Then_Text_Is_As_Expected()
        {
            var apiRate = 1;
            var marketRate = 2;
            var resultMesaMessage = messageBuilder.BuildExchangeMessage(apiRate, marketRate);

            Assert.AreEqual("Exchange rate from api layer: 1\nExchange rate from open market: 2 " +
                            "\nYou should exchange from open market rate",resultMesaMessage,"Message is as expected");
        }

        [TestMethod]
        public void Given_MarketRate_Bigger_That_ApiRate_When_MessageBuiler_Is_Called_Then_Text_Is_As_Expected()
        {
            var apiRate = 2;
            var marketRate = 1;
            var resultMesaMessage = messageBuilder.BuildExchangeMessage(apiRate, marketRate);

            Assert.AreEqual("Exchange rate from api layer: 2\nExchange rate from open market: 1 " +
                            "\nYou should exchange from api rate", resultMesaMessage, "Message is as expected");
        }

        [TestMethod]
        public void Given_ApiRate_Equal_To_MarketRate_When_MessageBuiler_Is_Called_Then_Text_Is_As_Expected()
        {
            var apiRate = 1;
            var marketRate = 1;
            var resultMesaMessage = messageBuilder.BuildExchangeMessage(apiRate, marketRate);

            Assert.AreEqual("Exchange rate from api layer: 1\nExchange rate from open market: 1 " +
                            "\nThe rates are the same, you can exchange from any market", resultMesaMessage, "Message is as expected");
        }
    }
}
