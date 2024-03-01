/** SOLUTION ONE **/

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        double Returns = 0;
        int c1 = 0, c2 = 0, num, count;
        double midPoint = (nums1.Length + nums2.Length) / 2.0;

        for (count = 0; count <= midPoint; count++)
        {
            num = (c1 < nums1.Length && (c2 >= nums2.Length || nums1[c1] < nums2[c2])) ? nums1[c1++] : nums2[c2++];
            if (count >= midPoint - 1) Returns += num / (2 - (midPoint * 2 % 2));
        }

        return (Returns);
    }
}

/** SOLUTION TWO **/

public class Solution {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var mergedArray = Merge(nums1, nums2);
            if (mergedArray.Length % 2 == 1)
                return mergedArray[mergedArray.Length / 2];
            else
                return (mergedArray[mergedArray.Length / 2] + mergedArray[mergedArray.Length / 2 - 1]) / 2.0;
        }

        public int[] Merge(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length + nums2.Length];
            int i = 0, j = 0;
            while (i < nums1.Length || j < nums2.Length)
            {
                if (i < nums1.Length && j < nums2.Length)
                {
                    if (nums1[i] <= nums2[j])
                    {
                        result[i + j] = nums1[i];
                        i++;
                    }
                    else
                    {
                        result[i + j] = nums2[j];
                        j++;
                    }
                    continue;
                }

                if (i < nums1.Length)
                {
                    result[i + j] = nums1[i];
                    i++;
                    continue;
                }
                
                if (j < nums2.Length)
                {
                    result[i + j] = nums2[j];
                    j++;
                    continue;
                }
            }
            return result;
        }
    }
