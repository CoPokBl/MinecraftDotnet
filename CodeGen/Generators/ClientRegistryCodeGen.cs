using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Dumps the vanilla element data for the registries that get synchronised to the client but
/// don't have a registry implementation on our side yet.
///
/// The client refuses to finish configuration unless these arrive with real data, and it
/// resolves individual elements by key (armour trim materials, jukebox songs and so on), so
/// sending a token entry isn't enough. Rather than hand maintain a list of what it wants, the
/// whole vanilla set is written out here and the server sends whatever it can't produce
/// itself at runtime.
/// </summary>
public static class ClientRegistryCodeGen {

    /// <summary>
    /// The registries the client synchronises that we don't have a real registry for yet. The
    /// full set is <c>RegistryDataLoader.SYNCHRONIZED_REGISTRIES</c> in the server jar:
    /// <code>
    /// javap -p -c -constants -cp versions/&lt;version&gt;/server-&lt;version&gt;.jar \
    ///     net.minecraft.resources.RegistryDataLoader
    /// </code>
    /// <c>datapack.json</c> can't tell us this — every datapack registry there looks the same,
    /// including the server side only ones like <c>minecraft:villager_trade</c>.
    ///
    /// Anything given a <c>MinecraftRegistry</c> implementation comes off this list; the server
    /// sends those from the registry itself and skips whatever it finds here for the same id.
    ///
    /// Sending a registry the client doesn't synchronise is not harmless: the element data is
    /// thrown away, and the tags that travel with it then fail to resolve, killing the
    /// connection at the end of configuration with
    /// <c>IllegalStateException: Missing registry: ...</c>. Re-check this list on every version
    /// bump.
    /// </summary>
    private static readonly string[] SynchronisedRegistries = [
        // Biomes first, and minecraft:plains first within them. The client hard requires plains
        // to exist (it's the fill value for a chunk's biome palette in Level's constructor, so
        // without it the world can't even be built) and our chunk sections default their biome
        // palette to id 0, which is a position in this list.
        "minecraft:worldgen/biome",
        "minecraft:chat_type",
        "minecraft:trim_material",
        "minecraft:wolf_variant",
        "minecraft:wolf_sound_variant",
        "minecraft:pig_variant",
        "minecraft:pig_sound_variant",
        "minecraft:frog_variant",
        "minecraft:cat_variant",
        "minecraft:cat_sound_variant",
        "minecraft:cow_variant",
        "minecraft:chicken_variant",
        "minecraft:chicken_sound_variant",
        "minecraft:zombie_nautilus_variant",
        "minecraft:sulfur_cube_archetype",
        "minecraft:test_environment",
        "minecraft:test_instance",
        "minecraft:dialog"
    ];

    /// <summary>Biome fields the server keeps to itself, see <c>Biome.NETWORK_CODEC</c>.</summary>
    private static readonly string[] BiomeWorldgenFields = ["carvers", "features", "spawners", "spawn_costs"];

    /// <summary>
    /// The elements of a registry, in the order they'll be given protocol ids. Alphabetical
    /// apart from <c>minecraft:plains</c>, which the client needs at biome id 0.
    /// </summary>
    private static IEnumerable<string> EnumerateElements(string folder) {
        return Directory.EnumerateFiles(folder, "*.json", SearchOption.AllDirectories)
            .OrderBy(file => Path.GetFileName(file) == "plains.json" ? 0 : 1)
            .ThenBy(file => file, StringComparer.Ordinal);
    }

    public static string CreateClientRegistryData(JObject _) {
        JObject output = new();
        int entryCount = 0;

        foreach (string registryId in SynchronisedRegistries) {
            string folder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft",
                registryId["minecraft:".Length..].Replace('/', Path.DirectorySeparatorChar));
            if (!Directory.Exists(folder)) {
                // The list above is hand maintained, so a missing folder means it's gone stale
                Console.WriteLine($"WARNING: no vanilla data for client registry {registryId}, " +
                                  "has it been renamed or removed?");
                continue;
            }

            JObject entries = new();
            foreach (string file in EnumerateElements(folder)) {
                string name = Path.GetRelativePath(folder, file).Replace(Path.DirectorySeparatorChar, '/');
                name = name[..^".json".Length];

                JObject element = JObject.Parse(File.ReadAllText(file));
                if (registryId == "minecraft:worldgen/biome") {
                    // Biome.NETWORK_CODEC doesn't read the terrain generation half of a biome,
                    // and it's eight times the size of the half it does read
                    foreach (string serverOnly in BiomeWorldgenFields) {
                        element.Remove(serverOnly);
                    }
                }

                entries["minecraft:" + name] = element;
                entryCount++;
            }

            if (entries.Count == 0) {
                continue;
            }

            // The client also rejects a registry whose tags were never bound, so they have
            // to travel with it
            JObject tags = new();
            string tagFolder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft", "tags",
                registryId["minecraft:".Length..].Replace('/', Path.DirectorySeparatorChar));
            if (Directory.Exists(tagFolder)) {
                foreach (string file in Directory.EnumerateFiles(tagFolder, "*.json", SearchOption.AllDirectories)) {
                    string name = Path.GetRelativePath(tagFolder, file).Replace(Path.DirectorySeparatorChar, '/');
                    JObject tag = JObject.Parse(File.ReadAllText(file));
                    tags["minecraft:" + name[..^".json".Length]] = tag["values"]?.ToObject<JArray>() ?? [];
                }
            }

            output[registryId] = new JObject {
                ["entries"] = entries,
                ["tags"] = tags
            };
        }

        // Written next to the ManagedServer project, which embeds it and sends it during config
        string repoRoot = Directory.GetCurrentDirectory();
        for (int i = 0; i < 3; i++) {
            repoRoot = Directory.GetParent(repoRoot)?.FullName
                       ?? throw new DirectoryNotFoundException("Could not walk up to the repo root.");
        }

        string outputDir = Path.Combine(repoRoot, "ManagedServer", "Resources");
        Directory.CreateDirectory(outputDir);
        File.WriteAllText(Path.Combine(outputDir, "ClientRegistries.json"),
            output.ToString(Formatting.None));

        Console.WriteLine($"Wrote {output.Count} client registries ({entryCount} entries)");
        return string.Empty;
    }
}
