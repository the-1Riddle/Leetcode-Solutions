/**
 * Runtime: 63 ms
 * Memory Usage: 49.3 MB
 */

/* solving the first gives you an hint to the other */
public class Solution
{
    public string IntToRoman(int num)
    {
        Dictionary<int, string> numeralMap = new Dictionary<int, string>()
        {
            {1, "I"},
            {4, "IV"},
            {5, "V"},
            {9, "IX"},
            {10, "X"},
            {40, "XL"},
            {50, "L"},
            {90, "XC"},
            {100, "C"},
            {400, "CD"},
            {500, "D"},
            {900, "CM"},
            {1000, "M"}
        };

        List<int> keySet = new List<int>(numeralMap.Keys);
        keySet.Sort((a, b) => b.CompareTo(a));

        List<string> result = new List<string>();

        while (num > 0)
        {
            foreach (int key in keySet)
            {
                while (num / key > 0)
                {
                    num -= key;
                    result.Add(numeralMap[key]);
                }
            }
        }

        return string.Join("", result);
    }
}
