using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerLogic
{
    public interface IFileUtil
    {
        /// <summary>
        /// This method reads all lines from file path
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public List<string> GetAllLinesFromLogFile(string filePath);
        

    }
}
