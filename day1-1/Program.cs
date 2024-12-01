// See https://aka.ms/new-console-template for more information

var inputText = File.ReadAllText("input.txt");

var lines = inputText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var left = new List<int>();
var right = new List<int>();

foreach (var line in lines)
{
    var nrParts = line.Split("   ");

    left.Add(int.Parse(nrParts[0]));
    right.Add(int.Parse(nrParts[1]));
}

left.Sort();
right.Sort();

var distance = 0;

for (int i = 0; i < left.Count; i++)
{
    if (left[i] > right[i])
    {
        distance += left[i] - right[i];
    }
    else
    {
        distance += right[i] - left[i];
    }
}
Console.WriteLine(distance);
