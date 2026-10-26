using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>Marks a sign item as waxed, so the sign it places cannot be edited.</summary>
public record WaxedComponent() : IDataComponent<None> {
    public static None Value => None.Value;
    public override Identifier Identifier => "minecraft:waxed";

    public override NbtCodec<None>? Codec => Persistent;
    private static readonly NbtCodec<None> Persistent = NbtCodecs.Unit();

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
