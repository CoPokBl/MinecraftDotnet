using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.BlockTransformer;

/// <summary>
/// <c>BlockTransformer</c>: what a tool turns the block it is used on into, tried in order until one
/// provider has an answer for the block. The axe, shovel and hoe each name one through their
/// <c>block_transformer</c> component.
/// </summary>
public interface IBlockTransformer : IProtocolType {
    public IReadOnlyList<BlockTransformData> Transforms { get; }

    /// <summary>The element is a bare list, <c>BlockTransformData.CODEC.listOf(1, 200)</c>.</summary>
    public INbtTag ToNbt() {
        return new ListTag(Transforms.Select(INbtTag (t) => t.ToNbt()).ToArray());
    }

    public static IBlockTransformer FromNbt(Identifier ident, INbtTag tag, MinecraftRegistry reg) {
        return new SimpleBlockTransformer(ident, tag.AsList()
            .Select(entry => BlockTransformData.FromNbt(entry, reg))
            .ToArray());
    }
}

public record SimpleBlockTransformer(Identifier Identifier, IReadOnlyList<BlockTransformData> Transforms) : IBlockTransformer;

/// <summary><c>BlockTransformer.TransformParticle</c>, with the level event each one plays.</summary>
public enum TransformParticle {
    None = 0,
    Scrape = 1,
    WaxOn = 2,
    WaxOff = 3
}

/// <summary><c>BlockTransformer.DropStrategy</c>: where the loot of a transform pops out.</summary>
public enum TransformDropStrategy {
    ClickedFace = 0,
    FromMiddle = 1
}

/// <summary><c>BlockTransformer.TransformType</c>. A copper chest also tells its other half.</summary>
public enum TransformType {
    SingleBlock = 0,
    CopperChest = 1
}

/// <summary><c>BlockTransformer.BlockTransformData</c>.</summary>
/// <param name="BlockStateProvider">
/// The provider, as a registry name or an inline provider object. A provider with no answer for the
/// clicked block is what passes on to the next entry.
/// </param>
/// <param name="DisallowedFaces">Faces that cannot be clicked to apply this entry.</param>
/// <param name="Loot">A loot table dropped from the block the transform replaces.</param>
/// <param name="UpdateFromNeighbors">Whether the new state is run through <c>Block.updateFromNeighbourShapes</c>.</param>
/// <param name="ItemDamagePerUse">
/// Durability a damageable tool loses. The codec's default is 0, not the builder's 1, and only the
/// codec's matters to a datapack.
/// </param>
public record BlockTransformData(
    INbtTag BlockStateProvider,
    Or<ISoundType, SoundEvent>? Sound = null,
    TransformParticle Particle = TransformParticle.None,
    BlockFace[]? DisallowedFaces = null,
    Identifier? Loot = null,
    TransformDropStrategy DropStrategy = TransformDropStrategy.FromMiddle,
    bool UpdateFromNeighbors = true,
    TransformType TransformType = TransformType.SingleBlock,
    bool ConsumeOnUse = true,
    int ItemDamagePerUse = 0) {

    /// <summary><c>SoundEvents.EMPTY</c>, which is what an entry with no sound plays.</summary>
    public const string EmptySound = "minecraft:intentionally_empty";

    private static readonly string[] FaceNames = ["down", "up", "north", "south", "west", "east"];

    public INbtTag ToNbt() {
        CompoundBuilder builder = new CompoundBuilder()
            .Tag("block_state_provider", BlockStateProvider)
            .Sound("sound", Sound is { IsValue1: true } named && named.Value1!.Identifier == EmptySound ? null : Sound)
            .Enum("particle", Particle, TransformParticle.None);
        if (DisallowedFaces is { Length: > 0 }) {
            builder.List("disallowed_faces", DisallowedFaces, face => new StringTag(FaceNames[(int)face]));
        }

        return builder
            .Id("loot", Loot)
            .Enum("drop_strategy", DropStrategy, TransformDropStrategy.FromMiddle)
            .Bool("update_from_neighbors", UpdateFromNeighbors, true)
            .Enum("transform_type", TransformType, TransformType.SingleBlock)
            .Bool("consume_on_use", ConsumeOnUse, true)
            .Int("item_damage_per_use", ItemDamagePerUse, 0)
            .Build();
    }

    public static BlockTransformData FromNbt(INbtTag tag, MinecraftRegistry reg) {
        NbtNode node = NbtNode.Of(tag, "minecraft:block_transformer");
        BlockTransformData data = new(
            node.Require("block_state_provider"),
            node.Sound("sound", reg),
            node.Enum("particle", TransformParticle.None),
            node.List("disallowed_faces", face => (BlockFace)Array.IndexOf(FaceNames, face.GetString())),
            node.IdOrNull("loot"),
            node.Enum("drop_strategy", TransformDropStrategy.FromMiddle),
            node.Bool("update_from_neighbors", true),
            node.Enum("transform_type", TransformType.SingleBlock),
            node.Bool("consume_on_use", true),
            node.Int("item_damage_per_use", 0));
        node.AssertRead();
        return data;
    }
}
