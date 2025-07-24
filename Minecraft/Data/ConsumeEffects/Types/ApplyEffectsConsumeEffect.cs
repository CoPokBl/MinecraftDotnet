using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ConsumeEffects.Types;

public record ApplyEffectsConsumeEffect(Identifier Identifier, int ProtocolId, PotionEffect[]? Effects = null, float Probability = 0f) : IConsumeEffect {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedArray(Effects ?? [], (effect, w) => w.Write(effect, registry))
            .WriteFloat(Probability);
    }

    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Effects = reader.ReadPrefixedArray<PotionEffect>(registry)
        };
    }
}
