/**
  O(n * k), k is the length of the common prefix
*/
public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        {
            return "";
        }

        for (int i = 0; i < strs[0].Length; i++)
        {
            foreach (string str in strs[1..])
            {
                if (i >= str.Length || str[i] != strs[0][i])
                {
                    return strs[0].Substring(0, i);
                }
            }
        }

        return strs[0];
    }
}
