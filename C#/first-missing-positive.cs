/**
    O(n)
    O(1)
*/
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int i = 0;
        while (i < nums.Length) {
            if (nums[i] > 0 && nums[i] - 1 < nums.Length && nums[i] != nums[nums[i] - 1]) {
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            } else {
                i++;
            }
        }

        for (int j = 0; j < nums.Length; j++) {
            if (nums[j] != j + 1) {
                return j + 1;
            }
        }

        return nums.Length + 1;
    }
}


/* SOLUTION TWO */

public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;

        for (int i = 0; i < n; ++i) {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i]) {
                Swap(ref nums[i], ref nums[nums[i] - 1]);
            }
        }

        for (int i = 0; i < n; ++i) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }

        return n + 1;
    }

    private void Swap(ref int a, ref int b) {
        int temp = a;
        a = b;
        b = temp;
    }
}

/* SOLUTION THREE WHICH MIGHT BE THE BEST OF ALL */

public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int n = nums.Length;
        
        for (int i = 0; i < n; i++) {
            while (nums[i] > 0 && nums[i] <= n && nums[nums[i] - 1] != nums[i]) {
                int temp = nums[nums[i] - 1];
                nums[nums[i] - 1] = nums[i];
                nums[i] = temp;
            }
        }

        for (int i = 0; i < n; i++) {
            if (nums[i] != i + 1) {
                return i + 1;
            }
        }

        return n + 1;
    }
}
