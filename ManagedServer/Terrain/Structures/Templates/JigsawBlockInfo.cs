using Minecraft.Registry;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using NBT;
using Minecraft.Placement;

namespace ManagedServer.Terrain.Structures.Templates;

/// <summary>
/// <c>JigsawBlockEntity.JointType</c>: whether two joined pieces have to agree about which way is up.
/// </summary>
public enum JointType {
    /// <summary>The tops must match, so the joined piece keeps this one's rotation.</summary>
    Aligned,

    /// <summary>The tops need not match, so the joined piece may take any of the four rotations.</summary>
    Rollable
}

/// <summary>
/// <c>StructureTemplate.JigsawBlockInfo</c>: a jigsaw block with its block entity already read.
/// </summary>
/// <remarks>
/// This is the one place a block entity's contents are read during generation, and it is only possible
/// because the contents travel <b>inside the template</b> rather than in the world: a jigsaw block's
/// pool, name and target are saved with the template, so no port of a live block entity is needed.
/// </remarks>
public readonly record struct JigsawBlockInfo(
    TemplateBlockInfo Info,
    JointType JointType,
    Identifier Name,
    Identifier Pool,
    Identifier Target,
    int PlacementPriority,
    int SelectionPriority) {

    public static readonly Identifier Empty = "minecraft:empty";

    public static JigsawBlockInfo Of(TemplateBlockInfo info, MinecraftRegistry registry) {
        NBT.Tags.CompoundTag nbt = info.Nbt
            ?? throw new FormatException($"A jigsaw block at {info.Pos} carries no block entity, so "
                + "there is nothing saying which pool it joins.");

        return new JigsawBlockInfo(
            info,
            ReadJointType(nbt, info.StateId, registry),
            nbt.Contains("name") ? Identifier.Parse(nbt["name"].GetString()) : Empty,
            nbt.Contains("pool") ? Identifier.Parse(nbt["pool"].GetString()) : Empty,
            nbt.Contains("target") ? Identifier.Parse(nbt["target"].GetString()) : Empty,
            nbt.Contains("placement_priority") ? nbt["placement_priority"].GetInteger() : 0,
            nbt.Contains("selection_priority") ? nbt["selection_priority"].GetInteger() : 0);
    }

    /// <summary>
    /// The joint, or the default for the block's own facing where the tag does not name one.
    /// </summary>
    /// <remarks>
    /// <c>getDefaultJointType</c>: a jigsaw facing horizontally is aligned and one facing up or down
    /// is rollable. That is what makes a village house keep its orientation while a floor decoration
    /// may be dropped in any of four ways.
    /// </remarks>
    private static JointType ReadJointType(NBT.Tags.CompoundTag nbt, uint stateId,
        MinecraftRegistry registry) {

        if (nbt.Contains("joint")) {
            string written = nbt["joint"].GetString();

            return written switch {
                "aligned" => JointType.Aligned,
                "rollable" => JointType.Rollable,
                _ => throw new FormatException($"Unknown jigsaw joint type \"{written}\".")
            };
        }

        return Directions.IsHorizontal(FrontFacing(registry, stateId))
            ? JointType.Aligned
            : JointType.Rollable;
    }

    /// <summary>Which way the jigsaw's front points, which is the side a piece joins on.</summary>
    public static BlockFace FrontFacing(MinecraftRegistry registry, uint stateId) {
        return Orientations.Split(OrientationOf(registry, stateId)).Front;
    }

    public static BlockFace TopFacing(MinecraftRegistry registry, uint stateId) {
        return Orientations.Split(OrientationOf(registry, stateId)).Top;
    }

    private static Orientation OrientationOf(MinecraftRegistry registry, uint stateId) {
        return registry.Blocks.GetByStateId(stateId) is IOriented oriented
            ? oriented.Orientation
            : throw new InvalidOperationException(
                "A jigsaw block info holds a state that is not a jigsaw block.");
    }

    /// <summary>
    /// <c>JigsawBlock.canAttach</c>: whether one jigsaw may be joined to another.
    /// </summary>
    /// <remarks>
    /// Three conditions, and the middle one is what the joint type is for: the fronts must be
    /// opposite, the <b>tops must match unless the source is rollable</b>, and this one's target must
    /// be the other one's name. Dropping the top test lets a rollable connection through in any
    /// rotation, which is the point of it.
    /// </remarks>
    public static bool CanAttach(MinecraftRegistry registry, JigsawBlockInfo source,
        JigsawBlockInfo target) {

        BlockFace sourceFront = FrontFacing(registry, source.Info.StateId);
        BlockFace targetFront = FrontFacing(registry, target.Info.StateId);
        BlockFace sourceTop = TopFacing(registry, source.Info.StateId);
        BlockFace targetTop = TopFacing(registry, target.Info.StateId);

        return sourceFront == targetFront.Opposite()
            && (source.JointType == JointType.Rollable || sourceTop == targetTop)
            && source.Target.Equals(target.Name);
    }
}
