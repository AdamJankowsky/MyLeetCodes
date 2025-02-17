
var s = new Solution();

Console.WriteLine(s.NumTilePossibilities("AAB"));

public class Solution
{
    public int NumTilePossibilities(string tiles)
    {
        var nums = new Dictionary<char, int>();
        for (int i = 0; i < tiles.Length; ++i)
        {
            var ch = tiles[i];
            if (nums.ContainsKey(ch))
            {
                nums[ch]++;
                continue;
            }
            nums[ch] = 1;
        }

        var possibilities = GetPossibleCombinations(nums);

        return possibilities;
    }

    private int GetPossibleCombinations(Dictionary<char, int> nums)
    {
        if (!nums.Keys.Any())
        {
            return 0;
        }

        var sum = 0;
        foreach (var val in nums.ToList())
        {
            var newNums = new Dictionary<char, int>(nums);
            if (newNums[val.Key] == 1)
            {
                newNums.Remove(val.Key);
            }
            else
            {
                newNums[val.Key] -= 1;
            }

            sum += 1;
            sum += GetPossibleCombinations(newNums);
        }
        return sum;
    }
}