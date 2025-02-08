
using System.Collections.ObjectModel;

public class NumberContainers
{
    private Dictionary<int, int> cache = new();
    private Dictionary<int, HashSet<int>> values = new();
    private Dictionary<int, int> dict = new();

    public NumberContainers()
    {

    }

    public void Change(int index, int number)
    {
        if (cache.ContainsKey(number))
        {
            cache.Remove(number);
        }
        if (dict.ContainsKey(index))
        {
            var oldNum = dict[index];
            if (cache.ContainsKey(oldNum))
            {
                cache.Remove(oldNum);
            }
            values[oldNum].Remove(index);
            if (!values[oldNum].Any())
            {
                values.Remove(oldNum);
            }

        }
        dict[index] = number;
        if (values.ContainsKey(number))
        {
            values[number].Add(index);
        }
        else
        {
            values[number] = [index];
        }
    }

    public int Find(int number)
    {
        if (cache.ContainsKey(number))
        {
            return cache[number];
        }
        var index = FindInternal(number);
        cache[number] = index;
        return index;
    }

    private int FindInternal(int number)
    {
        if (values.ContainsKey(number))
        {
            return values[number].OrderBy(x => x).First();
        }
        return -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */