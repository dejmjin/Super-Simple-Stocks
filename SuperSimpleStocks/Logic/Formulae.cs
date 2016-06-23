using SuperSimpleStocks.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperSimpleStocks.Logic
{
    public class Formulae
    {
        #region private methods
        /// <summary>
        /// Get trades from last 15minutes
        /// </summary>
        /// <param name="trades"></param>
        /// <returns>returns list of trades</returns>
        private static List<Trade> GetTradesFromLastFifteenMinutes(List<Trade> trades)
        {
            return trades.Where(x => x.Timestamp > DateTime.Now.AddMinutes(-15)).ToList();
        }

        /// <summary>
        /// Calculate dividend from last divident
        /// </summary>
        /// <param name="lastDividend"></param>
        /// <returns>returns the last dividend</returns>
        private static double CalculateDividendFromLastDividend(double lastDividend)
        {
            return lastDividend;
        }

        /// <summary>
        /// Calculate dividend from fixed dividend
        /// </summary>
        /// <param name="fixedDividend"></param>
        /// <param name="parValue"></param>
        /// <returns>returns fixedDividend multiplied by parValue</returns>
        private static double CalculateDividendFromFixedDividend(double fixedDividend, double parValue)
        {
            return fixedDividend * parValue;
        }

        /// <summary>
        /// Calculate dividend
        /// </summary>
        /// <param name="stock"></param>
        /// <returns>returns a different formula for a PREFERRED and COMMON stock types</returns>
        private static double CalculateDividend(Stock stock)
        {
            double dividend;
            if (stock.Type == Stock.StockType.PREFERRED)
            {
                dividend = CalculateDividendFromFixedDividend(stock.FixedDividend, stock.ParValue);
            }
            else
            {
                dividend = CalculateDividendFromLastDividend(stock.LastDividend);
            }
            return dividend;
        }

        /// <summary>
        /// Calculate dividend yield from dividend and market price
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="marketPrice"></param>
        /// <returns>returns the dividend yield from dividend and market price </returns>
        private static double CalculateDividendYieldFromDividend(double dividend, double marketPrice)
        {
            return dividend / marketPrice;
        }

        /// <summary>
        /// Calculate P/E ratio by market price and dividend
        /// </summary>
        /// <param name="marketPrice"></param>
        /// <param name="dividend"></param>
        /// <returns>returns P/E ratio by market price and dividend</returns>
        private static double CalculatePERatio(double marketPrice, double dividend)
        {
            return marketPrice / dividend;
        }

        /// <summary>
        /// Calculate geometric mean of prices
        /// </summary>
        /// <param name="prices"></param>
        /// <returns>returns geometric mean of prices</returns>
        private static double CalculateGeometricMean(double[] prices)
        {
            double productOfPrices = 1;
            foreach (double price in prices)
            {
                productOfPrices *= price;
            }

            //There might be a third party library which can create the following code in a better/safer way.
            //Here I'm assuming the prices are always a positive number
            double nRootPower = 1.0 / prices.Length;
            return Math.Pow(productOfPrices, nRootPower);
        }

        #endregion

        /// <summary>
        /// Calculate dividend yield
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="marketPrice"></param>
        /// <returns>returns the dividend yield from dividend and market price </returns>
        public static double CalculateDividendYield(Stock stock, double marketPrice)
        {
            return CalculateDividendYieldFromDividend(CalculateDividend(stock), marketPrice);
        }

        /// <summary>
        /// Calculate P/E ratio by stock object and market price
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="marketPrice"></param>
        /// <returns>returns P/E ratio by stock object and market price</returns>
        public static double CalculatePERatio(Stock stock, double marketPrice)
        {
            return CalculatePERatio(marketPrice, CalculateDividend(stock));
        }

        /// <summary>
        /// Calculate the stock price of trades in the last 15minutes
        /// </summary>
        /// <param name="trades"></param>
        /// <returns>returns the stock price of trades in the last 15minutes</returns>
        public static double CalculateStockPriceForTradesInLastFifteenMinutes(List<Trade> trades)
        {
            double allTradesValue = 0.0;
            double totalQuantity = 0.0;
            foreach (Trade trade in GetTradesFromLastFifteenMinutes(trades))
            {
                allTradesValue += (trade.Price * trade.Quantity);
                totalQuantity += trade.Quantity;
            }
            return allTradesValue / totalQuantity;
        }

        /// <summary>
        /// Calculate geometric mean of trades
        /// </summary>
        /// <param name="trades"></param>
        /// <returns>returns geometric mean of trades</returns>
        public static double CalculateGeometricMean(List<Trade> trades)
        {
            double[] prices = new double[trades.Count];
            int counter = 0;
            foreach (Trade trade in trades)
            {
                prices[counter] = trade.Price;
                counter++;
            }
            return CalculateGeometricMean(prices);
        }
    }
}
