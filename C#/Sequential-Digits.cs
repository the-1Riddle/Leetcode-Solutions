/**
 * Runtime: 65 ms
 * Memory Usage: 38 MB
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> result = new List<int>();
        Queue<int> q = new Queue<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9});
        while (q.Count > 0) {
            int num = q.Dequeue();
            if (num > high) {
                continue;
            }
            if (low <= num) {
                result.Add(num);
            }
            if (num % 10 + 1 < 10) {
                q.Enqueue(num * 10 + num % 10 + 1);
            }
        }
        return result;
    }
}
