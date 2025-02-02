var s = new Solution();

int[] grid = [2, 4, 1, 3];

var result = s.Check(grid);

Console.WriteLine(result);


public class Solution
{
    public bool Check(int[] nums)
    {
        bool secondPart = false;

        for (int i = 0; i < nums.Length - 1; ++i)
        {
            if (!secondPart)
            {
                if (nums[i] <= nums[i + 1])
                {
                    continue;
                }
                else
                {
                    if (nums[i + 1] > nums[0])
                    {
                        return false;
                    }
                    secondPart = true;
                    continue;
                }
            }
            else
            {
                if (nums[i] <= nums[i + 1])
                {
                    if (nums[i + 1] > nums[0])
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }

        return true;
    }
}