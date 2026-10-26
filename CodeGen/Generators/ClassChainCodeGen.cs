using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Writes out the vanilla Java class hierarchy behind each entity type and each block.
/// <para>
/// Vanilla's behaviour is written against those classes rather than against registry entries:
/// <c>AvoidEntityGoal&lt;Ocelot&gt;</c>, <c>NearestAttackableTargetGoal&lt;Raider&gt;</c>,
/// <c>block instanceof DoorBlock</c>, <c>block instanceof BaseRailBlock</c>. There is one entity
/// class and one block record per shape of data here, not one per vanilla class, so an
/// <c>instanceof</c> in a method being ported has nothing to test against without this.
/// </para>
/// <para>
/// The alternative is a hand written table of which block counts as a door and which mob counts as
/// a raider, which is exactly the kind of thing that goes quietly wrong on a version bump. As data,
/// an upstream hierarchy change is a diff in these files.
/// </para>
/// <para>
/// Each table comes with a <b>type</b> naming its members, so the name a caller matches against is
/// checked by the compiler. A bare string would make a typo, and an upstream rename, into code that
/// silently never runs, which is the failure this whole file exists to avoid.
/// </para>
/// </summary>
public static class ClassChainCodeGen {
    private const string Header =
"""
using Minecraft.Schemas;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

""";

    /// <summary>
    /// The name type. A struct wrapping the name rather than a set of string constants, so that an
    /// unchecked name cannot be passed at all without saying <c>Custom</c> out loud.
    /// </summary>
    private const string TypeBody =
"""
/// <summary>
{summary}/// <p/>
/// One member per distinct class in the table, so a name that does not exist upstream does not
/// compile, and a rename on a version bump breaks the build rather than silently matching nothing.
/// <see cref="Custom"/> is the way out for a class this build has never heard of; it is deliberately
/// wordy, because reaching for it is usually a mistake.
/// </summary>
public readonly record struct {typename} {
    private readonly string? _name;

    private {typename}(string name) {
        _name = name;
    }

    /// <summary>The simple Java class name. Empty for a default-constructed value.</summary>
    public string Name => _name ?? "";

    /// <summary>
    /// A class this build's table does not contain. Matches nothing unless something upstream of the
    /// generator puts the name into a chain, so it is only useful to code that extends the tables.
    /// </summary>
    public static {typename} Custom(string name) {
        return new {typename}(name);
    }

    public override string ToString() {
        return Name;
    }

{members}}

""";

    private const string ChainBody =
"""
/// <summary>
{summary}/// </summary>
public static class {classname} {
    private static readonly Dictionary<Identifier, {typename}[]> Chains = new() {
{entries}    };

    /// <summary>
    /// The class chain, nearest first. Empty for something this table has never heard of, which
    /// cannot happen for a vanilla entry.
    /// </summary>
    public static {typename}[] Of(Identifier id) {
        return Chains.TryGetValue(id, out {typename}[]? chain) ? chain : [];
    }

    /// <summary>
    /// Whether the entry is, or inherits from, the given vanilla class. The name is the simple one
    /// (<c>Raider</c>, <c>DoorBlock</c>, <c>Monster</c>), because that is what the code being ported
    /// names and a package move upstream is not a behaviour change.
    /// </summary>
    public static bool Is(Identifier id, {typename} className) {
        foreach ({typename} name in Of(id)) {
            if (name == className) {
                return true;
            }
        }

        return false;
    }
{extra}}

""";

    public static void GenerateEntityClassCode(JObject _) {
        JObject entityData = JObject.Parse(CodeGenUtils.ReadDumpFile("entity_type.json"));
        const string typeName = "EntityClass";

        File.WriteAllText(typeName + ".cs", Header + TypeBody
            .Replace("{typename}", typeName)
            .Replace("{summary}",
                "/// A vanilla entity Java class, as named by <see cref=\"EntityClasses\"/>.\n")
            .Replace("{members}", Members(entityData, "entityClassChain", typeName)));

        File.WriteAllText("EntityClasses.cs", Header + ChainBody
            .Replace("{classname}", "EntityClasses")
            .Replace("{typename}", typeName)
            .Replace("{summary}",
                "/// Each entity type's vanilla Java class and everything it inherits from, nearest first.\n" +
                "/// <p/>\n" +
                "/// This exists because vanilla's AI is written against those classes and ours is written\n" +
                "/// against entity types. A goal upstream declares as <c>AvoidEntityGoal&lt;Raider&gt;</c>\n" +
                "/// becomes a test against this table.\n")
            .Replace("{entries}", Entries(entityData, "entityClassChain", typeName))
            .Replace("{extra}", ""));
    }

