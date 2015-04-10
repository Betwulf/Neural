using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
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

    }
}
