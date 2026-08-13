using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What an item stops while it is being held up, vanilla's <c>BlocksAttacks</c>. Since 1.21.5 this
/// component is the whole of what makes a shield a shield: the client starts the blocking animation
/// for any item carrying one, and the server reads the same data back to decide what a hit is worth.
/// <p/>
/// An item without it cannot block, which is what makes a cosmetic shield a shield with the component
/// removed rather than a differently named item.
/// </summary>
public record BlocksAttacksComponent() : IDataComponent<BlocksAttacksComponent.Data> {
    public override Identifier Identifier => "minecraft:blocks_attacks";

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteFloat(val.BlockDelaySeconds)
            .WriteFloat(val.DisableCooldownScale)
            .WritePrefixedArray(val.DamageReductions, (reduction, w) => w
                .WriteFloat(reduction.HorizontalBlockingAngle)
                .WritePrefixedOptional(reduction.Type, (set, wr) => wr.Write(set, registry))
                .WriteFloat(reduction.Base)
                .WriteFloat(reduction.Factor))
            .WriteFloat(val.ItemDamage.Threshold)
            .WriteFloat(val.ItemDamage.Base)
            .WriteFloat(val.ItemDamage.Factor)
            .WritePrefixedOptional(val.BypassedBy, (set, w) => w.Write(set, registry))
            .WritePrefixedOptional(val.BlockSound, (sound, w) =>
                w.WriteIdOr(sound, registry.SoundTypes.GetProtocolId, (inline, wr) => wr.Write(inline, registry)))
            .WritePrefixedOptional(val.DisableSound, (sound, w) =>
                w.WriteIdOr(sound, registry.SoundTypes.GetProtocolId, (inline, wr) => wr.Write(inline, registry)));
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        float blockDelaySeconds = reader.ReadFloat();
        float disableCooldownScale = reader.ReadFloat();
        DamageReduction[] reductions = reader.ReadPrefixedArray(r => new DamageReduction(
            r.ReadFloat(),
            r.ReadPrefixedOptional(re => re.Read<IdSet>(registry)),
            r.ReadFloat(),
            r.ReadFloat()));
        ItemDamage itemDamage = new(reader.ReadFloat(), reader.ReadFloat(), reader.ReadFloat());
        IdSet? bypassedBy = reader.ReadPrefixedOptional(r => r.Read<IdSet>(registry));
        Or<ISoundType, SoundEvent>? blockSound = reader.ReadPrefixedOptional(ReadSound);
        Or<ISoundType, SoundEvent>? disableSound = reader.ReadPrefixedOptional(ReadSound);

        return new Data(blockDelaySeconds, disableCooldownScale, reductions, itemDamage, bypassedBy,
            blockSound, disableSound);

        Or<ISoundType, SoundEvent> ReadSound(DataReader r) {
            return r.ReadIdOr(id => registry.SoundTypes[id], re => re.Read<SoundEvent>(registry));
        }
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    public record Data(
        float BlockDelaySeconds,
        float DisableCooldownScale,
        DamageReduction[] DamageReductions,
        ItemDamage ItemDamage,
        IdSet? BypassedBy,
        Or<ISoundType, SoundEvent>? BlockSound,
        Or<ISoundType, SoundEvent>? DisableSound) {

        /// <summary>
        /// <c>blockDelayTicks</c>. A hit inside the delay is not blocked at all, which is what makes
        /// a shield raised as the swing lands do nothing.
        /// </summary>
        public int BlockDelayTicks => (int)Math.Floor(BlockDelaySeconds * 20f + 0.5f);

        /// <summary>Vanilla's own defaults, i.e. what a component written as <c>{}</c> means.</summary>
        public static Data Default => new(0f, 1f, [DamageReduction.Everything], ItemDamage.Default, null, null, null);
    }

    /// <summary>
    /// One rule for what is blocked, vanilla's <c>BlocksAttacks.DamageReduction</c>. A hit outside
    /// <see cref="HorizontalBlockingAngle"/> degrees of where the blocker is looking, or of a damage
    /// type outside <see cref="Type"/>, is not covered by this rule; what is left is
    /// <c>base + factor * damage</c>, clamped to the hit.
    /// </summary>
    public record DamageReduction(float HorizontalBlockingAngle, IdSet? Type, float Base, float Factor) {
        /// <summary>The rule vanilla defaults to: all of a hit landing within ninety degrees.</summary>
        public static DamageReduction Everything => new(90f, null, 0f, 1f);
    }

    /// <summary>
    /// What blocking a hit costs the item's durability, vanilla's
    /// <c>BlocksAttacks.ItemDamageFunction</c>: nothing below <see cref="Threshold"/> damage, and
    /// <c>floor(base + factor * damage)</c> above it.
    /// </summary>
    public record ItemDamage(float Threshold, float Base, float Factor) {
        public static ItemDamage Default => new(1f, 0f, 1f);

        public int Apply(float damage) {
            return damage < Threshold ? 0 : (int)Math.Floor(Base + Factor * damage);
        }
    }
}
