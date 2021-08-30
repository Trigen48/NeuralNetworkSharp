using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neural
{
    static partial class Program
    {


        static double cost_error(double output, double target = 4)
        {
             //return Math.Pow((IncorrectValue - ExpectedValue), 2);
            //return Math.Pow((target - output), 2);
            return 0.5* Math.Pow((target -output  ), 2);
        }

        static double num_slope(double b, double h = 0.0001)
        {
            //double slo=
            return (cost_error(b + h) - cost_error(b)) / h;
        }

        static double slope(double b, double target = 4)
        {
            return 2 * (b - target);
        }

    }
}
