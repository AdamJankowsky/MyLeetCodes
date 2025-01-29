using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;

var solution = new Solution();
var grid = new[] {
    new[] {20,3,20,17,2,12,15,17,4,15},
    new[] {20,10,13,14,15,5,2,3,14,3}
};

var result = solution.GridGame(grid);

Console.WriteLine(result);

public class Solution
{
    public long GridGame(int[][] grid)
    {
        long n = grid[0].Count();
        if (n == 1)
        {
            return 0;
        }

        var lowestCantake = long.MaxValue;

        long sumUpper = 0;
        for (int i = 0; i < n; ++i)
        {
            sumUpper += grid[0][i];
        }
        long sumLower = 0;
        long upperTaken = 0;

        for (int i = 0; i < n; ++i)
        {
            upperTaken += grid[0][i];
            if (i > 0)
            {
                sumLower += grid[1][i - 1];
            }

            long robot2Takes = Math.Max(sumUpper - upperTaken, sumLower);
            if (robot2Takes < lowestCantake)
            {
                lowestCantake = robot2Takes;
            }
        }

        return lowestCantake;
    }
}