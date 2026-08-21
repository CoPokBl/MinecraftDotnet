using Minecraft.Data.Components.Codecs;
using Minecraft.Data.WolfVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record WolfVariantComponent() : IDataComponent<IWolfVariant> {
    public override Identifier Identifier => "minecraft:wolf/variant";

    public override NbtCodec<IWolfVariant>? Codec => Persistent;
    private static readonly NbtCodec<IWolfVariant> Persistent = NbtCodecs.Holder<IWolfVariant>("minecraft:wolf/variant", reg => reg.WolfVariants);

    public override DataWriter WriteData(IWolfVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.WolfVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.WolfVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IWolfVariant val1, IWolfVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
