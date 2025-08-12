using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record SwizzleArgumentType(int ProtocolId) : ArgumentParser<(bool X, bool Y, bool Z)>(ProtocolId) {
    public override Identifier Identifier => "minecraft:swizzle";
    
    public override (bool X, bool Y, bool Z) Parse(ref string str, MinecraftRegistry _) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid swizzle format");

        string swizzle = parts[0].Trim().ToLower();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        bool x = swizzle.Contains('x');
        bool y = swizzle.Contains('y');
        bool z = swizzle.Contains('z');

        return (x, y, z);
    }

    public override string Format((bool X, bool Y, bool Z) value) {
        return $"{(value.X ? "x" : "")}{(value.Y ? "y" : "")}{(value.Z ? "z" : "")}";
    }
}
