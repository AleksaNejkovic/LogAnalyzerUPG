using LogAnalyzerClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerLogic
{
    public interface IDisplayUtil
    {
        /// <summary>
        /// This method displays the result of the parsed log.
        /// </summary>
        /// <param name="dict"></param>
        public void PrintParsingResult(Dictionary<string, int> dict);

    }
}
