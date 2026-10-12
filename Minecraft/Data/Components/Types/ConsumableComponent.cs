using Minecraft.Data.Components.Codecs;
using Minecraft.Data.ConsumeEffects;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace Minecraft.Data.Components.Types;

public record ConsumableComponent() : IDataComponent<ConsumableComponent.Data> {
    public override Identifier Identifier => "minecraft:consumable";

    /// <summary>
    /// The sound defaults to the generic eat rather than to nothing, so an item that says nothing
    /// still makes one.
    /// </summary>
    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, registry) => new CompoundBuilder()
            .Float("consume_seconds", val.ConsumeSeconds, DefaultConsumeSeconds)
            .Enum("animation", val.Animation, ConsumeAnimation.Eat)
            .Sound("sound", DefaultSound.Equals(val.Sound) ? null : val.Sound)
            .Bool("has_consume_particles", val.HasParticles, true)
            .ListOrOmit("on_consume_effects", val.Effects,
                effect => EffectCodecs.WriteConsumeEffect(effect, registry))
            .Build(),
        (tag, registry) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:consumable");
            Data data = new(
                node.Float("consume_seconds", DefaultConsumeSeconds),
                node.Enum("animation", ConsumeAnimation.Eat),
                node.Sound("sound", registry) ?? DefaultSound,
                node.Bool("has_consume_particles", true),
                node.List("on_consume_effects",
                    effect => EffectCodecs.ReadConsumeEffect(effect, registry, "minecraft:consumable")));
            node.AssertRead();
            return data;
        });

    private static readonly Or<ISoundType, SoundEvent> DefaultSound =
        Or<ISoundType, SoundEvent>.FromValue1(SoundType.GenericEat);

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(w => {
            w.WriteFloat(val.ConsumeSeconds);
            w.WriteVarInt((int)val.Animation);
            w.WriteIdOr(val.Sound, registry.SoundTypes.GetProtocolId, registry);
            w.WriteBoolean(val.HasParticles);
            w.WritePrefixedArray(val.Effects, (effect, wr) => effect.WriteData(wr.WriteVarInt(registry.ConsumeEffects.GetProtocolId(effect)), registry));
        });
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        float consumeSeconds = reader.ReadFloat();
        ConsumeAnimation animation = (ConsumeAnimation)reader.ReadVarInt();
        Or<ISoundType, SoundEvent> sound = reader.ReadIdOr(
            id => registry.SoundTypes[id],
            r => r.Read<SoundEvent>(registry)
        );
        bool hasParticles = reader.ReadBoolean();
        IConsumeEffect[] effects = reader.ReadPrefixedArray(r => {
            int protocolId = r.ReadVarInt();
            return registry.ConsumeEffects[protocolId].ReadData(r, registry);
        });
        return new Data(consumeSeconds, animation, sound, hasParticles, effects);
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    private const float DefaultConsumeSeconds = 1.6f;

    public record Data(
        float ConsumeSeconds = DefaultConsumeSeconds,
        ConsumeAnimation Animation = ConsumeAnimation.Eat,
        Or<ISoundType, SoundEvent>? Sound = null,
        bool HasParticles = true,
        IConsumeEffect[]? Effects = null) {
        
        public IConsumeEffect[] Effects { get; init; } = Effects ?? [];
        public Or<ISoundType, SoundEvent> Sound { get; init; } = Sound ?? Or<ISoundType, SoundEvent>.FromValue1(SoundType.GenericEat);

        public virtual bool Equals(Data? other) {
            if (other is null) return false;
            if (Math.Abs(ConsumeSeconds - other.ConsumeSeconds) > 0.001) return false;
            if (Animation != other.Animation) return false;
            if (!Sound.Equals(other.Sound)) return false;
            if (HasParticles != other.HasParticles) return false;
            if (Effects.Length != other.Effects.Length) return false;
            for (int i = 0; i < Effects.Length; i++) {
                if (!Effects[i].Equals(other.Effects[i])) return false;
            }
            return true;
        }

        public override int GetHashCode() {
            int effectsHash = Effects.Aggregate(0, (acc, effect) => acc ^ effect.GetHashCode());
            return HashCode.Combine(effectsHash, Sound, ConsumeSeconds, (int)Animation, HasParticles);
        }
    }
    
    public enum ConsumeAnimation {
        None = 0,
        Eat = 1,
        Drink = 2,
        Block = 3,
        Bow = 4,
        Trident = 5,
        Crossbow = 6,
        Spyglass = 7,
        TootHorn = 8,
        Brush = 9,
        Bundle = 10,
        Spear = 11
    }
}
