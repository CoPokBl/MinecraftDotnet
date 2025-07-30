using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record UseCooldownComponent(int ProtocolId) : IDataComponent<UseCooldownComponent.Data> {
    public override Identifier Identifier => "minecraft:use_cooldown";
    
    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteFloat(val.Seconds)
            .WritePrefixedOptional(val.CooldownGroup, (id, w) => w.Write(id));
    }
    
    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.ReadFloat(), reader.ReadPrefixedOptional<Identifier>(registry));
    }
    
    public record Data(float Seconds, Identifier? CooldownGroup);
}
