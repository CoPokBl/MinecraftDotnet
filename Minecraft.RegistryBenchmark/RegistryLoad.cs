using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace Minecraft.RegistryBenchmark;

/// <summary>
/// One measurement of getting <c>VanillaRegistry.Data</c> from "not touched yet" to "populated".
/// </summary>
/// <param name="AssemblyLoadMs">Resolving the type, which is what pulls Minecraft.dll in.</param>
/// <param name="StaticCtorMs">Running the static initialiser itself (includes JITting it).</param>
/// <param name="AllocatedBytes">Bytes allocated on the measuring thread across both phases.</param>
public readonly record struct LoadSample(double AssemblyLoadMs, double StaticCtorMs, long AllocatedBytes) {
    public double TotalMs => AssemblyLoadMs + StaticCtorMs;
}

public static class RegistryLoad {
    private const string RegistryAssembly = "Minecraft";
    private const string TypeName = "Minecraft.Data.Generated.VanillaRegistry";

    /// <summary>
    /// Measures the load in this process. Only meaningful once, since a static initialiser
    /// runs exactly once.
    /// </summary>
    public static LoadSample MeasureOnce() {
        // No compile time reference to the type: that would load Minecraft.dll before the
        // stopwatch starts and hide the assembly load cost.
        long allocatedBefore = GC.GetAllocatedBytesForCurrentThread();
        Stopwatch sw = Stopwatch.StartNew();

        Type type = Type.GetType($"{TypeName}, {RegistryAssembly}", throwOnError: true)!;
        double assemblyLoadMs = sw.Elapsed.TotalMilliseconds;

        // Type.GetType does not trigger the initialiser; this is what actually runs it.
        RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        double totalMs = sw.Elapsed.TotalMilliseconds;

        long allocated = GC.GetAllocatedBytesForCurrentThread() - allocatedBefore;
        return new LoadSample(assemblyLoadMs, totalMs - assemblyLoadMs, allocated);
    }

    /// <summary>
    /// Measures the load in a fresh collectible <see cref="AssemblyLoadContext"/>, so it can be
    /// repeated in one process.
    ///
    /// Collectible contexts JIT the initialiser much slower (~4x the cold start figure here),
    /// so use this to compare two versions of the initialiser, not for absolute numbers.
    /// </summary>
    public static LoadSample MeasureIsolated() {
        string assemblyPath = Path.Combine(AppContext.BaseDirectory, RegistryAssembly + ".dll");
        if (!File.Exists(assemblyPath)) {
            throw new FileNotFoundException($"Could not find {assemblyPath} next to the benchmark.");
        }

        IsolatedContext context = new(assemblyPath);
        try {
            long allocatedBefore = GC.GetAllocatedBytesForCurrentThread();
            Stopwatch sw = Stopwatch.StartNew();

            Assembly assembly = context.LoadFromAssemblyPath(assemblyPath);
            Type type = assembly.GetType(TypeName, throwOnError: true)!;
            double assemblyLoadMs = sw.Elapsed.TotalMilliseconds;

            RuntimeHelpers.RunClassConstructor(type.TypeHandle);
            double totalMs = sw.Elapsed.TotalMilliseconds;

            long allocated = GC.GetAllocatedBytesForCurrentThread() - allocatedBefore;
            return new LoadSample(assemblyLoadMs, totalMs - assemblyLoadMs, allocated);
        }
        finally {
            context.Unload();
        }
    }

    /// <summary>
    /// The generated static classes the registry pulls in, in the order they are worth blaming.
    /// The last five read their entries back out of <c>VanillaRegistry.Data</c>, so they come
    /// after it, where they show only their own lookups.
    /// </summary>
    public static readonly string[] BreakdownTypes = [
        "Minecraft.Data.Generated.Block",
        "Minecraft.Data.Generated.Item",
        "Minecraft.Data.Generated.SoundType",
        "Minecraft.Data.Generated.EntityType",
        "Minecraft.Data.Generated.Particle",
        "Minecraft.Data.Generated.BlockEntityType",
        "Minecraft.Data.Generated.CustomStatistic",
        "Minecraft.Data.Generated.PotionEffectType",
        "Minecraft.Data.Generated.Attribute",
        "Minecraft.Data.Generated.DataComponent",
        TypeName,
        "Minecraft.Data.Generated.DamageType",
        "Minecraft.Data.Generated.Enchantment",
        "Minecraft.Data.Generated.PaintingVariant",
        "Minecraft.Data.Generated.DimensionType",
        "Minecraft.Data.Generated.Timeline"
    ];

    /// <summary>
    /// Runs one type's initialiser and times it. Transitive dependencies are charged to whoever
    /// pulls them in first, so read a row as "cost of adding this on top of the last".
    /// </summary>
    public static (double Ms, long AllocatedBytes) MeasureTypeInit(string typeName) {
        Type type = Type.GetType($"{typeName}, {RegistryAssembly}", throwOnError: true)!;

        long allocatedBefore = GC.GetAllocatedBytesForCurrentThread();
        Stopwatch sw = Stopwatch.StartNew();
        RuntimeHelpers.RunClassConstructor(type.TypeHandle);
        double ms = sw.Elapsed.TotalMilliseconds;
        return (ms, GC.GetAllocatedBytesForCurrentThread() - allocatedBefore);
    }

    /// <summary>
    /// Entry counts per sub registry, to check the thing we timed actually filled in.
    /// Reflection only, so the benchmark keeps its no-compile-time-reference property.
    /// </summary>
    public static IEnumerable<(string Name, long Count)> DescribeLoadedRegistry() {
        Type type = Type.GetType($"{TypeName}, {RegistryAssembly}", throwOnError: true)!;
        object registry = type.GetField("Data", BindingFlags.Public | BindingFlags.Static)!.GetValue(null)!;

        foreach (PropertyInfo property in registry.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)) {
            if (property.GetIndexParameters().Length != 0) {
                continue;
            }

            object? subRegistry = property.GetValue(registry);
            PropertyInfo? count = subRegistry?.GetType().GetProperty("Count", BindingFlags.Public | BindingFlags.Instance);
            if (count?.GetValue(subRegistry) is { } value) {
                yield return (property.Name, Convert.ToInt64(value));
            }
        }
    }

    private sealed class IsolatedContext(string assemblyPath) : AssemblyLoadContext(isCollectible: true) {
        private readonly AssemblyDependencyResolver _resolver = new(assemblyPath);

        protected override Assembly? Load(AssemblyName assemblyName) {
            // Null falls back to the default context, which is right for framework assemblies.
            string? path = _resolver.ResolveAssemblyToPath(assemblyName);
            return path == null ? null : LoadFromAssemblyPath(path);
        }
    }
}
