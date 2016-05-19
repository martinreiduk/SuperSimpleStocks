using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    class StockPreferred : Stock
    {

        public decimal FixedDividend { get; set; }


        public StockPreferred(string symbol, decimal lastDividend, decimal fixedDividend, decimal parValue) : base(symbol,lastDividend,parValue)
        {
              FixedDividend = fixedDividend;
        }

        public override decimal CalculateDividendYield()
        {
            decimal dividendYield;
            //divide fixed dividend by 100 as it is quoted as a percentage
            dividendYield = ((FixedDividend/100) * ParValue)  / CalculateStockPrice();
            return dividendYield;

        }

    }
}
