



/*** SOLUTION TWO ****/

public class Solution {
    public int MyAtoi(string s) {
        const int maxCmp = int.MaxValue / 10;
        var num = 0;
        var sign = 1;

        var idx = 0;
        while (idx < s.Length && s[idx] == ' ')
            idx++;

        if (idx < s.Length && (s[idx] == '+' || s[idx] == '-'))
            sign = s[idx++] == '-' ? -1 : 1;

        while (idx < s.Length && s[idx] > 47 && s[idx] < 58)
        {
            if (num > maxCmp || (num == maxCmp && (s[idx] - '0') > 7))
                return sign == -1 ? int.MinValue : int.MaxValue;
            num = num * 10 + (s[idx++] - '0');
        }

        return num * sign;
    }
}
