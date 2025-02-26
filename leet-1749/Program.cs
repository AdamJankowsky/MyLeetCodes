var s = new Solution();
Console.WriteLine(s.MaxAbsoluteSum([1, -3, 2, 3, -4]));

public class Solution
{
    public int MaxAbsoluteSum(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }

        if (nums.Length == 1)
        {
            return Math.Abs(nums[0]);
        }

        var max = 0;
        var min = 0;

        var sum = 0;
        for (int i = 0; i < nums.Length; ++i)
        {
            sum += nums[i];
            max = Math.Max(max, sum);
            min = Math.Min(min, sum);
        }

        return max - min;
    }
}