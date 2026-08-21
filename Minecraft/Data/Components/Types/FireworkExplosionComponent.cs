using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Items;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>One burst, which is what a firework star is.</summary>
public record FireworkExplosionComponent() : IDataComponent<FireworkExplosionComponent.Data> {
    public override Identifier Identifier => "minecraft:firework_explosion";

    /// <summary>
    /// The colours are int arrays rather than lists, which only matters as tags: reading them out of
    /// JSON can only make a list, so the write has to name the array form for the two to agree.
    /// </summary>
    public override NbtCodec<Data>? Codec => Persistent;
    internal static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Enum("shape", val.Shape)
            .TagWhen("colors", new ArrayTag<int>(val.Colors), val.Colors.Length != 0)
            .TagWhen("fade_colors", new ArrayTag<int>(val.FadeColors), val.FadeColors.Length != 0)
            .Bool("has_trail", val.HasTrail, false)
            .Bool("has_twinkle", val.HasTwinkle, false)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:firework_explosion");
            Data data = new(
                node.Enum<FireworkShape>("shape"),
                node.Has("colors") ? node.Require("colors").GetIntegers().ToArray() : [],
                node.Has("fade_colors") ? node.Require("fade_colors").GetIntegers().ToArray() : [],
                node.Bool("has_trail", false),
                node.Bool("has_twinkle", false));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return Write(val, writer);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return Read(reader);
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    internal static DataWriter Write(Data val, DataWriter writer) {
        return writer
            .WriteVarInt((int)val.Shape)
            .WritePrefixedArray(val.Colors, (c, w) => w.WriteInteger(c))
            .WritePrefixedArray(val.FadeColors, (c, w) => w.WriteInteger(c))
            .WriteBoolean(val.HasTrail)
            .WriteBoolean(val.HasTwinkle);
    }

    internal static Data Read(DataReader reader) {
        return new Data(
            (FireworkShape)reader.ReadVarInt(),
            reader.ReadPrefixedArray(r => r.ReadInteger()),
            reader.ReadPrefixedArray(r => r.ReadInteger()),
            reader.ReadBoolean(),
            reader.ReadBoolean());
    }

    /// <param name="Colors">Packed RGB the burst starts as, one per particle group.</param>
    /// <param name="FadeColors">Packed RGB the burst fades into.</param>
    public record Data(
        FireworkShape Shape = FireworkShape.SmallBall,
        int[]? Colors = null,
        int[]? FadeColors = null,
        bool HasTrail = false,
        bool HasTwinkle = false) {

        public int[] Colors { get; init; } = Colors ?? [];
        public int[] FadeColors { get; init; } = FadeColors ?? [];

        public virtual bool Equals(Data? other) {
            return other != null && Shape == other.Shape && HasTrail == other.HasTrail &&
                   HasTwinkle == other.HasTwinkle && Colors.SequenceEqual(other.Colors) &&
                   FadeColors.SequenceEqual(other.FadeColors);
        }

        public override int GetHashCode() {
            return HashCode.Combine((int)Shape, Colors.Length, FadeColors.Length, HasTrail, HasTwinkle);
        }
    }
}
