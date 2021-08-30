using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neural
{

    public delegate double Activator(double x);

    public struct Perceptron
    {
        public double value;
        public double[] weights;
        public double bias;
        public Activator activator;

       // private int count;

        public void Activate(Perceptron[] layers)
        {

            if (weights.Length != 0)
            {

                if (weights.Length != layers.Length)
                    throw new Exception("Layers do not match weights");

                double total = 0;

                for (int i = 0; i < weights.Length; i++)
                {
                    total += weights[i] * layers[i].value;
                }

                total += bias * 1;

                if (activator != null)
                {
                    total = activator(total);
                }
                value = total;
            }
        }
        /*
        public Perceptron(int WeightCount = 0, Activator activator = null, double value = 0, double bias = 0)
        {
            this.value = value;
            this.activator = activator; Random r = new Random();

            if (WeightCount <= 0)
            {
             //   count = 0;
                weights = new double[0];
            }
            else
            {
               // count = WeightCount;
                weights = new double[WeightCount];



                for (int i = 0; i < count; i++)
                    weights[i] = r.NextDouble();
            }

            if (bias != 0)
                this.bias = bias;
            else
                this.bias = r.NextDouble();
        }

        */
    }

}
