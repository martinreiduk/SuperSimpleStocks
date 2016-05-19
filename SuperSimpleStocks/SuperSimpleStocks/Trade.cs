using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{

    public enum TransactionType
    {
        Buy,
        Sell
    }


    class Trade
    {

        public DateTime TradeDate { get; set; }
        public TransactionType TradeType { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Trade(DateTime tradeDate, TransactionType tradeType, int quantity, decimal price)
        {
            TradeDate = tradeDate;
            TradeType = tradeType;
            Quantity = quantity;
            Price = price;
        }

        public Decimal getTradeValue()
        {
            return Quantity * Price;
        }

    
    }


}
