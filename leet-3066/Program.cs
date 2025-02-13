

var s = new Solution();

Console.WriteLine(s.MinOperations([999999999, 999999999, 999999999], 1000000000));


public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        var pq = new PriorityQueue<long, long>();
        for (int i = 0; i < nums.Length; ++i)
        {
            pq.Enqueue(nums[i], nums[i]);
        }

        var loops = 0;
        while (pq.Peek() < k)
        {
            var first = pq.Dequeue();
            var second = pq.Dequeue();

            long el = first < second ? (first * 2) + second : (second * 2) + first;

            pq.Enqueue(el, el);
            loops++;
        }

        return loops;
    }

}