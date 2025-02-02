var s = new Solution();
var result = s.IsArraySpecial([1, 5]);

Console.WriteLine(result);

public class Solution
{
    public bool IsArraySpecial(int[] nums)
    {
        if (nums.Length == 1)
        {
            return true;
        }

        var even = nums[0] % 2 == 0;
        even = !even;
        for (int i = 1; i < nums.Length; ++i)
        {
            var isEven = nums[i] % 2 == 0;
            if (even != isEven)
            {
                return false;
            }
            even = !even;
        }
        return true;
    }
}