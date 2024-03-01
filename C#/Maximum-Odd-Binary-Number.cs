/* O(n)
  O(1)
  */

public class Solution
{
    public string MaximumOddBinaryNumber(string s)
    {
        int n = s.Count(c => c == '1');
        return new string('1', n - 1) + new string('0', s.Length - n) + '1';
    }
}
