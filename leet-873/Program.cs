var s = new Solution();

Console.WriteLine(s.LenLongestFibSubseq([2, 4, 5, 6, 7, 8, 11, 13, 14, 15, 21, 22, 34]));


public class Solution
{
    public int LenLongestFibSubseq(int[] arr)
    {
        var map = new HashSet<int>(arr);
        var longest = 0;
        for (int i = 0; i < arr.Length - 1; ++i)
        {
            for (int k = i + 1; k < arr.Length; ++k)
            {
                var currentLen = 1;
                var fib = arr[i] + arr[k];
                var lastFib = arr[k];

                while (true)
                {
                    currentLen++;
                    if (map.Contains(fib))
                    {
                        var temp = lastFib;
                        lastFib = fib;
                        fib = fib + temp;
                        continue;
                    }
                    else
                    {
                        longest = Math.Max(longest, currentLen);
                        break;
                    }
                }
            }

        }

        return longest > 2 ? longest : 0;
    }
}