using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>Damage types the item's holder takes nothing from, such as a netherite tool's fire.</summary>
public record DamageResistantComponent() : IDataComponent<IdSet> {
    public override Identifier Identifier => "minecraft:damage_resistant";

    /// <summary>The set is under <c>types</c>, and <c>repairable</c> puts the same shape under <c>items</c>.</summary>
    public override NbtCodec<IdSet>? Codec => Persistent;
    private static readonly NbtCodec<IdSet> Persistent = NbtCodecs.Wrapped("minecraft:damage_resistant", "types",
        NbtCodecs.IdSet("minecraft:damage_resistant", reg => reg.DamageTypes));

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
