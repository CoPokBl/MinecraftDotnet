using Minecraft.Data.Components.Codecs;
using Minecraft.Data.VillagerTypes;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record VillagerVariantComponent() : IDataComponent<IVillagerType> {
    public override Identifier Identifier => "minecraft:villager/variant";

    public override NbtCodec<IVillagerType>? Codec => Persistent;
    private static readonly NbtCodec<IVillagerType> Persistent = NbtCodecs.Holder<IVillagerType>("minecraft:villager/variant", reg => reg.VillagerTypes);

    public override DataWriter WriteData(IVillagerType val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.VillagerTypes.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.VillagerTypes[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IVillagerType val1, IVillagerType val2) {
        return val1.Identifier == val2.Identifier;
    }
}
