using ClientLib;
using ClientLib.Entities;
using ClientLib.Player;
using GraphicalClient.Rendering.Entities.Vanilla;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Sound;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace GraphicalClient.Audio;

/// <summary>
/// The sounds <c>LocalPlayer</c> makes for itself each tick: its <c>ambientSoundHandlers</c>, the underwater
/// enter and exit from <c>updateIsUnderwater</c>, the elytra wind from <c>onSyncedDataUpdated</c>, and the
/// riding loops from <c>startRiding</c>. A new <see cref="LocalPlayer"/> (a respawn) gets new handlers, as
/// vanilla's are made in its constructor.
/// </summary>
public sealed class LocalPlayerAmbience(ClientSounds sounds, MinecraftClient client) {
    private LocalPlayer? _player;
    private IAmbientSoundHandler[] _handlers = [];
    private bool _wasUnderwater;
    private bool _wasFallFlying;

    public void Tick() {
        LocalPlayer? player = client.Player;
        if (player != _player) {
            if (_player != null) {
                _player.StartedRiding -= StartRiding;
            }
            if (player != null) {
                player.StartedRiding += StartRiding;
            }
            _player = player;
            _wasUnderwater = false;
            _wasFallFlying = false;
            // Level.getRandom upstream, shared with animateTick and the rest; it is unseeded, so a stream of
            // the handlers' own changes no distribution.
            LegacyRandom random = new();
            _handlers = player == null ? [] : [
                new UnderwaterAmbientSoundHandler(sounds.Engine, client, player, random),
                new BubbleColumnAmbientSoundHandler(sounds, client, player),
                new BiomeAmbientSoundsHandler(sounds.Engine, client, player, random)
            ];
        }
        if (player == null || client.Level == null || !client.ClientLoaded) {
            return;
        }

        UpdateIsUnderwater(player);

        // onSyncedDataUpdated fires on the shared flags changing, against the wasFallFlying aiStep keeps; read
        // once a tick here, which sees the same transition.
        bool fallFlying = HumanoidEntityData.IsFallFlying(player);
        if (fallFlying && !_wasFallFlying) {
            sounds.Engine.Play(new ElytraOnPlayerSoundInstance(client, player));
        }
        _wasFallFlying = fallFlying;

        foreach (IAmbientSoundHandler handler in _handlers) {
            handler.Tick();
        }
    }

    /// <summary>
    /// <c>LocalPlayer.updateIsUnderwater</c>. The player's tick has already set <see cref="LocalPlayer.IsUnderWater"/>
    /// at the point vanilla would play these, before it moved, which is where <see cref="ClientEntity.OldPosition"/> is.
    /// </summary>
    private void UpdateIsUnderwater(LocalPlayer player) {
        bool oldIsUnderwater = _wasUnderwater;
        bool newIsUnderwater = player.IsUnderWater;
        _wasUnderwater = newIsUnderwater;
        if (player.IsSpectator) {
            return;
        }
        if (!oldIsUnderwater && newIsUnderwater) {
            sounds.Play(SoundType.UnderwaterEnter, SoundCategory.Ambient, 1.0F, 1.0F, player.OldPosition);
            sounds.Engine.Play(new UnderwaterAmbientSoundInstances.UnderwaterAmbientSoundInstance(client, player));
        }
        if (oldIsUnderwater && !newIsUnderwater) {
            sounds.Play(SoundType.UnderwaterExit, SoundCategory.Ambient, 1.0F, 1.0F, player.OldPosition);
        }
    }

    /// <summary><c>LocalPlayer.startRiding</c>'s loops: a minecart's two, a happy ghast's and a nautilus's.</summary>
    private void StartRiding(ClientEntity vehicle) {
        if (_player is not { } player) {
            return;
        }
        if (vehicle.Is(EntityClass.AbstractMinecart)) {
            sounds.Engine.Play(new RidingMinecartSoundInstance(player, vehicle, true, SoundType.MinecartInsideUnderwater.Identifier));
            sounds.Engine.Play(new RidingMinecartSoundInstance(player, vehicle, false, SoundType.MinecartInside.Identifier));
        }
        else if (vehicle.Is(EntityClass.HappyGhast)) {
            sounds.Engine.Play(new RidingEntitySoundInstance(player, vehicle, false, SoundType.HappyGhastRiding.Identifier, SoundCategory.Neutral, 0.0F, 1.0F, 5.0F));
        }
        else if (vehicle.Is(EntityClass.AbstractNautilus)) {
            sounds.Engine.Play(new RidingEntitySoundInstance(player, vehicle, true, SoundType.NautilusRiding.Identifier, SoundCategory.Neutral, 0.0F, 1.0F, 5.0F));
        }
    }
}
