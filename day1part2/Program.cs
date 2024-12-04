var relativePath = @"..\..\..\..\input.txt";
var absolutePath = Path.GetFullPath(relativePath);

List<int> leftColumn = [];
List<int> rightCollum = [];
List<int> similarityScore = [];

try
{
    var lines = File.ReadLines(absolutePath);

    foreach (var line in lines)
    {
        var colluns = line.Split("   ");
        leftColumn.Add(int.Parse(colluns[0].Trim()));
        rightCollum.Add(int.Parse(colluns[1].Trim()));
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

foreach (var number in leftColumn)
{
    var appearsInTheSecondCollum = rightCollum.Count(sc => sc == number);
    similarityScore.Add(number * appearsInTheSecondCollum);
}

Console.WriteLine(similarityScore.Sum());