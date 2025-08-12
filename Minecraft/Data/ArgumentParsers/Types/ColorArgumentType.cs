using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ColorArgumentType(int ProtocolId) : ArgumentParser<NamedTextColor?>(ProtocolId) {
    public override Identifier Identifier => "minecraft:color";
    
    public override NamedTextColor? Parse(ref string str, MinecraftRegistry _) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid color format");

        string colorName = parts[0].Trim();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        if (colorName == "reset") {
            return null; // Represents no colour
        }

        return NamedTextColorExtensions.FromName(colorName);
    }

    public override string Format(NamedTextColor? value) {
        return value?.GetName() ?? "reset";  // "reset" for no colour
    }
}
