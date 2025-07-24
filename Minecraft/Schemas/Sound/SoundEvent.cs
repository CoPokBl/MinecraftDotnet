using Minecraft.Data;
using Minecraft.Data.Sounds;
using Minecraft.Registry;

namespace Minecraft.Schemas.Sound;

public record SoundEvent(ISoundType Type, float? FixedRange) : INetworkType<SoundEvent> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
        return writer
            .Write(Type.Identifier)
            .WritePrefixedOptional(FixedRange, (f, wr) => wr.WriteFloat(f));
    }

    public static SoundEvent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new SoundEvent(
            registry.SoundTypes[reader.ReadString()],
            reader.ReadPrefixedOptional(re => re.ReadFloat()));
    }
}
