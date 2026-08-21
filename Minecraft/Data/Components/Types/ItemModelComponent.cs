using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record ItemModelComponent() : IDataComponent<Identifier> {
    public override Identifier Identifier => "minecraft:item_model";

    public override NbtCodec<Identifier>? Codec => Persistent;
    private static readonly NbtCodec<Identifier> Persistent = NbtCodecs.Id();
    
    public override DataWriter WriteData(Identifier val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(val);
    }

    public override string ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadString();
    }

    public override bool ValuesEqual(Identifier val1, Identifier val2) {
        return val1 == val2;
    }
}
