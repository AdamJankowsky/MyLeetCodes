var s = new Solution();
var edges = new int[][] {
    [1,2],[2,3],[3,4],[1,4],[1,5]
};
var result = s.FindRedundantConnection(edges);
Console.WriteLine(string.Join(", ", result));

public class Solution
{
    public int[] FindRedundantConnection(int[][] edges)
    {
        var n = edges.Count();
        var union = new UnionFind(n);

        int[] redundantPair = new int[2];
        foreach (var edge in edges)
        {
            (int edge1, int edge2) = (edge[0], edge[1]);
            if (union.FindNode(edge1) == union.FindNode(edge2))
            {
                redundantPair[0] = edge1;
                redundantPair[1] = edge2;
            }

            union.Union(edge1, edge2);
        }

        return redundantPair;
    }
}

public class UnionFind
{
    private int[] NodesParents;

    public UnionFind(int nodesNumber)
    {
        NodesParents = new int[nodesNumber];
        for (int i = 1; i <= nodesNumber; ++i)
        {
            NodesParents[i - 1] = i;
        }

    }

    public int FindNode(int node)
    {
        if (NodesParents[node - 1] == node)
        {
            return node;
        }

        return FindNode(NodesParents[node - 1]);
    }

    public void Union(int node1, int node2)
    {
        var node1Rep = FindNode(node1);
        var node2Rep = FindNode(node2);

        NodesParents[node1Rep - 1] = node2Rep;
    }
}