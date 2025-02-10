public class Solution {
    public string ClearDigits(string s) {
        var resultArr = new char[s.Length];
        int resultsPtr = 0;
        for(int i = 0; i<s.Length; ++i)
        {
            if(!Char.IsDigit(s[i]))
            {
                resultArr[resultsPtr++] = s[i];
                continue;
            }
            if(resultsPtr == 0)
            {
                continue;
            }
            resultsPtr--;
            continue;
        }
        var result = resultArr.AsSpan(0, resultsPtr);
        return new string(result);
    }
}