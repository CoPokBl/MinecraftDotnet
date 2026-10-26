using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// The pattern a sherd puts on the side of a decorated pot it is crafted into, by its name in <see cref="MinecraftRegistry.DecoratedPotPatterns"/>.
/// </summary>
/// <remarks>
/// A name rather than the element: the registry is synchronised, so the element a client should use
/// is the one the server sent, and an item's defaults are built before any registry is.
/// </remarks>
public record ProvidesPotteryPatternComponent() : IDataComponent<Identifier> {
    public override Identifier Identifier => "minecraft:provides_pottery_pattern";

    public override NbtCodec<Identifier>? Codec => Persistent;
    private static readonly NbtCodec<Identifier> Persistent = NbtCodecs.Id();

    public override DataWriter WriteData(Identifier val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WriteVarInt(registry.DecoratedPotPatterns.GetProtocolId(val));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return registry.DecoratedPotPatterns[reader.ReadVarInt()].Identifier;
    }

    public override bool ValuesEqual(Identifier val1, Identifier val2) {
        return val1 == val2;
    }
}
