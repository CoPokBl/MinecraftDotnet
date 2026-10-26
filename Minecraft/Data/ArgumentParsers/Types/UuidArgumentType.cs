using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record UuidArgumentType() : ArgumentParser<Guid>() {
    public override Identifier Identifier => "minecraft:uuid";

    public override Guid Parse(ref string str, MinecraftRegistry reg) {
        int space = str.IndexOf(' ');
        string token = space == -1 ? str : str[..space];
        str = space == -1 ? string.Empty : str[(space + 1)..];
        return Guid.Parse(token);
    }

    public override string Format(Guid value) => value.ToString();
}
