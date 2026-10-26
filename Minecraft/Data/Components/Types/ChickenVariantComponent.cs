using Minecraft.Data.ChickenVariant;
using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ChickenVariantComponent() : IDataComponent<IChickenVariant> {
    public override Identifier Identifier => "minecraft:chicken/variant";

    public override NbtCodec<IChickenVariant>? Codec => Persistent;
    private static readonly NbtCodec<IChickenVariant> Persistent = NbtCodecs.Holder<IChickenVariant>("minecraft:chicken/variant", reg => reg.ChickenVariants);

    public override DataWriter WriteData(IChickenVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.ChickenVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.ChickenVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IChickenVariant val1, IChickenVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
