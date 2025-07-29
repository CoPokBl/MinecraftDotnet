using Minecraft.Data;
using Minecraft.Registry;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace Minecraft.Schemas;

[JsonConverter(typeof(IdentifierConverter))]
public readonly struct Identifier(string ns, string key) : IEquatable<Identifier>, INetworkType<Identifier>, IWritable {
    public readonly string Namespace = ns;
    public readonly string Key = key;

    public static Identifier Parse(string nsi) {
        string[] parts = nsi.Split(':', 2);
        
        return parts.Length switch {
            1 => new Identifier("minecraft", parts[0]),
            2 => new Identifier(parts[0], parts[1]),
            _ => throw new ArgumentException("Invalid identifier format", nameof(nsi))
        };
    }
    
    public static implicit operator Identifier(string nsi) => Parse(nsi);
    public static implicit operator string(Identifier id) => id.ToString();
    
    public override string ToString() {
        return $"{Namespace}:{Key}";
    }

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry _) {
        return writer.WriteString(ToString());
    }

    public void Write(DataWriter writer) {
        writer.WriteString(ToString());
    }

    public static Identifier ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadString();
    }

    public bool Equals(Identifier other) {
        return Namespace == other.Namespace && Key == other.Key;
    }

    public override bool Equals(object? obj) {
        return obj is Identifier other && Equals(other);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Namespace, Key);
    }

    public static bool operator ==(Identifier left, Identifier right) {
        return left.Equals(right);
    }

    public static bool operator !=(Identifier left, Identifier right) {
        return !(left == right);
    }
}

// This serialiser will serialise it as a string in the format "namespace:key"
public class IdentifierConverter : JsonConverter<Identifier> {
    
    public override void WriteJson(JsonWriter writer, Identifier value, JsonSerializer serializer) {
        writer.WriteValue(value.ToString());
    }

    public override Identifier ReadJson(JsonReader reader, Type objectType, Identifier existingValue, bool hasExistingValue,
        JsonSerializer serializer) {
        if (reader.TokenType != JsonToken.String) {
            throw new JsonSerializationException("Expected string token for Identifier");
        }

        if (reader.Value is not string value) {
            throw new JsonSerializationException("Expected string value for Identifier");
        }
        
        return Identifier.Parse(value);
    }
}
