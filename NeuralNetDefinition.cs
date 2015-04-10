using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural
{
    public class NeuralNetDefinition
    {
        public string StrategyName { get; set; }

        public int Attempts { get; set; }

        public int Iterations { get; set; }

        public double LearningRate { get; set; }

        public double ErrorThreshold { get; set; }

        public NeuralDataSetDefinition DataSetDefinition { get; set; }


        public bool IsValid()
        {
            if (DataSetDefinition == null) return false;
            if (Attempts <= 0) return false;
            if (Iterations <= 0) return false;
            if (LearningRate > 1 || LearningRate < 0) return false;
            if (ErrorThreshold < 0.001 || ErrorThreshold >= 1) return false;
            return true;
        }
    }
}
