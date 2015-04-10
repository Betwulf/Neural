using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural
{
    public class NeuralDataSetDefinition
    {
        public List<DateTime> DateList { get; set; }

        public string TickerList { get; set; }


        public NeuralDataSetDefinition()
        {
            DateList = new List<DateTime>();
        }
    }
}
