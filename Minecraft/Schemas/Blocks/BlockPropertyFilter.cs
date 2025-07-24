using Minecraft.Data;
using Minecraft.Registry;

namespace Minecraft.Schemas.Blocks;

public record BlockPropertyFilter(
    string Name,
    bool ExactMatch = false,
    string? ExactValue = null,
    string? MinValue = null,
    string? MaxValue = null) : INetworkType<BlockPropertyFilter> {
    
    public static BlockPropertyFilter Exact(string prop, string value) {
        return new BlockPropertyFilter(prop, true, value);
    }
    
    public static BlockPropertyFilter Range(string prop, string min, string max) {
        return new BlockPropertyFilter(prop, false, null, min, max);
    }
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry _) {
        writer.WriteString(Name);
        writer.WriteBoolean(ExactMatch);
        if (ExactMatch) {
            writer.WriteString(ExactValue.ThrowIfNull());
        } else {
            writer.WriteString(MinValue.ThrowIfNull());
            writer.WriteString(MaxValue.ThrowIfNull());
        }
        return writer;
    }
    
    public static BlockPropertyFilter ReadData(DataReader reader, MinecraftRegistry _) {
        string name = reader.ReadString();
        bool exactMatch = reader.ReadBoolean();
        string? exactValue = exactMatch ? reader.ReadString() : null;
        string? minValue = exactMatch ? null : reader.ReadString();
        string? maxValue = exactMatch ? null : reader.ReadString();
        
        return new BlockPropertyFilter(name, exactMatch, exactValue, minValue, maxValue);
    }
}
