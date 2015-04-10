using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;


namespace Neural
{
    public class NeuralDataSet
    {
        public Dictionary<string, Matrix> Data { get; set; }

        public NeuralDataSetDefinition Definition { get; set; }


        public string Name
        {
            get { return Definition.TickerList; }
        }

        public NeuralDataSet(NeuralDataSetDefinition aDefinition)
        {
            Definition = aDefinition;
        }


    }
}
