using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using Minecraft.Schemas.Tags;
using NBT;
using NBT.Tags;

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

    /// <summary>
    /// <c>disabled_sound</c> carries the d that <c>block_sound</c> beside it does not, which is
    /// vanilla's spelling.
    /// </summary>
    /// <remarks>
    /// Nothing measures <c>damage_reductions</c>: the shield is the only item carrying this component
    /// and it leaves the field at its default, so those four keys come off
    /// <c>BlocksAttacks.DamageReduction</c> in the jar rather than off any vanilla value.
    /// </remarks>
    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .Float("block_delay_seconds", val.BlockDelaySeconds, 0f)
            .Float("disable_cooldown_scale", val.DisableCooldownScale, 1f)
            .TagWhen("damage_reductions", new ListTag(val.DamageReductions
                    .Select(reduction => (INbtTag)new CompoundBuilder()
                        .Float("horizontal_blocking_angle", reduction.HorizontalBlockingAngle, 90f)
                        .IdSet("type", reduction.Type, registry.DamageTypes)
                        .Float("base", reduction.Base)
                        .Float("factor", reduction.Factor)
                        .Build())
                    .ToArray()),
                !IsDefaultReductions(val.DamageReductions))
            .TagWhen("item_damage", new CompoundBuilder()
                    .Float("threshold", val.ItemDamage.Threshold)
                    .Float("base", val.ItemDamage.Base)
                    .Float("factor", val.ItemDamage.Factor)
                    .Build(),
                !val.ItemDamage.Equals(ItemDamage.Default))
            .IdSet("bypassed_by", val.BypassedBy, registry.DamageTypes)
            .Sound("block_sound", val.BlockSound)
            .Sound("disabled_sound", val.DisableSound)
            .Build(),

        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:blocks_attacks");

            Data data = new(
                node.Float("block_delay_seconds", 0f),
                node.Float("disable_cooldown_scale", 1f),
                node.Has("damage_reductions")
                    ? node.Objects("damage_reductions", reduction => {
                        DamageReduction read = new(
                            reduction.Float("horizontal_blocking_angle", 90f),
                            reduction.IdSetOrNull("type", registry.DamageTypes),
                            reduction.Float("base"),
                            reduction.Float("factor"));
                        reduction.AssertRead();
                        return read;
                    })
                    : [DamageReduction.Everything],
                node.Object("item_damage", damage => {
                    ItemDamage read = new(
                        damage.Float("threshold"), damage.Float("base"), damage.Float("factor"));
                    damage.AssertRead();
                    return read;
                }, ItemDamage.Default),
                node.IdSetOrNull("bypassed_by", registry.DamageTypes),
                node.Sound("block_sound", registry),
                node.Sound("disabled_sound", registry));

            node.AssertRead();
            return data;
        });

    private static bool IsDefaultReductions(DamageReduction[] reductions) {
        return reductions.Length == 1 && reductions[0].Equals(DamageReduction.Everything);
    }

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
