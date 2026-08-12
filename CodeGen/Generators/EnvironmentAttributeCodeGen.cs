using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Generates the environment attribute registry: the properties of the world that biomes,
/// dimensions and timelines set.
/// </summary>
/// <remarks>
/// The value type of an attribute is only visible at runtime, in the codec the vanilla
/// <c>EnvironmentAttributes</c> class builds it with, so it can't be read out of the data reports.
/// <c>Data/environment_attributes.json</c> carries it instead, keyed by attribute id. It's an
/// embedded resource, so rebuild CodeGen after editing it.
///
/// An attribute missing from that table is a hard error rather than a warning: the biomes that use
/// it would silently lose the value, and the client would just quietly render the wrong thing.
/// </remarks>
public static class EnvironmentAttributeCodeGen {

    public static string CreateEnvironmentAttributes(JObject registriesJson) {
        JObject valueTypes = JObject.Parse(CodeGenUtils.ReadEmbeddedFile("environment_attributes.json"));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, int protocolId) in
                 CodeGenUtils.BuildRegularRegistryEntries(registriesJson, "minecraft:environment_attribute")) {
            if (valueTypes[key] is not JObject info) {
                throw new InvalidOperationException(
                    $"No value type known for environment attribute '{key}'. Add it to " +
                    "CodeGen/Data/environment_attributes.json and rebuild CodeGen.");
            }

            string kind = info["kind"]!.Value<string>()!;
            bool syncable = info["syncable"]!.Value<bool>();
            string name = NameFor(key);

            fileEntries.Add($"public static readonly IEnvironmentAttribute {name} = " +
                            $"new SimpleEnvironmentAttribute(\"{key}\", " +
                            $"EnvironmentAttributeValueKind.{kind}, {syncable.ToString().ToLower()});");
            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.EnvironmentAttributes.Add({protocolId}, " +
                           $"EnvironmentAttribute.{name});");
        }

        CodeGenUtils.CreateVanillaEntriesFile("EnvironmentAttribute", "EnvironmentAttributes",
            fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }

    /// <summary>
    /// Attribute ids are grouped, as in <c>minecraft:visual/sky_color</c>, and the group is part
    /// of the name, so <c>gameplay/sky_light_level</c> and <c>visual/sky_light_color</c> stay apart.
    /// </summary>
    private static string NameFor(string key) {
        return string.Concat(key["minecraft:".Length..]
            .Split('/')
            .Select(CodeGenUtils.NamespacedIdToPascalName));
    }
}
