// See https://aka.ms/new-console-template for more information

/*
 * Example 1:

Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
Output: [1,2,2,3,5,6]

Input: nums1 = [1], m = 1, nums2 = [], n = 0
Output: [1]

Input: nums1 = [0], m = 0, nums2 = [1], n = 1
Output: [1]
 */

//ex1
var nums1_ = new[] { 1,2,3,0,0,0 };
var m_ = 3;

var nums2_ = new[] { 2,5,6 };
var n_ = 3;

Merge(nums1_, m_, nums2_, n_);
Console.WriteLine($"Example1: [{string.Join(", ", nums1_)}]");


//ex2
nums1_ = new[] { 1 };
m_ = 1;

nums2_ = new int[0];
n_ = 0;

Merge(nums1_, m_, nums2_, n_);
Console.WriteLine($"Example2: [{string.Join(", ", nums1_)}]");



//ex3
nums1_ = new[] { 0 };
m_ = 0;

nums2_ = new [] { 1 };
n_ = 1;

Merge(nums1_, m_, nums2_, n_);
Console.WriteLine($"Example3: [{string.Join(", ", nums1_)}]");

//ex4
nums1_ = new[] { -1, 0, 0, 3, 3, 3, 0, 0, 0 };
m_ = 6;
nums2_ = new[] { 1, 2, 2 };
n_ = 3;
Merge(nums1_, m_, nums2_, n_);
Console.WriteLine($"Example3: [{string.Join(", ", nums1_)}]");


/*
 * идем по массиву куда вставляем.
 * Если элемент в массиве меньше либо равен вставляемому - то идем далее
 * если элемент в массиве оказался больше - тогда с этого элемента массив сдвигаем направо, и вставляемый кладем в дырку.
 * следующий элемент для вставки гарантированно НЕ МЕНЬШЕ вставленного так что игнорим весь массив до вставленного элемента и вставленный элемент заодно.
 */

void Merge(int[] nums1, int m, int[] nums2, int n)
{
    int startSearchFrom = 0;
    int currentArrayLenght = m;
    bool atEmptyPosition = m is 0;

    foreach (var valueToInsert in nums2)
    {
        for (var index = startSearchFrom; index < currentArrayLenght + 1; index++)
        {
            if (atEmptyPosition)
            {
                nums1[index] = valueToInsert;
                startSearchFrom = index + 1;
                currentArrayLenght++;
                break;
            }

            if (nums1[index] <= valueToInsert)
            {
                if (index == currentArrayLenght - 1)
                    atEmptyPosition = true;
                continue;
            }


            MoveRight(nums1, index, currentArrayLenght);

            nums1[index] = valueToInsert;
            startSearchFrom = index + 1;
            currentArrayLenght++;

            break;
        }
    }
}

void MoveRight(int[] nums, int startIndex, int currentLength)
{
    for (int index = currentLength - 1; index >= startIndex; index--)
    {
        nums[index + 1] = nums[index];
    }
}