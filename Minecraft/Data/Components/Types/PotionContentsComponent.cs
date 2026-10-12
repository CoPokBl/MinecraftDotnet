using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Potions;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What a potion, tipped arrow or splash bottle does, vanilla's <c>PotionContents</c>. The registry
/// potion and the custom effects both apply, so an item can have either or both.
/// </summary>
public record PotionContentsComponent() : IDataComponent<PotionContentsComponent.Data> {
    public override Identifier Identifier => "minecraft:potion_contents";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .Maybe("potion", val.Potion, potion => new StringTag(potion.Identifier.ToString()))
            .Maybe("custom_color", val.CustomColor, colour => new IntegerTag(colour))
            .ListOrOmit("custom_effects", val.CustomEffects, EffectCodecs.WriteEffect)
            .String("custom_name", val.CustomName, null)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:potion_contents");
            Data data = new(
                node.Has("potion") ? node.Holder("potion", registry.Potions) : null,
                node.Has("custom_color") ? node.Int("custom_color") : null,
                node.List("custom_effects",
                    effect => EffectCodecs.ReadEffect(effect, registry, "minecraft:potion_contents")),
                node.StringOrNull("custom_name"));
            node.AssertRead();
            return data;
        });


    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedOptional(val.Potion, (p, w) => w.WriteVarInt(registry.Potions.GetProtocolId(p)))
            .WritePrefixedOptional(val.CustomColor, (c, w) => w.WriteInteger(c))
            .WritePrefixedArray(val.CustomEffects, registry)
            .WritePrefixedOptional(val.CustomName, (n, w) => w.WriteString(n));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadPrefixedOptional(r => registry.Potions[r.ReadVarInt()]),
            reader.ReadPrefixedOptionalValue(r => r.ReadInteger()),
            reader.ReadPrefixedArray<PotionEffect>(registry),
            reader.ReadPrefixedOptional(r => r.ReadString()));
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    /// <param name="CustomColor">Packed RGB overriding the colour mixed from the effects.</param>
    /// <param name="CustomName">
    /// Suffix of the translation key the tooltip uses, so a custom brew reads as something other
    /// than "Potion".
    /// </param>
    public record Data(
        IPotion? Potion = null,
        int? CustomColor = null,
        PotionEffect[]? CustomEffects = null,
        string? CustomName = null) {

        public PotionEffect[] CustomEffects { get; init; } = CustomEffects ?? [];

        public virtual bool Equals(Data? other) {
            return other != null && Potion?.Identifier == other.Potion?.Identifier &&
                   CustomColor == other.CustomColor && CustomName == other.CustomName &&
                   CustomEffects.SequenceEqual(other.CustomEffects);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Potion?.Identifier, CustomColor, CustomName, CustomEffects.Length);
        }
    }
}
