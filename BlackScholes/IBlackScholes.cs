using System;
using System.Collections.Generic;
using System.Text;

namespace BlackScholes
{

    interface IBlackScholes
    {
        double D_1(double s, double x, double d, int y, double v);
        double D_2(double s, double x, double d, int y, double v);
        double Nd_1(double s, double x, double d, int y, double v);
        double Nd_2(double s, double x, double d, int y, double v);
        double N_d_1(double s, double x, double d, int y, double v);
        double N_d_2(double s, double x, double d, int y, double v);
        double N1d_1(double s, double x, double d, int y, double v);
        double OptionPrice(Char optionType, double s, double x, double d, int y, double v);
        double Delta(Char optionType, double s, double x, double d, int y, double v);
        double Theta(double s, double x, double d, int y, double v);
        double Gamma(double s, double x, double d, int y, double v);
        double Vega(double s, double x, double d, int y, double v);
        double NormSDist(double num);
    }

}
