var s = new Solution();
Console.WriteLine(s.Reverse(1563847412));

public class Solution
{
    public int Reverse(int x)
    {
        var l = new Queue<int>();

        var len = 0;
        while (x != 0)
        {
            l.Enqueue(x % 10);
            x /= 10;
            len++;
        }
        int sum = 0;
        checked
        {
            while (len > 0)
            {
                try
                {
                    sum += (int)Math.Pow(10, --len) * l.Dequeue();
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }


        return sum;
    }
}