/**
 * Runtime: 171 ms
Memory Usage: 54.5 MB
*/

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int MinFallingPathSum(int[][] grid)
    {
        for (int i = 1; i < grid.Length; i++)
        {
            int[] smallestTwo = grid[i - 1].OrderBy(x => x).Take(2).ToArray();
            for (int j = 0; j < grid[0].Length; j++)
            {
                grid[i][j] += (grid[i - 1][j] == smallestTwo[0]) ? smallestTwo[1] : smallestTwo[0];
            }
        }

        return grid.Last().Min();
    }
}
