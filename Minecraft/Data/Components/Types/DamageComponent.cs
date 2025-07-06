using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record DamageComponent(int Value) : IDataComponent<int> {
    public static DamageComponent Default => new(0);
    public Identifier Identifier => "minecraft:damage";

    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(Value);
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return new DamageComponent(reader.ReadVarInt());
    }
}
