using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Generates the entries for a registry that the client synchronises, i.e. one whose elements are
/// NBT rather than a fixed protocol id table. Every one of them is written the same way — read
/// Minestom's dump, hand each element to the type's <c>FromNbt</c>, and write an entries file that
/// reads the built element back out of the registry — so they only differ by name.
/// </summary>
public static class DynamicRegistryCodeGen {

    /// <param name="dataFile">The Minestom data file holding the registry, e.g. <c>damage_type.json</c>.</param>
    /// <param name="interfaceName">The element interface, e.g. <c>IDamageType</c>.</param>
    /// <param name="className">
    /// The generated entries class, which is also its file name and the namespace under
    /// <c>Minecraft.Data</c> the interface lives in unless <paramref name="typeNamespace"/> says
    /// otherwise.
    /// </param>
    /// <param name="registryProperty">The property on <c>MinecraftRegistry</c> to add to.</param>
    public static string CreateEntries(string dataFile, string interfaceName, string className,
        string registryProperty, string? typeNamespace = null) {
        JObject regJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile(dataFile));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, JToken? value) in regJson) {
            if (value is not JObject obj) {
                Console.WriteLine($"Warning: Invalid {className} entry for key: " + key);
                continue;
            }

            string objJsonStr = obj.ToString(Formatting.None);
            fileEntries.Add($"public static readonly {interfaceName} {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"VanillaRegistry.Data.{registryProperty}[\"{key}\"];");

            // The entry is built here and read back out of the registry by the entries file. The other
            // way round — entries file builds it, registry adds it — makes the two static initialisers
            // circular, and whichever runs second sees the other's fields as null.
            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.{registryProperty}.Add({interfaceName}.FromNbt(" +
                           $"\"{key}\", (CompoundTag)INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"), Data));");
        }

        CodeGenUtils.CreateVanillaEntriesFile(className, typeNamespace ?? className, fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }
}
