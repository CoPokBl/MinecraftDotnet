using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Particles;

public interface IParticle {
    public int ProtocolId { get; }
    public Identifier Identifier { get; }
    
    /// <summary>
    /// Writes the data for this particle to the given writer.
    /// DOES NOT include the particle ID.
    /// </summary>
    /// <param name="writer">The object to write to.</param>
    /// <returns>The writer object.</returns>
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
    public IParticle ReadData(DataReader reader, MinecraftRegistry registry);
}
