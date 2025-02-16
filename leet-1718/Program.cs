

var s = new Solution();
Console.WriteLine(string.Join(", ", s.ConstructDistancedSequence(12)));


public class Solution
{
    public int[] ConstructDistancedSequence(int n)
    {
        if (n == 1)
        {
            return [1];
        }

        int iteration = 0;
        var arrays = new List<int[]>();
        for (int i = n; i > 1; --i)
        {
            var arr = new int[(n * 2) - 1];
            var placedNums = new HashSet<int>();
            var placements = new Dictionary<int, int>();
            arr[0] = i;
            placedNums.Add(i);
            if (i != 1)
            {
                placements[i] = i;
            }

            arrays.AddRange(GetArrays(arr, iteration + 1, placements, placedNums, n));
            if (arrays.Any())
            {
                break;
            }
        }

        arrays.Sort(new ArrComparer());


        return arrays.Last();
    }

    private int[][] GetArrays(int[] arr, int iteration, Dictionary<int, int> placements, HashSet<int> placedNums, int n)
    {
        var list = new List<int[]>();
        if (iteration == (n * 2) - 1)
        {
            return [arr];
        }

        if (placements.ContainsKey(iteration))
        {
            arr[iteration] = placements[iteration];
            return GetArrays(arr, iteration + 1, placements, placedNums, n);
        }

        for (int j = n; j > 0; --j)
        {
            if (placedNums.Contains(j))
            {
                continue;
            }

            var newArr = arr.ToArray();
            newArr[iteration] = j;
            var newPlacements = new Dictionary<int, int>(placements);
            if (j != 1)
            {
                if (newPlacements.ContainsKey(iteration + j) || (iteration + j > ((n * 2) - 2)))
                {
                    continue;
                }
                newPlacements[iteration + j] = j;
            }
            var newPlaced = new HashSet<int>(placedNums);
            newPlaced.Add(j);
            var arrs = GetArrays(newArr, iteration + 1, newPlacements, newPlaced, n);
            if (arrs.Any())
            {
                return arrs;
            }
        }


        return list.ToArray();
    }
}

class ArrComparer : IComparer<int[]>
{
    public int Compare(int[]? x, int[]? y)
    {
        var length = x.Length;
        for (int i = 0; i < length; ++i)
        {
            var el1 = x[i];
            var el2 = y[i];
            if (el1 < el2)
            {
                return -1;
            }
            else if (el1 == el2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        return 0;
    }
}
