SuperSimpleStocks application for JP Morgan
Written by Martin Reid, 19th May 2016

The class GBCE is the main class delivering the requirements.

To use, create an instance of this class. The requirements are made available through the following functions on this class:

CalculateDividendYield(string stockSymbol)
CalculatePERatio(string stockSymbol)
CalculateStockPrice(string stockSymbol)
RecordTrade(string stockSymbol, DateTime tradeDate, TransactionType tradeType, int quantity, decimal price)
CalculateGeometricMean()

Program.cs is a console application to demonstrate and test the functionality of the system. This carries out the following:

1. Use the RecordTrade to record 100 random trades against the 5 sample stocks.
2. Cycle through the stocks showing the Yield, P/E ratio and Stock Price. Some additional stats are shown to allow verification of these calculations.
3. Finally the Geometric mean of stock prices for the GBCE All Share index is calculated and displayed.

Assumptions:

1. I have assumed for purpose of calculating the Dividend Yield and P/E Ratio that Ticker Price is defined as the Stock Price calculation.



