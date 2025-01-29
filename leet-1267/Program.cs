using Microsoft.VisualBasic;

var s = new Solution();

//[[],[],[],[]]
var grid = new[]
{
    new[] {1,1,0,0},
    new[] {0,0,1,0},
    new[] {0,0,1,0},
    new[] {0,0,0,1},
};

var result = s.CountServers(grid);

Console.WriteLine(result);


public class Solution
{
    public int CountServers(int[][] grid)
    {
        var rows = grid.Count();
        var columns = grid[0].Count();
        var rowsCommunication = new Dictionary<int, int>();
        var colsCommunication = new Dictionary<int, int>();
        for (int r = 0; r < rows; ++r)
        {
            rowsCommunication[r] = 0;
        }
        for (int c = 0; c < columns; ++c)
        {
            colsCommunication[c] = 0;
        }

        var communicationGrid = new bool[rows][];
        for (int r = 0; r < rows; ++r)
        {
            communicationGrid[r] = new bool[columns];
        }

        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if (grid[r][c] == 1)
                {
                    rowsCommunication[r] += 1;
                    colsCommunication[c] += 1;
                }
            }
        }

        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if ((rowsCommunication[r] > 1 || colsCommunication[c] > 1) && grid[r][c] == 1)
                {
                    communicationGrid[r][c] = true;
                }
            }
        }

        return communicationGrid.SelectMany(x => x).Count(x => x == true);
    }
}