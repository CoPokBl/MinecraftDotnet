using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record UseCooldownComponent() : IDataComponent<UseCooldownComponent.Data> {
    public override Identifier Identifier => "minecraft:use_cooldown";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Float("seconds", val.Seconds)
            .Id("cooldown_group", val.CooldownGroup)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:use_cooldown");
            Data data = new(node.Float("seconds"), node.IdOrNull("cooldown_group"));
            node.AssertRead();
            return data;
        });
    
    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteFloat(val.Seconds)
            .WritePrefixedOptional(val.CooldownGroup, (id, w) => w.Write(id));
    }
    
    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(reader.ReadFloat(), reader.ReadPrefixedOptionalValue<Identifier>(registry));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    public record Data(float Seconds, Identifier? CooldownGroup);
}
