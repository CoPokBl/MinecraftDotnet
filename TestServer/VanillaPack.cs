using ManagedServer.Terrain.Data;

namespace TestServer;

/// <summary>
/// The vanilla datapack the demos read their worldgen and loot tables from.
/// </summary>
/// <remarks>
/// <b>Nothing Mojang wrote ships with this framework</b>, so a consumer who wants vanilla data
/// supplies it. This is what that looks like from the consumer's side, and it is the whole of it: one
/// call, cached on disk, and the source is then handed to whatever wants it.
/// <p/>
/// <c>MCDOTNET_JAR</c> points at a jar already on the machine instead of downloading one, and
/// <c>MCDOTNET_PACK</c> at an unpacked datapack directory. A consumer with their own worldgen would
/// layer it over this with <see cref="LayeredDatapack"/>.
/// </remarks>
public static class VanillaPack {
    private static readonly Lock Gate = new();
    private static IDatapackSource? _source;

    /// <summary>The pack, fetched on the first ask and kept for the life of the process.</summary>
    public static IDatapackSource Source {
        get {
            lock (Gate) {
                return _source ??= Resolve();
            }
        }
    }

    private static IDatapackSource Resolve() {
        if (Environment.GetEnvironmentVariable("MCDOTNET_PACK") is { Length: > 0 } directory) {
            Console.WriteLine($"Reading vanilla data from {directory}.");
            return new DirectoryDatapack(directory);
        }

        if (Environment.GetEnvironmentVariable("MCDOTNET_JAR") is { Length: > 0 } jar) {
            Console.WriteLine($"Reading vanilla data from {jar}.");
            return new ZipDatapack(jar);
        }

        Console.WriteLine("Fetching the vanilla server jar for its worldgen data and loot tables. "
            + "It is cached, so this happens once.");

        IDatapackSource source = VanillaDatapack.Download().GetAwaiter().GetResult();
        Console.WriteLine($"Reading vanilla data from {source.Describe()}.");

        return source;
    }
}
