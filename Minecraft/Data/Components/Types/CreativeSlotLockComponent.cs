using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CreativeSlotLockComponent(int ProtocolId) : IDataComponent<None> {
    public static None Value => None.Value;
    public override Identifier Identifier => "minecraft:creative_slot_lock";
    
    public override DataWriter WriteData(None _, DataWriter writer, MinecraftRegistry registry) {
        return writer;
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return Value;
    }

    public override bool ValuesEqual(None val1, None val2) {
        return true;
    }
}
