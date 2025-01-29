
// [[1,1,1,1],[2,2,2,2],[1,1,1,1],[2,2,2,2]]
using System.Net.Mail;

var grid = new[]
{
    new[] {1,2},
    new[] {4,3},
};


var solution = new Solution();
var result = solution.MinCost(grid);

Console.WriteLine(result);


public class Solution
{
    public int MinCost(int[][] grid)
    {
        var rows = grid.Count();
        var columns = grid[0].Count();

        int[][] minValues = new int[rows][];
        for (int r = 0; r < rows; r++)
        {
            minValues[r] = new int[columns];
            for (int c = 0; c < columns; c++)
            {
                minValues[r][c] = int.MaxValue;
            }
        }
        minValues[0][0] = 0;

        var pQ = new PriorityQueue<(int Row, int Column), int>();

        pQ.Enqueue((0, 0), 0);

        while (pQ.Count > 0)
        {
            pQ.TryDequeue(out var current, out var totalCost);

            if (minValues[current.Row][current.Column] < totalCost)
            {
                continue;
            }


            for (int i = 1; i <= 4; i++)
            {
                var nextCords = GetNextCords(current.Row, current.Column, i);

                if (nextCords.Row < 0 || nextCords.Row == rows || nextCords.Column < 0 || nextCords.Column == columns)
                {
                    continue;
                }

                var addedCost = i == grid[current.Row][current.Column] ? 0 : 1;

                var newTotalCost = totalCost + addedCost;

                if (minValues[nextCords.Row][nextCords.Column] <= newTotalCost)
                {
                    continue;
                }

                minValues[nextCords.Row][nextCords.Column] = newTotalCost;
                pQ.Enqueue(nextCords, newTotalCost);
            }
        }

        return minValues[rows - 1][columns - 1];
    }

    private static (int Row, int Column) GetNextCords(int row, int col, int direction)
    {
        var dir = Dirs[direction - 1];
        return (row + dir[0], col + dir[1]);
    }

    private static int[][] Dirs = new[] { new[] { 0, 1 }, new[] { 0, -1 }, new[] { 1, 0 }, new[] { -1, 0 } };
}

