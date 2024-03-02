public class Solution
{
    /**
     * Merges two sorted arrays in-place.
     * @param nums1: First array containing m elements
     * @param m: Length of nums1
     * @param nums2: Second array containing n elements
     * @param n: Length of nums2
     */
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int last = m + n - 1;
        int i = m - 1;
        int j = n - 1;

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[last] = nums1[i];
                last--;
                i--;
            }
            else
            {
                nums1[last] = nums2[j];
                last--;
                j--;
            }
        }

        while (j >= 0)
        {
            nums1[last] = nums2[j];
            last--;
            j--;
        }
    }
}


/*** SOLUTION TWO ***/

public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if (n == 0) {
            return;
        }

        if (m == 0) {
            for (var i = 0; i < n; i++) {
                nums1[i] = nums2[i];
            }
            return;
        }

        var end = m + n - 1;
        var ind1 = m - 1;
        var ind2 = n - 1;
        
        while (end >= 0) {
            if (ind1 < 0 && ind2 < 0) {
                return;
            } 
            else if (ind1 < 0) {
                nums1[end] = nums2[ind2];
                ind2--;
            } 
            else if (ind2 < 0) {
                nums1[end] = nums1[ind1];
                ind1--;   
            }
            else if (nums1[ind1] > nums2[ind2]) {
                nums1[end] = nums1[ind1];
                ind1--;
            } else {
                nums1[end] = nums2[ind2];
                ind2--;
            }
            
            end--;
        }
    }
}
