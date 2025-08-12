using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record BooleanArgumentType(int ProtocolId) : ArgumentParser<bool>(ProtocolId) {
    public override Identifier Identifier => "brigadier:bool";
    
    public override bool Parse(ref string str, MinecraftRegistry _) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid boolean format");

        string boolStr = parts[0].Trim().ToLower();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        return boolStr switch {
            "true" => true,
            "false" => false,
            _ => throw new ArgumentException($"Unknown boolean value: {boolStr}")
        };
    }

    public override string Format(bool value) {
        return value ? "true" : "false";
    }
}
