using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

public record IntangibleProjectileComponent(int ProtocolId) : IDataComponent<None> {
    public override Identifier Identifier => "minecraft:intangible_projectile";
    public static None Value => None.Value;
    
    public override DataWriter WriteData(None _, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteNbt(new EmptyTag());
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        reader.ReadNbt();
        return Value;
    }

    public override bool ValuesEqual(None val1, None val2) {
        return true;
    }
}
