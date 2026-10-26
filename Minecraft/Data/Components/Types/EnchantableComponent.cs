using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The enchanting table's enchantability value, which sets how good its offers get.</summary>
public record EnchantableComponent() : IDataComponent<int> {
    public override Identifier Identifier => "minecraft:enchantable";

    /// <summary>The number is under a key rather than bare, which the wire form does not show.</summary>
    public override NbtCodec<int>? Codec => Persistent;
    private static readonly NbtCodec<int> Persistent = NbtCodecs.Wrapped("minecraft:enchantable", "value", NbtCodecs.Int());

    public override DataWriter WriteData(int val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadVarInt();
    }

    public override bool ValuesEqual(int val1, int val2) {
        return val1 == val2;
    }
}
