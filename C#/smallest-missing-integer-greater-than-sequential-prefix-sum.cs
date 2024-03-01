/**
    O(n)
    O(n)
*/
public class Solution
{
    public int MissingInteger(int[] nums)
    {
        int total = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 1] + 1)
            {
                break;
            }
            total += nums[i];
        }

        HashSet<int> lookup = new HashSet<int>(nums);
        while (lookup.Contains(total))
        {
            total += 1;
        }

        return total;
    }
}
