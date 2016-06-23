using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SuperSimpleStocks.UnitTests.Services
{
    [TestClass]
    public class TradingServicesTests
    {
        private Objects.Stock newStock
        {
            get
            {
                return new Objects.Stock("TEA", Objects.Stock.StockType.COMMON, 0, 0, 100);
            }
        }

        /// <summary>
        /// checks if the BuyStock method returns a null item
        /// </summary>
        [TestMethod]
        public void BuyStockReturnsANonNullObject()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.BuyStock(newStock, 10, 2);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// checks if the BuyStock method returns a BUY trade action
        /// </summary>
        [TestMethod]
        public void BuyStockReturnsAnObjectWithCorrectTradeAction()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.BuyStock(newStock, 10, 2);

            Assert.AreEqual(result.Action, Objects.Trade.TradeAction.BUY);
        }

        /// <summary>
        /// checks the timestamp of the returned object
        /// </summary>
        [TestMethod]
        public void BuyStockReturnsAnObjectWithCorrectTimestamp()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.BuyStock(newStock, 10, 2);

            Assert.IsTrue(result.Timestamp > DateTime.Now.AddMinutes(-15));
        }

        /// <summary>
        /// checks the details of output object are the same as the input ones
        /// </summary>
        [TestMethod]
        public void BuyStockReturnsAnObjectWithCorrectInputDetails()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.BuyStock(newStock, 10, 2);

            Assert.AreEqual(result.Price, 10);
            Assert.AreEqual(result.Quantity, 2);
            Assert.AreEqual(result.Stock, newStock);
        }

        /// <summary>
        /// checks if the SellStock method returns a null item
        /// </summary>
        [TestMethod]
        public void SellStockReturnsANonNullObject()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.SellStock(newStock, 10, 2);

            Assert.IsNotNull(result);
        }

        /// <summary>
        /// checks if the SellStock method returns a SELL trade action
        /// </summary>
        [TestMethod]
        public void SellStockReturnsAnObjectWithCorrectTradeAction()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.SellStock(newStock, 10, 2);

            Assert.AreEqual(result.Action, Objects.Trade.TradeAction.SELL);
        }

        /// <summary>
        /// checks the timestamp of the returned object
        /// </summary>
        [TestMethod]
        public void SellStockReturnsAnObjectWithCorrectTimestamp()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.SellStock(newStock, 10, 2);

            Assert.IsTrue(result.Timestamp > DateTime.Now.AddMinutes(-15));
        }

        /// <summary>
        /// checks the details of output object are the same as the input ones
        /// </summary>
        [TestMethod]
        public void SellStockReturnsAnObjectWithCorrectInputDetails()
        {
            var tradingService = new SuperSimpleStocks.Services.TradingService();

            var result = tradingService.SellStock(newStock, 10, 2);

            Assert.AreEqual(result.Price, 10);
            Assert.AreEqual(result.Quantity, 2);
            Assert.AreEqual(result.Stock, newStock);
        }
    }
}
