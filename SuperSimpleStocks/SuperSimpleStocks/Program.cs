using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleStocks;

namespace SuperSimpleStocks
{
    class Program
    {
        static void Main(string[] args)
        {

            GBCE gbce = new GBCE(); // create new instance of the GBCE system.

            // requirement 1.a.iii - record a trade, with timestamp, quantity of shares, buy or sell indicator and price
            // Create some random trades to give some data to work with
            
            Random rnd = new Random();

            for (int i = 0; i < 100; i++)
            {

                int stock = rnd.Next(1, 6); // choose a random stock. Min value is inclusive, max is exclusive.
                int transaction = rnd.Next(1, 3); //random buy or sell
                int quantity = rnd.Next(1, 1001); // create random quantity between 1 and 1000
                int price = rnd.Next(50, 101); // create random price between 50 and 100

                string stockSymbol = "";

                switch (stock)
                {
                    case 1:
                        stockSymbol = "TEA";
                        break;
                    case 2:
                        stockSymbol = "POP";
                        break;
                    case 3:
                        stockSymbol = "ALE";
                        break;
                    case 4:
                        stockSymbol = "GIN";
                        break;
                    case 5:
                        stockSymbol = "JOE";
                        break;
                }
                
                TransactionType transactionType = (transaction == 1) ? TransactionType.Buy : TransactionType.Sell;

                gbce.RecordTrade(stockSymbol, DateTime.Now, transactionType, quantity, price);

            }



                foreach (Stock stock in gbce.Stocks)
                {
                    Console.WriteLine("***** " + stock.Symbol + " *****");

                    try
                    {
                        // not required but allows me to check everything working OK
                        Console.WriteLine("Trades: " + stock.Trades.Count().ToString());

                        // not required but allows me to check everything working OK
                        int quantity = 0;
                        stock.Trades.ForEach(t => quantity += t.Quantity);
                        Console.WriteLine("Quantity of shares Traded: " + quantity.ToString());

                        // not required but allows me to check everything working OK
                        decimal value = 0;
                        stock.Trades.ForEach(t => value += t.getTradeValue());
                        Console.WriteLine("Value of all trades: " + value.ToString("F2"));

                        Console.WriteLine("");

                        //requirement 1.a.i - Calculate the dividend yield
                        Console.WriteLine("Dividend Yield: " + stock.CalculateDividendYield().ToString("P2")); // show as percentage

                        //requirement 1.a.ii - Calculate the P/E Ratio
                        Console.WriteLine("P/E Ratio: " + stock.CalulatePERatio().ToString("F2"));

                        //requirement 1.a.iv - Calculate Stock Price based on trades recorded in past 15 minutes
                        Console.WriteLine("Stock Price: " + stock.CalculateStockPrice().ToString("F2"));

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    Console.WriteLine("");
                }


            Console.WriteLine("***** GBCE All Share Index *****");

            try
            {
                //requirement 1.b - Calculate the GBCE All Share Index using the geometric mean of prices for all stocks
                Console.WriteLine("Geometric Mean of Prices: " + gbce.CalculateGeometricMean().ToString("F2"));
            }            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
