using Minecraft.Schemas;
using Minecraft.Schemas.Items;

namespace Minecraft.Data.Particles.Types;

public record ItemParticle(Identifier Identifier, int ProtocolId, Slot? Item = null) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .Write(Item ?? Slot.Air);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Item = Slot.Read(reader)
        };
    }
}
