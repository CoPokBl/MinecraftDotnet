using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ConsumeEffects;

public record SimpleConsumeEffect(Identifier Identifier, int ProtocolId) : IConsumeEffect {
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer;
    }

    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        return this;
    }
}
