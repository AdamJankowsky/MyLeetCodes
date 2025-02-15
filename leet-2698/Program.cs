using System.Diagnostics.Contracts;

var s = new Solution();
Console.WriteLine(s.PunishmentNumber(703));


public class Solution
{
    private LinkedList<(int i, int pow)> cache;
    private HashSet<int> wrongNumbers = new();

    public Solution()
    {
        cache = new();
        cache.AddFirst((1, 1));
    }

    public int PunishmentNumber(int n)
    {
        int sum = 0;
        var cachePtr = cache.First;
        int i = cachePtr.Value.i;
        while (i <= n)
        {
            if (cachePtr is not null)
            {
                sum += cachePtr.Value.pow;
                if (cachePtr.Next is not null)
                {
                    cachePtr = cachePtr.Next;
                    i = cachePtr.Value.i;
                    continue;
                }
                else
                {
                    cachePtr = null;
                    i++;
                    continue;
                }
            }

            if (!wrongNumbers.Contains(i) && CheckIfPartitions(i))
            {
                var pow = i * i;
                sum += pow;
                cache.AddLast((i, pow));
            }
            else
            {
                wrongNumbers.Add(i);
            }
            i++;
        }

        return sum;
    }

    private bool CheckIfPartitions(int i)
    {
        var sums = Sums(i * i);

        return sums.Contains(i);
    }

    private int[] Sums(int i)
    {
        if (i < 10)
        {
            return [i];
        }
        if (i < 100)
        {
            return [i, (i / 10 + i % 10)];
        }
        var list = new List<int>();
        var j = 10;
        while (true)
        {
            var part1 = i / j;
            var part2 = i % j;

            list.Add(part1 + part2);
            if (part1 == 0)
            {
                break;
            }

            foreach (var sum in Sums(part1))
            {
                list.Add(part2 + sum);
            }

            foreach (var sum in Sums(part2))
            {
                list.Add(part1 + sum);
            }
            j *= 10;
        }

        return list.ToArray();
    }
}