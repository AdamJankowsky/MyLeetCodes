using System.Text.Json;

var s = new Solution();

var numCourses = 2;
var prerequisites = new[] {
    new[] {1, 0}
};

var queries = new[] {
    new[] {0, 1},
    new[] {1, 0},
};

var result = s.CheckIfPrerequisite(numCourses, prerequisites, queries);

Console.WriteLine(JsonSerializer.Serialize(result));


public class Solution
{
    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries)
    {
        var distance = new int[numCourses][];
        for (int i = 0; i < numCourses; ++i)
        {
            distance[i] = new int[numCourses];
            for (int k = 0; k < numCourses; ++k)
            {
                if (i == k)
                {
                    distance[i][k] = 0;
                    continue;
                }

                distance[i][k] = int.MaxValue;
            }
        }
        for (int i = 0; i < prerequisites.Count(); ++i)
        {
            var courseA = prerequisites[i][0];
            var courseB = prerequisites[i][1];

            distance[courseB][courseA] = 0;
        }

        for (int node = 0; node < numCourses; node++)
        {
            for (int i = 0; i < numCourses; i++)
            {
                for (int j = 0; j < numCourses; j++)
                {
                    if (distance[i][node] != int.MaxValue && distance[node][j] != int.MaxValue)
                    {
                        distance[i][j] = Math.Min(distance[i][j], distance[i][node] + distance[node][j]);
                    }
                }
            }
        }

        var result = new bool[queries.Length];

        for (int i = 0; i < queries.Length; ++i)
        {
            var courseA = queries[i][0];
            var courseB = queries[i][1];
            result[i] = distance[courseB][courseA] != int.MaxValue;
        }
        return result;
    }
}