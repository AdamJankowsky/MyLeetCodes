using System.Text;

var s = new Solution();
var word = "PAYPALISHIRING";
var numRows = 3;

var result = s.Convert(word, numRows);

Console.WriteLine(result);

public class Solution
{
    public string Convert(string s, int numRows)
    {
        if (s.Length == 1)
        {
            return s;
        }
        if (numRows == 1)
        {
            return s;
        }
        if (s.Length <= numRows)
        {
            return s;
        }

        var sb = new StringBuilder();
        var segmenntsNumber = numRows + numRows - 2;
        var columns = System.Convert.ToInt32(Math.Ceiling(System.Convert.ToDecimal(s.Length) / System.Convert.ToDecimal(segmenntsNumber)));
        for (int r = 0; r < numRows; ++r)
        {
            var startingPtr = r;
            var goUnder = true;
            var rowsOver = r;
            var rowsUnder = numRows - 1 - r;

            var cols = rowsOver == 0 || rowsUnder == 0 ? 1 : 2;

            for (int c = 0; c < columns * cols; ++c)
            {
                if (startingPtr > s.Length - 1)
                {
                    break;
                }
                if (goUnder && rowsUnder == 0)
                {
                    goUnder = !goUnder;
                }
                else if (!goUnder && rowsOver == 0)
                {
                    goUnder = !goUnder;
                }

                sb.Append(s[startingPtr]);
                if (goUnder)
                {
                    startingPtr += CharsToSkip(rowsUnder) + 1;
                }
                else
                {
                    startingPtr += CharsToSkip(rowsOver) + 1;
                }
                goUnder = !goUnder;
            }
        }

        return sb.ToString();

    }




    public int CharsToSkip(int rows)
    {
        if (CharsToSkipDict.ContainsKey(rows))
        {
            return CharsToSkipDict[rows];
        }

        var r = rows + rows - 1;
        CharsToSkipDict[rows] = r;
        return r;
    }

    public Dictionary<int, int> CharsToSkipDict { get; } = new Dictionary<int, int>()
    {
        [0] = -1,
        [1] = 1,
        [2] = 3,
    };
}