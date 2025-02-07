var s = new Solution();

int[][] queries = [[1, 4], [2, 5], [1, 3], [3, 4]];
var limit = 4;

var result = s.QueryResults(limit, queries);
Console.WriteLine("[" + string.Join(", ", result) + "]");


public class Solution
{
    public int[] QueryResults(int limit, int[][] queries)
    {
        var colors = new Dictionary<int, int>();
        var colorsUsed = new Dictionary<int, int>();
        int[] results = new int[queries.Length];

        for (int i = 0; i < queries.Length; ++i)
        {
            (int ball, int color) = (queries[i][0], queries[i][1]);
            if (colors.ContainsKey(ball))
            {
                var oldColor = colors[ball];
                if (colorsUsed[oldColor] == 1)
                {
                    colorsUsed.Remove(oldColor);
                }
                else
                {
                    colorsUsed[oldColor]--;
                }
            }

            colors[ball] = color;

            if (!colorsUsed.ContainsKey(color))
            {
                colorsUsed[color] = 1;
                results[i] = colorsUsed.Count;
                continue;
            }

            colorsUsed[color]++;
            results[i] = colorsUsed.Count;
            continue;
        }

        return results;
    }
}