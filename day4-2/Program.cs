// See https://aka.ms/new-console-template for more information

var inputText = File.ReadAllText("input.txt");

var lines = inputText.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

var grid = new char[lines.Length, lines[0].Length];

for (int i = 0; i < lines.Length; i++)
{
    for (int j = 0; j < lines[i].Length; j++)
    {
        grid[i, j] = lines[i][j];
    }
}

var totalXmasCount = 0;

for (int i = 0; i < grid.GetLength(0); i++)
{
    for (int j = 0; j < grid.GetLength(1); j++)
    {
        if(grid[i, j] == 'A')
        {
            var xmasFound = HasXMAS(i, j);
            if(xmasFound)
            {
                Console.WriteLine($"XMAS found at ({i}, {j})");
                totalXmasCount++;
            }
            
        }
    }
}

Console.WriteLine($"Total XMAS found: {totalXmasCount}");

return;

bool HasXMAS (int xstart, int ystart)
{
    if(!AreXpointsValid(xstart, ystart))
    {
        return false;
    }
    
    if(grid[xstart, ystart] != 'A')
    {
        return false;
    }
    
    if(grid[xstart+1, ystart+1] == 'M' && grid[xstart-1, ystart-1] == 'S' &&
       grid[xstart-1, ystart+1] == 'M' && grid[xstart+1, ystart-1] == 'S' 
       ||
       grid[xstart+1, ystart+1] == 'M' && grid[xstart-1, ystart-1] == 'S' &&
       grid[xstart+1, ystart-1] == 'M' && grid[xstart-1, ystart+1] == 'S'
       ||
       grid[xstart-1, ystart-1] == 'M' && grid[xstart+1, ystart+1] == 'S' &&
       grid[xstart-1, ystart+1] == 'M' && grid[xstart+1, ystart-1] == 'S'
       ||
       grid[xstart-1, ystart-1] == 'M' && grid[xstart+1, ystart+1] == 'S' &&
       grid[xstart+1, ystart-1] == 'M' && grid[xstart-1, ystart+1] == 'S'
       )
    {
        return true;
    }
    
    return false;
}




bool AreXpointsValid(int x, int y)
{
    return IsValidPoint(x+1, y+1) && IsValidPoint(x+1, y-1) && IsValidPoint(x-1, y+1) && IsValidPoint(x-1, y-1);
}

bool IsValidPoint(int x, int y)
{
    return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
}