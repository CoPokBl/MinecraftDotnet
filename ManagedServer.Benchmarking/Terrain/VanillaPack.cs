using ManagedServer.Terrain.Data;

namespace ManagedServer.Benchmarking.Terrain;

/// <summary>
/// The vanilla datapack every terrain benchmark generates from.
/// </summary>
/// <remarks>
/// Nothing Mojang wrote ships here, so the data is fetched rather than embedded. Downloaded once into
/// the shared jar cache and held open for the run, since the loaders cache their parsed data per
/// source and a fresh source would reparse the density function tree per benchmark.
/// <p/>
/// <c>MCDOTNET_JAR</c> points it at a jar that is already somewhere.
/// </remarks>
public static class VanillaPack {
    private static readonly Lock Gate = new();
    private static IDatapackSource? _source;

    public static IDatapackSource Source {
        get {
            lock (Gate) {
                return _source ??= Resolve();
            }
        }
    }

    private static IDatapackSource Resolve() {
        if (Environment.GetEnvironmentVariable("MCDOTNET_JAR") is { Length: > 0 } path) {
            return new ZipDatapack(path);
        }

        return VanillaDatapack.Download().GetAwaiter().GetResult();
    }
}
