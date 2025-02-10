var s = new Solution();

Console.WriteLine(s.CountBadPairs([1, 2, 3, 4, 5]));

public class Solution
{
    public long CountBadPairs(int[] nums)
    {
        var n = nums.Length;
        long badPairs = 0;

        var results = new Dictionary<int, int>();

        for (int i = 0; i < n; ++i)
        {
            var result = nums[i] - i;
            if (results.ContainsKey(result))
            {
                badPairs += i - results[result];
                results[result]++;
                continue;
            }
            badPairs += i;
            results[result] = 1;
        }

        return badPairs;
    }
}