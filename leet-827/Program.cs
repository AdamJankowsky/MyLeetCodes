var s = new Solution();
int[][] grid = [[0, 0], [0, 0]];
var result = s.LargestIsland(grid);
Console.WriteLine(result);

public class Solution
{
    public int LargestIsland(int[][] grid)
    {
        var n = grid.Length;

        bool[][] visited = new bool[n][];

        for (int i = 0; i < n; ++i)
        {
            visited[i] = new bool[n];
        }

        var firstCheckedQ = new Queue<(int Row, int Col)>();

        var maxArea = 0;
        for (int row = 0; row < n; ++row)
        {
            for (int col = 0; col < n; ++col)
            {
                if (visited[row][col] == true)
                {
                    continue;
                }

                if (grid[row][col] == 0)
                {
                    continue;
                }

                firstCheckedQ.Enqueue((row, col));
                var area = 0;
                var breachedArea = new List<int>();
                var possibleBreachPoints = new HashSet<(int Row, int Col)>();
                while (firstCheckedQ.Count > 0)
                {
                    firstCheckedQ.TryDequeue(out var current);

                    if (visited[current.Row][current.Col])
                    {
                        continue;
                    }
                    visited[current.Row][current.Col] = true;
                    area += 1;


                    for (int i = 0; i < 4; ++i)
                    {
                        (int Row, int Col) next = (current.Row + NextNode[i][0], current.Col + NextNode[i][1]);

                        if (next.Row < 0 || next.Row == n || next.Col < 0 || next.Col == n)
                        {
                            continue;
                        }

                        if (grid[next.Row][next.Col] == 1)
                        {
                            if (!visited[next.Row][next.Col])
                            {
                                firstCheckedQ.Enqueue(next);
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            if (visited[next.Row][next.Col] == true)
                            {
                                continue;
                            }
                            possibleBreachPoints.Add(next);

                        }



                    }
                }

                foreach (var next in possibleBreachPoints)
                {
                    visited[next.Row][next.Col] = true;
                    var breachedQ = new Queue<(int Row, int Col)>();

                    var breachedAreaCurrent = 0;
                    breachedQ.Enqueue(next);
                    var visitedNodes = new HashSet<(int Row, int Col)>();
                    while (breachedQ.Count > 0)
                    {
                        var currentBreached = breachedQ.Dequeue();
                        if (visitedNodes.Contains(currentBreached))
                        {
                            continue;
                        }
                        visitedNodes.Add(currentBreached);
                        breachedAreaCurrent += 1;

                        for (int k = 0; k < 4; ++k)
                        {
                            (int Row, int Col) nextBreached = (currentBreached.Row + NextNode[k][0], currentBreached.Col + NextNode[k][1]);

                            if (nextBreached.Row < 0 || nextBreached.Row == n || nextBreached.Col < 0 || nextBreached.Col == n)
                            {
                                continue;
                            }
                            if (grid[nextBreached.Row][nextBreached.Col] == 1 && !visited[nextBreached.Row][nextBreached.Col])
                            {
                                breachedQ.Enqueue(nextBreached);
                            }
                        }
                    }

                    breachedArea.Add(breachedAreaCurrent);
                }


                var maxBreached = breachedArea.Any() ? breachedArea.Max() : 0;
                maxArea = Math.Max(area + maxBreached, maxArea);
            }
        }

        if (n > 0 && maxArea == 0)
        {
            return 1;
        }

        return maxArea;

    }




    private int[][] NextNode = [[-1, 0], [1, 0], [0, -1], [0, 1]];
}