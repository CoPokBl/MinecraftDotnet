using Minecraft.Data.Components.Codecs;
using Minecraft.Data.PotionEffectTypes;
using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>What eating a suspicious stew applies. Each effect is level one for its duration.</summary>
public record SuspiciousStewEffectsComponent() : IDataComponent<SuspiciousStewEffectsComponent.Entry[]> {
    /// <summary>How long an effect lasts when the data does not say.</summary>
    public const int DefaultDuration = 160;

    public override Identifier Identifier => "minecraft:suspicious_stew_effects";

    public override DataWriter WriteData(Entry[] val, DataWriter writer, MinecraftRegistry registry) {
        return writer.WritePrefixedArray(val, (entry, w) => w
            .WriteVarInt(registry.PotionEffectTypes.GetProtocolId(entry.Effect))
            .WriteVarInt(entry.Duration));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return reader.ReadPrefixedArray(r =>
            new Entry(registry.PotionEffectTypes[r.ReadVarInt()], r.ReadVarInt()));
    }

    public override bool ValuesEqual(Entry[] val1, Entry[] val2) {
        if (val1.Length != val2.Length) return false;
        for (int i = 0; i < val1.Length; i++) {
            if (val1[i].Effect.Identifier != val2[i].Effect.Identifier || val1[i].Duration != val2[i].Duration) {
                return false;
            }
        }
        return true;
    }

    public override NbtCodec<Entry[]>? Codec => Persistent;

    /// <summary>
    /// The value is a bare list rather than an object, and the effect's key is <c>id</c> where the
    /// field it fills is the effect, which is vanilla's naming and follows from neither side.
    /// </summary>
    /// <remarks>
    /// Vanilla reads the duration leniently, so a malformed one falls back to the default there and
    /// throws here. That is the stricter half of the same bargain the rest of the datapack reading
    /// makes: a value that cannot be read is a value that changes what the item is.
    /// </remarks>
    private static readonly NbtCodec<Entry[]> Persistent = new(
        (val, _) => new ListTag(val
            .Select(entry => (INbtTag)new CompoundBuilder()
                .Id("id", entry.Effect.Identifier)
                .Int("duration", entry.Duration, DefaultDuration)
                .Build())
            .ToArray()),

        (tag, registry) => {
            if (tag is not ListTag list) {
                throw new UnportedComponentException("minecraft:suspicious_stew_effects",
                    $"expected a list, got {tag.GetType().Name}.");
            }

            Entry[] entries = new Entry[list.Tags.Length];

            for (int i = 0; i < entries.Length; i++) {
                NbtNode node = NbtNode.Of(list.Tags[i], "minecraft:suspicious_stew_effects");
                entries[i] = new Entry(
                    node.Holder("id", registry.PotionEffectTypes),
                    node.Int("duration", DefaultDuration));
                node.AssertRead();
            }

            return entries;
        });

    /// <param name="Duration">Ticks the effect lasts.</param>
    public record Entry(IPotionEffectType Effect, int Duration = DefaultDuration);
}
