/**
 * O(n)
 * O(n)
 */

using System;

public class Solution
{
    public int ClimbStairs(int n)
    {
        int[][] matrix_expo(int[][] A, int K)
        {
            int[][] result = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                result[i] = new int[A[i].Length];
                for (int j = 0; j < A[i].Length; j++)
                {
                    result[i][j] = (i == j) ? 1 : 0;
                }
            }

            while (K > 0)
            {
                if (K % 2 == 1)
                {
                    result = matrix_mult(result, A);
                }
                A = matrix_mult(A, A);
                K /= 2;
            }

            return result;
        }

        int[][] matrix_mult(int[][] A, int[][] B)
        {
            int[][] result = new int[A.Length][];
            for (int i = 0; i < A.Length; i++)
            {
                result[i] = new int[B[0].Length];
                for (int j = 0; j < B[0].Length; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < A[i].Length; k++)
                    {
                        sum += A[i][k] * B[k][j];
                    }
                    result[i][j] = sum;
                }
            }

            return result;
        }

        int[][] T = new int[][] { new int[] { 1, 1 }, new int[] { 1, 0 } };
        return matrix_mult(new int[][] { new int[] { 1, 0 } }, matrix_expo(T, n))[0][0];
    }
}
