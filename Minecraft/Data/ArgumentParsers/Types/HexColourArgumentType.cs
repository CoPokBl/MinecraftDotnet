using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.ArgumentParsers.Types;

public record HexColourArgumentType(int ProtocolId) : ArgumentParser<TextColor>(ProtocolId) {
    public override Identifier Identifier => "minecraft:hex_color";
    
    public override TextColor Parse(ref string str, MinecraftRegistry _) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid hex color format");

        string hexColor = parts[0].Trim();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        if (hexColor.Length != 6) {
            throw new ArgumentException($"Invalid hex color: {hexColor}");
        }

        return TextColor.Hex(hexColor);
    }

    public override string Format(TextColor value) {
        return value.ToHex()[1..];  // Remove the '#' character
    }
}
