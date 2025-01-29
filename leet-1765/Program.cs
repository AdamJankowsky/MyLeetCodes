using System.Text.Json;

var s = new Solution();

var data = new[] {
    new[] {0, 0, 1},
    new[] {1, 0, 0},
    new[] {0, 0, 0},
};

var result = s.HighestPeak(data);

Console.WriteLine(JsonSerializer.Serialize(result));



public class Solution
{
    public int[][] HighestPeak(int[][] isWater)
    {
        var rows = isWater.Count();
        var columns = isWater[0].Count();
        var heightMap = new int[rows][];
        for (int r = 0; r < rows; ++r)
        {
            heightMap[r] = new int[columns];
        }

        var visited = new bool[rows][];
        for (int r = 0; r < rows; ++r)
        {
            visited[r] = new bool[columns];
        }

        var queue = new Queue<(int Row, int Col)>();

        for (int r = 0; r < rows; ++r)
        {
            for (int c = 0; c < columns; ++c)
            {
                if (isWater[r][c] == 1)
                {
                    visited[r][c] = true;
                    queue.Enqueue((r, c));
                }
            }
        }

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            foreach (var neighbour in GetNewPositions(current.Row, current.Col))
            {
                if (neighbour.Row < 0 || neighbour.Row == rows || neighbour.Col < 0 || neighbour.Col == columns)
                {
                    continue;
                }

                if (visited[neighbour.Row][neighbour.Col])
                {
                    continue;
                }

                var newVal = heightMap[current.Row][current.Col] + 1;
                heightMap[neighbour.Row][neighbour.Col] = newVal;
                visited[neighbour.Row][neighbour.Col] = true;
                queue.Enqueue(neighbour);
            }

        }

        return heightMap;
    }


    private IEnumerable<(int Row, int Col)> GetNewPositions(int row, int col)
    {
        yield return (row + 1, col);
        yield return (row - 1, col);
        yield return (row, col + 1);
        yield return (row, col - 1);
    }
}