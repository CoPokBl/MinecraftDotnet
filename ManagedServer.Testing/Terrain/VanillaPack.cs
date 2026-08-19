using ManagedServer.Terrain.Data;

namespace ManagedServer.Testing.Terrain;

/// <summary>
/// The vanilla datapack the worldgen and loot tests read.
/// </summary>
/// <remarks>
/// <b>Nothing Mojang wrote is committed here</b>, so a test that needs the vanilla data has to fetch
/// it. The jar is downloaded once into a cache directory shared by every test in the run and, by
/// default, by every other project on the machine, so a second run costs a SHA-1 of a file already on
/// disk.
/// <p/>
/// <c>MCDOTNET_JAR</c> points this at a jar that is already somewhere, which is what a build with no
/// network egress wants; <c>MCDOTNET_JAR_CACHE</c> moves only the download directory.
/// <p/>
/// One <see cref="ZipDatapack"/> for the whole run, because the loaders cache their parsed data per
/// source and a fresh source per fixture would reparse the density function tree every time.
/// </remarks>
public static class VanillaPack {
    private static readonly Lock Gate = new();
    private static IDatapackSource? _source;

    /// <summary>The vanilla pack, downloading it on the first ask.</summary>
    public static IDatapackSource Source {
        get {
            lock (Gate) {
                return _source ??= Resolve();
            }
        }
    }

    private static IDatapackSource Resolve() {
        if (Environment.GetEnvironmentVariable("MCDOTNET_JAR") is { Length: > 0 } path) {
            if (!File.Exists(path)) {
                throw new FileNotFoundException($"MCDOTNET_JAR points at \"{path}\", which is not there.");
            }

            return new ZipDatapack(path);
        }

        string? cache = Environment.GetEnvironmentVariable("MCDOTNET_JAR_CACHE");

        // Blocking, since a test fixture has nowhere to await to and this happens once per run.
        return VanillaDatapack.Download(cacheDirectory: string.IsNullOrEmpty(cache) ? null : cache)
            .GetAwaiter().GetResult();
    }
}
