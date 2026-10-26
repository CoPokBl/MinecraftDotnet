using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Generates the entries for a registry that the client synchronises, i.e. one whose elements are
/// NBT rather than a fixed protocol id table. Every one of them is written the same way: read the
/// vanilla element data, hand each element to the type's <c>FromNbt</c>, and write an entries file
/// that reads the built element back out of the registry, so they only differ by name.
/// </summary>
public static class DynamicRegistryCodeGen {

    /// <param name="dataFile">
    /// The file naming the registry, e.g. <c>damage_type.json</c>. The same path without
    /// <c>.json</c> is the folder the vanilla data generator writes its elements to.
    /// </param>
    /// <param name="interfaceName">The element interface, e.g. <c>IDamageType</c>.</param>
    /// <param name="className">
    /// The generated entries class, which is also its file name and the namespace under
    /// <c>Minecraft.Data</c> the interface lives in unless <paramref name="typeNamespace"/> says
    /// otherwise.
    /// </param>
    /// <param name="registryProperty">The property on <c>MinecraftRegistry</c> to add to.</param>
    /// <param name="firstEntry">
    /// An element to put at protocol id 0, for the registries where the client cares which one
    /// lands there.
    /// </param>
    /// <param name="dropFields">
    /// Top level fields to leave out of the generated data. The registries with their own network
    /// codec are sent a cut down version, and there's no point baking the rest into the source:
    /// biome terrain generation alone is eight times the size of the half that's read.
    /// </param>
    public static string CreateEntries(string dataFile, string interfaceName, string className,
        string registryProperty, string? typeNamespace = null, string? firstEntry = null,
        string[]? dropFields = null) {
        JObject regJson = ReadRegistryData(dataFile);

        List<string> fileEntries = [];
        List<string> regEntries = [];

        IEnumerable<KeyValuePair<string, JToken?>> entries = regJson;
        if (firstEntry != null) {
            if (!regJson.ContainsKey(firstEntry)) {
                Console.WriteLine($"WARNING: {firstEntry} is missing from {dataFile}, so it can't be " +
                                  "put first. Has it been renamed or removed?");
            }
            entries = entries.OrderBy(e => e.Key == firstEntry ? 0 : 1);
        }

        foreach ((string key, JToken? value) in entries) {
            // A few elements are a bare list rather than an object, block_transformer among them, and
            // those are handed to FromNbt as the list.
            string cast;
            if (value is JObject obj) {
                foreach (string field in dropFields ?? []) {
                    obj.Remove(field);
                }
                cast = "(CompoundTag)";
            }
            else if (value is JArray && dropFields is null) {
                cast = "";
            }
            else {
                Console.WriteLine($"Warning: Invalid {className} entry for key: " + key);
                continue;
            }

            string objJsonStr = value.ToString(Formatting.None);
            fileEntries.Add($"public static readonly {interfaceName} {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"VanillaRegistry.Data.{registryProperty}[\"{key}\"];");

            // The entry is built here and read back out of the registry by the entries file. The
            // other way round, where the entries file builds it and the registry adds it, makes the
            // two static initialisers circular, and whichever runs second sees the other's fields as null.
            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.{registryProperty}.Add({interfaceName}.FromNbt(" +
                           $"\"{key}\", {cast}INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"), Data));");
        }

        CodeGenUtils.CreateVanillaEntriesFile(className, typeNamespace ?? className, fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }

    /// <summary>
    /// Reads the registry's elements, keyed by namespaced id.
    /// </summary>
    /// <remarks>
    /// The vanilla data generator writes these as a datapack, one file per element, so they get
    /// stitched back into the object the rest of the generator expects.
    /// </remarks>
    private static JObject ReadRegistryData(string dataFile) {
        string folder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft",
            dataFile[..^".json".Length].Replace('/', Path.DirectorySeparatorChar));
        if (!Directory.Exists(folder)) {
            throw new DirectoryNotFoundException($"No registry data for '{dataFile}': no {folder}.");
        }

        JObject result = new();
        foreach (string file in Directory.EnumerateFiles(folder, "*.json", SearchOption.AllDirectories)
                     .OrderBy(f => f, StringComparer.Ordinal)) {
            string name = Path.GetRelativePath(folder, file).Replace(Path.DirectorySeparatorChar, '/');
            result["minecraft:" + name[..^".json".Length]] = JToken.Parse(File.ReadAllText(file));
        }

        return result;
    }
}
