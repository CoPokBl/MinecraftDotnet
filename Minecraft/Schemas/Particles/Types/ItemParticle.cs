using Minecraft.Schemas.Items;

namespace Minecraft.Schemas.Particles.Types;

public record ItemParticle(int Id, Slot? Item = null) : IParticle {
    
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
