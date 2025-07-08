using Minecraft.Data.Blocks;

namespace Minecraft.Schemas.Items;

public record ToolRule(IdSet Blocks, float? Speed, bool? CorrectDropForBlocks) : IWritable {
    
    public void Write(DataWriter writer) {
        writer.Write(Blocks);
        writer.WritePrefixedOptional(Speed, (f, w) => w.WriteFloat(f));
        writer.WritePrefixedOptional(CorrectDropForBlocks, (b, w) => w.WriteBoolean(b));
    }

    public static ToolRule Read(DataReader reader) {
        IdSet blocks = IdSet.Read(reader);
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
