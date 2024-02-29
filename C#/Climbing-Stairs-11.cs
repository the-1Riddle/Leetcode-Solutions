/**
 * O(n)
 * O(n)
 */

using System;

public class Solution
{
    /**
     * number of stairs
     */
    public int ClimbStairs(int n)
    {
        int prev = 0, current = 1;
        for (int i = 0; i < n; i++)
        {
            int temp = current;
            current = prev + current;
            prev = temp;
        }
        return current;
    }
}
