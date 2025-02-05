
Console.WriteLine((new Solution()).AreAlmostEqual("bank", "kanb"));

public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        var n = s1.Length;

        int wrongCharsPtr = 0;
        (char a, char b)[] wrongChars = new (char a, char b)[2];

        for (int i = 0; i < n; ++i)
        {
            if (s1[i] == s2[i])
            {
                continue;
            }
            else
            {
                if (wrongCharsPtr == 2)
                {
                    return false;
                }
                wrongChars[wrongCharsPtr++] = (s1[i], s2[i]);
            }
        }

        return wrongCharsPtr == 0 || (wrongChars[0].a, wrongChars[0].b) == (wrongChars[1].b, wrongChars[1].a);

    }
}