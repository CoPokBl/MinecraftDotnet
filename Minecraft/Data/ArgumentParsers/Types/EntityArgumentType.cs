using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

/// <summary>A selector or a name. The flags are what the client's suggestions and validation go by.</summary>
public record EntityArgumentType(bool Single = false, bool PlayersOnly = false) : TokenArgumentType {
    public override Identifier Identifier => "minecraft:entity";

    public override DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteByte((Single ? 1 : 0) | (PlayersOnly ? 2 : 0));
    }

    public override IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        int flags = reader.ReadByte();
        return this with { Single = (flags & 1) != 0, PlayersOnly = (flags & 2) != 0 };
    }
}
