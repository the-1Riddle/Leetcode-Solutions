/**
 * Runtime: 98 ms
 * Memory Usage: 52.6 MB
*/
using System;
using System.Collections.Generic;

public class Solution
{
    public bool CanCross(int[] stones)
    {
        Dictionary<int, bool>[] dp = new Dictionary<int, bool>[stones.Length];
        for (int i = 0; i < dp.Length; i++)
        {
            Dictionary<int, bool> map = new Dictionary<int, bool>();
            dp[i] = map;
        }
        bool ans = JumpLast(stones, 0, 0, dp);
        return ans;
    }

    public bool JumpLast(int[] stones, int idx, int jumps, Dictionary<int, bool>[] dp)
    {
        if (idx == stones.Length - 1)
        {
            return true;
        }
        else if (idx > stones.Length - 1)
        {
            return false;
        }

        if (dp[idx].ContainsKey(jumps))
        {
            return dp[idx][jumps];
        }

        dp[idx][jumps] = false;

        for (int i = idx + 1; i < stones.Length; i++)
        {
            if (stones[i] - stones[idx] >= jumps - 1 && stones[i] - stones[idx] <= jumps + 1)
            {
                bool jump1 = JumpLast(stones, i, stones[i] - stones[idx], dp);
                if (jump1)
                {
                    dp[idx][jumps] = true;
                    return true;
                }
            }
            else if (stones[i] - stones[idx] > jumps + 1)
            {
                break;
            }
        }

        return false;
    }
}
