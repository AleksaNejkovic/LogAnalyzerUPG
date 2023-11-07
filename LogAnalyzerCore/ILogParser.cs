using LogAnalyzerClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerLogic
{
    public interface ILogParser
    {
        /// <summary>
        /// This method parses the log file line by line and creates a dictionary with IP addresses as keys and the number of hits as values.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>Dictionary<string, int></returns>
        public Dictionary<string, int> ParseLogFile(string filePath);


    }
}
