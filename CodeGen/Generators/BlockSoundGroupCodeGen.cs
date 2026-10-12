using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns sound_type.json into <c>BlockSoundGroups</c>: every block sound group vanilla defines, by the
/// name a block state's <c>SoundType</c> carries, pointing at the generated sound events.
/// </summary>
public static class BlockSoundGroupCodeGen {
    private const string FileTemplate =
"""
using Minecraft.Data.Blocks;
using Minecraft.Data.Sounds;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>Vanilla's block sound groups, <c>SoundType</c>'s static fields.</summary>
public static class BlockSoundGroups {
{members}
    private static readonly Dictionary<string, BlockSoundGroup> ByName = new() {
{names}    };

    /// <summary>The group a block state plays, by the name its generated data carries.</summary>
    public static BlockSoundGroup Of(IBlock block) => ByName.TryGetValue(block.SoundType, out BlockSoundGroup? group) ? group : Stone;
}

""";

    public static void GenerateBlockSoundGroupCode(JObject registries) {
        JObject groups = JObject.Parse(CodeGenUtils.ReadDumpFile("sound_type.json"));
        JObject registered = (JObject)registries["minecraft:sound_event"]!["entries"]!;
        StringBuilder members = new();
        StringBuilder names = new();
        foreach ((string name, JToken? token) in groups) {
            JObject group = (JObject)token!;
            string member = CodeGenUtils.NamespacedIdToPascalName(name);
            // The empty group's intentionally_empty has no category for SoundCodeGen to name it by, and the
            // SoundType table leaves it out, so it is held directly.
            string Event(string key) {
                string id = group.Value<string>(key)!;
                return registered.ContainsKey(id) && id.Contains('.') ? "SoundType." + SoundCodeGen.GetVariableName(id) : $"new SimpleSoundType(\"{id}\")";
            }
            members.Append("    public static readonly BlockSoundGroup ").Append(member).Append(" = new(")
                .Append(group.Value<float>("volume").ToString("R", CultureInfo.InvariantCulture)).Append("f, ")
                .Append(group.Value<float>("pitch").ToString("R", CultureInfo.InvariantCulture)).Append("f, ")
                .Append(Event("break")).Append(", ").Append(Event("step")).Append(", ").Append(Event("place")).Append(", ")
                .Append(Event("hit")).Append(", ").Append(Event("fall")).Append(");\n");
            names.Append("        [\"").Append(name).Append("\"] = ").Append(member).Append(",\n");
        }
        File.WriteAllText("BlockSoundGroups.cs", FileTemplate.Replace("{members}", members.ToString()).Replace("{names}", names.ToString()));
    }
}
