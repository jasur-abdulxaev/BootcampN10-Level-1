
char[] s = new char[]
{
    'A','b', 'b', 'o', 's'
};



Console.WriteLine(new string(s));

Solution sol = new Solution();
sol.ReverseString(s);
Console.WriteLine(new string(s));

public class Solution
{
    public void ReverseString(char[] s)
    {
        int left = 0, right = s.Length - 1;
        while (left < right)
        {
            (s[left], s[right]) = (s[right], s[left]);
            left++;
            right--;
        }
    }
}

