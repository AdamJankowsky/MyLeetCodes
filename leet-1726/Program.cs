using System.Runtime.CompilerServices;

var s = new Solution();
int[] nums = [1, 2, 4, 5, 10];

Console.WriteLine(s.TupleSameProduct(nums));


public class Solution
{
    public int TupleSameProduct(int[] nums)
    {
        var n = nums.Length;

        var products = new Dictionary<int, int>();

        for (int i = 0; i < n; ++i)
        {
            for (int j = 0; j < n; ++j)
            {
                if (i == j)
                {
                    continue;
                }

                (int a, int b) = (nums[i], nums[j]);
                var product = a * b;
                if (products.ContainsKey(product))
                {
                    products[product] += 1;
                }
                else
                {
                    products[product] = 1;
                }
            }
        }

        return products.Values.Select(c =>
        {
            return (c * (c - 1)) - c;
        }).Sum();
    }
}