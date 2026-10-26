using Minecraft.Data.Components.Codecs;
using Minecraft.Data.FrogVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record FrogVariantComponent() : IDataComponent<IFrogVariant> {
    public override Identifier Identifier => "minecraft:frog/variant";

    public override NbtCodec<IFrogVariant>? Codec => Persistent;
    private static readonly NbtCodec<IFrogVariant> Persistent = NbtCodecs.Holder<IFrogVariant>("minecraft:frog/variant", reg => reg.FrogVariants);

    public override DataWriter WriteData(IFrogVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.FrogVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.FrogVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IFrogVariant val1, IFrogVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
