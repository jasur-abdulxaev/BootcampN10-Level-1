int[] digits = new int[]
{
    1, 2, 3, 4, 9
};

int[] result = new Solution().PlusOne(digits);

for (int i = 0; i < result.Length; i++)
{
    Console.WriteLine(result[i]);
}


public class Solution
{
    public int[] PlusOne(int[] digits)
    {

        // Oxiridan boshlab iterate qilamiz
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            // Agar 9 bo'lmasa shunchaki +1 qilib chiqamiz
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits;
            }

            // Agar 9 bo'lsa 0 ga aylantiramiz, carry davom etadi
            digits[i] = 0;
        }

        // [9,9,9] holat — hammasi 0 bo'ldi, boshiga 1 qo'shamiz
        int[] result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}
