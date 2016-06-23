using System;

namespace SuperSimpleStocks.Objects
{
    public class Trade
    {
        public enum TradeAction
        {
            BUY, SELL
        }

        public Stock Stock;
        public TradeAction Action;
        public double Price;
        public int Quantity;
        public DateTime Timestamp;

        /// <summary>
        /// Constructor. 
        /// Timestamp taken automatically from DateTime.Now
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="indicator"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public Trade(Stock stock, TradeAction tradeAction, double price, int quantity)
        {
            this.Stock = stock;
            this.Action = tradeAction;
            this.Price = price;
            this.Quantity = quantity;
            this.Timestamp = DateTime.Now;
        }
    }
}
