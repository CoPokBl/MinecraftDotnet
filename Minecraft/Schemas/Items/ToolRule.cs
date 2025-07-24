using Minecraft.Data;
using Minecraft.Data.Blocks;
using Minecraft.Registry;

namespace Minecraft.Schemas.Items;

public record ToolRule(IdSet Blocks, float? Speed, bool? CorrectDropForBlocks) : INetworkType<ToolRule> {
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry reg) {
        writer.Write(Blocks, reg);
        writer.WritePrefixedOptional(Speed, (f, w) => w.WriteFloat(f));
        return writer.WritePrefixedOptional(CorrectDropForBlocks, (b, w) => w.WriteBoolean(b));
    }

    public static ToolRule ReadData(DataReader reader, MinecraftRegistry reg) {
        IdSet blocks = reader.Read<IdSet>(reg);
        float? speed = reader.ReadPrefixedOptional(r => r.ReadFloat());
        bool? correctDropForBlocks = reader.ReadPrefixedOptional(r => r.ReadBoolean());
        return new ToolRule(blocks, speed, correctDropForBlocks);
    }

    public bool ValidFor(IBlock block) {
        if (Blocks is IdSet.Tag tagSet) {
            return tagSet.TagName == block.Identifier;
        }
        if (Blocks is IdSet.Ids idSet) {
            return idSet.Values.Contains((int)block.StateId);
        }
        
        throw new InvalidOperationException("Invalid IdSet type in ToolRule.");
    }
}
