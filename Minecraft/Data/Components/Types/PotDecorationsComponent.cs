using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Items;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// The four sherds on a decorated pot, in back, left, right, front order. A plain brick is what a
/// side with no sherd on it is written as.
/// </summary>
public record PotDecorationsComponent() : IDataComponent<IItem[]> {
    public override Identifier Identifier => "minecraft:pot_decorations";

    public override NbtCodec<IItem[]>? Codec => Persistent;
    private static readonly NbtCodec<IItem[]> Persistent = new(
        (val, _) => new ListTag(val
            .Select(item => (INbtTag)new StringTag(item.Identifier.ToString()))
            .ToArray()),
        (tag, registry) => tag.AsList()
            .Select(item => registry.Items[(Identifier)item.GetString()])
            .ToArray());

    public override DataWriter WriteData(IItem[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (item, w) => w.WriteVarInt(registry.Items.GetProtocolId(item)));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r => registry.Items[r.ReadVarInt()]);
    }

    public override bool ValuesEqual(IItem[] val1, IItem[] val2) {
        if (val1.Length != val2.Length) return false;
        for (int i = 0; i < val1.Length; i++) {
            if (val1[i].Identifier != val2[i].Identifier) return false;
        }
        return true;
    }
}
