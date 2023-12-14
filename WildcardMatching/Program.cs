/*

https://leetcode.com/problems/wildcard-matching/

Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:

'?' Matches any single character.
'*' Matches any sequence of characters (including the empty sequence).
    The matching should cover the entire input string (not partial).



    Example 1:

Input: s = "aa", p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".
    Example 2:

Input: s = "aa", p = "*"
Output: true
Explanation: '*' matches any sequence.
    Example 3:

Input: s = "cb", p = "?a"
Output: false
Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.


    Constraints:

0 <= s.length, p.length <= 2000
s contains only lowercase English letters.
    p contains only lowercase English letters, '?' or '*'.
*/

using System.Diagnostics;
using WildcardMatching;

var sln = new Solution();

var testData = new TestData[]
{
    new("a", "", false),
    new("aasdasDASa", "", false),
    new("aa", "a", false),
    new("aa", "*", true),
    new("cb", "?a", false),
    new("", "****", true),
    new("", "*?*", false),
    new("bab", "*?*", true),
    new("bab", "*???*", true),
    new("bfbbbbb", "*f*", true),
    new("abcfdfjksdbfkjsdbfkljsdabceeeee", "a?c*abc", false),
    new("abcfdfjksdbfkjsdbfkljsdabceeeee", "a?c*a?c**", true),
    new("abfcd", "ab?cd", true),
    new("abfcd", "**a**b****?*c***d***", true),
    
    new("abcabczzzde", "*abc???de*", true),
    new("abcabc", "*abc", true),
    new("aaaaaaaa", "*a", true),
    new("abbabbbaabaaabbbbbabbabbabbbabbaaabbbababbabaaabbab", "*aabb***aa**a******aa*", true),
};

var sw = new Stopwatch();
for (int i = 0; i < testData.Length; i++)
{
    sw.Restart();
    
    var data = testData[i];
    var index = i + 1;
    var (input, pattern, expected) = data;

    var result = sln.IsMatch(input, pattern);
    
    sw.Stop();

    ResultOutput(index, expected, result, sw.Elapsed.TotalMilliseconds);
}


void ResultOutput(int testIndex, bool expected, bool actual, double ms)
{
    bool passed = actual == expected;
    Console.WriteLine(
        $"Test_{testIndex:00} | Expected: {expected,-5} | Actual: {actual,-5} | Passed: {passed,-5} | Duration: {ms, -10}");
}

readonly record struct TestData(string Input, string Pattern, bool ExpectedResult);