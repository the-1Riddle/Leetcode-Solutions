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


/**
 * Runtime: 113 ms
 * Memory Usage: 115.2 MB
 */

using System;
using System.Collections.Generic;

public class Solution {
    public string ShortestCommonSupersequence(string str1, string str2) {
        if (string.IsNullOrEmpty(str1) && string.IsNullOrEmpty(str2)) {
            return string.Empty;
        } else if (string.IsNullOrEmpty(str1)) {
            return str2;
        } else if (string.IsNullOrEmpty(str2)) {
            return str1;
        }

        int m = str1.Length, n = str2.Length;
        int[,] dp = new int[2, n + 1];
        Tuple<int, int, char>[,] bt = new Tuple<int, int, char>[m + 1, n + 1];

        for (int i = 0; i < m; ++i) {
            bt[i + 1, 0] = Tuple.Create(i, 0, str1[i]);
        }

        for (int j = 0; j < n; ++j) {
            bt[0, j + 1] = Tuple.Create(0, j, str2[j]);
        }

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (dp[i % 2, j + 1] > dp[1 - i % 2, j]) {
                    dp[1 - i % 2, j + 1] = dp[i % 2, j + 1];
                    bt[i + 1, j + 1] = Tuple.Create(i, j + 1, str1[i]);
                } else {
                    dp[1 - i % 2, j + 1] = dp[1 - i % 2, j];
                    bt[i + 1, j + 1] = Tuple.Create(i + 1, j, str2[j]);
                }

                if (str1[i] != str2[j]) {
                    continue;
                }

                if (dp[i % 2, j] + 1 > dp[1 - i % 2, j + 1]) {
                    dp[1 - i % 2, j + 1] = dp[i % 2, j] + 1;
                    bt[i + 1, j + 1] = Tuple.Create(i, j, str1[i]);
                }
            }
        }

        int x = m, y = n;
        char c = (char)0;
        var result = new List<char>();

        while (x != 0 || y != 0) {
            Tuple<int, int, char> tuple = bt[x, y];
            x = tuple.Item1;
            y = tuple.Item2;
            c = tuple.Item3;
            result.Add(c);
        }

        result.Reverse();
        return new string(result.ToArray());
    }
}


/**
 * Runtime: 142 ms
 * Memory Usage: 134.5 MB
 */

using System;
using System.Collections.Generic;

public class Solution {
    public string ShortestCommonSupersequence(string str1, string str2) {
        int m = str1.Length, n = str2.Length;
        int[,] dp = new int[2, n + 1];
        Tuple<int, int, char>[,] bt = new Tuple<int, int, char>[m + 1, n + 1];

        for (int i = 0; i < m; ++i) {
            bt[i + 1, 0] = Tuple.Create(i, 0, str1[i]);
        }

        for (int j = 0; j < n; ++j) {
            bt[0, j + 1] = Tuple.Create(0, j, str2[j]);
        }

        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (dp[i % 2, j + 1] > dp[(i + 1) % 2, j]) {
                    dp[(i + 1) % 2, j + 1] = dp[i % 2, j + 1];
                    bt[i + 1, j + 1] = Tuple.Create(i, j + 1, str1[i]);
                } else {
                    dp[(i + 1) % 2, j + 1] = dp[(i + 1) % 2, j];
                    bt[i + 1, j + 1] = Tuple.Create(i + 1, j, str2[j]);
                }

                if (str1[i] != str2[j]) {
                    continue;
                }

                if (dp[i % 2, j] + 1 > dp[(i + 1) % 2, j + 1]) {
                    dp[(i + 1) % 2, j + 1] = dp[i % 2, j] + 1;
                    bt[i + 1, j + 1] = Tuple.Create(i, j, str1[i]);
                }
            }
        }

        int x = m, y = n;
        char c = (char)0;
        var result = new List<char>();

        while (x != 0 || y != 0) {
            Tuple<int, int, char> tuple = bt[x, y];
            x = tuple.Item1;
            y = tuple.Item2;
            c = tuple.Item3;
            result.Add(c);
        }

        result.Reverse();
        return new string(result.ToArray());
    }
}
