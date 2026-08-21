using Minecraft.Data.Components.Codecs;
using Minecraft.Data.DamageType;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The damage an item deals when it is what hurt something, such as a mace's smash.</summary>
public record DamageTypeComponent() : IDataComponent<IDamageType> {
    public override Identifier Identifier => "minecraft:damage_type";

    public override NbtCodec<IDamageType>? Codec => Persistent;
    private static readonly NbtCodec<IDamageType> Persistent = NbtCodecs.Holder<IDamageType>("minecraft:damage_type", reg => reg.DamageTypes);

    public override DataWriter WriteData(IDamageType val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.DamageTypes.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.DamageTypes[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IDamageType val1, IDamageType val2) {
        return val1.Identifier == val2.Identifier;
    }
}
