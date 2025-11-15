using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record MaxDamageComponent(int ProtocolId) : IDataComponent<int> {
    public override Identifier Identifier => "minecraft:max_damage";
    
    public override DataWriter WriteData(int val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadVarInt();
    }

    public override bool ValuesEqual(int val1, int val2) {
        return val1 == val2;
    }
}
