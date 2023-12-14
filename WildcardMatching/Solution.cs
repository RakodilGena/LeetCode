namespace WildcardMatching;

internal sealed class Solution
{
    //todo gets TLE rewrte laters.
    public bool IsMatch(string s, string p)
    {
        var patternLengthWithoutWildcards = p.Count(pc => pc is not '*');
        return IsMatch(ref s, ref p, 0, 0, false, patternLengthWithoutWildcards);
    }
    
    private static bool IsMatch(
        ref string input, 
        ref string pattern, 
        ushort patternPointer, 
        int inputPointer, 
        bool wildCardScan,
        int patternLengthWithoutWildcards)
    {
        //no input - ok only if pattern allows empty string
        if (string.IsNullOrEmpty(input))
        {
            if (pattern.All(pChar => pChar is '*'))
                return true;
            return false;
        }

        int patternLength = pattern.Length,
            inputLength = input.Length;

        while (true)
        {
            //all pattern checked.
            if (patternPointer >= patternLength)
            {
                break;
            }

            var patternChar = pattern[patternPointer];

            if (patternChar is '*')
            {
                //'*' is last symbol => any sequence in the string end allowed
                if (patternPointer == patternLength - 1)
                    return true;

                //if '*' is not last - turn on wildcard scan, to next pattern char on CURRENT inputChar
                wildCardScan = true;
                patternPointer++;
                continue;
            }

            //all string checked.
            if (inputPointer >= inputLength)
            {
                break;
            }

            if (wildCardScan)
            {
                //Terrible brute force for handling repeating constructions matching pattern.
                
                //if we can substring current string
                if (inputLength > patternLengthWithoutWildcards)
                {
                    bool substringMatch = IsMatch(ref input, ref pattern,
                        patternPointer, inputPointer + 1, wildCardScan, patternLengthWithoutWildcards);
            
                    if (substringMatch)
                        return true;
                }
            }

            //if (patternChar is not '*') ALWAYS TRUE
            var inputChar = input[inputPointer];
            bool match = patternChar is '?'
                         || patternChar == inputChar;

            if (match)
            {
                wildCardScan = false;
                patternPointer++;
                inputPointer++;
                continue;
            }

            //not match and not wildcard sequence
            if (wildCardScan is false)
                return false;

            //not match and in wildcard - just go to next inputChar on CURRENT patternChar
            inputPointer++;
        }

        return patternPointer >= patternLength && inputPointer >= inputLength;
    }
    // public bool IsMatch_Net8(string s, string p)
    // {
    //     var input = s.AsSpan();
    //     var pattern = p.AsSpan();
    //     return IsMatch_Net8(ref input, ref pattern, 0, 0, false);
    // }
    //
    // private static bool IsMatch_Net8(
    //     ref ReadOnlySpan<char> input, 
    //     ref ReadOnlySpan<char> pattern, 
    //     ushort patternPointer, 
    //     int inputPointer, 
    //     bool wildCardScan)
    // {
    //     //no pattern = any string is ok
    //     if (pattern.IsEmpty)
    //         return true;
    //
    //     //no input - ok only if pattern allows empty string
    //     if (input.IsEmpty)
    //     {
    //         if (pattern.IndexOfAnyExcept('*') is -1)
    //             return true;
    //         return false;
    //     }
    //
    //     int patternLength = pattern.Length,
    //         inputLength = input.Length;
    //
    //     while (true)
    //     {
    //         //all pattern checked.
    //         if (patternPointer >= patternLength)
    //         {
    //             break;
    //         }
    //
    //         var patternChar = pattern[patternPointer];
    //
    //         if (patternChar is '*')
    //         {
    //             //'*' is last symbol => any sequence in the string end allowed
    //             if (patternPointer == patternLength - 1)
    //                 return true;
    //
    //             //if '*' is not last - turn on wildcard scan, to next pattern char on CURRENT inputChar
    //             wildCardScan = true;
    //             patternPointer++;
    //             continue;
    //         }
    //
    //         //all string checked.
    //         if (inputPointer >= inputLength)
    //         {
    //             break;
    //         }
    //
    //         var inputChar = input[inputPointer];
    //
    //         if (wildCardScan)
    //         {
    //             //Terrible brute force for handling repeating constructions matching pattern.
    //             
    //             var patternLengthWithoutWildcards = patternLength - pattern.Count('*');
    //
    //             //if we can substring current string
    //             if (inputLength > patternLengthWithoutWildcards)
    //             {
    //                 bool substringMatch = IsMatch_Net8(ref input, ref pattern,
    //                     patternPointer, inputPointer + 1, wildCardScan);
    //
    //                 if (substringMatch)
    //                     return true;
    //             }
    //         }
    //
    //         //if (patternChar is not '*') ALWAYS TRUE
    //
    //         bool match = patternChar is '?'
    //                      || patternChar == inputChar;
    //
    //         if (match)
    //         {
    //             wildCardScan = false;
    //             patternPointer++;
    //             inputPointer++;
    //             continue;
    //         }
    //
    //         //not match and not wildcard sequence
    //         if (wildCardScan is false)
    //             return false;
    //
    //         //not match and in wildcard - just go to next inputChar on CURRENT patternChar
    //         inputPointer++;
    //     }
    //
    //     return patternPointer >= patternLength && inputPointer >= inputLength;
    // }
}