using System.Runtime.CompilerServices;

var s = new Solution();

var fav = new[] { 1, 0, 0, 2, 1, 4, 7, 8, 9, 6, 7, 10, 8 };
var result = s.MaximumInvitations(fav);
Console.WriteLine(result);
public class Solution
{
    public int MaximumInvitations(int[] favorite)
    {
        var n = favorite.Count();
        var edges = new Dictionary<int, List<int>>();
        for (int i = 0; i < n; ++i)
        {
            edges[i] = new List<int>();
        }

        for (int i = 0; i < n; ++i)
        {
            edges[favorite[i]].Add(i);
        }
        var longestCycle = 0;
        var twoCycleInvitations = 0;

        var visited = new HashSet<int>();
        for (int i = 0; i < n; ++i)
        {
            if (!visited.Contains(i))
            {
                var visitedPersons = new Dictionary<int, int>();
                var currentPerson = i;
                var distance = 0;
                while (true)
                {
                    if (visited.Contains(currentPerson))
                    {
                        break;
                    }
                    visited.Add(currentPerson);
                    visitedPersons[currentPerson] = distance;
                    distance += 1;
                    var nextPerson = favorite[currentPerson];

                    if (visitedPersons.ContainsKey(nextPerson))
                    {
                        var cyclelength = distance - visitedPersons[nextPerson];
                        longestCycle = Math.Max(longestCycle, cyclelength);

                        var visitedNodes = new HashSet<int>(new[] { currentPerson, nextPerson });
                        if (cyclelength == 2)
                        {
                            twoCycleInvitations += 2 + bfs(nextPerson, visitedNodes, edges) + bfs(currentPerson, visitedNodes, edges);
                        }
                        break;
                    }

                    currentPerson = nextPerson;
                }
            }
        }

        return Math.Max(longestCycle, twoCycleInvitations);

    }

    public int bfs(int startNode, HashSet<int> visitedNodes, Dictionary<int, List<int>> reversedGraph)
    {
        var queue = new PriorityQueue<int, int>();
        var totalDistance = 0;
        queue.Enqueue(startNode, 0);

        while (queue.Count > 0)
        {
            queue.TryDequeue(out var current, out var distance);
            foreach (var neighbour in reversedGraph[current])
            {
                if (visitedNodes.Contains(neighbour))
                {
                    continue;
                }
                visitedNodes.Add(neighbour);
                queue.Enqueue(neighbour, distance + 1);
                totalDistance = Math.Max(totalDistance, distance + 1);
            }
        }

        return totalDistance;
    }
}