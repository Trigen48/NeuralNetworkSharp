using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neural
{
    static partial class Program
    {

        static double sigmoid(double x)
        {

            return 1d / (1d + Math.Exp(-x));
        }

        static double sigmoidPrime(double x)
        {
            double sig = sigmoid(x);

            return sig * (1 - sig);
        }

        static double tanh(double x)
        {
            return (2d / (1 + Math.Exp(-(2 * x)))) - 1;
        }

        static double relu(double x)
        {
            return Math.Max(0, x);
        }
    }
}
