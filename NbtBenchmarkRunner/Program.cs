using BenchmarkDotNet.Running;
using Tests;

Console.WriteLine("Running NBT Serialization/Deserialization Benchmarks...");
Console.WriteLine();

var summary = BenchmarkRunner.Run<NbtBenchmark>();

Console.WriteLine();
Console.WriteLine($"Benchmark results saved to: {summary.ResultsDirectoryPath}");
Console.WriteLine("Done!");
