namespace Minecraft.Schemas.Sound;

public record SoundEvent(string Identifier, float? FixedRange) : IWritable {
    
    public void Write(DataWriter writer) {
        writer
            .WriteString(Identifier)
            .WritePrefixedOptional(FixedRange, (f, wr) => wr.WriteFloat(f));
    }

    public static SoundEvent Deserialise(DataReader reader) {
        return new SoundEvent(
            reader.ReadString(),
            reader.ReadPrefixedOptional(re => re.ReadFloat()));
    }
}
