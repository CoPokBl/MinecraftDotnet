using System.Globalization;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Generates the environment attribute registry: the properties of the world that biomes,
/// dimensions and timelines set.
/// </summary>
/// <remarks>
/// An attribute's type, default, range and flags are only visible at runtime, in the builder the vanilla
/// <c>EnvironmentAttributes</c> class makes it with, so they come from the dump's
/// <c>environment_attribute.json</c>. Each attribute names its type as a member of the hand-written
/// <c>AttributeTypes</c>, so a type that is new upstream fails here or fails to compile rather than going unread.
/// </remarks>
public static class EnvironmentAttributeCodeGen {

    /// <summary>The attribute type's member on <c>AttributeTypes</c>, and the C# type of its values.</summary>
    private static readonly Dictionary<string, (string Member, string ValueType)> Types = new() {
        ["minecraft:boolean"] = ("Boolean", "bool"),
        ["minecraft:tri_state"] = ("TriState", "TriState"),
        ["minecraft:float"] = ("Float", "float"),
        ["minecraft:angle_degrees"] = ("AngleDegrees", "float"),
        ["minecraft:rgb_color"] = ("RgbColor", "Vector3"),
        ["minecraft:argb_color"] = ("ArgbColor", "Vector4"),
        ["minecraft:moon_phase"] = ("MoonPhase", "MoonPhase"),
        ["minecraft:activity"] = ("Activity", "Identifier"),
        ["minecraft:bed_rule"] = ("BedRule", "BedRule"),
        ["minecraft:particle"] = ("Particle", "ParticleValue"),
        ["minecraft:ambient_particles"] = ("AmbientParticles", "IReadOnlyList<AmbientParticle>"),
        ["minecraft:background_music"] = ("BackgroundMusic", "BackgroundMusic"),
        ["minecraft:ambient_sounds"] = ("AmbientSounds", "AmbientSounds"),
        ["minecraft:mob_spawn_settings"] = ("MobSpawnSettings", "INbtTag")
    };

    public static string CreateEnvironmentAttributes(JObject registriesJson) {
        JObject dump = JObject.Parse(CodeGenUtils.ReadDumpFile("environment_attribute.json"));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, int protocolId) in
                 CodeGenUtils.BuildRegularRegistryEntries(registriesJson, "minecraft:environment_attribute")) {
            if (dump[key] is not JObject info) {
                throw new InvalidOperationException($"The dump has no environment attribute '{key}'. Delete the dump directory and rerun.");
            }
            string typeId = info["type"]!.Value<string>()!;
            if (!Types.TryGetValue(typeId, out (string Member, string ValueType) type)) {
                throw new InvalidOperationException(
                    $"Environment attribute '{key}' has the attribute type '{typeId}', which has no entry in " +
                    $"{nameof(EnvironmentAttributeCodeGen)}.{nameof(Types)} or member on AttributeTypes.");
            }

            string name = NameFor(key);
            string defaultValue = DefaultFor(key, type.Member, info);
            string range = info["rangeMin"] is { } min
                ? $"AttributeRange.OfFloat({FloatLiteral(min.Value<string>()!)}, {FloatLiteral(info["rangeMax"]!.Value<string>()!)})"
                : $"AttributeRange<{type.ValueType}>.Any";

            fileEntries.Add($"public static readonly EnvironmentAttribute<{type.ValueType}> {name} = new(\"{key}\", " +
                            $"AttributeTypes.{type.Member}, {defaultValue}, {range}, " +
                            $"syncable: {Bool(info, "syncable")}, positional: {Bool(info, "positional")}, " +
                            $"spatiallyInterpolated: {Bool(info, "spatiallyInterpolated")}, " +
                            $"fullResolutionBiomes: {Bool(info, "fullResolutionBiomes")});");
            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.EnvironmentAttributes.Add({protocolId}, " +
                           $"EnvironmentAttribute.{name});");
        }

        CodeGenUtils.CreateVanillaEntriesFile("EnvironmentAttribute",
            "EnvironmentAttributes;\nusing System.Numerics;\nusing Minecraft.Schemas;\nusing NBT", fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }

    private static string Bool(JObject info, string key) => info[key]!.Value<bool>() ? "true" : "false";

    /// <summary>
    /// The default as C#. Numbers and colours come as their float components; everything else as its codec's
    /// JSON, which for the vanilla defaults is always an empty or a single valued form, so anything richer is
    /// refused here rather than guessed at.
    /// </summary>
    private static string DefaultFor(string key, string member, JObject info) {
        if (info["defaultComponents"] is JArray components) {
            string[] floats = components.Select(c => FloatLiteral(c.ToString(Newtonsoft.Json.Formatting.None))).ToArray();
            return member switch {
                "Float" or "AngleDegrees" => floats[0],
                "RgbColor" => $"new Vector3({string.Join(", ", floats)})",
                "ArgbColor" => $"new Vector4({string.Join(", ", floats)})",
                _ => throw new InvalidOperationException($"'{key}' is a {member} with float components")
            };
        }

        JToken encoded = JToken.Parse(info["default"]!.Value<string>()!);
        string json = encoded.ToString(Newtonsoft.Json.Formatting.None);
        return member switch {
            "Boolean" => encoded.Value<bool>() ? "true" : "false",
            "TriState" => $"TriStateExtensions.ParseTriState(\"{encoded.Value<string>()}\")",
            "MoonPhase" => $"MoonPhaseExtensions.ParseMoonPhase(\"{encoded.Value<string>()}\")",
            "Activity" => $"(Identifier)\"{encoded.Value<string>()}\"",
            "Particle" when encoded is JObject particle && particle.Count == 1 =>
                $"new ParticleValue(\"{particle["type"]!.Value<string>()}\")",
            "AmbientParticles" when encoded is JArray { Count: 0 } => "Array.Empty<AmbientParticle>()",
            "BackgroundMusic" when encoded is JObject { Count: 0 } => "BackgroundMusic.Silent",
            "AmbientSounds" when encoded is JObject { Count: 0 } => "AmbientSounds.None",
            "BedRule" => $"BedRule.FromNbt(INbtTag.FromJson(\"\"\"{json}\"\"\"))",
            "MobSpawnSettings" => $"INbtTag.FromJson(\"\"\"{json}\"\"\")",
            _ => throw new InvalidOperationException($"No way to write the default of '{key}' ({member}): {json}")
        };
    }

    /// <summary>Java's <c>Float.toString</c> round trips, so the same text parses back to the same float here.</summary>
    private static string FloatLiteral(string javaFloat) {
        switch (javaFloat) {
            case "Infinity":
                return "float.PositiveInfinity";
            case "-Infinity":
                return "float.NegativeInfinity";
        }
        string text = float.Parse(javaFloat, CultureInfo.InvariantCulture).ToString("R", CultureInfo.InvariantCulture);
        return text.Contains('.') || text.Contains('E') ? text + "F" : text + ".0F";
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
