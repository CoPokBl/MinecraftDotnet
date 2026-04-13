using BenchmarkDotNet.Running;

if (args.Length > 0 && args[0] == "--quick") {
    ManagedServer.Benchmarking.Lighting.QuickBench.Run();
    return;
}

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
