using BenchmarkDotNet.Attributes;

namespace TwoSum;

[MemoryDiagnoser]
public class Benchmarks
{
    // private Solution sln = new ();
    // private int [] array = [2, 7, 11, 15, 19, 28, 12, 90, 45, 22, 16, 999, 18, 1000, 3421,312312, 23, 24, 34, 455, -12, 14, 66, 888, 67, 68, 69, 78];
    // private int target = 999 + 888;

    [Benchmark]
    public void SumNaive()
    {
        var sln = new Solution();
        int[] array =
        [
            2, 7, 11, 15, 19, 28, 12, 90, 45, 22, 16, 999, 18, 1000, 3421, 312312, 23, 24, 34, 12, 45, 455, -12, 14, 66, 888,
            67, 68, 69, 78
        ];
        int target = 999 + 888;
        sln.TwoSumNaive(array, target);
    }

    [Benchmark]
    public void SumSpans()
    {
        var sln = new Solution();
        int[] array =
        [
            2, 7, 11, 15, 19, 28, 12, 90, 45, 22, 16, 999, 18, 1000, 3421, 312312, 23, 24, 34, 12, 45, 455, -12, 14, 66, 888,
            67, 68, 69, 78
        ];
        int target = 999 + 888;
        sln.TwoSumSpans(array, target);
    }

    [Benchmark]
    public void SumDict()
    {
        var sln = new Solution();
        int[] array =
        [
            2, 7, 11, 15, 19, 28, 12, 90, 45, 22, 16, 999, 18, 1000, 3421, 312312, 23, 24, 34, 12, 45, 455, -12, 14, 66, 888,
            67, 68, 69, 78
        ];
        int target = 999 + 888;
        sln.TwoSumDictionary(array, target);
    }
}
/*
| Method   | Mean      | Error    | StdDev   | Gen0   | Gen1   | Allocated |
|--------- |----------:|---------:|---------:|-------:|-------:|----------:|
| SumNaive | 117.59 ns | 1.326 ns | 1.241 ns | 0.0038 |      - |      32 B |
| SumSpans |  35.77 ns | 0.306 ns | 0.271 ns | 0.0038 |      - |      32 B |
| SumDict  | 195.90 ns | 3.349 ns | 4.908 ns | 0.0889 | 0.0002 |     744 B |

 */