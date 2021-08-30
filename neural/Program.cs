using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace neural
{


    static partial class Program
    {

        //static Perceptron[][] layers;

        static Perceptron[] DoAi(Perceptron[][] layers, double[] values)
        {

            if (layers == null || layers.Length < 2)
                throw new Exception("Number of layers have to be 2 or more, (input, output layer)");

            if (layers[0].Length != values.Length)
                throw new Exception("Values must match the input layer length");


            for (int i = 0; i < values.Length; i++)
            {
                layers[0][i].value = values[i];
            }


            int lastLayer = layers.Length - 1;


            for (int i = 0; i < lastLayer; i++)
            {
                int nl = i + 1;
                int len1 = layers[nl].Length;

                for (int j = 0; j < len1; j++)
                {
                    layers[nl][j].Activate(layers[i]);

                }

            }


            return layers[lastLayer]; // return the output layer data
        }

        static Perceptron[][] TrainAi(Perceptron[][] layers, double[][] trainingValues, double[][] outputs)
        {

            if (trainingValues == null)
            {
                throw new Exception("Training data cannot be null");
            }

            int trainlen = trainingValues.Length;
            int last = layers.Length - 1;
            int outlen = layers[last].Length;

            for (int x = 0; x < trainlen; x++)
            {

                double[] tValue = trainingValues[x];
                double[] tOut = outputs[x];

                Perceptron[] Ouput = DoAi(layers, tValue);

                double error = 0;
                double incorrect = 0;

                for (int e = 0; e < outlen; e++)
                {

                    if (tOut[e] != Ouput[e].value)
                    {
                        error += cost_error(Ouput[e].value, tOut[e]);
                        incorrect++;
                    }

                }

            }

            return null;
        }


        static void Main(string[] args)
        {

            /*
             
                Perceptron[][] layers;

                layers = new Perceptron[2][];

                layers[0] = new Perceptron[] { new Perceptron(0, null), new Perceptron(0, null) };
                layers[1] = new Perceptron[1] { new Perceptron(2, sigmoid) };

            */

            Perceptron[][] layers;

            layers = new Perceptron[3][];

            layers[0] = new Perceptron[] 
            { 
                new Perceptron(), 
                new Perceptron()
            };

            layers[1] = new Perceptron[] 
            { 
                new Perceptron() { weights = new double[]{0.15,0.20 }, bias= 0.35, activator=sigmoid }, 
                new Perceptron() { weights = new double[]{0.25,0.30 }, bias= 0.35, activator=sigmoid  }
            };

            layers[2] = new Perceptron[] 
            {
                new Perceptron() { weights = new double[]{0.40,0.45} , bias= 0.60, activator=sigmoid },
                new Perceptron() { weights = new double[]{0.50,0.55} , bias= 0.60, activator=sigmoid }
            };
            //Perceptron p = new Perceptron(2, sigmoid);


            //p.activator = sigmoid;

            TrainAi(layers,
                new double[][] { new double[] { 0.05, 0.10 } },
                new double[][] { new double[] { 0.01, 0.99 } });

            Perceptron[] Ouput = DoAi(layers, new double[] { 0.05, 0.10 });

            Console.WriteLine(slope(3));
            Console.ReadLine();
        }



    }
}
