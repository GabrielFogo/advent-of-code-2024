var relativePath = @"..\..\..\..\input.txt";
var absolutePath = Path.GetFullPath(relativePath);

List<int> leftColumn = [];
List<int> rightColmn= [];
List<int> distances = [];

try
{
    var lines = File.ReadLines(absolutePath);

    foreach (var line in lines)
    {
        var colluns = line.Split("   ");
        leftColumn.Add(int.Parse(colluns[0].Trim()));
        rightColmn.Add(int.Parse(colluns[1].Trim()));
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

var firstCollumOrded = leftColumn.Order().ToList();
var secondCollumOrded = rightColmn.Order().ToList();

for (int i = 0; i < firstCollumOrded.Count; i++)
{
    var distance = secondCollumOrded[i] - firstCollumOrded[i];
    distances.Add(Math.Abs(distance));
}

Console.WriteLine(distances.Sum());