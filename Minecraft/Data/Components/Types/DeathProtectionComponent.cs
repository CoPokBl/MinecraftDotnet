using Minecraft.Data.Components.Codecs;
using Minecraft.Data.ConsumeEffects;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What makes an item a totem: a fatal hit consumes it instead, and these effects are applied.
/// </summary>
public record DeathProtectionComponent() : IDataComponent<IConsumeEffect[]> {
    public override Identifier Identifier => "minecraft:death_protection";

    public override NbtCodec<IConsumeEffect[]>? Codec => Persistent;
    private static readonly NbtCodec<IConsumeEffect[]> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .ListOrOmit("death_effects", val,
                effect => EffectCodecs.WriteConsumeEffect(effect, registry))
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:death_protection");
            IConsumeEffect[] effects = node.List("death_effects",
                effect => EffectCodecs.ReadConsumeEffect(effect, registry, "minecraft:death_protection"));
            node.AssertRead();
            return effects;
        });

    public override DataWriter WriteData(IConsumeEffect[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (effect, w) =>
            effect.WriteData(w.WriteVarInt(registry.ConsumeEffects.GetProtocolId(effect)), registry));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r => registry.ConsumeEffects[r.ReadVarInt()].ReadData(r, registry));
    }

    public override bool ValuesEqual(IConsumeEffect[] val1, IConsumeEffect[] val2) {
        return val1.SequenceEqual(val2);
    }
}
