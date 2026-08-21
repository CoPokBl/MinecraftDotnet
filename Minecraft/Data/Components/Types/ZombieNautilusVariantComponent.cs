using Minecraft.Data.Components.Codecs;
using Minecraft.Data.ZombieNautilusVariant;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ZombieNautilusVariantComponent() : IDataComponent<IZombieNautilusVariant> {
    public override Identifier Identifier => "minecraft:zombie_nautilus/variant";

    public override NbtCodec<IZombieNautilusVariant>? Codec => Persistent;
    private static readonly NbtCodec<IZombieNautilusVariant> Persistent = NbtCodecs.Holder<IZombieNautilusVariant>("minecraft:zombie_nautilus/variant", reg => reg.ZombieNautilusVariants);

    public override DataWriter WriteData(IZombieNautilusVariant val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.ZombieNautilusVariants.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.ZombieNautilusVariants[reader.ReadVarInt()];
    }

    public override bool ValuesEqual(IZombieNautilusVariant val1, IZombieNautilusVariant val2) {
        return val1.Identifier == val2.Identifier;
    }
}
