using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>Items an anvil accepts as repair material for this one.</summary>
public record RepairableComponent() : IDataComponent<IdSet> {
    public override Identifier Identifier => "minecraft:repairable";

    public override NbtCodec<IdSet>? Codec => Persistent;
    private static readonly NbtCodec<IdSet> Persistent = NbtCodecs.Wrapped("minecraft:repairable", "items",
        NbtCodecs.IdSet("minecraft:repairable", reg => reg.Items));

    public override DataWriter WriteData(IdSet val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val, registry);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.Read<IdSet>(registry);
    }

    public override bool ValuesEqual(IdSet val1, IdSet val2) {
        return val1.Equals(val2);
    }
}
