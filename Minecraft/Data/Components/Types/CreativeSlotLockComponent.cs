using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CreativeSlotLockComponent : IDataComponent<None> {
    public Identifier Identifier => "minecraft:creative_slot_lock";
    public static CreativeSlotLockComponent Default => new();
    
    public DataWriter WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer;
    }

    public IDataComponent ReadData(DataReader reader, MinecraftRegistry registry) {
        return this;
    }

    public None Value => None.Value;
}
