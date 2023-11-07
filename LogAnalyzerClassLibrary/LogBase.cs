using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogAnalyzerClassLibrary
{
    public class LogBase
    {
        public DateTime? Date { get; set; } = null;
        public TimeSpan? Time { get; set; } = null;
        public string? SourceIP { get; set; } = null;
        public string? RequestMethod { get; set; } = null;
        public string? UriStem { get; set; } = null;
        public string? UriQuery { get; set; } = null;
        public int SourcePort { get; set; } = 0;
        public string? Username { get; set; } = null;
        public string? ClientIP { get; set; } = null;
        public string? UserAgent { get; set; } = null;
        public string? Referer { get; set; } = null;
        public string? Host { get; set; } = null;
        public int StatusCode { get; set; } = 0;
        public int BytesSent { get; set; } = 0;
        public int BytesReceived { get; set; } = 0;
        public int SubstatusCode { get; set; } = 0;
        public int Win32Status { get; set; } = 0;
        public TimeSpan? TimeTaken { get; set; } = null;
    }
}
