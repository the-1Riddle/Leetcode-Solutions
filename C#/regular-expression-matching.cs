

/** SOLUTION TWO **/

public class Solution {
    public bool IsMatch(string s, string p)
    {
        bool[,] dp = new bool[p.Length + 1,s.Length + 1];

        for (int i = 0; i < dp.GetLength(0); i++)
        {
            for (int j = 0; j < dp.GetLength(1); j++)
            {
                if(i==0 && j == 0)
                {
                    //first corner cell
                    dp[i,j] = true;
                } else if (i == 0)
                {
                    //first row
                    dp[i, j] = false;
                } else if (j == 0)
                {
                    char pc = p[i - 1];
                    if(pc == '*')
                    {
                        dp[i, j] = dp[i - 2, j];
                    }
                    else
                    {
                        dp[i, j] = false;
                    }
                }
                else
                {
                  
                    char pc = p[i-1];
                    char sc = s[j-1];

                    if (pc == '*')
                    {
                        dp[i,j] = dp[i - 2, j];

                        var pslc = p[i-2];
                        if(pslc == '.' || pslc == sc){
                            dp[i,j]=dp[i,j]||dp[i,j-1];
                        }
                    } else if (pc == '.')
                    {
                        dp[i, j] = dp[i - 1, j - 1];

                    } else if (pc == sc)
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    } else
                    {
                        dp[i, j] = false;
                    }


                }
            }
        }

        return dp[p.Length,s.Length];
    }
}
