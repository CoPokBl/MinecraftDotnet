using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas;

public class ProfileProperty : INetworkType<ProfileProperty> {
    public required string Name { get; init; }
    public required string Value { get; init; }
    public string? Signature { get; init; }
    
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

    public override bool Equals(object? obj) {
        if (obj is not ProfileProperty other) return false;
        return Name == other.Name && Value == other.Value && Signature == other.Signature;
    }
    
    public override int GetHashCode() {
        return HashCode.Combine(Name, Value, Signature);
    }
}
