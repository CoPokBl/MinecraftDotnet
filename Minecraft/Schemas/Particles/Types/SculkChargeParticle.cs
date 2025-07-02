namespace Minecraft.Schemas.Particles.Types;

public record SculkChargeParticle(int Id, float Roll = 0f) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteFloat(Roll);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            Roll = reader.ReadFloat()
        };
    }
}
