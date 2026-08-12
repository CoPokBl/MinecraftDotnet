# Minecraft.RegistryBenchmark

Measures how long `VanillaRegistry` takes to load.

`VanillaRegistry.Data` is filled by a static initialiser, so the cost is paid once per
process, on whatever line first touches it. BenchmarkDotNet cannot see that, since there is
no second iteration to measure. This project starts fresh processes instead.

```bash
dotnet build Minecraft.RegistryBenchmark -c Release
cd Minecraft.RegistryBenchmark/bin/Release/net10.0

./Minecraft.RegistryBenchmark              # 10 cold starts, summarised
./Minecraft.RegistryBenchmark -n 30        # more of them
./Minecraft.RegistryBenchmark --single     # one measurement plus the registry sizes
./Minecraft.RegistryBenchmark --breakdown  # time each generated initialiser separately
./Minecraft.RegistryBenchmark --alc        # repeat in-process, see below
```

Always build Release. A Debug build measures the debug JIT, which is not what a server ships.

## What it does

- Nothing here references `VanillaRegistry` at compile time. The type is resolved with
  `Type.GetType` and forced with `RuntimeHelpers.RunClassConstructor`, so the JIT cannot load
  `Minecraft.dll` before the stopwatch starts and hide part of the cost.
- Two phases are reported separately: loading `Minecraft.dll`, then running the initialiser.
- The default mode spawns one child process per sample (plus a discarded warmup) and
  aggregates min/median/mean/max/stddev. It also prints .NET's own startup time for scale.

## `--alc`

Loads `Minecraft.dll` into a fresh collectible `AssemblyLoadContext` per iteration, making
the measurement repeatable inside one process.

Numbers come out several times higher than a real cold start, because collectible contexts
JIT the initialiser differently. Use this mode to compare two versions of the initialiser,
not to quote a figure.
