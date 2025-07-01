namespace Minecraft.Schemas.Particles;

public record SimpleParticle(int Id) : IParticle {
    
    public DataWriter WriteData(DataWriter writer) {
        // No data for simple particles
        return writer;
    }

    public IParticle ReadData(DataReader reader) {
        // No data for simple particles
        return this;
    }
}
