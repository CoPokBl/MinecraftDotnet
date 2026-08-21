using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>The block entity a block item carries onto the block it places.</summary>
public record BlockEntityDataComponent() : IDataComponent<BlockEntityData> {
    public override Identifier Identifier => "minecraft:block_entity_data";

    /// <summary>
    /// The type travels inside the tag under <c>id</c>, the way it does for an entity, where the
    /// wire form carries it beside the tag as a protocol id.
    /// </summary>
    public override NbtCodec<BlockEntityData>? Codec => Persistent;
    private static readonly NbtCodec<BlockEntityData> Persistent = new(
        (val, _) => new CompoundTag(val.Tag.Children
            .Where(child => child.key != "id")
            .Append(("id", (INbtTag)new StringTag(val.Type.Identifier.ToString())))
            .ToArray()),
        (tag, registry) => {
            CompoundTag compound = tag.GetCompound();
            Identifier id = compound["id"].GetString();
            return new BlockEntityData(registry.BlockEntityTypes[id],
                new CompoundTag(compound.Children.Where(child => child.key != "id").ToArray()));
        });

    public override DataWriter WriteData(BlockEntityData val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.Read<BlockEntityData>(registry);
    }

    public override bool ValuesEqual(BlockEntityData val1, BlockEntityData val2) {
        return val1.Equals(val2);
    }
}
