using LogAnalyzerClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerLogic
{
    public class DisplayUtil : IDisplayUtil
    {

        public void PrintParsingResult(Dictionary<string, int> dict)
        {
            foreach (var ip in dict.Keys)
            {
                Console.WriteLine($"{Common.GetHostNameForIp(ip)} ({ip}) - {dict[ip]}");
            }
        }
    }
}
