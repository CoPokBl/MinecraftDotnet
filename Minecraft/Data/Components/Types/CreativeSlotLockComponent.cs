using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record CreativeSlotLockComponent() : IDataComponent<None> {
    public static None Value => None.Value;
    public override Identifier Identifier => "minecraft:creative_slot_lock";

    /// <summary>
    /// None. <b>Vanilla marks this component transient</b>, so it has no persistent form to port:
    /// it is a creative mode inventory hint, which nothing persists, and no datapack or saved stack ever carries one.
    /// </summary>
    public override NbtCodec<None>? Codec => null;
    
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
