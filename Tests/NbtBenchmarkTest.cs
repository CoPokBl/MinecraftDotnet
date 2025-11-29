using BenchmarkDotNet.Running;

namespace Tests;

public class NbtBenchmarkTest {
    
    [Test]
    [Explicit("Run manually to execute benchmarks")]
    public void RunNbtBenchmarks() {
        var summary = BenchmarkRunner.Run<NbtBenchmark>();
        Assert.Pass($"Benchmark completed. See results in {summary.ResultsDirectoryPath}");
    }
    
    // Sanity test to ensure benchmark setup works
    [Test]
    public void TestBenchmarkSetup() {
        var benchmark = new NbtBenchmark();
        benchmark.Setup();
        
        // Test simple operations
        var simpleResult = benchmark.DeserializeSimple();
        Assert.That(simpleResult, Is.Not.Null);
        
        var serializedSimple = benchmark.SerializeSimple();
        Assert.That(serializedSimple, Is.Not.Null);
        Assert.That(serializedSimple.Length, Is.GreaterThan(0));
        
        // Test complex operations
        var complexResult = benchmark.DeserializeComplex();
        Assert.That(complexResult, Is.Not.Null);
        
        var serializedComplex = benchmark.SerializeComplex();
        Assert.That(serializedComplex, Is.Not.Null);
        Assert.That(serializedComplex.Length, Is.GreaterThan(0));
        
        // Test nested operations
        var nestedResult = benchmark.DeserializeNested();
        Assert.That(nestedResult, Is.Not.Null);
        
        var serializedNested = benchmark.SerializeNested();
        Assert.That(serializedNested, Is.Not.Null);
        Assert.That(serializedNested.Length, Is.GreaterThan(0));
        
        // Test round trips
        var roundTripSimple = benchmark.RoundTripSimple();
        Assert.That(roundTripSimple, Is.Not.Null);
        
        var roundTripComplex = benchmark.RoundTripComplex();
        Assert.That(roundTripComplex, Is.Not.Null);
        
        // Test DataWriter/DataReader operations
        var viaWriter = benchmark.SerializeViaDataWriter();
        Assert.That(viaWriter, Is.Not.Null);
        Assert.That(viaWriter.Length, Is.GreaterThan(0));
        
        var viaReader = benchmark.DeserializeViaDataReader();
        Assert.That(viaReader, Is.Not.Null);
    }
}
