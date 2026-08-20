using Minecraft.Schemas;

namespace ManagedServer.Terrain.Data;

/// <summary>One file of a datapack, and the registry id it is filed under.</summary>
/// <remarks>
/// <see cref="Path"/> is what <see cref="IDatapackSource.Open"/> takes and is the full path within the
/// pack, so a layered source can tell two files of the same id apart by where each came from.
/// </remarks>
public readonly record struct DatapackEntry(Identifier Id, string Path);

/// <summary>
/// Somewhere the data that describes a world is read from: a directory, a zip, or the vanilla server
/// jar, which is laid out as a datapack itself.
/// </summary>
/// <remarks>
/// <b>This exists because nothing Mojang wrote ships here.</b> The density function tree, the biome
/// feature lists, the loot tables and the structure templates are all content rather than measured
/// fact, so they are supplied by the consumer at runtime instead of embedded.
/// <p/>
/// It buys a second thing that matters more day to day: worldgen becomes configurable. A consumer
/// overriding one density function or adding a feature to a biome writes one file and layers it over
/// vanilla with <see cref="LayeredDatapack"/>, rather than rebuilding this assembly.
/// <p/>
/// A datapack's layout is <c>data/&lt;namespace&gt;/&lt;registry path&gt;/&lt;id&gt;.&lt;ext&gt;</c>,
/// and an id keeps any subdirectories under the registry path, so
/// <c>data/minecraft/worldgen/density_function/overworld/base_3d_noise.json</c> is
/// <c>minecraft:overworld/base_3d_noise</c>. That is vanilla's own resolution, which is what lets the
/// server jar be read directly.
/// </remarks>
public interface IDatapackSource {
    /// <summary>
    /// Every file filed under a registry path, across every namespace the pack carries.
    /// </summary>
    /// <param name="registryPath">
    /// The part between the namespace and the id, such as <c>worldgen/density_function</c> or
    /// <c>loot_table/blocks</c>. No leading or trailing slash.
    /// </param>
    /// <param name="extension">The file extension to take, including its dot.</param>
    IEnumerable<DatapackEntry> Entries(string registryPath, string extension = ".json");

    /// <summary>Opens one entry by the path it was listed under.</summary>
    Stream Open(string path);

    /// <summary>
    /// A name for this source, for the message a parser throws with.
    /// </summary>
    /// <remarks>
    /// The input is a consumer's pack rather than a copy pinned to this build, so "what could not be
    /// parsed" has to come with "and which pack it came from" to be worth anything.
    /// </remarks>
    string Describe();
}
