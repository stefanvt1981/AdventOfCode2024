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
        if(grid[i, j] == 'X')
        {
            var xmasCount = HasXMAS(i, j);
            if(xmasCount > 0)
            {
                Console.WriteLine($"XMAS found at ({i}, {j}) with {xmasCount} occurrences");
            }
            totalXmasCount += xmasCount;
        }
    }
}

Console.WriteLine($"Total XMAS count: {totalXmasCount}");

return;

int HasXMAS (int xstart, int ystart)
{
    var xmasCount = 0;  
    
    if (CheckHorizontal(ystart, xstart, xstart + 3))
    {
        xmasCount++;
    }
    if (CheckHorizontal(ystart, xstart, xstart - 3))
    {
        xmasCount++;
    }
    
    if (CheckVertical(xstart, ystart, ystart + 3))
    {
        xmasCount++;
    }
    if (CheckVertical(xstart, ystart, ystart - 3))
    {
        xmasCount++;
    }
    
    if (CheckDiagonal(xstart, ystart, xstart - 3, ystart + 3))
    {
        xmasCount++;
    }
    if (CheckDiagonal(xstart, ystart, xstart + 3, ystart + 3))
    {
        xmasCount++;
    }
    if (CheckDiagonal(xstart, ystart, xstart - 3, ystart - 3))
    {
        xmasCount++;
    }
    if (CheckDiagonal(xstart, ystart, xstart + 3, ystart - 3))
    {
        xmasCount++;
    }
    
    return xmasCount;
}

bool CheckHorizontal(int y, int xstart, int xend)
{
    if (IsValidPoint(xstart, y) == false || IsValidPoint(xend, y) == false)
    {
        return false;
    }
    
    if(xstart > xend)
    {
        if(grid[xstart, y] == 'X' && 
           grid[xstart-1, y] == 'M' &&
           grid[xstart-2, y] == 'A' &&
           grid[xstart-3, y] == 'S')
        {
            return true;
        }
    }
    else
    {
        if(grid[xstart, y] == 'X' && 
           grid[xstart+1, y] == 'M' &&
           grid[xstart+2, y] == 'A' &&
           grid[xstart+3, y] == 'S')
        {
            return true;
        }
    }
    
    return false;
}

bool CheckVertical(int x, int ystart, int yend)
{
    if (IsValidPoint(x, ystart) == false || IsValidPoint(x, yend) == false)
    {
        return false;
    }
    
    if(ystart > yend)
    {
        if(grid[x, ystart] == 'X' && 
           grid[x, ystart-1] == 'M' &&
           grid[x, ystart-2] == 'A' &&
           grid[x, ystart-3] == 'S')
        {
            return true;
        }
    }
    else
    {
        if(grid[x, ystart] == 'X' && 
           grid[x, ystart+1] == 'M' &&
           grid[x, ystart+2] == 'A' &&
           grid[x, ystart+3] == 'S')
        {
            return true;
        }
    }
    
    return false;
}

bool CheckDiagonal(int startx, int starty, int endx, int endy)
{
    if (IsValidPoint(startx, starty) == false || IsValidPoint(endx, endy) == false)
    {
        return false;
    }
    
    if(startx > endx && starty > endy)
    {
        if(grid[startx, starty] == 'X' && 
           grid[startx-1, starty-1] == 'M' &&
           grid[startx-2, starty-2] == 'A' &&
           grid[startx-3, starty-3] == 'S')
        {
            return true;
        }
    }
    else if(startx < endx && starty < endy)
    {
        if(grid[startx, starty] == 'X' && 
           grid[startx+1, starty+1] == 'M' &&
           grid[startx+2, starty+2] == 'A' &&
           grid[startx+3, starty+3] == 'S')
        {
            return true;
        }
    }
    else if(startx < endx && starty > endy)
    {
        if(grid[startx, starty] == 'X' && 
           grid[startx+1, starty-1] == 'M' &&
           grid[startx+2, starty-2] == 'A' &&
           grid[startx+3, starty-3] == 'S')
        {
            return true;
        }
    }
    else if(startx > endx && starty < endy)
    {
        if(grid[startx, starty] == 'X' && 
           grid[startx-1, starty+1] == 'M' &&
           grid[startx-2, starty+2] == 'A' &&
           grid[startx-3, starty+3] == 'S')
        {
            return true;
        }
    }
    
    return false;
}

bool IsValidPoint(int x, int y)
{
    return x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1);
}