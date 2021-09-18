using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using TodayExchangeRate.Business;
using TodayExchangeRate.Models;

namespace TodayExchangeRate.Tests
{
    [TestClass]
    public class ExchangeRatesTests
    {
        [TestMethod]
        public void GivenExchangeRates_When_GetApiLayerRatesAsync_Is_Called_Then_The_ApiLayerModel_IsReturned()
        {
            //arrange
            var expectedModel = new ApiLayerModel()
            {
                Success = true,
                Terms = "Test_Terms",
                Privacy = "Test_Privacy",
                TimeStamp = 123,
                Source = "Test_Source",
                Quotes = new Dictionary<string, decimal>()
                {
                    {"Test_Key1",  1_000.5m},
                    { "Test_Key2", 2_000.5m }
                }
            };
            var httpClient = SetupHttpApiExchangeRate(expectedModel, HttpStatusCode.OK);

            ExchangeRates exchangeRates = new ExchangeRates(httpClient);

            var result = exchangeRates.GetApiLayerRatesAsync().Result;

            Assert.AreEqual(expectedModel.Success,result.Success);
            Assert.AreEqual(expectedModel.Terms, result.Terms);
            Assert.AreEqual(expectedModel.Privacy, result.Privacy);
            Assert.AreEqual(expectedModel.TimeStamp, result.TimeStamp);
            Assert.AreEqual(expectedModel.Source, result.Source);
            Assert.AreEqual(expectedModel.Quotes["Test_Key1"], result.Quotes["Test_Key1"]);
            Assert.AreEqual(expectedModel.Quotes["Test_Key2"], result.Quotes["Test_Key2"]);
        }
        [TestMethod]
        public void GivenExchangeRates_When_GetOpenMarketRatesAsync_Is_Called_Then_The_ApiLayerModel_IsReturned()
        {
            //arrange
            var expectedModel = new OpenMarketModel()
            {
                Disclaimer = "Test_Disclaimer",
                TimeStamp = 123,
                Base = "Test_Base",
                Rates = new Dictionary<string, decimal>()
                {
                    {"Test_Key1",  1_000.5m},
                    { "Test_Key2", 2_000.5m }
                }
            };
            var httpClient = SetupHttpMarketExchangeRate(expectedModel, HttpStatusCode.OK);

            ExchangeRates exchangeRates = new ExchangeRates(httpClient);

            var result = exchangeRates.GetOpenMarketRatesAsync().Result;

            Assert.AreEqual(expectedModel.Disclaimer, result.Disclaimer);
            Assert.AreEqual(expectedModel.TimeStamp, result.TimeStamp);
            Assert.AreEqual(expectedModel.Base, result.Base);
            Assert.AreEqual(expectedModel.Rates["Test_Key1"], result.Rates["Test_Key1"]);
            Assert.AreEqual(expectedModel.Rates["Test_Key2"], result.Rates["Test_Key2"]);
        }

        private HttpClient SetupHttpApiExchangeRate(ApiLayerModel expectedModel, HttpStatusCode httpStatusCode)
        {
            var json = JsonConvert.SerializeObject(expectedModel);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = httpStatusCode;
            httpResponse.Content = new StringContent(json);

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);
            HttpClient httpClient = new HttpClient(mockHandler.Object);
            return httpClient;
        }

        private HttpClient SetupHttpMarketExchangeRate(OpenMarketModel expectedModel, HttpStatusCode httpStatusCode)
        {
            var json = JsonConvert.SerializeObject(expectedModel);
            HttpResponseMessage httpResponse = new HttpResponseMessage();
            httpResponse.StatusCode = httpStatusCode;
            httpResponse.Content = new StringContent(json);

            Mock<HttpMessageHandler> mockHandler = new Mock<HttpMessageHandler>();
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync",
                    ItExpr.Is<HttpRequestMessage>(r => r.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);
            HttpClient httpClient = new HttpClient(mockHandler.Object);
            return httpClient;
        }

    }
}
