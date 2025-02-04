var s = new Solution();

int[] nums = [12, 17, 15, 13, 10, 11, 12];

var result = s.MaxAscendingSum(nums);

Console.WriteLine(result);

public class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        if (nums.Length == 1)
        {
            return nums[0];
        }

        var partialSum = nums[0];
        var maxSum = nums[0];

        for (int i = 0; i < nums.Length - 1; ++i)
        {
            if (nums[i] < nums[i + 1])
            {
                partialSum += nums[i + 1];
            }
            else
            {
                maxSum = Math.Max(maxSum, partialSum);
                partialSum = nums[i + 1];
            }
        }
        maxSum = Math.Max(maxSum, partialSum);

        return maxSum;
    }
}