﻿/*
 * Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.



Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].


Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]



Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]


Constraints:

2 <= nums.length <= 10^4
-10^9 <= nums[i] <= 10^9
-10^9 <= target <= 10^9
Only one valid answer exists.
 */


using BenchmarkDotNet.Running;
using TwoSum;

var summary = BenchmarkRunner.Run<Benchmarks>();


return;

var sln = new Solution();

var res1 = sln.TwoSumDictionary([2,7,11,15], 9);
bool res1Ok = res1[0] is 0 && res1[1] is 1;
Console.WriteLine($"Res1: {res1Ok}");

var res2 = sln.TwoSumDictionary([3,2,4], 6);
bool res2Ok = res2[0] is 1 && res2[1] is 2;
Console.WriteLine($"Res2: {res2Ok}");

var res3 = sln.TwoSumDictionary([3,3], 6);
bool res3Ok = res3[0] is 0 && res3[1] is 1;
Console.WriteLine($"Res3: {res3Ok}");