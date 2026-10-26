using System.Globalization;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

/// <summary>Degrees, or <c>~</c> for relative to the sender. A relative angle parses as its offset.</summary>
public record AngleArgumentType() : ArgumentParser<float>() {
    public override Identifier Identifier => "minecraft:angle";

    public override float Parse(ref string str, MinecraftRegistry reg) {
        int space = str.IndexOf(' ');
        string token = space == -1 ? str : str[..space];
        str = space == -1 ? string.Empty : str[(space + 1)..];
        string number = token.StartsWith('~') ? token[1..] : token;
        return number.Length == 0 ? 0.0F : float.Parse(number, CultureInfo.InvariantCulture);
    }

    public override string Format(float value) => value.ToString(CultureInfo.InvariantCulture);
}
