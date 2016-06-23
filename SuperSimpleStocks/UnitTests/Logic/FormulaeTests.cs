using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperSimpleStocks.Logic;
using SuperSimpleStocks.Objects;
using System.Collections.Generic;

namespace SuperSimpleStocks.UnitTests.Services
{
    [TestClass]
    public class FormulaeTests
    {
        private const double outputResult = 0.001;

        [TestMethod]
        public void CalculateDividendYieldFromLastDividendReturnsCorrectDividendForCOMMONStock()
        {
            Stock stock = new Stock("TEA", Stock.StockType.COMMON, 0.08, 0.02, 1);
            Assert.AreEqual(0.8, Formulae.CalculateDividendYield(stock, 0.1), outputResult);
        }

        [TestMethod]
        public void CalculateDividendYieldFromLastDividendReturnsCorrectDividendForPREFERREDStock()
        {
            Stock stock = new Stock("TEA", Stock.StockType.PREFERRED, 0.08, 0.02, 1);
            Assert.AreEqual(0.2, Formulae.CalculateDividendYield(stock, 0.1), outputResult);
        }

        [TestMethod]
        public void CalculatePERationReturnsCorrectDividendYieldForCOMMONStock()
        {
            Stock stock = new Stock("TEA", Stock.StockType.COMMON, 0.08, 0.02, 1);
            Assert.AreEqual(1.25, Formulae.CalculatePERatio(stock, 0.1), outputResult);
        }

        [TestMethod]
        public void CalculatePERationReturnsCorrectDividendYieldForPREFERREDStock()
        {
            Stock stock = new Stock("TEA", Stock.StockType.PREFERRED, 0.08, 0.02, 1);
            Assert.AreEqual(5.0, Formulae.CalculatePERatio(stock, 0.1), outputResult);
        }

        [TestMethod]
        public void CalculateGeometricMeanReturnsCorrectResult()
        {
            Stock stock = new Stock("TEA", Stock.StockType.COMMON, 0.0, 0.0, 1.0);

            List<Trade> trades = new List<Trade>();
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.10, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.09, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.08, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.09, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.1, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.11, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.12, 10));

            Assert.AreEqual(0.097, Formulae.CalculateGeometricMean(trades), outputResult);
        }

        [TestMethod]
        public void CalculateStockPriceForTradesInLastFifteenMinutesReturnsCorrectResult()
        {
            Stock stock = new Stock("TEA", Stock.StockType.COMMON, 0.0, 0.0, 1.0);

            List<Trade> trades = new List<Trade>();
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.10, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.09, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.08, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.09, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.1, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.11, 10));
            trades.Add(new Trade(stock, Trade.TradeAction.BUY, 0.12, 10));

            Assert.AreEqual(0.0985, Formulae.CalculateStockPriceForTradesInLastFifteenMinutes(trades), outputResult);
        }
    }
}
