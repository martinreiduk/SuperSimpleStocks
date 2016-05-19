using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    class Stock
    {

        public string Symbol { get; set; }
        public decimal LastDividend { get; set; }
        public decimal ParValue { get; set; }

        public List<Trade> Trades { get; set; }

        public Stock(string symbol, decimal lastDividend, decimal parValue)
        {
            Symbol = symbol;
            LastDividend = lastDividend;
            ParValue = parValue;

            Trades = new List<Trade>();
        }

        public virtual decimal CalculateDividendYield()
        {
            decimal dividendYield;
            dividendYield = LastDividend / CalculateStockPrice();            
            return dividendYield;
        }

        public decimal CalulatePERatio()
        {

            decimal peRatio;
            peRatio = (LastDividend == 0) ? 0 : CalculateStockPrice() / LastDividend;
            return peRatio;
        }

        public decimal CalculateStockPrice()
        {
            DateTime last15mins;
            last15mins = DateTime.Now.AddMinutes(-15);

            decimal totalValue = 0;
            decimal totalQuantity = 0;

            var recentTrades = Trades.Where(trade => trade.TradeDate >= last15mins);

            if (recentTrades.Count() == 0)
            {
                throw new ApplicationException("No trades in last 15 mins");
            }

            foreach (var trade in recentTrades)
            {
                totalValue += trade.getTradeValue();
                totalQuantity += trade.Quantity;
            }


            return totalValue / totalQuantity;

        }

        public void RecordTrade(DateTime tradeDate, TransactionType tradeType, int quantity, decimal price)
        {
            Trades.Add(new Trade(tradeDate, tradeType, quantity, price));
        }
    
    
    } 
}
