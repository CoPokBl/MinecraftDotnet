using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ConsumeEffects.Types;

public record TeleportRandomlyConsumeEffect(Identifier Identifier, int ProtocolId, float Diameter = 0f) : IConsumeEffect {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteFloat(Diameter);
    }

    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Diameter = reader.ReadFloat()
        };
    }
}
