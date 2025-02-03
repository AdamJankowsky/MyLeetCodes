var s = new Solution();

int[] nums = [3, 2, 1];
var result = s.LongestMonotonicSubarray(nums);

Console.WriteLine(result);


public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int maxDecreased = 0;
        int maxIncreased = 0;

        int decreasedSubCol = 1;
        int increasedSubCol = 1;

        for (int i = 0; i < nums.Length - 1; ++i)
        {
            if (nums[i] < nums[i + 1])
            {
                increasedSubCol += 1;
                maxDecreased = Math.Max(maxDecreased, decreasedSubCol);
                decreasedSubCol = 1;
            }
            if (nums[i] > nums[i + 1])
            {
                decreasedSubCol += 1;
                maxIncreased = Math.Max(maxIncreased, increasedSubCol);
                increasedSubCol = 1;
            }
            if (nums[i] == nums[i + 1])
            {
                maxDecreased = Math.Max(maxDecreased, decreasedSubCol);
                maxIncreased = Math.Max(maxIncreased, increasedSubCol);
                increasedSubCol = 1;
                decreasedSubCol = 1;
            }
        }

        maxIncreased = Math.Max(maxIncreased, increasedSubCol);
        maxDecreased = Math.Max(maxDecreased, decreasedSubCol);

        return Math.Max(maxIncreased, maxDecreased);
    }
}