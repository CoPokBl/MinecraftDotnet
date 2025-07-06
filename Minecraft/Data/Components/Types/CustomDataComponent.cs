using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record CustomDataComponent(INbtTag Value) : IDataComponent<INbtTag> {
    public static CustomDataComponent Default => new(new EmptyTag());
    public Identifier Identifier => "minecraft:custom_data";
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new CustomDataComponent(reader.ReadNbt());
    }
}
