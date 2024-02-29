/**
 * Runtime: 91 ms
Memory Usage: 47.3 MB
*/

using System;

public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        for (int i = 1; i < matrix.Length; i++) {
            for (int j = 0; j < matrix[i].Length; j++) {
                matrix[i][j] += Min(
                    GetSafeValue(matrix, i - 1, j - 1),
                    GetSafeValue(matrix, i - 1, j),
                    GetSafeValue(matrix, i - 1, j + 1)
                );
            }
        }
        return GetMinValueInLastRow(matrix);
    }

    private int Min(params int[] values) {
        int min = values[0];
        for (int i = 1; i < values.Length; i++) {
            min = Math.Min(min, values[i]);
        }
        return min;
    }

    private int GetSafeValue(int[][] matrix, int i, int j) {
        if (i >= 0 && i < matrix.Length && j >= 0 && j < matrix[i].Length) {
            return matrix[i][j];
        }
        return int.MaxValue;
    }

    private int GetMinValueInLastRow(int[][] matrix) {
        int min = matrix[matrix.Length - 1][0];
        for (int j = 1; j < matrix[matrix.Length - 1].Length; j++) {
            min = Math.Min(min, matrix[matrix.Length - 1][j]);
        }
        return min;
    }
}
