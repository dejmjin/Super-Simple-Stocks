namespace SuperSimpleStocks.Objects
{
    public class Stock
    {
        public enum StockType { COMMON, PREFERRED };

        public string Symbol;
        public StockType Type;
        public double LastDividend;
        public double FixedDividend;
        public double ParValue;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="type"></param>
        /// <param name="lastDividend"></param>
        /// <param name="fixedDividend"></param>
        /// <param name="parValue"></param>
        public Stock(string symbol, StockType stockType, double lastDividend, double fixedDividend, double parValue)
        {
            this.Symbol = symbol;
            this.Type = stockType;
            this.LastDividend = lastDividend;
            this.FixedDividend = fixedDividend;
            this.ParValue = parValue;
        }
    }
}
