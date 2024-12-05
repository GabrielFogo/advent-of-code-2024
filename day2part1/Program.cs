var relativePath = @"..\..\..\..\input.txt";
var absolutePath = Path.GetFullPath(relativePath);
var reportSafes = 0;

try
{
    var lines = File.ReadLines(absolutePath);

    foreach (var line in lines)
    {
        var reports = line.Split(" ").ToList();
        var reportsInt = ParseReports(reports);        
        var isSafe = VerifyIfReportIsSafe(reportsInt);
        
        if (isSafe)
        {
            reportSafes++;
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

Console.WriteLine(reportSafes);
return;

List<int> ParseReports(List<string> reports)
{ 
     return reports.Select(report => int.Parse(report.Trim())).ToList();
}

bool VerifyIfReportIsSafe(List<int> reports)
{
    return CheckIfIsSafeByIncreasingQuantity(reports) && CheckIfIsOnlyDecreasingOrIncreasing(reports);
}

bool CheckIfIsSafeByIncreasingQuantity(List<int> reports)
{
    var isSafe = true;
    for (var i = 0; i < reports.Count - 1; i++)
    {
        var diff = Math.Abs(reports[i] - reports[i + 1]);
        
        if (diff is > 3 or 0)
        {
            isSafe = false;
        }
    }

    return isSafe;
}

bool CheckIfIsOnlyDecreasingOrIncreasing(List<int> reports)
{
    var hasDecreasing = false;
    var hasIncreasing = false;

    for (var i = 0; i < reports.Count - 1; i++)
    {
        if (reports[i] < reports[i + 1])
        {
            hasIncreasing = true;
        }
        else if (reports[i] > reports[i + 1])
        {
            hasDecreasing = true;
        }
        
        if (hasDecreasing && hasIncreasing)
        {
            return false;
        }
    }

    return true;
}