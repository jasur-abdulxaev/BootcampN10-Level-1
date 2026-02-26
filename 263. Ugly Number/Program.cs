
var number = 36;
var result = new Solution();
var answer = result.IsUgly(number);
var answer2 = result.NthUglyNumber(number);
Console.WriteLine(answer);
Console.WriteLine(answer2);

public class Solution
{
    public bool IsUgly(int n)
    {
        if (n <= 0) return false;

        while (n > 1 && (n % 2 == 0)) n /= 2;
        while (n > 1 && (n % 3 == 0)) n /= 3;
        while (n > 1 && (n % 5 == 0)) n /= 5;

        return n == 1;
    }

    public int NthUglyNumber(int n)
    {
        int[] ugly = new int[n];
        ugly[0] = 1;

        int i2 = 0, i3 = 0, i5 = 0;

        for (int i = 1; i < n; i++)
        {
            int next2 = ugly[i2] * 2;
            int next3 = ugly[i3] * 3;
            int next5 = ugly[i5] * 5;

            int min = Math.Min(next2, Math.Min(next3, next5));
            ugly[i] = min;

            if (min == next2) i2++;
            if (min == next3) i3++;
            if (min == next5) i5++;
        }

        return ugly[n - 1];
    }

}