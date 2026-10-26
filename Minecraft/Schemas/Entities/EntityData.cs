using Minecraft.Data;
using Minecraft.Data.Entities;
using Minecraft.Registry;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas.Entities;

/// <summary>
/// An entity's type with the tag it would be spawned from, vanilla's
/// <c>TypedEntityData&lt;EntityType&gt;</c>.
/// </summary>
/// <remarks>
/// The type is carried beside the tag rather than in it. Vanilla strips any <c>id</c> key on the way
/// in and puts one back on the way out, so a tag holding one would write the type twice.
/// </remarks>
public record EntityData(IEntityType Type, CompoundTag Tag) : INetworkType<EntityData> {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.EntityTypes.GetProtocolId(Type)).WriteNbt(Tag);
    }

    public static EntityData ReadData(DataReader reader, MinecraftRegistry registry) {
        return new EntityData(registry.EntityTypes[reader.ReadVarInt()], (CompoundTag)reader.ReadNbt());
    }

    public virtual bool Equals(EntityData? other) {
        return other != null && Type.Identifier == other.Type.Identifier &&
               Tag.ToJsonString() == other.Tag.ToJsonString();
    }

    public override int GetHashCode() {
        return HashCode.Combine(Type.Identifier, Tag.ToJsonString());
    }
}
