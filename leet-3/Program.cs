
var s = new Solution();
var str = "abcabcbb";
var result = s.LengthOfLongestSubstring(str);
Console.WriteLine(result);

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        if (s.Length == 1)
        {
            return 1;
        }
        var chars = new Dictionary<char, int>();
        var longestSum = 0;
        var currentSum = 0;
        var charPtr = 0;
        while (true)
        {
            if (charPtr == s.Length)
            {
                break;
            }
            if (!chars.ContainsKey(s[charPtr]))
            {
                chars[s[charPtr]] = charPtr;
                currentSum++;
                charPtr++;
                continue;
            }
            else
            {
                if (currentSum > longestSum)
                {
                    longestSum = currentSum;
                }

                charPtr = chars[s[charPtr]] + 1;
                chars.Clear();
                currentSum = 0;
            }

        }


        return Math.Max(currentSum, longestSum);

    }
}