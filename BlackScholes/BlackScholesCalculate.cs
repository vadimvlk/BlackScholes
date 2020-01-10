using System;
using System.Collections.Generic;
using System.Text;

namespace BlackScholes
{
    public class BlackScholesCalculate : IBlackScholes
    {
        public double D_1(double s, double x, double d, int y, double v)
        {
            double t = d / y;
            return (Math.Log(s / x) + (0.5 * (Math.Pow(v, 2))) * t) / (v * Math.Pow(t, 0.5));
        }

        public double D_2(double s, double x, double d, int y, double v)
        {
            double t = d / y;
            return D_1(s, x, d, y, v) - v * Math.Pow(t, 0.5);
        }

        public double Nd_1(double s, double x, double d, int y, double v)
        {
            return NormSDist(D_1(s, x, d, y, v));
        }

        public double Nd_2(double s, double x, double d, int y, double v)
        {
            return NormSDist(D_2(s, x, d, y, v));
        }

        public double N_d_1(double s, double x, double d, int y, double v)
        {
            return NormSDist(-D_1(s, x, d, y, v));
        }

        public double N_d_2(double s, double x, double d, int y, double v)
        {
            return NormSDist(-D_2(s, x, d, y, v));
        }

        public double N1d_1(double s, double x, double d, int y, double v)
        {
            const double PI = 3.14159265358979;
            double t = d / y;
            return 1 / Math.Pow((2 * PI), 0.5) * Math.Exp(-0.5 * Math.Pow(D_1(s, x, d, y, v), 2));
        }
        public double OptionPrice(char optionType, double s, double x, double d, int y, double v)
        {
            switch (optionType)
            {
                case 'C':
                    {
                        return s * Nd_1(s, x, d, y, v) - x * Nd_2(s, x, d, y, v);
                    }
                case 'P':
                    {
                        return x * N_d_2(s, x, d, y, v) - s * N_d_1(s, x, d, y, v);
                    }
                default:
                    Console.WriteLine("Option type not valid!");
                    return 0;
            }
        }

        public double Delta(char optionType, double s, double x, double d, int y, double v)
        {
            switch (optionType)
            {
                case 'C':
                    {
                        return NormSDist(D_1(s, x, d, y, v));
                    }
                case 'P':
                    {
                        return NormSDist(D_1(s, x, d, y, v)) - 1;
                    }
                default:
                    Console.WriteLine("Option type not valid!");
                    return 0;
            }
        }

        public double Theta(double s, double x, double d, int y, double v)
        {
            double t = d / y;
            return -((s * v * N1d_1(s, x, d, y, v)) / (2 * Math.Pow(t, 0.5))) / y;
        }

        public double Gamma(double s, double x, double d, int y, double v)
        {
            double t = d / y;
            return N1d_1(s, x, d, y, v) / (s * (v * Math.Pow(t, 0.5)));
        }

        public double Vega(double s, double x, double d, int y, double v)
        {
            double t = d / y;
            return (s * Math.Pow(t, 0.5) * N1d_1(s, x, d, y, v)) / 100;
        }
        public double NormSDist(double z)
        {
            double sign = 1;
            if (z < 0) sign = -1;
            return 0.5 * (1.0 + sign * Erf(Math.Abs(z) / Math.Sqrt(2)));
        }
        private static double Erf(double x)
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
