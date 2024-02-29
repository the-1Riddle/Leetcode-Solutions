/**
 * Runtime: 27 ms
 * Memory Usage: 5.4 MB
 */
/**
 * longestCommonSubsequence - the entry point
 *
 * Return: the length of their longest common subsequence
 */
#define max(a, b) ((a) > (b) ? (a) : (b))

int longestCommonSubsequence(char* text1, char* text2) {
    int m = strlen(text1);
    int n = strlen(text2);

    if (m < n) {
        /* Swap text1 and text2 */
        char* temp = text1;
        text1 = text2;
        text2 = temp;

        /* Swap m and n */
        int temp_len = m;
        m = n;
        n = temp_len;
    }

    int dp[2][n + 1];
    int i, j;

    for (i = 0; i <= m; ++i) {
        for (j = 0; j <= n; ++j) {
            if (i == 0 || j == 0)
                dp[i % 2][j] = 0;
            else if (text1[i - 1] == text2[j - 1])
                dp[i % 2][j] = dp[(i - 1) % 2][j - 1] + 1;
            else
                dp[i % 2][j] = max(dp[(i - 1) % 2][j], dp[i % 2][j - 1]);
        }
    }

    return dp[m % 2][n];
}
