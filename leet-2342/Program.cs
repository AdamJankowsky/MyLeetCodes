
var s = new Solution();

Console.WriteLine(s.MaximumSum([383, 77, 97, 261, 102, 344, 150, 130, 55, 337, 401, 498, 21, 5]));

public class Solution
{
    public int MaximumSum(int[] nums)
    {
        var maxSum = -1;
        var dict = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            var current = nums[i];
            var sum = GetSum(current);
            if (dict.ContainsKey(sum))
            {
                maxSum = Math.Max(maxSum, dict[sum] + current);
                dict[sum] = Math.Max(dict[sum], current);
            }
            else
            {
                dict[sum] = current;
            }
        }

        return maxSum;
    }

    private int GetSum(int current)
    {
        var sum = 0;
        while (current > 0)
        {
            sum += current % 10;
            current /= 10;
        }
        return sum;
    }
}