using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using Minecraft.RegistryBenchmark;

// Measured first thing so it covers as much of the runtime's own startup as possible.
double processStartMs = ProcessStartMs();

Options options;
try {
    options = Options.Parse(args);
}
catch (ArgumentException e) {
    Console.Error.WriteLine(e.Message);
    Options.PrintUsage();
    return 1;
}

if (options.Help) {
    Options.PrintUsage();
    return 0;
}

switch (options.Mode) {
    case Mode.Child:
        RunChild(processStartMs);
        return 0;
    case Mode.Single:
        RunSingle(processStartMs);
        return 0;
    case Mode.Alc:
        RunAlc(options.Iterations);
        return 0;
    case Mode.Breakdown:
        RunBreakdown();
        return 0;
    default:
        return RunColdStarts(options.Iterations);
}

static double ProcessStartMs() {
    return (DateTime.UtcNow - Process.GetCurrentProcess().StartTime.ToUniversalTime()).TotalMilliseconds;
}

// Cold start child: measure once, print one machine readable line, exit.
static void RunChild(double processStartMs) {
    LoadSample sample = RegistryLoad.MeasureOnce();
    Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
        $"SAMPLE {sample.AssemblyLoadMs:R} {sample.StaticCtorMs:R} {sample.AllocatedBytes} {processStartMs:R}"));
}

static void RunSingle(double processStartMs) {
    PrintEnvironment();
    LoadSample sample = RegistryLoad.MeasureOnce();

    Console.WriteLine("Cold load of VanillaRegistry in this process:");
    Console.WriteLine($"  Runtime startup before us : {processStartMs,8:F2} ms");
    Console.WriteLine($"  Load Minecraft.dll        : {sample.AssemblyLoadMs,8:F2} ms");
    Console.WriteLine($"  Run static initialiser    : {sample.StaticCtorMs,8:F2} ms");
    Console.WriteLine($"  Total                     : {sample.TotalMs,8:F2} ms");
    Console.WriteLine($"  Allocated                 : {Mib(sample.AllocatedBytes),8:F2} MiB");
    Console.WriteLine();
    PrintRegistryContents();
}

static void RunBreakdown() {
    PrintEnvironment();
    Console.WriteLine("Static initialisers run in dependency order, each charged with everything it");
    Console.WriteLine("pulls in that nothing before it already paid for.");
    Console.WriteLine();

    double total = 0;
    long allocatedTotal = 0;
    foreach (string typeName in RegistryLoad.BreakdownTypes) {
        (double ms, long allocated) = RegistryLoad.MeasureTypeInit(typeName);
        total += ms;
        allocatedTotal += allocated;
        Console.WriteLine($"  {typeName.Split('.')[^1],-18} {ms,8:F2} ms   {Mib(allocated),6:F2} MiB");
    }

    Console.WriteLine($"  {"total",-18} {total,8:F2} ms   {Mib(allocatedTotal),6:F2} MiB");
}

static void RunAlc(int iterations) {
    PrintEnvironment();
    Console.WriteLine($"Loading VanillaRegistry into {iterations} fresh AssemblyLoadContexts.");
    Console.WriteLine("Collectible contexts JIT the initialiser far slower than a normal load (~4x here),");
    Console.WriteLine("so these are only good for comparing runs to each other, not as absolute numbers.");
    Console.WriteLine();

    List<LoadSample> samples = [];
    for (int i = 0; i < iterations; i++) {
        LoadSample sample = RegistryLoad.MeasureIsolated();
        samples.Add(sample);
        Console.WriteLine($"  #{i + 1,-3} load {sample.AssemblyLoadMs,7:F2} ms   cctor {sample.StaticCtorMs,7:F2} ms   total {sample.TotalMs,7:F2} ms");
    }

    Console.WriteLine();
    PrintStats(samples);
}

