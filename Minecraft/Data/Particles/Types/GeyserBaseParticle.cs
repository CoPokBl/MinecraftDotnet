using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record GeyserBaseParticle(Identifier Identifier,  int WaterBlocks = 0, float BurstImpulseBase = 0f) : IParticle {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteInteger(WaterBlocks)
            .WriteFloat(BurstImpulseBase);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            WaterBlocks = reader.ReadInteger(),
            BurstImpulseBase = reader.ReadFloat()
        };
    }
}
