/**
 * Runtime: 42 ms
 * Memory Usage: 49.3 MB
 * O(n)
 */

/* */
public class Solution
{
    public int RomanToInt(string s)
    {
        Dictionary<char, int> numeralMap = new Dictionary<char, int>()
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int decimalValue = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (i > 0 && numeralMap[s[i]] > numeralMap[s[i - 1]])
            {
                decimalValue += numeralMap[s[i]] - 2 * numeralMap[s[i - 1]];
            }
            else
            {
                decimalValue += numeralMap[s[i]];
            }
        }

        return decimalValue;
    }
}
