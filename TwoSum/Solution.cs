namespace TwoSum;

public sealed class Solution
{
    public int[] TwoSumNaive(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        return [];
    }


    public int[] TwoSumSpans(int[] nums, int target)
    {
        var arraySpan = nums.AsSpan();
        
        for (int i = 0; i < arraySpan.Length - 1; i++)
        {
            int number = arraySpan[i];

            int searchTarget = target - number;

            var span = arraySpan[(i + 1)..];

            var indexOfSearchTarget = span.IndexOf(searchTarget);

            if (indexOfSearchTarget is not -1)
                return [i, indexOfSearchTarget + i + 1];
        }

        return [];
    }
    
    public int[] TwoSumDictionary(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>(nums.Length-1);
        
        var arraySpan = nums.AsSpan();
        
        for (int i = 0; i < arraySpan.Length; i++)
        {
            int number = arraySpan[i];

            int searchTarget = target - number;
            
            var indexOfSearchTarget = dict.GetValueOrDefault(searchTarget, -1);
            if (indexOfSearchTarget is not -1)
                return [indexOfSearchTarget, i];
            
            dict.TryAdd(number, i);
        }

        return [];
    }
}