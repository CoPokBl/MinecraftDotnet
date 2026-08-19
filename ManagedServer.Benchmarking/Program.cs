using BenchmarkDotNet.Running;

if (args.Length > 0 && args[0] == "--quick") {
    switch (args.Length > 1 ? args[1] : "lighting") {
        case "chunks":
            ManagedServer.Benchmarking.Worlds.ChunkPipelineQuickBench.Run(args[2..]);
            return;

        case "join":
            ManagedServer.Benchmarking.Worlds.JoinResponsivenessQuickBench.Run(args[2..]);
            return;

        case "lighting":
            ManagedServer.Benchmarking.Lighting.QuickBench.Run();
            return;

        default:
            Console.WriteLine("Usage: --quick [lighting|chunks|join] [args]");
            return;
    }
}

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
