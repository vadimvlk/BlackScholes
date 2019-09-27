using System;

namespace BlackScholes
{
    class Program
    {
        class MainClass
        {

            public static void Main(string[] args)
            {
                A:
                Console.WriteLine("Input current Price: ");
                double S = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input Strike: ");
                double X = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input day for expiry: ");
                double d = Convert.ToDouble(Console.ReadLine());
                int y = 365;
                Console.WriteLine("Input IV: ");
                double v = Convert.ToDouble(Console.ReadLine());


                BlackSchoulZZZ blackShould = new BlackSchoulZZZ();


                Console.WriteLine("Премия Call : " + (blackShould.OptionPrice('C', S, X, d, y, v)) / S);
                Console.WriteLine("Премия Put : " + (blackShould.OptionPrice('P', S, X, d, y, v)) / S);
                Console.WriteLine("Delta Call : " + blackShould.Delta('C', S, X, d, y, v));
                Console.WriteLine("Delta Put" + blackShould.Delta('P', S, X, d, y, v));
                Console.WriteLine("Gamma  : " + blackShould.Gamma(S, X, d, y, v));
                Console.WriteLine("Vega :" + blackShould.Vega(S, X, d, y, v));
                Console.WriteLine("Theta :" + blackShould.Theta(S, X, d, y, v));


                Console.ReadLine();

                goto A;

            }
        }
    }
}
