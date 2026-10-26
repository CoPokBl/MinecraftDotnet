using ClientLib.Entities;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary><c>SoundInstance.Attenuation</c>.</summary>
public enum Attenuation {
    None,
    Linear
}

/// <summary>
/// vanilla's <c>AbstractSoundInstance</c> and <c>SimpleSoundInstance</c>: one playing of one sound event,
/// with the variant it picks decided when it starts.
/// </summary>
public class SoundInstance(Identifier identifier, SoundCategory source, LegacyRandom random) {
    public Identifier Identifier { get; } = identifier;
    public SoundCategory Source { get; } = source;

    public Sound? Sound { get; private set; }
    public float BaseVolume { get; set; } = 1.0F;
    public float BasePitch { get; set; } = 1.0F;
    public double X { get; set; }
    public double Y { get; set; }
    public double Z { get; set; }
    public bool Looping { get; init; }
    public int Delay { get; init; }
    public Attenuation Attenuation { get; init; } = Attenuation.Linear;
    public bool Relative { get; init; }

    /// <summary><c>resolve</c>: picks the variant, or null when nothing defines the event.</summary>
    public WeighedSoundEvents? Resolve(SoundRegistry registry) {
        if (Identifier == Sound.IntentionallyEmpty.Location) {
            Sound = Sound.IntentionallyEmpty;
            return null;
        }
        WeighedSoundEvents? events = registry.Get(Identifier);
        Sound = events == null ? Sound.Empty : events.GetSound(random);
        return events;
    }

    public float Volume => BaseVolume * (Sound?.Volume ?? 1.0F);
    public float Pitch => BasePitch * (Sound?.Pitch ?? 1.0F);

    public virtual bool CanPlaySound => true;
    public virtual bool CanStartSilent => false;

    /// <summary><c>SimpleSoundInstance</c> at a position, which is what most of the game plays.</summary>
    public static SoundInstance At(Identifier sound, SoundCategory source, float volume, float pitch, LegacyRandom random, double x, double y, double z) =>
        new(sound, source, random) { BaseVolume = volume, BasePitch = pitch, X = x, Y = y, Z = z };

    /// <summary><c>forUI</c>: heard the same wherever the player is.</summary>
    public static SoundInstance ForUi(Identifier sound, float pitch, float volume = 0.25F) =>
        new(sound, SoundCategory.Ui, new LegacyRandom()) { BaseVolume = volume, BasePitch = pitch, Attenuation = Attenuation.None, Relative = true };

    /// <summary><c>forMusic</c>.</summary>
    public static SoundInstance ForMusic(Identifier sound) =>
        new(sound, SoundCategory.Music, new LegacyRandom()) { Attenuation = Attenuation.None, Relative = true };

    /// <summary><c>forLocalAmbience</c>.</summary>
    public static SoundInstance ForLocalAmbience(Identifier sound, float pitch, float volume) =>
        new(sound, SoundCategory.Ambient, new LegacyRandom()) { BaseVolume = volume, BasePitch = pitch, Attenuation = Attenuation.None, Relative = true };

    /// <summary><c>forAmbientMood</c>.</summary>
    public static SoundInstance ForAmbientMood(Identifier sound, LegacyRandom random, double x, double y, double z) =>
        new(sound, SoundCategory.Ambient, random) { X = x, Y = y, Z = z };
}

/// <summary><c>AbstractTickableSoundInstance</c>: a sound that follows something or changes as it plays.</summary>
public abstract class TickableSoundInstance(Identifier identifier, SoundCategory source, LegacyRandom random) : SoundInstance(identifier, source, random) {
    public bool IsStopped { get; private set; }

    protected void Stop() => IsStopped = true;

    /// <summary>Puts the sound at the entity, through floats as every vanilla instance that follows one does.</summary>
    protected void MoveTo(ClientEntity entity) {
        X = (float)entity.Position.X;
        Y = (float)entity.Position.Y;
        Z = (float)entity.Position.Z;
    }

    protected static bool IsSilent(ClientEntity entity) => entity.Get(EntityDataFields.Entity.Silent);

    public abstract void Tick();
}

/// <summary><c>EntityBoundSoundInstance</c>: a sound that moves with the entity making it.</summary>
public sealed class EntityBoundSoundInstance : TickableSoundInstance {
    private readonly ClientEntity _entity;
    private readonly Func<ClientEntity, bool> _removed;

    public EntityBoundSoundInstance(Identifier sound, SoundCategory source, float volume, float pitch, ClientEntity entity, long seed, Func<ClientEntity, bool> removed)
        : base(sound, source, new LegacyRandom(seed)) {
        BaseVolume = volume;
        BasePitch = pitch;
        _entity = entity;
        _removed = removed;
        MoveTo(entity);
    }

    public override bool CanPlaySound => !IsSilent(_entity);

    public override void Tick() {
        if (_removed(_entity)) {
            Stop();
            return;
        }
        MoveTo(_entity);
    }
}
