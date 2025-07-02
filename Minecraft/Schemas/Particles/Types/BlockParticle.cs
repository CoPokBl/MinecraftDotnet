namespace Minecraft.Schemas.Particles.Types;

public record BlockParticle(int Id, int BlockState = 0) : IParticle {

    public DataWriter WriteData(DataWriter writer) {
        return writer
            .WriteVarInt(BlockState);
    }

    public IParticle ReadData(DataReader reader) {
        return this with {
            BlockState = reader.ReadVarInt()
        };
    }
}
