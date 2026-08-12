using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles.Types;

public record GeyserParticle(Identifier Identifier,  int WaterBlocks = 0) : IParticle {

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteInteger(WaterBlocks);
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            WaterBlocks = reader.ReadInteger()
        };
    }
}
