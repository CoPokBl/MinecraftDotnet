using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec.Relative;

namespace Minecraft.Data.ArgumentParsers.Types;

public record Vec3ArgumentType(int ProtocolId) : ArgumentParser<RelativeVec3<double>>(ProtocolId) {
    public override Identifier Identifier => "minecraft:vec3";

    private static RelativeCoordinate<double> ReadCoordinate(ref string str) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid coordinate format");
        
        string coordinate = parts[0].Trim();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;
        
        return RelativeCoordinate<double>.Parse(coordinate);
    }
    
    public override RelativeVec3<double> Parse(ref string str, MinecraftRegistry _) {
        RelativeCoordinate<double> x = ReadCoordinate(ref str);
        RelativeCoordinate<double> y = ReadCoordinate(ref str);
        RelativeCoordinate<double> z = ReadCoordinate(ref str);
        
        return new RelativeVec3<double>(x, y, z);
    }

    public override string Format(RelativeVec3<double> value) {
        return $"{value.X} {value.Y} {value.Z}";
    }
}
