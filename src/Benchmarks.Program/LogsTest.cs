using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Logging;

[MemoryDiagnoser]
public class LogsTest
{
    private const long _amountIterations = 1_000_000;
    private const string _logMessage = "This a log message: {0} | {1}"; 
    
    private readonly ILoggerFactory _logMicrosoftFactory = LoggerFactory.Create(builder => 
    {
        builder.AddConsole().SetMinimumLevel(LogLevel.Warning);
    });

    private readonly ILogger _logMicrosoft;

    public LogsTest()
    {
        _logMicrosoft = new Logger<LogsTest>(_logMicrosoftFactory);
    }

    public static int TestNumber => 1;

    [Benchmark]
    public void LogMicrosoft()
    {
        _logMicrosoft.LogInformation(_logMessage, 1, 2);
    }
}
