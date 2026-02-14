

int[] nums = new[]
{
    1, 2, 3, 4, 5, 6,
    1, 2, 4, 5, 6
};

int result = new Solution().SingleNumber(nums);
Console.WriteLine(result);

public class Solution
{
    public int SingleNumber(int[] nums)
    {
        int result = 0;
        foreach (int num in nums)
        {
            result ^= num;
        }
        return result;
    }
}