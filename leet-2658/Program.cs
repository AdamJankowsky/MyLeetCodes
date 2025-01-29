
var s = new Solution();

var grid = new int[][] {
    [8,6],[2,6],
};
var result = s.FindMaxFish(grid);

Console.WriteLine(result);

public class Solution
{
    public int FindMaxFish(int[][] grid)
    {
        var visited = new HashSet<(int Row, int Col)>();
        var rows = grid.Length;
        var columns = grid[0].Length;
        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if (grid[r][c] == 0)
                {
                    visited.Add((r, c));
                }
            }
        }

        var totalSum = 0;

        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if (visited.Contains((r, c)))
                {
                    continue;
                }

                var q = new Queue<(int Row, int Col)>();
                q.Enqueue((r, c));
                var sum = 0;

                while (q.Count > 0)
                {
                    var current = q.Dequeue();
                    if (visited.Contains(current))
                    {
                        continue;
                    }
                    visited.Add(current);
                    sum += grid[current.Row][current.Col];

                    var nextCells = GetNextCells(current, rows, columns, visited);
                    foreach (var cell in nextCells)
                    {
                        q.Enqueue(cell);
                    }
                }

                totalSum = Math.Max(totalSum, sum);
            }
        }

        return totalSum;
    }

    private IEnumerable<(int Row, int Col)> GetNextCells((int Row, int Col) current, int rows, int columns, HashSet<(int Row, int Col)> visited)
    {
        var nextCells = new List<(int Row, int Col)>();
        for (int i = 0; i < 4; ++i)
        {
            (int Row, int Col) next = (current.Row + NextCellsVector[i][0], current.Col + NextCellsVector[i][1]);
            if (visited.Contains(next))
            {
                continue;
            }
            if (next.Row < 0 || next.Row == rows || next.Col < 0 || next.Col == columns)
            {
                continue;
            }
            nextCells.Add(next);
        }
        return nextCells;
    }

    private int[][] NextCellsVector = new int[][] { [-1, 0], [1, 0], [0, -1], [0, 1] };
}