static int RunColdStarts(int iterations) {
    PrintEnvironment();

    if (!TryGetSelfCommand(out string exe, out List<string> baseArgs)) {
        Console.Error.WriteLine("Could not work out how to re-launch this benchmark; use --single instead.");
        return 1;
    }

    Console.WriteLine($"Measuring {iterations} cold starts, one fresh process each (plus a discarded warmup).");
    Console.WriteLine();

    if (!TryRunChild(exe, baseArgs, out LoadSample warmup, out _, out string? error)) {
        Console.Error.WriteLine($"Warmup process failed: {error}");
        return 1;
    }
    Console.WriteLine($"  warmup   load {warmup.AssemblyLoadMs,7:F2} ms   cctor {warmup.StaticCtorMs,7:F2} ms   total {warmup.TotalMs,7:F2} ms   (discarded)");

    List<LoadSample> samples = [];
    List<double> startupMs = [];
    for (int i = 0; i < iterations; i++) {
        if (!TryRunChild(exe, baseArgs, out LoadSample sample, out double runtimeStartMs, out error)) {
            Console.Error.WriteLine($"Child process failed: {error}");
            return 1;
        }

        samples.Add(sample);
        startupMs.Add(runtimeStartMs);
        Console.WriteLine($"  #{i + 1,-3}     load {sample.AssemblyLoadMs,7:F2} ms   cctor {sample.StaticCtorMs,7:F2} ms   total {sample.TotalMs,7:F2} ms");
    }

    Console.WriteLine();
    PrintStats(samples);
    Console.WriteLine();
    Console.WriteLine($"For scale, .NET startup before the first line of our code ran averaged {startupMs.Average():F2} ms.");
    return 0;
}

static bool TryRunChild(string exe, List<string> baseArgs, out LoadSample sample, out double processStartMs, out string? error) {
    sample = default;
    processStartMs = 0;
    error = null;

    ProcessStartInfo info = new(exe) {
        RedirectStandardOutput = true,
        RedirectStandardError = true,
        UseShellExecute = false
    };
    foreach (string arg in baseArgs) {
        info.ArgumentList.Add(arg);
    }
    info.ArgumentList.Add("--child");

    using Process? process = Process.Start(info);
    if (process == null) {
        error = "process did not start";
        return false;
    }

    string stdout = process.StandardOutput.ReadToEnd();
    string stderr = process.StandardError.ReadToEnd();
    process.WaitForExit();

    if (process.ExitCode != 0) {
        error = $"exit code {process.ExitCode}: {stderr.Trim()}";
        return false;
    }

    string? line = stdout.Split('\n').FirstOrDefault(l => l.StartsWith("SAMPLE ", StringComparison.Ordinal));
    string[]? parts = line?.Trim().Split(' ');
    if (parts is not { Length: 5 }) {
        error = $"unexpected output: {stdout.Trim()}";
        return false;
    }

    sample = new LoadSample(
        double.Parse(parts[1], CultureInfo.InvariantCulture),
        double.Parse(parts[2], CultureInfo.InvariantCulture),
        long.Parse(parts[3], CultureInfo.InvariantCulture));
    processStartMs = double.Parse(parts[4], CultureInfo.InvariantCulture);
    return true;
}

// Handles both the apphost and the muxer (`dotnet Minecraft.RegistryBenchmark.dll`).
static bool TryGetSelfCommand(out string exe, out List<string> args) {
    args = [];
    exe = Environment.ProcessPath ?? "";
    if (exe.Length == 0) {
        return false;
    }

    string name = Path.GetFileNameWithoutExtension(exe);
    if (!name.Equals("dotnet", StringComparison.OrdinalIgnoreCase)) {
        return true;
    }

    string dll = Path.ChangeExtension(Environment.GetCommandLineArgs()[0], ".dll");
    if (!File.Exists(dll)) {
        return false;
    }

    args.Add(dll);
    return true;
}

