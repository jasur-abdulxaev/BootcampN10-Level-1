
int[] nums = new[]
{
    1, 2, 3, 3, 4, 5, 5, 6
};

int result = new Solution().RemoveDuplicates(nums);
Console.WriteLine(result);


public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int writeIndex = 1;

        for (int readIndex = 1; readIndex < nums.Length; readIndex++)
            if (nums[readIndex] != nums[readIndex - 1])
                nums[writeIndex++] = nums[readIndex];

        return writeIndex;
    }
}