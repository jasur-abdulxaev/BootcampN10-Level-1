var isHappyNumber = 91;
var isHappyN = new Solution();
Console.WriteLine(isHappyN.IsHappy(isHappyNumber));

public class Solution
{
    public bool IsHappy(int n)
    {
        if (n < 10)
            return n == 1 || n == 7;

        int sum = 0;
        while (n > 0)
        {
            int digit = n % 10;
            sum += digit * digit;
            n /= 10;
        }
        return IsHappy(sum);
    }
}