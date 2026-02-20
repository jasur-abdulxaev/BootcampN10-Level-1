int number = 1234;
int number2 = -1234;

var result = new Solution().Reverse(number);
var result2 = new Solution().Reverse(number2);

Console.WriteLine(result);
Console.WriteLine(result2);


public class Solution
{
    public int Reverse(int x)
    {
        int r = 0;
        while (x != 0)
        {
            if (r < int.MinValue / 10 || r > int.MaxValue / 10) return 0;

            r = r * 10 + x % 10;
            x = x / 10;
        }
        return r;
    }
}

