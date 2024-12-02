// See https://aka.ms/new-console-template for more information

var inputText = File.ReadAllText("input.txt");

var lines = inputText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var _safe = 0;
var _unsafe = 0;

foreach (var line in lines)
{
    var nrs = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    
    var ints = nrs.Select(int.Parse).ToList();
    
    if((CheckIncrease(ints) && CheckDeviationForAll(ints)) ||
       CheckDecrease(ints) && CheckDeviationForAll(ints))
    {
        _safe++;
        continue;
    }
    
    if (ProcessDampened(ints))
    {
        _safe++;
    }
    else
    {
        _unsafe++;
    }
}

Console.WriteLine($"Safe: {_safe}");
Console.WriteLine($"Unsafe: {_unsafe}");

return;

bool ProcessDampened(List<int> ints)
{
    for (int i = 0; i < ints.Count(); i++)
    {
        var clone = ints.ToList();
        clone.RemoveAt(i);

        if (ValidateDampened(clone))
        {
            return true;
        }
    }

    return false;
}

bool ValidateDampened(List<int> ints)
{
    return (CheckIncrease(ints) && CheckDeviationForAll(ints)) ||
           CheckDecrease(ints) && CheckDeviationForAll(ints);
}

bool CheckDecrease(List<int> ints)
{
    for (var i = 0; i < ints.Count - 1; i++)
    {
        if (ints[i] < ints[i + 1])
        {
            return false;
        }
    }
    
    return true;
}

bool CheckIncrease(List<int> ints)
{
    for (var i = 0; i < ints.Count - 1; i++)
    {
        if (ints[i] > ints[i + 1])
        {
            return false;
        }
    }
    
    return true;
}

bool CheckDeviation(int one, int two)
{
    if (one == two)
    {
        return false;
    }
    
    return Math.Abs(one - two) <= 3;
}

bool CheckDeviationForAll(List<int> ints)
{
    for (var i = 0; i < ints.Count - 1; i++)
    {
        if (!CheckDeviation(ints[i], ints[i + 1]))
        {
            return false;
        }
    }
    
    return true;
}