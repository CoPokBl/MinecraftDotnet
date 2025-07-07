using Minecraft.Data.Sounds;
using Minecraft.Registry;

namespace Minecraft.Schemas.Sound;

public record SoundEvent(ISoundType Type, float? FixedRange) : IWritable {
    
    public void Write(DataWriter writer) {
        writer
            .Write(Type.Identifier)
            .WritePrefixedOptional(FixedRange, (f, wr) => wr.WriteFloat(f));
    }

    public static SoundEvent Deserialise(DataReader reader, MinecraftRegistry registry) {
        return new SoundEvent(
            registry.SoundTypes[reader.ReadString()],
            reader.ReadPrefixedOptional(re => re.ReadFloat()));
    }
}
