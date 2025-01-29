var s = new Solution();
int[] answers = [1, 1, 2];
var result = s.NumRabbits(answers);
Console.WriteLine(result);

public class Solution
{
    public int NumRabbits(int[] answers)
    {
        var ans = new Dictionary<int, int>();
        var sum = 0;
        for (int i = 0; i < answers.Count(); ++i)
        {
            if (answers[i] == 0)
            {
                sum++;
                continue;
            }
            var answer = answers[i];
            if (!ans.ContainsKey(answer))
            {
                sum += answer + 1;
                ans[answer] = 1;
                continue;
            }
            if (ans[answer] < answer + 1)
            {
                ans[answer] += 1;
                continue;
            }
            if (ans[answer] == answer + 1)
            {
                ans[answer] = 1;
                sum += answer + 1;
            }
        }
        return sum;
    }
}