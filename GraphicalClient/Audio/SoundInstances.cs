using ClientLib;
using ClientLib.Entities;
using ClientLib.Entities.Vehicles;
using ClientLib.Player;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Entities;
using Minecraft.Schemas.Sound;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace GraphicalClient.Audio;

/// <summary>
/// <c>GuardianAttackSoundInstance</c>: the beam's hum, louder and higher as the attack charges. Mob.getTarget
/// is the server's AI target and always null on a client, so only removal stops it.
/// </summary>
public sealed class GuardianAttackSoundInstance : TickableSoundInstance {
    private readonly ClientEntity _guardian;
    private readonly Func<ClientEntity, bool> _removed;
    private readonly int _attackDuration;
    private int _lastAttackTarget;
    private int _clientSideAttackTime;

    public GuardianAttackSoundInstance(ClientEntity guardian, Func<ClientEntity, bool> removed)
        : base(SoundType.GuardianAttack.Identifier, SoundCategory.Hostile, new LegacyRandom()) {
        _guardian = guardian;
        _removed = removed;
        Attenuation = Attenuation.None;
        Looping = true;
        // Guardian.getAttackDuration, which ElderGuardian shortens.
        _attackDuration = guardian.Is(EntityClass.ElderGuardian) ? 60 : 80;
        _lastAttackTarget = guardian.Get(EntityDataFields.Guardian.IdAttackTarget);
    }

    public override bool CanPlaySound => !IsSilent(_guardian);

    public override void Tick() {
        if (_removed(_guardian)) {
            Stop();
            return;
        }
        TickAttackTime();
        MoveTo(_guardian);
        float scale = (float)_clientSideAttackTime / _attackDuration;
        BaseVolume = 0.0F + 1.0F * scale * scale;
        BasePitch = 0.7F + 0.5F * scale;
    }

    /// <summary>
    /// <c>Guardian.clientSideAttackTime</c>, which the client entity does not keep: reset by
    /// <c>onSyncedDataUpdated</c> when the attack target changes, then counted up by <c>aiStep</c> while
    /// it is alive and has one.
    /// </summary>
    private void TickAttackTime() {
        int target = _guardian.Get(EntityDataFields.Guardian.IdAttackTarget);
        if (target != _lastAttackTarget) {
            _lastAttackTarget = target;
            _clientSideAttackTime = 0;
        }
        if (_guardian.CurrentHealth > 0.0F && target != 0 && _clientSideAttackTime < _attackDuration) {
            _clientSideAttackTime++;
        }
    }
}

/// <summary><c>SnifferSoundInstance</c>: digging, for as long as the sniffer keeps at it. Mob.getTarget is always null on a client.</summary>
public sealed class SnifferSoundInstance : TickableSoundInstance {
    private readonly ClientEntity _sniffer;
    private readonly Func<ClientEntity, bool> _removed;

    public SnifferSoundInstance(ClientEntity sniffer, Func<ClientEntity, bool> removed)
        : base(SoundType.SnifferDigging.Identifier, SoundCategory.Neutral, new LegacyRandom()) {
        _sniffer = sniffer;
        _removed = removed;
    }

    public override bool CanPlaySound => !IsSilent(_sniffer);

    public override void Tick() {
        // Sniffer.canPlayDiggingSound.
        if (!_removed(_sniffer) && _sniffer.Get(EntityDataFields.Sniffer.State) is SnifferState.Digging or SnifferState.Searching) {
            MoveTo(_sniffer);
            BaseVolume = 1.0F;
            BasePitch = 1.0F;
        }
        else {
            Stop();
        }
    }
}

/// <summary><c>ElytraOnPlayerSoundInstance</c>: the wind while gliding, silent for the first second and louder with speed.</summary>
public sealed class ElytraOnPlayerSoundInstance : TickableSoundInstance {
    private const int DelayTicks = 20;

    private readonly MinecraftClient _client;
    private readonly LocalPlayer _player;
    private int _time;

    public ElytraOnPlayerSoundInstance(MinecraftClient client, LocalPlayer player)
        : base(SoundType.ElytraFlying.Identifier, SoundCategory.Players, new LegacyRandom()) {
        _client = client;
        _player = player;
        Looping = true;
        BaseVolume = 0.1F;
    }

    public override void Tick() {
        _time++;
        if (_client.Player == _player && (_time <= DelayTicks || HumanoidEntityData.IsFallFlying(_player))) {
            MoveTo(_player);
            float speed = (float)_player.DeltaMovement.LengthSqr();
            BaseVolume = speed >= 1.0E-7 ? Math.Clamp(speed / 4.0F, 0.0F, 1.0F) : 0.0F;
            if (_time < 20) {
                BaseVolume = 0.0F;
            }
            else if (_time < 40) {
                BaseVolume *= (_time - 20) / 20.0F;
            }
            BasePitch = BaseVolume > 0.8F ? 1.0F + (BaseVolume - 0.8F) : 1.0F;
        }
        else {
            Stop();
        }
    }
}

