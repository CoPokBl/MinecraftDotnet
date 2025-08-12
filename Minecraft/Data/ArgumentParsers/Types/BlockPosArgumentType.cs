using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec.Relative;

namespace Minecraft.Data.ArgumentParsers.Types;

public record BlockPosArgumentType(int ProtocolId) : ArgumentParser<RelativeVec3<int>>(ProtocolId) {
    public override Identifier Identifier => "minecraft:block_pos";
    
    private static RelativeCoordinate<int> ReadCoordinate(ref string str) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid coordinate format");
        
        string coordinate = parts[0].Trim();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;
        
        return RelativeCoordinate<int>.Parse(coordinate);
    }
    
    public override RelativeVec3<int> Parse(ref string str, MinecraftRegistry _) {
        RelativeCoordinate<int> x = ReadCoordinate(ref str);
        RelativeCoordinate<int> y = ReadCoordinate(ref str);
        RelativeCoordinate<int> z = ReadCoordinate(ref str);
        
        return new RelativeVec3<int>(x, y, z);
    }

    public override string Format(RelativeVec3<int> value) {
        return $"{value.X} {value.Y} {value.Z}";
    }
}
