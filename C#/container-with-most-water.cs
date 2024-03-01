


/** solution two **/

public class Solution {
    public int MaxArea(int[] height) {
        int area = 0;
        int j=0;
        int k = height.Length-1;
        List<int> myListArea = new List<int>();
        while(j<k)
        {
            area = Math.Min(height[j], height[k]) * (k-j);
            myListArea.Add(area);
            if(height[j]<height[k])
        {
            j++;
        }
        else
        {
            k--;
        }
        }
        
        return myListArea.Max();
    }
}