/// <summary><c>UnderwaterAmbientSoundInstances</c>.</summary>
public static class UnderwaterAmbientSoundInstances {
    /// <summary><c>SubSound</c>: one of the underwater additions, cut off when the player surfaces.</summary>
    public sealed class SubSound : TickableSoundInstance {
        private readonly MinecraftClient _client;
        private readonly LocalPlayer _player;

        public SubSound(MinecraftClient client, LocalPlayer player, ISoundType sound) : base(sound.Identifier, SoundCategory.Ambient, new LegacyRandom()) {
            _client = client;
            _player = player;
            Relative = true;
        }

        public override void Tick() {
            if (_client.Player != _player || !_player.IsUnderWater) {
                Stop();
            }
        }
    }

    /// <summary><c>UnderwaterAmbientSoundInstance</c>: the loop, which fades in over two seconds and out twice as fast.</summary>
    public sealed class UnderwaterAmbientSoundInstance : TickableSoundInstance {
        private const int FadeDuration = 40;

        private readonly MinecraftClient _client;
        private readonly LocalPlayer _player;
        private int _fade;

        public UnderwaterAmbientSoundInstance(MinecraftClient client, LocalPlayer player)
            : base(SoundType.UnderwaterLoop.Identifier, SoundCategory.Ambient, new LegacyRandom()) {
            _client = client;
            _player = player;
            Looping = true;
            Relative = true;
        }

        public override void Tick() {
            if (_client.Player == _player && _fade >= 0) {
                _fade += _player.IsUnderWater ? 1 : -2;
                _fade = Math.Min(_fade, FadeDuration);
                BaseVolume = Math.Max(0.0F, Math.Min(_fade / 40.0F, 1.0F));
            }
            else {
                Stop();
            }
        }
    }
}

/// <summary>
/// <c>RidingEntitySoundInstance</c>: a loop that follows nothing and swells with the speed of what the
/// player rides, until the player gets off.
/// </summary>
public class RidingEntitySoundInstance : TickableSoundInstance {
    protected readonly LocalPlayer Player;
    protected readonly ClientEntity Entity;
    protected readonly bool UnderwaterSound;
    private readonly float _volumeMin, _volumeMax, _volumeAmplifier;

    public RidingEntitySoundInstance(LocalPlayer player, ClientEntity entity, bool underwaterSound, Identifier sound, SoundCategory source,
        float volumeMin, float volumeMax, float volumeAmplifier) : base(sound, source, new LegacyRandom()) {
        Player = player;
        Entity = entity;
        UnderwaterSound = underwaterSound;
        _volumeMin = volumeMin;
        _volumeMax = volumeMax;
        _volumeAmplifier = volumeAmplifier;
        Attenuation = Attenuation.None;
        Looping = true;
        BaseVolume = volumeMin;
    }

    public override bool CanPlaySound => !IsSilent(Entity);

    public override bool CanStartSilent => true;

    /// <summary><c>Entity.isUnderWater</c>: the eyes in water, which only a vehicle the client simulates keeps.</summary>
    protected virtual bool ShouldNotPlayUnderwaterSound() =>
        UnderwaterSound != Entity switch {
            ClientBoat boat => boat.IsUnderWater,
            ClientVehicle vehicle => vehicle.Fluids.EyeInWater,
            _ => false
        };

    protected virtual float EntitySpeed => (float)Entity.DeltaMovement.Length();

    public override void Tick() {
        if (Entity.IsRemoved || !Player.IsPassenger || Player.Vehicle != Entity) {
            Stop();
        }
        else if (ShouldNotPlayUnderwaterSound()) {
            BaseVolume = _volumeMin;
        }
        else {
            float speed = EntitySpeed;
            BaseVolume = speed >= 0.01F ? _volumeAmplifier * (_volumeMin + Math.Min(speed, 1.0F) * (_volumeMax - _volumeMin)) : _volumeMin;
        }
    }
}

/// <summary>
/// <c>RidingMinecartSoundInstance</c>: louder with the cart's horizontal speed. The cart is not
/// simulated here, so it always counts as on rails, which <c>OldMinecartBehavior</c> makes true anyway.
/// </summary>
public sealed class RidingMinecartSoundInstance(LocalPlayer player, ClientEntity minecart, bool underwaterSound, Identifier sound)
    : RidingEntitySoundInstance(player, minecart, underwaterSound, sound, SoundCategory.Neutral, 0.0F, 0.75F, 1.0F) {
    protected override bool ShouldNotPlayUnderwaterSound() => UnderwaterSound != Player.IsUnderWater;

    protected override float EntitySpeed => (float)Math.Sqrt(Entity.DeltaMovement.HorizontalDistanceSqr());
}
