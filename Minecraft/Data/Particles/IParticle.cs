using Minecraft.Registry;

namespace Minecraft.Data.Particles;

public interface IParticle : IProtocolType {
    /// <summary>
    /// Writes the data for this particle to the given writer.
    /// DOES NOT include the particle ID.
    /// </summary>
    /// <param name="writer">The object to write to.</param>
    /// <param name="registry">Registry object to use to deserialise data.</param>
    /// <returns>The writer object.</returns>
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
    public IParticle ReadData(DataReader reader, MinecraftRegistry registry);
}
