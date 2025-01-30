

using System.Drawing;

var s = new Solution();
var n = 6;
int[][] edges = [[1, 2], [2, 3], [3, 1]];
var result = s.MagnificentSets(n, edges);
Console.WriteLine(result);


//Did that with help of editorial 
public class Solution
{
    public int MagnificentSets(int n, int[][] edges)
    {
        var neigbourNodes = new Dictionary<int, HashSet<int>>();
        for (int i = 1; i <= n; ++i)
        {
            neigbourNodes[i] = new HashSet<int>();
        }

        for (int i = 0; i < edges.Count(); ++i)
        {
            (int edge1, int edge2) = (edges[i][0], edges[i][1]);

            neigbourNodes[edge1].Add(edge2);
            neigbourNodes[edge2].Add(edge1);
        }

        var colors = new int[n];
        Array.Fill(colors, -1);
        for (int node = 0; node < n; node++)
        {
            if (colors[node] != -1) continue;
            colors[node] = 0;
            if (!IsBipartite(node + 1, neigbourNodes, colors)) return -1;
        }

        var distances = new int[n];
        for (int i = 0; i < n; ++i)
        {
            distances[i] = GetLongestShortestPath(i + 1, neigbourNodes, n);
        }

        var visited = new bool[n];
        var maxNumberOfGroups = 0;
        for (int i = 0; i < n; ++i)
        {
            if (visited[i])
            {
                continue;
            }

            maxNumberOfGroups += GetNumberOfGroupsForComponent(i + 1, neigbourNodes, distances, visited);
        }

        return maxNumberOfGroups;
    }

    private bool IsBipartite(int node, Dictionary<int, HashSet<int>> neigbourNodes, int[] colors)
    {
        foreach (var neigbour in neigbourNodes[node])
        {
            if (colors[neigbour - 1] == colors[node - 1])
            {
                return false;
            }

            if (colors[neigbour - 1] != -1)
            {
                continue;
            }
            colors[neigbour - 1] = colors[node - 1] == 0 ? 1 : 0;
            if (!IsBipartite(neigbour, neigbourNodes, colors))
            {
                return false;
            }
        }
        return true;
    }

    private int GetNumberOfGroupsForComponent(int node, Dictionary<int, HashSet<int>> neigbourNodes, int[] distances, bool[] visited)
    {
        var maxNumberOfGroups = distances[node - 1];
        visited[node - 1] = true;
        foreach (var neigbour in neigbourNodes[node])
        {
            if (visited[neigbour - 1])
            {
                continue;
            }
            maxNumberOfGroups = Math.Max(maxNumberOfGroups, GetNumberOfGroupsForComponent(neigbour, neigbourNodes, distances, visited));
        }


        return maxNumberOfGroups;
    }

    private int GetLongestShortestPath(int node, Dictionary<int, HashSet<int>> neigbourNodes, int nodesNumber)
    {
        var visited = new bool[nodesNumber];
        var q = new Queue<int>();
        var distance = 0;
        visited[node - 1] = true;
        q.Enqueue(node);
        while (q.Count > 0)
        {
            var nodesInLayer = q.Count;
            for (int i = 0; i < nodesInLayer; i++)
            {
                var current = q.Dequeue();
                var neigbours = neigbourNodes[current];
                foreach (var neigbourNode in neigbours)
                {
                    if (visited[neigbourNode - 1] == true)
                    {
                        continue;
                    }
                    visited[neigbourNode - 1] = true;
                    q.Enqueue(neigbourNode);
                }
            }
            distance++;
        }

        return distance;
    }
    private bool Color(int i, int[] colors, int color, bool[] visited, Dictionary<int, HashSet<int>> neigbourNodes)
    {
        if (visited[i - 1] == true)
        {
            return true;
        }

        visited[i - 1] = true;

        var currentColor = colors[i - 1];
        if (currentColor != -1 && currentColor != color)
        {
            return false;
        }
        colors[i - 1] = color;

        var newColor = color == 1 ? 0 : 1;
        foreach (var neigbourNode in neigbourNodes[i])
        {
            if (!Color(neigbourNode, colors, newColor, visited, neigbourNodes))
            {
                return false;
            }
        }
        return true;
    }
}
