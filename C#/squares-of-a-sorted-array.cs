public class Solution
{
    public int[] SortedSquares(int[] nums)
    {
        int right = BinarySearchLeft(nums, 0);
        int left = right - 1;
        int[] result = new int[nums.Length];

        int index = 0;
        while (left >= 0 || right < nums.Length)
        {
            if (right == nums.Length || (left >= 0 && Math.Pow(nums[left], 2) < Math.Pow(nums[right], 2)))
            {
                result[index++] = (int)Math.Pow(nums[left], 2);
                left--;
            }
            else
            {
                result[index++] = (int)Math.Pow(nums[right], 2);
                right++;
            }
        }

        return result;
    }

    private int BinarySearchLeft(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length;

        while (left < right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }

        return left;
    }
}

/** SOLUTION TWO **/

public class Solution {
    public int[] SortedSquares(int[] nums) {
        
        int[] result = new int[nums.Length];

        int left  = 0;
        int right = nums.Length-1;

        for (int i=nums.Length-1; i>=0; i--) {

            int square;

            if (Math.Abs(nums[left]) < Math.Abs(nums[right])) 
            {
                square = nums[right];
                right--;
            } else {
                square = nums[left];
                left++;
            }
            result[i] = square * square;
        }

        return result;
    }
}
