using ClientLib;
using ClientLib.Entities;
using ClientLib.Maths;
using Minecraft.Data.Sounds;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary>
/// The game's side of sound: the sound packets as <c>ClientPacketListener</c> and <c>ClientLevel</c>
/// play them, and the ways the client plays the sounds vanilla makes locally rather than being sent.
/// </summary>
public sealed class ClientSounds(SoundEngine engine, MinecraftClient client, Func<(double X, double Y, double Z)> camera) {
    private readonly LegacyRandom _random = new();

    public SoundEngine Engine => engine;

    public void Handle(MinecraftPacket packet) {
        switch (packet) {
            case ClientBoundSoundEffectPacket sound:
                // playSeededSound: the seed picks the variant, so every client hears the same one.
                engine.Play(SoundInstance.At(TypeOf(sound.Event, sound.Type).Identifier, sound.Category, sound.Volume, sound.Pitch,
                    new LegacyRandom(sound.Seed), sound.Pos.X, sound.Pos.Y, sound.Pos.Z));
                break;
            case ClientBoundEntitySoundEffectPacket entitySound:
                if (client.Entities.TryGetValue(entitySound.EntityId, out ClientEntity? entity)) {
                    engine.Play(new EntityBoundSoundInstance(TypeOf(entitySound.Event, entitySound.Type).Identifier, entitySound.Category,
                        entitySound.Volume, entitySound.Pitch, entity, entitySound.Seed, IsRemoved));
                }
                break;
            case ClientBoundStopSoundPacket stop:
                engine.Stop(stop.Sound, stop.Category);
                break;
        }
    }

    /// <summary>A sound a packet or component gives either inline or as a registered event.</summary>
    public static ISoundType TypeOf(SoundEvent? inline, ISoundType? registered) => inline?.Type ?? registered!;

    public static ISoundType TypeOf(Or<ISoundType, SoundEvent> sound) => sound.IsValue1 ? sound.Value1! : sound.Value2!.Type;

    /// <summary>Whether the entity has left the level, or its id now names a different one.</summary>
    public bool IsRemoved(ClientEntity entity) => !client.Entities.TryGetValue(entity.Id, out ClientEntity? current) || current != entity;

    public static double DistanceSqr((double X, double Y, double Z) from, double x, double y, double z) =>
        (x - from.X) * (x - from.X) + (y - from.Y) * (y - from.Y) + (z - from.Z) * (z - from.Z);

    /// <summary>
    /// <c>ClientLevel.playLocalSound</c> at a position: one this client makes for itself. With
    /// <paramref name="distanceDelay"/> a sound further than ten blocks off arrives late, at forty blocks a
    /// second, as thunder and distant explosions do.
    /// </summary>
    public void Play(ISoundType sound, SoundCategory category, float volume, float pitch, double x, double y, double z, bool distanceDelay = false) {
        double distanceSqr = DistanceSqr(camera(), x, y, z);
        SoundInstance instance = SoundInstance.At(sound.Identifier, category, volume, pitch, new LegacyRandom(_random.NextLong()), x, y, z);
        if (distanceDelay && distanceSqr > 100.0) {
            double delayTicks = Math.Sqrt(distanceSqr) / 40.0;
            engine.PlayDelayed(instance, (int)(delayTicks * 20.0));
        }
        else {
            engine.Play(instance);
        }
    }

    public void Play(ISoundType sound, SoundCategory category, float volume, float pitch, Vec3d at) => Play(sound, category, volume, pitch, at.X, at.Y, at.Z);

    /// <summary><c>Level.playLocalSound(BlockPos, ...)</c> and <c>playSound(player, BlockPos, ...)</c>: the middle of the block.</summary>
    public void PlayAtBlock(int x, int y, int z, ISoundType sound, SoundCategory category, float volume, float pitch, bool distanceDelay = false) =>
        Play(sound, category, volume, pitch, x + 0.5, y + 0.5, z + 0.5, distanceDelay);

    /// <summary><c>LocalPlayer.playSound</c>: where the player stands, in its category, and with no silent check.</summary>
    public void PlayFromPlayer(ClientEntity player, ISoundType sound, float volume, float pitch) =>
        Play(sound, SoundCategory.Players, volume, pitch, player.Position);

    /// <summary><c>ClientLevel.playLocalSound(entity, ...)</c>: a sound that follows the entity making it.</summary>
    public void PlayAt(ClientEntity entity, ISoundType sound, SoundCategory category, float volume, float pitch) =>
        engine.Play(new EntityBoundSoundInstance(sound.Identifier, category, volume, pitch, entity, _random.NextLong(), IsRemoved));

    /// <summary><c>SimpleSoundInstance.forUI</c>, a menu's click.</summary>
    public void PlayUi(ISoundType sound, float pitch = 1.0F, float volume = 0.25F) => engine.Play(SoundInstance.ForUi(sound.Identifier, pitch, volume));
}
