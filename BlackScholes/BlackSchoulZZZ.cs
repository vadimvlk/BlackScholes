using System;
using System.Collections.Generic;
using System.Text;

namespace BlackScholes
{
    public class BlackSchoulZZZ : IBlackScholes
    {
        public double d_1(double S, double X, double d, int y, double v)
        {
            double t = d / y;
            return (Math.Log(S / X) + (0.5 * (Math.Pow(v, 2))) * t) / (v * Math.Pow(t, 0.5));
        }

        public double d_2(double S, double X, double d, int y, double v)
        {
            double t = d / y;
            return d_1(S, X, d, y, v) - v * Math.Pow(t, 0.5);
        }

        public double Nd_1(double S, double X, double d, int y, double v)
        {
            return NormSDist(d_1(S, X, d, y, v));
        }

        public double Nd_2(double S, double X, double d, int y, double v)
        {
            return NormSDist(d_2(S, X, d, y, v));
        }

        public double N_d_1(double S, double X, double d, int y, double v)
        {
            return NormSDist(-d_1(S, X, d, y, v));
        }

        public double N_d_2(double S, double X, double d, int y, double v)
        {
            return NormSDist(-d_2(S, X, d, y, v));
        }

        public double N1d_1(double S, double X, double d, int y, double v)
        {
            const double PI = 3.14159265358979;
            double t = d / y;
            return 1 / Math.Pow((2 * PI), 0.5) * Math.Exp(-0.5 * Math.Pow(d_1(S, X, d, y, v), 2));
        }
        public double OptionPrice(char optionType, double S, double X, double d, int y, double v)
        {
            switch (optionType)
            {
                case 'C':
                    {
                        return S * Nd_1(S, X, d, y, v) - X * Nd_2(S, X, d, y, v);
                    }
                case 'P':
                    {
                        return X * N_d_2(S, X, d, y, v) - S * N_d_1(S, X, d, y, v);
                    }
                default:
                    Console.WriteLine("Option type not valid!");
                    return 0;
            }
        }

        public double Delta(char optionType, double S, double X, double d, int y, double v)
        {
            switch (optionType)
            {
                case 'C':
                    {
                        return NormSDist(d_1(S, X, d, y, v));
                    }
                case 'P':
                    {
                        return NormSDist(d_1(S, X, d, y, v)) - 1;
                    }
                default:
                    Console.WriteLine("Option type not valid!");
                    return 0;
            }
        }

        public double Theta(double S, double X, double d, int y, double v)
        {
            double t = d / y;
            return -((S * v * N1d_1(S, X, d, y, v)) / (2 * Math.Pow(t, 0.5))) / y;
        }

        public double Gamma(double S, double X, double d, int y, double v)
        {
            double t = d / y;
            return N1d_1(S, X, d, y, v) / (S * (v * Math.Pow(t, 0.5)));
        }

        public double Vega(double S, double X, double d, int y, double v)
        {
            double t = d / y;
            return (S * Math.Pow(t, 0.5) * N1d_1(S, X, d, y, v)) / 100;
        }
        public double NormSDist(double z)
        {
            double sign = 1;
            if (z < 0) sign = -1;
            return 0.5 * (1.0 + sign * erf(Math.Abs(z) / Math.Sqrt(2)));
        }
        private static double erf(double x)
        {
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;
            double p = 0.3275911;
            x = Math.Abs(x);
            double t = 1 / (1 + p * x);
            return 1 - ((((((a5 * t + a4) * t) + a3) * t + a2) * t) + a1) * t * Math.Exp(-1 * x * x);
        }
    }
}
