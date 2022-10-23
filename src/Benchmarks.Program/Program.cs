using BenchmarkDotNet.Running;

Console.WriteLine("Hello, let's do some Benchmark tests!");

int testNumber;

do
{
    Console.WriteLine("Choose the test number you would like to execute:");
    Console.WriteLine($"{LogsTest.TestNumber} - Logs");
    
    int.TryParse(Console.ReadLine(), out testNumber);
    
} while (!IsTestValid(testNumber));

switch (testNumber)
{
    case 1:
        BenchmarkRunner.Run<LogsTest>();
        break;
}

bool IsTestValid(int testNumber)
{
    var validsTests = new int[] { LogsTest.TestNumber };

    return validsTests.Any(o => o == testNumber);
}