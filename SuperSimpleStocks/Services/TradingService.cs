using SuperSimpleStocks.Objects;

namespace SuperSimpleStocks.Services
{
    public class TradingService
    {
        /// <summary>
        /// a new trade to buy stock
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns>returns a new Trade object for a buy trade </returns>
        public Trade BuyStock(Stock stock, double price, int quantity)
        {
            return new Trade(stock, Trade.TradeAction.BUY, price, quantity);
        }

        /// <summary>
        /// a new trade to sell stock
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <returns>returns a new Trade object for a sell trade</returns>
        public Trade SellStock(Stock stock, double price, int quantity)
        {
            return new Trade(stock, Trade.TradeAction.SELL, price, quantity);
        }
    }
}
