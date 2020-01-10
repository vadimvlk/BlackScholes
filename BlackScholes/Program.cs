using System;
using System.Threading;

namespace BlackScholes
{
    class Program
    {
        public static void Main(string[] args)
        {
        A:
            Console.WriteLine("Input current Price: ");
            double currentPrice = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input Strike: ");
            double strike = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input day for expiry: ");
            double dayForExpiry = Convert.ToDouble(Console.ReadLine());
            int totalYearDays = 365;
            Console.WriteLine("Input IV: ");
            double impliedVolatility = Convert.ToDouble(Console.ReadLine());


            BlackScholesCalculate blackShould = new BlackScholesCalculate();


            Console.WriteLine("Премия Call : " + (blackShould.OptionPrice('C', currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility)) / currentPrice);
            Console.WriteLine("Премия Put : " + (blackShould.OptionPrice('P', currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility)) / currentPrice);
            Console.WriteLine("Delta Call : " + blackShould.Delta('C', currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility));
            Console.WriteLine("Delta Put" + blackShould.Delta('P', currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility));
            Console.WriteLine("Gamma  : " + blackShould.Gamma(currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility));
            Console.WriteLine("Vega :" + blackShould.Vega(currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility));
            Console.WriteLine("Theta :" + blackShould.Theta(currentPrice, strike, dayForExpiry, totalYearDays, impliedVolatility));

            Thread.Sleep(10000);
        }
    }
}
