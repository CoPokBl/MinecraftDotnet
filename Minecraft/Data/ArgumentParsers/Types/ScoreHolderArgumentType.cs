using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ScoreHolderArgumentType(bool Multiple = false) : TokenArgumentType {
    public override Identifier Identifier => "minecraft:score_holder";

    public override DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteByte(Multiple ? 1 : 0);
    }

    public override IArgumentParser ReadData(DataReader reader, MinecraftRegistry registry) {
        return this with { Multiple = (reader.ReadByte() & 1) != 0 };
    }
}
