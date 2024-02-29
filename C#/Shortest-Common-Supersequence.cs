/**
 * Runtime: 66 ms
 * Memory Usage: 47.8 MB
 */

public class Solution {
    public string ShortestCommonSupersequence(string s1, string s2) {
        int n = s1.Length;
        int m = s2.Length;
        int[,] dp = new int[n + 1, m + 1];

        for (int i = 1; i <= n; i++) {
            for (int j = 1; j <= m; j++) {
                if (s1[i - 1] == s2[j - 1]) {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                } else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }

        string result = "";
        int x = n, y = m;

        while (x > 0 && y > 0) {
            if (s1[x - 1] == s2[y - 1]) {
                result += s1[x - 1];
                x--;
                y--;
            } else if (dp[x - 1, y] > dp[x, y - 1]) {
                result += s1[x - 1];
                x--;
            } else {
                result += s2[y - 1];
                y--;
            }
        }

        while (x > 0) {
            result += s1[x - 1];
            x--;
        }

        while (y > 0) {
            result += s2[y - 1];
            y--;
        }

        char[] resultArray = result.ToCharArray();
        Array.Reverse(resultArray);
        return new string(resultArray);
    }
}
