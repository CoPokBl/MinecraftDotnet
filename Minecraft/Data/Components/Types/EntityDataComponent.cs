using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>The entity a spawn egg or armour stand item puts into the world.</summary>
public record EntityDataComponent() : IDataComponent<EntityData> {
    public override Identifier Identifier => "minecraft:entity_data";

    /// <summary>
    /// The type travels inside the tag under <c>id</c>, where the wire form has it beside the tag as
    /// a protocol id, so it is taken out on the way in and put back on the way out.
    /// </summary>
    public override NbtCodec<EntityData>? Codec => Persistent;
    private static readonly NbtCodec<EntityData> Persistent = new(
        (val, _) => WithId(val.Tag, val.Type.Identifier),
        (tag, registry) => {
            CompoundTag compound = tag.GetCompound();
            Identifier id = compound["id"].GetString();
            return new EntityData(registry.EntityTypes[id], Without(compound, "id"));
        });

    private static CompoundTag WithId(CompoundTag tag, Identifier id) {
        return new CompoundTag(tag.Children
            .Where(child => child.key != "id")
            .Append(("id", (INbtTag)new StringTag(id.ToString())))
            .ToArray());
    }

    private static CompoundTag Without(CompoundTag tag, string key) {
        return new CompoundTag(tag.Children.Where(child => child.key != key).ToArray());
    }

    public override DataWriter WriteData(EntityData val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.Read<EntityData>(registry);
    }

    public override bool ValuesEqual(EntityData val1, EntityData val2) {
        return val1.Equals(val2);
    }
}
