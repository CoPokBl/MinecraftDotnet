using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec.Relative;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ChunkPosArgumentType(int ProtocolId) : ArgumentParser<RelativeVec2<int>>(ProtocolId) {
    public override Identifier Identifier => "minecraft:column_pos";
    
    private static RelativeCoordinate<int> ReadCoordinate(ref string str) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid coordinate format");
        
        string coordinate = parts[0].Trim();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;
        
        return RelativeCoordinate<int>.Parse(coordinate);
    }
    
    public override RelativeVec2<int> Parse(ref string str, MinecraftRegistry _) {
        RelativeCoordinate<int> x = ReadCoordinate(ref str);
        RelativeCoordinate<int> z = ReadCoordinate(ref str);
        
        return new RelativeVec2<int>(x, z);
    }

    public override string Format(RelativeVec2<int> value) {
        return $"{value.X} {value.Y}";  // Format as "x z"
    }
}
