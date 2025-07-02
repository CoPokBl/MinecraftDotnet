namespace Minecraft.Schemas.Particles.Types;

public record ShriekParticle(int Id, int Delay = 0) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteVarInt(Delay);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Delay = reader.ReadVarInt()
        };
    }
}
