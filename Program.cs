using Encog.Engine.Network.Activation;
using Encog.ML.Data.Basic;
using Encog.Neural.Networks;
using Encog.Neural.Networks.Layers;
using Encog.Neural.Networks.Training.Lma;
using Encog.Neural.Networks.Training.Propagation.Back;
using Encog.Neural.Networks.Training.Propagation.Manhattan;
using Encog.Neural.Networks.Training.Propagation.Resilient;
using Encog.Persist;
using Encog.Util.Arrayutil;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural
{
    class Program
    {
        static void Main(string[] args)
        {

            var def = new NeuralDataSetDefinition();
            def.DateList.Add(DateTime.Parse("1/2/2015"));
            def.TickerList = "Technology";
            var test = new NeuralDataSetProcessor();
            var x = test.Process(def);

            Console.ReadKey();
        }


        static void OldMain(string[] args)
        {
            double[][] xorInput = 
            {
                new[] {0d,0d},
                new[] {0d,1d},
                new[] {1d,0d},
                new[] {1d,1d},
            };

            double[][] xorIdeal = 
            {
                new[] {0d},
                new[] {1d},
                new[] {1d},
                new[] {0d},

            };

            NormalizedField f = new NormalizedField(NormalizationAction.Normalize, "Test", 100d, 0d, 1d, 0d);
            var x = f.Normalize(500);

            var trainingData = new BasicMLDataSet(xorInput, xorIdeal);

            BasicNetwork network = CreateNetwork();

            //var trainer = new ResilientPropagation(network, trainingData);
            //var trainer = new ManhattanPropagation(network, trainingData, 0.005);
            //var trainer = new Backpropagation(network, trainingData, 0.7, 0.2);
            var trainer = new LevenbergMarquardtTraining(network, trainingData);

            for (int iteration = 0; iteration < 100000; iteration++)
            {
                trainer.Iteration();
                Console.WriteLine("iteration {0} - Error: {1}", iteration, trainer.Error);
                if (trainer.Error < .005) break;

            }

            foreach (var item in trainingData)
            {
                var output = network.Compute(item.Input);
                Console.WriteLine("Input: {0},{1} - Out [{2}] vs Actual [{3}]", item.Input[0], item.Input[1], item.Ideal[0], output[0]);
            }

            Console.ReadKey();
        }



        private static BasicNetwork CreateNetwork()
        {
            var network = new BasicNetwork();
            network.AddLayer(new BasicLayer(null, true, 2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 3));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), true, 2));
            network.AddLayer(new BasicLayer(new ActivationSigmoid(), false, 1));
            network.Structure.FinalizeStructure();
            network.Reset();
            EncogDirectoryPersistence.SaveObject(new FileInfo("neuralnetworkdefinition.txt"), network);
            return network;
            throw new NotImplementedException();
        }



    }
}
