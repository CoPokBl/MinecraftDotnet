using Minecraft.Registry;

namespace Minecraft.Data.ConsumeEffects;

public interface IConsumeEffect : IProtocolType {
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry);
    public IConsumeEffect ReadData(DataReader reader, MinecraftRegistry registry);
}
