using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Neural
{
    public class NeuralDataSetProcessor
    {
        public string Name { get { return "Default"; } }

        public Task<NeuralDataSet> Process(NeuralDataSetDefinition aDefinition)
        {

            return new Task<NeuralDataSet>(() =>
            {
                var appSettings = ConfigurationManager.AppSettings;
                int lPort = Int32.Parse(appSettings["CouchDbPort"]);
                var db = new CouchDBConnection(
                    appSettings["CouchDbHost"], 
                    lPort, 
                    appSettings["CouchDbTickerListDatabase"], 
                    appSettings["CouchDbUsername"], 
                    appSettings["CouchDbPassword"]);
                var x = db.Get(aDefinition.TickerList);
                Console.WriteLine(x.ToString());
                return new NeuralDataSet(aDefinition);
            }
            );
            
        }

    }
}
