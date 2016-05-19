using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks
{
    class GBCE
    {

        public List<Stock> Stocks;


        public GBCE()
        {

            Stocks = new List<Stock>();
            Stocks.Add(new Stock("TEA", 0, 100));
            Stocks.Add(new Stock("POP", 8, 100));
            Stocks.Add(new Stock("ALE", 23, 60));
            Stocks.Add(new StockPreferred("GIN", 8, 2, 100));
            Stocks.Add(new Stock("JOE", 13, 250));

        }


        public decimal CalculateDividendYield(string stockSymbol)
        {
            return Stocks.Where(stock => stock.Symbol == stockSymbol).First().CalculateDividendYield();
        }

        
        public decimal CalculatePERatio(string stockSymbol)
        {
            return Stocks.Where(stock => stock.Symbol == stockSymbol).First().CalulatePERatio();
        }


        public decimal CalculateStockPrice(string stockSymbol)
        {
            return Stocks.Where(stock => stock.Symbol == stockSymbol).First().CalculateStockPrice();
        }

        public void RecordTrade(string stockSymbol, DateTime tradeDate, TransactionType tradeType, int quantity, decimal price)
        {
            Stocks.Where(stock => stock.Symbol == stockSymbol).First().RecordTrade(tradeDate, tradeType, quantity, price);
        }


        public double CalculateGeometricMean()
        {

            double product = 1;
            int count = 0;
            double geometricMean;

            foreach (Stock stock in Stocks)
            {

                try
                {
                    product *= (double)stock.CalculateStockPrice();
                    count += 1;
                }
                catch (ApplicationException e)
                {
                    if (e.Message != "No trades in last 15 mins") // if no trades on a particular stock then just ignore this stock when calculating the geometric mean
                    {
                        throw e;
                    }

                }
            }

            geometricMean = Math.Pow(product, 1.0/ count);

            return geometricMean;
        }


    }

   
}
