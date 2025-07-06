using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Particles.Types;

public record ItemParticle(Identifier Identifier, int ProtocolId, ItemStack? Item = null) : IParticle {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .Write(w => (Item ?? ItemStack.Air).Write(w, registry));
    }

    public IParticle ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with {
            Item = ItemStack.Read(reader, registry)
        };
    }
}
