var s = new Solution();

Console.WriteLine(s.RemoveOccurrences("kpygkivtlqoockpygkivtlqoocssnextkqzjpycbylkaondsskpygkpygkivtlqoocssnextkqzjpkpygkivtlqoocssnextkqzjpycbylkaondsycbylkaondskivtlqoocssnextkqzjpycbylkaondssnextkqzjpycbylkaondshijzgaovndkjiiuwjtcpdpbkrfsi", "kpygkivtlqoocssnextkqzjpycbylkaonds"));

public class Solution {
    public string RemoveOccurrences(string s, string part) {
        int[] lps = new int[part.Length];

        var current = 1;
        var prefixLength = 0;
        while(true)
        {
            if(current == part.Length)
            {
                break;
            }
            if(part[current] == part[prefixLength])
            {
                prefixLength++;
                lps[current] = prefixLength;
                current++;
                continue;
            }
            else
            {
                if(prefixLength != 0)
                {
                    prefixLength = lps[prefixLength-1];
                }
                else
                {
                    lps[current] = 0;
                    current++;
                }
            }
        }
        
        var charStack = new Stack<char>();
        var patternIndexes = new int[s.Length +1];
        var patternIndex = 0;
        int strIndex =0;
        while(strIndex<s.Length)
        {
            var currentChar = s[strIndex];
            charStack.Push(currentChar);
            if(currentChar == part[patternIndex])
            {
                patternIndexes[charStack.Count] = ++patternIndex;
                if(patternIndex == part.Length)
                {
                    for(int j= 0; j<part.Length; ++j)
                        charStack.Pop();
                    patternIndex = charStack.Count == 0 ? 0 : patternIndexes[charStack.Count];
                }
            }
            else
            {
                if(patternIndex != 0)
                {
                    patternIndex = lps[patternIndex-1];
                    strIndex--;
                    charStack.Pop();
                }
                else
                {
                    patternIndexes[charStack.Count] = 0;
                }
            }

            strIndex++;
        }

        var result = new Stack<char>(charStack);
        var resultArr = new char[result.Count];
        var resultArrPtr = 0;
        while(result.Count >0)
        {
            resultArr[resultArrPtr++] = result.Pop();
        }

        return new string (resultArr);
    }
}