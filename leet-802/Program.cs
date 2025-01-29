var s = new Solution();

//[[1,2],[2,3],[5],[0],[5],[],[]] 
var graph = new[] {
    new[]  {1,2 },
    [2,3],
    [3],
    [5],
    [5],
    [],
    [],
};
var result = s.EventualSafeNodes(graph);
Console.WriteLine(string.Join(", ", result));


public class Solution
{
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        var numberOfNodes = graph.Count();
        var safeNodes = new HashSet<int>();
        var pointToNode = new Dictionary<int, List<int>>();
        for (int i = 0; i < numberOfNodes; ++i)
        {
            pointToNode[i] = new List<int>();
        }


        for (int i = 0; i < numberOfNodes; ++i)
        {
            if (graph[i].Count() == 0)
            {
                safeNodes.Add(i);
            }
            else
            {
                foreach (var nextNode in graph[i])
                {
                    pointToNode[nextNode].Add(i);
                }
            }
        }

        var q = new Queue<int>(safeNodes);

        while (q.Count > 0)
        {
            q.TryDequeue(out var current);
            var nodesPointsTo = graph[current];
            var isSafe = nodesPointsTo.All(x => safeNodes.Contains(x));
            if (isSafe)
            {
                safeNodes.Add(current);
            }
            if (!isSafe)
            {
                continue;
            }

            var nodesPointing = pointToNode[current];
            if (nodesPointing.Count == 0)
            {
                continue;
            }

            foreach (var node in nodesPointing)
            {
                q.Enqueue(node);
            }
        }



        return safeNodes.ToList().OrderBy(x => x).ToArray();

    }
}