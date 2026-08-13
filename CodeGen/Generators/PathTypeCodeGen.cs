using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns path_type.json into the <c>PathType</c> enum and its default malus table.
/// <para>
/// The malus values are enum constructor constants in the jar, so nothing but the enum knows them
/// and a rebalance upstream would otherwise have to be spotted by eye. They are also load bearing
/// rather than decorative: a negative malus is how the node evaluator says "not passable", so a
/// wrong sign turns a wall into a door.
/// </para>
/// <para>
/// The enum's order is vanilla's, which is the order the values travel in the debug path packet.
/// </para>
/// </summary>
public static class PathTypeCodeGen {
    private const string FileTemplate =
"""
namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>
/// What a mob's pathfinder makes of a block, vanilla's <c>PathType</c>. Declared in vanilla's own
/// order, which is the order these travel in the debug path packet.
/// </summary>
public enum PathType {
{members}}

/// <summary>
/// What each <see cref="PathType"/> costs to path through before a mob's own overrides, vanilla's
/// <c>PathType.getMalus</c>.
/// <p/>
/// A negative value means impassable, which is the single most load bearing fact in the table: the
/// node evaluator rejects a candidate on <c>malus &lt; 0</c> rather than on any property of the
/// block. Read it through a mob's <c>PathfindingMalus</c>, which layers its own answers on top.
/// </summary>
public static class PathTypeMalus {
    private static readonly float[] Defaults = [
{values}    ];

    public static float Of(PathType type) {
        return Defaults[(int)type];
    }
}

""";

    public static void GeneratePathTypeCode(JObject _) {
        JObject pathTypes = JObject.Parse(CodeGenUtils.ReadDumpFile("path_type.json"));

        StringBuilder members = new();
        StringBuilder values = new();

        foreach ((string name, JToken? malus) in pathTypes) {
            members.Append("    ").Append(CodeGenUtils.NamespacedIdToPascalName(name.ToLowerInvariant()))
                .Append(",\n");
            values.Append("        ")
                .Append(malus!.ToObject<float>().ToString("R", CultureInfo.InvariantCulture))
                .Append("f,\n");
        }

        File.WriteAllText("PathType.cs", FileTemplate
            .Replace("{members}", members.ToString())
            .Replace("{values}", values.ToString()));
    }
}
