using Minecraft.Data.Components.Codecs;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// What makes a weapon stab everything along its reach at once rather than the first thing it meets,
/// vanilla's <c>PiercingWeapon</c>.
/// </summary>
public record PiercingWeaponComponent() : IDataComponent<PiercingWeaponComponent.Data> {
    public override Identifier Identifier => "minecraft:piercing_weapon";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Bool("deals_knockback", val.DealsKnockback, true)
            .Bool("dismounts", val.Dismounts, false)
            .Sound("sound", val.Sound)
            .Sound("hit_sound", val.HitSound)
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:piercing_weapon");
            Data data = new(
                node.Bool("deals_knockback", true),
                node.Bool("dismounts", false),
                node.Sound("sound", registry),
                node.Sound("hit_sound", registry));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteBoolean(val.DealsKnockback)
            .WriteBoolean(val.Dismounts)
            .WritePrefixedOptional(val.Sound, WriteSound)
            .WritePrefixedOptional(val.HitSound, WriteSound);

        void WriteSound(Or<ISoundType, SoundEvent> sound, DataWriter w) {
            w.WriteIdOr(sound, registry.SoundTypes.GetProtocolId, (inline, wr) => wr.Write(inline, registry));
        }
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        return new Data(
            reader.ReadBoolean(),
            reader.ReadBoolean(),
            reader.ReadPrefixedOptional(ReadSound),
            reader.ReadPrefixedOptional(ReadSound));

        Or<ISoundType, SoundEvent> ReadSound(DataReader r) {
            return r.ReadIdOr(id => registry.SoundTypes[id], re => re.Read<SoundEvent>(registry));
        }
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }

    /// <param name="Sound">Played whenever the weapon is used, hit or miss.</param>
    /// <param name="HitSound">Played on top of it when the stab connected with something.</param>
    public record Data(
        bool DealsKnockback = true,
        bool Dismounts = false,
        Or<ISoundType, SoundEvent>? Sound = null,
        Or<ISoundType, SoundEvent>? HitSound = null);
}
