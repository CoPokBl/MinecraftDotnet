using Minecraft.Data;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Blocks;

/// <summary>
/// A block entity's type with the tag it would be created from, vanilla's
/// <c>TypedEntityData&lt;BlockEntityType&gt;</c>.
/// </summary>
/// <remarks>
/// The type is carried beside the tag rather than in it. Vanilla strips any <c>id</c> key on the way
/// in and puts one back on the way out, so a tag holding one would write the type twice.
/// </remarks>
public record BlockEntityData(IBlockEntityType Type, CompoundTag Tag) : INetworkType<BlockEntityData> {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.BlockEntityTypes.GetProtocolId(Type)).WriteNbt(Tag);
    }

    public static BlockEntityData ReadData(DataReader reader, MinecraftRegistry registry) {
        return new BlockEntityData(registry.BlockEntityTypes[reader.ReadVarInt()], (CompoundTag)reader.ReadNbt());
    }

    public virtual bool Equals(BlockEntityData? other) {
        return other != null && Type.Identifier == other.Type.Identifier &&
               Tag.ToJsonString() == other.Tag.ToJsonString();
    }

    public override int GetHashCode() {
        return HashCode.Combine(Type.Identifier, Tag.ToJsonString());
    }
}
