using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LogAnalyzerClassLibrary;
using LogAnalyzerConstantsLibrary;
using System.Net;
using System.Collections;
using System.IO;

namespace LogAnalyzerLogic
{
    public class LogParser : ILogParser
    {
        private readonly IFileUtil fileUtil;

        public LogParser(IFileUtil fileUtil)
        {
            this.fileUtil = fileUtil;
        }

        private void SaveData(ref LogBase logBaseOBJ, List<string> parts, int countOfFields)
        {
            if (countOfFields == LogAnalyzerConstants.LOG_NUMBER_OF_FIELD_ex040730)
            {
                if (DateTime.TryParse(parts[0], out DateTime Date))
                    logBaseOBJ.Date = DateTime.Parse(parts[0]);
                if (TimeSpan.TryParse(parts[1], out TimeSpan Time))
                    logBaseOBJ.Time = TimeSpan.Parse(parts[1]);
                logBaseOBJ.ClientIP = parts[2];
                logBaseOBJ.Username = parts[3];
                logBaseOBJ.SourceIP = parts[4];
                if (Int32.TryParse(parts[5], out int sPort))
                    logBaseOBJ.SourcePort = sPort;
                logBaseOBJ.RequestMethod = parts[6];
                logBaseOBJ.UriStem = parts[7];
                logBaseOBJ.UriQuery = parts[8];
                if (Int32.TryParse(parts[9], out int statusCode))
                    logBaseOBJ.StatusCode = statusCode;
                if (Int32.TryParse(parts[10], out int sentBytes))
                    logBaseOBJ.BytesSent = sentBytes;
                if (Int32.TryParse(parts[11], out int receivedBytes))
                    logBaseOBJ.BytesReceived = receivedBytes;
                logBaseOBJ.UserAgent = parts[12];
                logBaseOBJ.Referer = parts[13];

            }
            if (countOfFields == LogAnalyzerConstants.LOG_NUMBER_OF_FIELD_ex120326)
            {
                if (DateTime.TryParse(parts[0], out DateTime Date))
                    logBaseOBJ.Date = DateTime.Parse(parts[0]);
                if (TimeSpan.TryParse(parts[1], out TimeSpan Time))
                    logBaseOBJ.Time = TimeSpan.Parse(parts[1]);
                logBaseOBJ.SourceIP = parts[2];
                logBaseOBJ.RequestMethod = parts[3];
                logBaseOBJ.UriStem = parts[4];
                logBaseOBJ.UriQuery = parts[5];
                if (Int32.TryParse(parts[6], out int sPort))
                    logBaseOBJ.SourcePort = sPort;
                logBaseOBJ.Username = parts[7];
                logBaseOBJ.ClientIP = parts[8];
                logBaseOBJ.UserAgent = parts[9];
                logBaseOBJ.Referer = parts[10];
                logBaseOBJ.Host = parts[11];
                if (Int32.TryParse(parts[12], out int statusCode))
                    logBaseOBJ.StatusCode = statusCode;
                if (Int32.TryParse(parts[13], out int subStatusCode))
                    logBaseOBJ.StatusCode = subStatusCode;
                if (Int32.TryParse(parts[14], out int win32Status))
                    logBaseOBJ.Win32Status = win32Status;
                if (Int32.TryParse(parts[15], out int sentBytes))
                    logBaseOBJ.BytesSent = sentBytes;
                if (Int32.TryParse(parts[16], out int receivedBytes))
                    logBaseOBJ.BytesReceived = receivedBytes;
                if (TimeSpan.TryParse(parts[17], out TimeSpan timeTaken))
                    logBaseOBJ.TimeTaken = timeTaken;
            }
        }
        private LogBase ParseLine(List<string> parts, int countOfFields)
        {
            LogBase logBaseOBJ = new LogBase();
            SaveData(ref logBaseOBJ, parts, countOfFields);
            return logBaseOBJ;
        }
        public Dictionary<string, int> ParseLogFile(string filePath)
        {
            List<string> logs = fileUtil.GetAllLinesFromLogFile(filePath);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            var countOfFields = 0;

            foreach (var line in logs.Where(s => s.Contains(LogAnalyzerConstants.LOG_SEARCH_FIELDS) || Regex.IsMatch(s.Split(' ').First(), @"^(\d{4}-\d{2}-\d{2})")))
            {
                var parts = line.Split(' ').ToList();

                if (!parts.Any())
                    continue;

                if (line.Contains(LogAnalyzerConstants.LOG_SEARCH_FIELDS)) //field line
                    countOfFields = parts.Where(s => !string.IsNullOrEmpty(s)).Skip(1).ToList().Count;
                else //log Line
                {
                    var logBase = ParseLine(parts, countOfFields);
                    if (logBase == null) 
                        continue;

                    if (dict.TryGetValue(logBase.ClientIP!, out int value))
                        dict[logBase.ClientIP!] = value + 1;
                    else
                        dict.Add(logBase.ClientIP!, 1);

                }
            }
            return dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

    }
}
