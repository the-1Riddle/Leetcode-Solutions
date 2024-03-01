

/**  SOLUTION TWO  **/

public class Solution 
{
    public string Convert(string s, int numRows) 
    {
        if(numRows == 1 || s.Length <= 1)
        {
            return s;
        }

        string[] solution = new string[numRows];

        int i = 0, direction = 1;
        foreach(char c in s)
        {
            solution[i] += c;

            i += direction;

            if (i == numRows-1 || i==0) direction *= -1;
        }

        return string.Concat(solution);
    }
}
