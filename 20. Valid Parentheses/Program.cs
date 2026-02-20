
string str = "(({{[}]}))";

bool isValid = new Solution().IsValid(str);
Console.WriteLine(isValid);

public class Solution
{
    public bool IsValid(string s)
    {
        while (s.Contains("()") || s.Contains("[]") || s.Contains("{}"))
        {
            s = s.Replace("()", "").Replace("[]", "").Replace("{}", "");
        }

        return s.Length == 0;
    }
}