using System;
using System.Collections.Generic;
using System.Text;

namespace BlackScholes
{

    interface IBlackScholes
    {
        double d_1(double S, double X, double d, int y, double v);
        double d_2(double S, double X, double d, int y, double v);
        double Nd_1(double S, double X, double d, int y, double v);
        double Nd_2(double S, double X, double d, int y, double v);
        double N_d_1(double S, double X, double d, int y, double v);
        double N_d_2(double S, double X, double d, int y, double v);
        double N1d_1(double S, double X, double d, int y, double v);
        double OptionPrice(Char optionType, double S, double X, double d, int y, double v);
        double Delta(Char optionType, double S, double X, double d, int y, double v);
        double Theta(double S, double X, double d, int y, double v);
        double Gamma(double S, double X, double d, int y, double v);
        double Vega(double S, double X, double d, int y, double v);
        double NormSDist(double num);
    }

}
