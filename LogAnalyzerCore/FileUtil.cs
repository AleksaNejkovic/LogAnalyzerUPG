using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerLogic
{
    public class FileUtil : IFileUtil
    {
        public List<string> GetAllLinesFromLogFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentNullException(nameof(filePath), $"Parameter cannot be empty or null.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found on the specified path - {filePath}");

            return new List<string>(File.ReadAllLines(filePath));
        }
}
}
