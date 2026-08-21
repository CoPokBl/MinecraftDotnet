using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>The packed RGB the map item's tooltip square is tinted with.</summary>
public record MapColorComponent() : IDataComponent<int> {
    public override Identifier Identifier => "minecraft:map_color";

    public override NbtCodec<int>? Codec => Persistent;
    private static readonly NbtCodec<int> Persistent = NbtCodecs.Int();

    public override DataWriter WriteData(int val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteInteger(val);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadInteger();
    }

    public override bool ValuesEqual(int val1, int val2) {
        return val1 == val2;
    }
}