static void PrintStats(List<LoadSample> samples) {
    double[] totals = samples.Select(s => s.TotalMs).Order().ToArray();
    double[] cctors = samples.Select(s => s.StaticCtorMs).Order().ToArray();

    Console.WriteLine($"  {"",-20} {"min",8} {"median",8} {"mean",8} {"max",8} {"stddev",8}");
    PrintRow("static initialiser", cctors);
    PrintRow("load + initialiser", totals);
    Console.WriteLine();
    Console.WriteLine($"  Allocated: {Mib((long)samples.Average(s => s.AllocatedBytes)):F2} MiB");
    return;

    static void PrintRow(string label, double[] sorted) {
        Console.WriteLine($"  {label,-20} {sorted[0],8:F2} {Median(sorted),8:F2} {sorted.Average(),8:F2} {sorted[^1],8:F2} {StdDev(sorted),8:F2}");
    }
}

static double Median(double[] sorted) {
    int mid = sorted.Length / 2;
    return sorted.Length % 2 == 0 ? (sorted[mid - 1] + sorted[mid]) / 2 : sorted[mid];
}

static double StdDev(double[] values) {
    if (values.Length < 2) {
        return 0;
    }

    double mean = values.Average();
    return Math.Sqrt(values.Sum(v => (v - mean) * (v - mean)) / (values.Length - 1));
}

static double Mib(long bytes) => bytes / 1024d / 1024d;

static void PrintRegistryContents() {
    Console.WriteLine("Registry contents:");
    foreach ((string name, long count) in RegistryLoad.DescribeLoadedRegistry().OrderByDescending(e => e.Count)) {
        Console.WriteLine($"  {name,-22} {count,7}");
    }
}

static void PrintEnvironment() {
#if DEBUG
    const string configuration = "Debug (build with -c Release for numbers worth quoting)";
#else
    const string configuration = "Release";
#endif
    Console.WriteLine($"VanillaRegistry load benchmark — {configuration}");
    Console.WriteLine($"  .NET {Environment.Version}, {RuntimeInformation.RuntimeIdentifier}, {Environment.ProcessorCount} cores");
    Console.WriteLine();
}

internal enum Mode {
    ColdStart,
    Single,
    Alc,
    Breakdown,
    Child
}

internal sealed record Options(Mode Mode, int Iterations, bool Help) {
    public static Options Parse(string[] args) {
        Mode mode = Mode.ColdStart;
        int? iterations = null;
        bool help = false;

        for (int i = 0; i < args.Length; i++) {
            switch (args[i]) {
                case "--single":
                    mode = Mode.Single;
                    break;
                case "--child":
                    mode = Mode.Child;
                    break;
                case "--alc":
                    mode = Mode.Alc;
                    break;
                case "--breakdown":
                    mode = Mode.Breakdown;
                    break;
                case "--processes":
                    mode = Mode.ColdStart;
                    break;
                case "-n":
                case "--iterations":
                    if (i + 1 >= args.Length || !int.TryParse(args[++i], out int parsed) || parsed < 1) {
                        throw new ArgumentException($"{args[i - 1]} needs a positive count.");
                    }
                    iterations = parsed;
                    break;
                case "-h":
                case "--help":
                    help = true;
                    break;
                default:
                    throw new ArgumentException($"Unknown argument: {args[i]}");
            }
        }

        return new Options(mode, iterations ?? (mode == Mode.Alc ? 20 : 10), help);
    }

    public static void PrintUsage() {
        Console.WriteLine("""
            Usage: Minecraft.RegistryBenchmark [mode] [-n <count>]

            Modes:
              (default)    Cold start: run <count> child processes, each measuring the load once.
                           This is the number that matters for server startup.
              --single     Measure once in this process and dump the resulting registry sizes.
              --alc        Load the registry <count> times into fresh AssemblyLoadContexts.
                           Repeatable in one process, but collectible contexts JIT much slower,
                           so the numbers are inflated — use it for A/B, not absolutes.
              --breakdown  Time each generated static class initialiser separately, once.
              -n <count>   Iterations (default 10 for cold start, 20 for --alc).
            """);
    }
}