    public static void GenerateBlockClassCode(JObject _) {
        JObject blockData = JObject.Parse(CodeGenUtils.ReadDumpFile("block.json"));
        const string typeName = "BlockClass";

        List<string> byHand = [];
        foreach ((string key, JToken? entry) in blockData) {
            JToken? opensByHand = entry!["doorOpensByHand"];
            if (opensByHand != null && opensByHand.ToObject<bool>()) {
                byHand.Add("        \"" + key + "\",");
            }
        }

        string extra =
            "\n" +
            "    /// <summary>\n" +
            "    /// The doors a mob can decide to open, <c>DoorBlock.type().canOpenByHand()</c>. It lives\n" +
            "    /// on the block set type rather than on any state, and it is the whole difference between\n" +
            "    /// a closed door the pathfinder routes through and one it treats as a wall.\n" +
            "    /// </summary>\n" +
            "    private static readonly HashSet<Identifier> HandOpenableDoors = [\n" +
            string.Join("\n", byHand) + "\n" +
            "    ];\n" +
            "\n" +
            "    public static bool DoorOpensByHand(Identifier block) {\n" +
            "        return HandOpenableDoors.Contains(block);\n" +
            "    }\n";

        File.WriteAllText(typeName + ".cs", Header + TypeBody
            .Replace("{typename}", typeName)
            .Replace("{summary}",
                "/// A vanilla block Java class, as named by <see cref=\"BlockClasses\"/>.\n")
            .Replace("{members}", Members(blockData, "blockClassChain", typeName)));

        File.WriteAllText("BlockClasses.cs", Header + ChainBody
            .Replace("{classname}", "BlockClasses")
            .Replace("{typename}", typeName)
            .Replace("{summary}",
                "/// Each block's vanilla Java class and everything it inherits from, nearest first.\n" +
                "/// <p/>\n" +
                "/// The pathfinder's block classification is a chain of <c>instanceof</c> tests\n" +
                "/// (<c>DoorBlock</c>, <c>BaseRailBlock</c>, <c>LeavesBlock</c>, <c>FenceGateBlock</c>) and\n" +
                "/// there is no C# class per vanilla block to test. This is what they become.\n")
            .Replace("{entries}", Entries(blockData, "blockClassChain", typeName))
            .Replace("{extra}", extra));
    }

    /// <summary>Every distinct class name in the table, in the order they are first met.</summary>
    private static List<string> DistinctNames(JObject data, string field) {
        List<string> names = [];
        HashSet<string> seen = [];
        foreach ((string _, JToken? entry) in data) {
            foreach (string name in entry![field]!.ToObject<string[]>()!) {
                if (seen.Add(name)) {
                    names.Add(name);
                }
            }
        }

        names.Sort(StringComparer.Ordinal);
        return names;
    }

    private static string Members(JObject data, string field, string typeName) {
        StringBuilder members = new();
        foreach (string name in DistinctNames(data, field)) {
            if (name == typeName) {
                // A member cannot share its type's name. No vanilla class does today; if one ever
                // does, it needs a decided-on rename rather than a silently skipped member.
                throw new InvalidOperationException(
                    $"Vanilla class '{name}' collides with the generated type name.");
            }

            members.Append("    public static readonly ").Append(typeName).Append(' ').Append(name)
                .Append(" = new(\"").Append(name).Append("\");\n");
        }

        return members.ToString();
    }

    private static string Entries(JObject data, string field, string typeName) {
        StringBuilder entries = new();
        foreach ((string key, JToken? entry) in data) {
            string[] chain = entry![field]!.ToObject<string[]>()!;
            entries.Append("        { \"").Append(key).Append("\", [")
                .Append(string.Join(", ", chain.Select(name => typeName + "." + name)))
                .Append("] },\n");
        }

        return entries.ToString();
    }
}
