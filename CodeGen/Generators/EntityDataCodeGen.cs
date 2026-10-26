using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

/// <summary>
/// Turns entity_data.json into <c>EntityDataFields</c>: one class per vanilla entity class holding a typed
/// <c>EntityDataField</c> for each accessor it declares. The indices come from the order accessors are
/// defined down the hierarchy, so a field added upstream shifts every subclass; reading a bare number
/// instead of one of these goes quietly wrong on the next version.
/// </summary>
public static class EntityDataCodeGen {
    private const string FileTemplate =
"""
using Minecraft.Data.Blocks;
using Minecraft.Data.PaintingVariant;
using Minecraft.Data.Particles;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Entities.Meta;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.

/// <summary>
/// The entity data each vanilla entity class declares, by the class's simple name. A field is valid
/// for an entity whose class chain contains the class it sits in.
/// </summary>
public static class EntityDataFields {
{classes}}

""";

    // The C# type EntityMetaContainer reads each serializer into. An unknown serializer fails the
    // generator, so a new one upstream is met by adding its reader rather than by a field typed wrongly.
    private static readonly Dictionary<string, string> Types = new() {
        ["BYTE"] = "sbyte",
        ["INT"] = "int",
        ["LONG"] = "long",
        ["FLOAT"] = "float",
        ["STRING"] = "string",
        ["COMPONENT"] = "TextComponent",
        ["OPTIONAL_COMPONENT"] = "Optional<TextComponent>",
        ["ITEM_STACK"] = "ItemStack",
        ["BOOLEAN"] = "bool",
        ["ROTATIONS"] = "Vec3<float>",
        ["BLOCK_POS"] = "Vec3<int>",
        ["OPTIONAL_BLOCK_POS"] = "Optional<Vec3<int>>",
        ["DIRECTION"] = "Cardinal",
        ["OPTIONAL_LIVING_ENTITY_REFERENCE"] = "Optional<Guid>",
        ["BLOCK_STATE"] = "IBlock",
        ["OPTIONAL_BLOCK_STATE"] = "Optional<IBlock>",
        ["PARTICLE"] = "IParticle",
        ["PARTICLES"] = "IParticle[]",
        ["VILLAGER_DATA"] = "(int, int, int)",
        ["OPTIONAL_UNSIGNED_INT"] = "Optional<int>",
        ["POSE"] = "EntityPose",
        ["CAT_VARIANT"] = "int",
        ["CAT_SOUND_VARIANT"] = "int",
        ["COW_VARIANT"] = "int",
        ["COW_SOUND_VARIANT"] = "int",
        ["WOLF_VARIANT"] = "int",
        ["WOLF_SOUND_VARIANT"] = "int",
        ["FROG_VARIANT"] = "int",
        ["PIG_VARIANT"] = "int",
        ["PIG_SOUND_VARIANT"] = "int",
        ["CHICKEN_VARIANT"] = "int",
        ["CHICKEN_SOUND_VARIANT"] = "int",
        ["ZOMBIE_NAUTILUS_VARIANT"] = "int",
        ["OPTIONAL_GLOBAL_POS"] = "Optional<(Identifier, Vec3<int>)>",
        ["PAINTING_VARIANT"] = "Or<int, IPaintingVariant>",
        ["SNIFFER_STATE"] = "SnifferState",
        ["ARMADILLO_STATE"] = "ArmadilloState",
        ["COPPER_GOLEM_STATE"] = "CopperGolemState",
        ["WEATHERING_COPPER_STATE"] = "WeatheringCopperState",
        ["VECTOR3"] = "Vec3<float>",
        ["QUATERNION"] = "Quaternion",
        // No reader decodes a profile yet, so nothing can be typed tighter than what the field holds.
        ["RESOLVABLE_PROFILE"] = "object",
        ["HUMANOID_ARM"] = "HumanoidArm",
        ["DYE_COLOR"] = "DyeColor"
    };

    public static void GenerateEntityDataCode(JObject _) {
        JObject classes = JObject.Parse(CodeGenUtils.ReadDumpFile("entity_data.json"));

        StringBuilder body = new();
        bool first = true;
        foreach ((string className, JToken? fields) in classes) {
            if (!first) {
                body.Append('\n');
            }
            first = false;
            body.Append("    public static class ").Append(className).Append(" {\n");
            foreach (JToken field in fields!) {
                string serializer = field["serializer"]!.ToString();
                if (!Types.TryGetValue(serializer, out string? type)) {
                    throw new InvalidDataException($"{className}.{field["field"]} uses serializer {serializer}, which has no C# type");
                }
                body.Append("        /// <summary><c>").Append(field["field"]).Append("</c>.</summary>\n")
                    .Append("        public static readonly EntityDataField<").Append(type).Append("> ")
                    .Append(MemberName(className, field["field"]!.ToString())).Append(" = new(")
                    .Append(field["id"]!.Value<int>()).Append(");\n");
            }
            body.Append("    }\n");
        }

        File.WriteAllText("EntityDataFields.cs", FileTemplate.Replace("{classes}", body.ToString()));
    }

    // DATA_SWELL_DIR, SLEEPING_POS_ID and AGE_LOCKED as SwellDir, SleepingPos and AgeLocked. The _ID
    // stays where dropping it would name the member after its class, as ItemDisplay's would.
    private static string MemberName(string className, string field) {
        string name = field.StartsWith("DATA_") ? field[5..] : field;
        string member = CodeGenUtils.NamespacedIdToPascalName((name.EndsWith("_ID") ? name[..^3] : name).ToLowerInvariant());
        return member == className ? CodeGenUtils.NamespacedIdToPascalName(name.ToLowerInvariant()) : member;
    }
}
