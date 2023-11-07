using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerLogic
{
    public static class Common
    {
        /// <summary>
        /// Resolve host name from IP address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string? GetHostNameForIp(string ip)
        {
            try
            {
                return Dns.GetHostEntry(ip).HostName;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return "Unknown";
            }
            
        }

        
    }
}
