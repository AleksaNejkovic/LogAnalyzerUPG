using LogAnalyzerLogic;
using LogAnalyzerConstantsLibrary;
using System.Resources;
using System.Reflection;

IFileUtil fileUtil = new FileUtil();
IDisplayUtil displayUtil = new DisplayUtil();
ILogParser logParser = new LogParser(fileUtil);

string LOG_DIR_ex040730 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName, "LogFile", "ex040730.log");
string LOG_DIR_ex120326 = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName, "LogFile", "ex120326.log");

Console.WriteLine("Parsed file name: ex040730.log");
displayUtil.PrintParsingResult(logParser.ParseLogFile(LOG_DIR_ex040730));
Console.WriteLine("Parsed file name: ex120326.log");
displayUtil.PrintParsingResult(logParser.ParseLogFile(LOG_DIR_ex120326));


Console.ReadLine();