using LogAnalyzerLogic;
using LogAnalyzerConstantsLibrary;

IFileUtil fileUtil = new FileUtil();
IDisplayUtil displayUtil = new DisplayUtil();
ILogParser logParser = new LogParser(fileUtil);

Console.WriteLine("Parsed file name: ex040730.log");
displayUtil.PrintParsingResult(logParser.ParseLogFile(LogAnalyzerConstants.LOG_DIR_ex040730));
Console.WriteLine("Parsed file name: ex120326.log");
displayUtil.PrintParsingResult(logParser.ParseLogFile(LogAnalyzerConstants.LOG_DIR_ex120326));


Console.ReadLine(); //Avoid closing window