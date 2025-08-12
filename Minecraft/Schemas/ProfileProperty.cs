using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas;

public class ProfileProperty : INetworkType<ProfileProperty> {
    public required string Name;
    public required string Value;
    public string? Signature;
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteString(Name)
            .WriteString(Value)
            .WritePrefixedOptional(Signature, (s, w) => w.WriteString(s));
    }

    public static ProfileProperty ReadData(DataReader reader, MinecraftRegistry registry) {
        string name = reader.ReadString();
        string value = reader.ReadString();
        string? signature = reader.ReadPrefixedOptional(r => r.ReadString());
        
        return new ProfileProperty {
            Name = name,
            Value = value,
            Signature = signature
        };
    }
}
