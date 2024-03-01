public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int i=0,count=0,maxCount=0;
        var m = new Dictionary<char, int>();
        for(int k=0;k<s.Length;k++){
            m[s[k]]=-1;
        }
        while(i<s.Length){
            if(m[s[i]]==-1){
                count++;
                m[s[i]]=i;
            }
            else{
                count=i-m[s[i]];
                foreach(var key in m.Keys.ToList()){
                    if(m[key]<m[s[i]]){
                        m[key]=-1;
                    }
                }
                m[s[i]]=i;
            }
            if(count>maxCount)
                maxCount=count;
            i++;
        }
        return maxCount;
    }
}
