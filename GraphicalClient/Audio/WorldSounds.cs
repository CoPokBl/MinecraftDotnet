using ClientLib;
using ClientLib.Entities;
using ClientLib.World;
using Minecraft.Data.Generated;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary>
/// The sounds the client makes for itself when told something happened in the world: level events,
/// explosions, game events, entity and damage events, items picked up, and lightning striking.
/// </summary>
public sealed class WorldSounds {
    private readonly ClientSounds _sounds;
    private readonly MinecraftClient _client;
    private readonly Func<(double X, double Y, double Z)> _camera;
    private readonly EntityEventSounds _entityEvents;
    // ClientLevel's and ClientPacketListener's randoms are unseeded, so any random stands in for either.
    private readonly LegacyRandom _random = new();
    private readonly LegacyRandom _listenerRandom = new();
    // Entity.random, for the lightning bolts.
    private readonly LegacyRandom _boltRandom = new();
    private readonly Dictionary<ClientEntity, int> _boltLife = new();
    private ClientLevel? _level;
    private LevelEventHandler? _levelEvents;

    public WorldSounds(ClientSounds sounds, MinecraftClient client, Func<(double X, double Y, double Z)> camera) {
        _sounds = sounds;
        _client = client;
        _camera = camera;
        _entityEvents = new EntityEventSounds(sounds, client, camera);
        client.LevelChanged += SetLevel;
        client.EntityTaken += TakeEntity;
        if (client.Level != null) {
            SetLevel(client.Level);
        }
    }

    /// <summary>A new <c>ClientLevel</c> brings a new <c>LevelEventHandler</c>, jukeboxes and all.</summary>
    private void SetLevel(ClientLevel level) {
        if (_level != null) {
            _level.LevelEvent -= LocalLevelEvent;
        }
        _level = level;
        _levelEvents = new LevelEventHandler(_sounds, level, _camera);
        level.LevelEvent += LocalLevelEvent;
    }

    private void LocalLevelEvent(int type, int x, int y, int z, int data) => _levelEvents?.LevelEvent(type, x, y, z, data);

    public void Handle(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundWorldEventPacket { DisableRelativeVolume: true } levelEvent:
                // ClientPacketListener.handleLevelEvent.
                _levelEvents?.GlobalLevelEvent(levelEvent.Event, levelEvent.Location.X, levelEvent.Location.Y, levelEvent.Location.Z, levelEvent.Data);
                break;
            case ClientBoundWorldEventPacket levelEvent:
                _levelEvents?.LevelEvent(levelEvent.Event, levelEvent.Location.X, levelEvent.Location.Y, levelEvent.Location.Z, levelEvent.Data);
                break;
            case ClientBoundExplosionPacket explosion:
                // ClientPacketListener.handleExplosion.
                _sounds.Play(ClientSounds.TypeOf(explosion.SoundEvent, explosion.SoundType), SoundCategory.Blocks, 4.0F,
                    (1.0F + (_random.NextFloat() - _random.NextFloat()) * 0.2F) * 0.7F, explosion.Center.X, explosion.Center.Y, explosion.Center.Z);
                break;
            case ClientBoundGameEventPacket gameEvent:
                HandleGameEvent(gameEvent);
                break;
            case ClientBoundEntityEventPacket entityEvent:
                if (_client.Entities.TryGetValue(entityEvent.EntityId, out ClientEntity? entity)) {
                    _entityEvents.HandleEntityEvent(entity, (byte)entityEvent.Status);
                }
                break;
            case ClientBoundDamageEventPacket damage:
                if (_client.Entities.TryGetValue(damage.EntityId, out ClientEntity? damaged)) {
                    _entityEvents.HandleDamageEvent(damaged, damage.SourceType);
                }
                break;
        }
    }

    /// <summary>Once a game tick, as the level ticks its entities and the particle engine its particles.</summary>
    public void Tick() {
        TickLightning();
        _entityEvents.Tick();
    }

    /// <summary>
    /// The client half of <c>LightningBolt.tick</c>: thunder and the strike on the bolt's first tick. Later
    /// flashes restart its life at 1, never 2, so they are silent.
    /// </summary>
    private void TickLightning() {
        foreach (ClientEntity entity in _client.Entities.Values) {
            if (!entity.Is(EntityClass.LightningBolt)) {
                continue;
            }
            int life = _boltLife.GetValueOrDefault(entity, 2);
            if (life == 2) {
                _sounds.Play(SoundType.LightningBoltThunder, SoundCategory.Weather, 10000.0F, 0.8F + _boltRandom.NextFloat() * 0.2F, entity.Position);
                _sounds.Play(SoundType.LightningBoltImpact, SoundCategory.Weather, 2.0F, 0.5F + _boltRandom.NextFloat() * 0.2F, entity.Position);
            }
            _boltLife[entity] = life - 1;
        }
        foreach (ClientEntity tracked in _boltLife.Keys) {
            if (_sounds.IsRemoved(tracked)) {
                _boltLife.Remove(tracked);
            }
        }
    }

    /// <summary>The sound in <c>ClientPacketListener.handleTakeItemEntity</c>.</summary>
    private void TakeEntity(ClientEntity from, ClientEntity to) {
        if (from.Is(EntityClass.ExperienceOrb)) {
            _sounds.Play(SoundType.ExperienceOrbPickup, SoundCategory.Players, 0.1F,
                (_listenerRandom.NextFloat() - _listenerRandom.NextFloat()) * 0.35F + 0.9F, from.Position);
        }
        else {
            _sounds.Play(SoundType.ItemPickup, SoundCategory.Players, 0.2F,
                (_listenerRandom.NextFloat() - _listenerRandom.NextFloat()) * 1.4F + 2.0F, from.Position);
        }
    }

    /// <summary>
    /// <c>ClientPacketListener.handleGameEvent</c>. Its <c>level.playSound(player, ...)</c> plays because the
    /// excluded entity is the local player, which on a client means play.
    /// </summary>
    private void HandleGameEvent(ClientBoundGameEventPacket packet) {
        if (_client.Player is not { } player) {
            return;
        }
        int param = (int)Math.Floor(packet.Value + 0.5F);
        switch (packet.Event) {
            case GameEvent.ArrowHitPlayer:
                _sounds.Play(SoundType.ArrowHitPlayer, SoundCategory.Players, 0.18F, 0.45F, player.Position.X, player.Position.Y + player.CurrentEyeHeight, player.Position.Z);
                break;
            case GameEvent.PlayPufferfishStingSound:
                _sounds.Play(SoundType.PufferFishSting, SoundCategory.Neutral, 1.0F, 1.0F, player.Position);
                break;
            case GameEvent.PlayEnderGuardianMobAppearance when param == 1:
                _sounds.Play(SoundType.ElderGuardianCurse, SoundCategory.Hostile, 1.0F, 1.0F, player.Position);
                break;
        }
    }
}
