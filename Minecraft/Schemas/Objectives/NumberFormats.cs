using Minecraft.Registry;
using Minecraft.Text;
using NBT.Tags;

namespace Minecraft.Schemas.Objectives;

public record BlankNumberFormat : INumberFormat<BlankNumberFormat> {
    public int TypeId => 0;
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) => writer.WriteVarInt(TypeId);
    public static BlankNumberFormat ReadData(DataReader reader, MinecraftRegistry registry) => new();
}

public record StyledNumberFormat(CompoundTag Styling) : INumberFormat<StyledNumberFormat> {
    public int TypeId => 1;
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(TypeId)
            .WriteNbt(Styling);
    }

    public static StyledNumberFormat ReadData(DataReader reader, MinecraftRegistry registry) {
        return new StyledNumberFormat((reader.ReadNbt() as CompoundTag).ThrowIfNull());
    }
}

public record FixedNumberFormat(TextComponent Content) : INumberFormat<FixedNumberFormat> {
    public int TypeId => 2;
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(TypeId)
            .WriteNbt(Content);
    }

    public static FixedNumberFormat ReadData(DataReader reader, MinecraftRegistry registry) {
        return new FixedNumberFormat(reader.ReadText());
    }
}
