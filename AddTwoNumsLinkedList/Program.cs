

//https://leetcode.com/problems/add-two-numbers/
/*
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Example:
Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.


Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]


Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
INTEGERS!

 */

using AddTwoNumsLinkedList;

var sln = new Solution();

int[] input1_1 = [2,4,3], input1_2 = [5,6,4];
var l1_1 = ConvertInput(input1_1);
var l1_2 = ConvertInput(input1_2);

var result1 = sln.AddTwoNumbers(l1_1, l1_2);

int[] input2_1 = [0], input2_2 = [0];
var l2_1 = ConvertInput(input2_1);
var l2_2 = ConvertInput(input2_2);

var result2 = sln.AddTwoNumbers(l2_1, l2_2);

int[] input3_1 = [9,9,9,9,9,9,9], input3_2 = [9,9,9,9];
var l3_1 = ConvertInput(input3_1);
var l3_2 = ConvertInput(input3_2);

var result3 = sln.AddTwoNumbers(l3_1, l3_2);

var a = 5;



ListNode ConvertInput(int[] input)
{
 ListNode first = new ListNode(input[0]);
 ListNode current = first;
 
 foreach (var digit in input.AsSpan()[1..])
 {
  var node = new ListNode(digit);
  current.next = node;
  current = node;
 }

 return first;
}