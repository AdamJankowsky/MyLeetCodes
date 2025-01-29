
using System.IO.MemoryMappedFiles;

// var heightMap = new[] {
//     new [] {12,13,1,12},
//     new [] {13,4,13,12},
//     new [] {13,8,10,12},
//     new [] {12,13,12,12},
//     new [] {13,13,13,13},
// };

var heightMap = new[] {
    new [] {1},
};

var solution = new Solution();

var result = solution.TrapRainWater(heightMap);
Console.WriteLine(result);


public class Solution
{
    public int TrapRainWater(int[][] heightMap)
    {
        var map = new Map(heightMap);
        if (map.Rows < 2 || map.Columns < 2)
        {
            return 0;
        }

        var trappedWater = 0;

        var boundaryCells = new Cell[((map.Columns * 2) + ((map.Rows - 2) * 2))];

        var boundaryCellIter = 0;
        for (int c = 0; c < map.Columns; ++c)
        {
            boundaryCells[boundaryCellIter++] = map.Cells[0][c];
            boundaryCells[boundaryCellIter++] = map.Cells[map.Rows - 1][c];
        }

        for (int r = 1; r < map.Rows - 1; ++r)
        {
            boundaryCells[boundaryCellIter++] = map.Cells[r][0];
            boundaryCells[boundaryCellIter++] = map.Cells[r][map.Columns - 1];
        }


        var pQ = new PriorityQueue<Cell, int>();
        foreach (var boundaryCell in boundaryCells)
        {
            pQ.Enqueue(boundaryCell, boundaryCell.Height);
            map.Visited[boundaryCell.Row][boundaryCell.Col] = true;
        }


        while (pQ.Count > 0)
        {
            pQ.TryDequeue(out var cell, out var minHeight);
            if (cell == null)
            {
                continue;
            }
            var minBoundaryHeight = minHeight;

            for (int i = 0; i < 4; ++i)
            {
                var newCol = Map.MovC[i] + cell.Col;
                var newRow = Map.MovR[i] + cell.Row;

                if (newCol > map.Columns - 1 || newRow > map.Rows - 1 || newCol < 0 || newRow < 0)
                {
                    continue;
                }
                var neighbourCell = map.Cells[newRow][newCol];
                if (neighbourCell == null || map.Visited[neighbourCell.Row][neighbourCell.Col])
                {
                    continue;
                }
                else
                {
                    var heightDiff = minBoundaryHeight - neighbourCell.Height;
                    if (heightDiff > 0)
                    {
                        trappedWater += heightDiff;
                    }
                    var height = Math.Max(minBoundaryHeight, neighbourCell.Height);
                    map.Visited[newRow][newCol] = true;
                    pQ.Enqueue(neighbourCell, height);
                }
            }

        }

        return trappedWater;
    }
}

public class Map
{

    public Map(int[][] heightMap)
    {
        Rows = heightMap.Count();
        Columns = heightMap[0].Count();
        Visited = new bool[Rows][];
        for (int r = 0; r < Rows; ++r)
        {
            Visited[r] = new bool[Columns];
        }

        Cells = new Cell[Rows][];
        for (int r = 0; r < Rows; ++r)
        {
            Cells[r] = new Cell[Columns];
            for (int c = 0; c < Columns; ++c)
            {
                Cells[r][c] = new Cell(r, c, heightMap[r][c]);
            }
        }
    }

    public Cell[][] Cells { get; }
    public int Rows { get; }
    public int Columns { get; }

    public bool[][] Visited { get; }

    public static int[] MovR = new[] { -1, 1, 0, 0 };
    public static int[] MovC = new[] { 0, 0, -1, 1 };
}

public record Cell(int Row, int Col, int Height)
{
    public int Height { get; set; } = Height;
}
