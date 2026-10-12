using ClientLib;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Sounds;
using Minecraft.Physics;
using Minecraft.Schemas;
using Minecraft.Schemas.Sound;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace GraphicalClient.Audio;

/// <summary><c>AmbientSoundHandler</c>: ticked by the local player once it has loaded.</summary>
public interface IAmbientSoundHandler {
    void Tick();
}

/// <summary><c>UnderwaterAmbientSoundHandler</c>: the rare noises rolled each tick while the player is under water.</summary>
public sealed class UnderwaterAmbientSoundHandler(SoundEngine engine, MinecraftClient client, LocalPlayer player, LegacyRandom random) : IAmbientSoundHandler {
    private int _tickDelay;

    public void Tick() {
        _tickDelay--;
        if (_tickDelay <= 0 && player.IsUnderWater) {
            float rand = random.NextFloat();
            ISoundType? sound = rand < 1.0E-4F ? SoundType.UnderwaterLoopAdditionsUltraRare
                : rand < 0.001F ? SoundType.UnderwaterLoopAdditionsRare
                : rand < 0.01F ? SoundType.UnderwaterLoopAdditions
                : null;
            if (sound != null) {
                _tickDelay = 0;
                engine.Play(new UnderwaterAmbientSoundInstances.SubSound(client, player, sound));
            }
        }
    }
}

/// <summary><c>BubbleColumnAmbientSoundHandler</c>: the whoosh on entering a bubble column.</summary>
public sealed class BubbleColumnAmbientSoundHandler(ClientSounds sounds, MinecraftClient client, LocalPlayer player) : IAmbientSoundHandler {
    private bool _wasInBubbleColumn;
    private bool _firstTick = true;

    public void Tick() {
        if (client.Level is not { } level) {
            return;
        }
        Box box = player.BoundingBox.Inflate(0.0, -0.4F, 0.0).Inflate(-1.0E-6);
        if (FirstBubbleColumn(level, box) is { } state) {
            if (!_wasInBubbleColumn && !_firstTick && !player.IsSpectator) {
                sounds.PlayFromPlayer(player, state.Drag ? SoundType.BubbleColumnWhirlpoolInside : SoundType.BubbleColumnUpwardsInside, 1.0F, 1.0F);
            }
            _wasInBubbleColumn = true;
        }
        else {
            _wasInBubbleColumn = false;
        }
        _firstTick = false;
    }

    /// <summary><c>getBlockStatesIfLoaded</c> filtered to the first bubble column, in <c>BlockPos.betweenClosed</c> order (x, then y, then z).</summary>
    private static BubbleColumnBlock? FirstBubbleColumn(ClientLevel level, Box box) {
        int x0 = Mth.Floor(box.MinX), x1 = Mth.Floor(box.MaxX);
        int y0 = Mth.Floor(box.MinY), y1 = Mth.Floor(box.MaxY);
        int z0 = Mth.Floor(box.MinZ), z1 = Mth.Floor(box.MaxZ);
        if (y1 < level.MinY || y0 > level.MaxY) {
            return null;
        }
        for (int cx = x0 >> 4; cx <= x1 >> 4; cx++) {
            for (int cz = z0 >> 4; cz <= z1 >> 4; cz++) {
                if (!level.HasChunk(cx, cz)) {
                    return null;
                }
            }
        }
        for (int z = z0; z <= z1; z++) {
            for (int y = y0; y <= y1; y++) {
                for (int x = x0; x <= x1; x++) {
                    if (level.GetBlock(x, y, z) is BubbleColumnBlock column) {
                        return column;
                    }
                }
            }
        }
        return null;
    }
}

/// <summary>
/// <c>BiomeAmbientSoundsHandler</c>: the <c>audio/ambient_sounds</c> attribute at the player's feet, played as
/// a cross faded loop, rolled additions, and the mood sound that builds up in the dark.
/// </summary>
public sealed class BiomeAmbientSoundsHandler(SoundEngine engine, MinecraftClient client, LocalPlayer player, LegacyRandom random) : IAmbientSoundHandler {
    private const int LoopSoundCrossFadeTime = 40;

    // An Object2ObjectArrayMap upstream, so iteration is insertion order; fadeOut does not depend on it.
    private readonly Dictionary<SoundEvent, LoopSoundInstance> _loopSounds = new();
    private SoundEvent? _previousLoopSound;
    private float _moodiness;

    public void Tick() {
        foreach ((SoundEvent sound, LoopSoundInstance instance) in _loopSounds) {
            if (instance.IsStopped) {
                _loopSounds.Remove(sound);
            }
        }
        if (client.Level is not { } level) {
            return;
        }
        AmbientSounds ambientSounds = AudioEnvironment.AmbientSounds(level, player.Position.X, player.Position.Y, player.Position.Z);
        SoundEvent? currentLoopSound = ambientSounds.Loop;
        if (!Equals(currentLoopSound, _previousLoopSound)) {
            _previousLoopSound = currentLoopSound;
            foreach (LoopSoundInstance instance in _loopSounds.Values) {
                instance.FadeOut();
            }
            if (currentLoopSound != null) {
                if (!_loopSounds.TryGetValue(currentLoopSound, out LoopSoundInstance? soundInstance)) {
                    soundInstance = new LoopSoundInstance(currentLoopSound);
                    engine.Play(soundInstance);
                    _loopSounds[currentLoopSound] = soundInstance;
                }
                soundInstance.FadeIn();
            }
        }

        foreach (AmbientAdditionsSettings additions in ambientSounds.Additions) {
            if (random.NextDouble() < additions.TickChance) {
                // SimpleSoundInstance.forAmbientAddition
                engine.Play(SoundInstance.ForLocalAmbience(additions.Sound.Type.Identifier, 1.0F, 1.0F));
            }
        }

        if (ambientSounds.Mood is { } mood) {
            Mood(level, mood);
        }
    }

    private void Mood(ClientLevel level, AmbientMoodSettings mood) {
        double eyeY = player.Position.Y + player.CurrentEyeHeight;
        int searchSpan = mood.BlockSearchExtent * 2 + 1;
        int blockX = Mth.Floor(player.Position.X + random.NextInt(searchSpan) - mood.BlockSearchExtent);
        int blockY = Mth.Floor(eyeY + random.NextInt(searchSpan) - mood.BlockSearchExtent);
        int blockZ = Mth.Floor(player.Position.Z + random.NextInt(searchSpan) - mood.BlockSearchExtent);
        int skyBrightness = level.GetSkyLight(blockX, blockY, blockZ);
        if (skyBrightness > 0) {
            _moodiness -= skyBrightness / 15.0F * 0.001F;
        }
        else {
            _moodiness -= (float)(level.GetBlockLight(blockX, blockY, blockZ) - 1) / mood.TickDelay;
        }

        if (_moodiness >= 1.0F) {
            double blockSampleX = blockX + 0.5;
            double blockSampleY = blockY + 0.5;
            double blockSampleZ = blockZ + 0.5;
            double blockDirectionX = blockSampleX - player.Position.X;
            double blockDirectionY = blockSampleY - eyeY;
            double blockDirectionZ = blockSampleZ - player.Position.Z;
            double blockDistance = Math.Sqrt(blockDirectionX * blockDirectionX + blockDirectionY * blockDirectionY + blockDirectionZ * blockDirectionZ);
            double soundSourceDistance = blockDistance + mood.Offset;
            engine.Play(SoundInstance.ForAmbientMood(mood.Sound.Type.Identifier, random,
                player.Position.X + blockDirectionX / blockDistance * soundSourceDistance,
                eyeY + blockDirectionY / blockDistance * soundSourceDistance,
                player.Position.Z + blockDirectionZ / blockDistance * soundSourceDistance));
            _moodiness = 0.0F;
        }
        else {
            _moodiness = Math.Max(_moodiness, 0.0F);
        }
    }

    /// <summary><c>LoopSoundInstance</c>.</summary>
    private sealed class LoopSoundInstance : TickableSoundInstance {
        private int _fadeDirection;
        private int _fade;

        public LoopSoundInstance(SoundEvent soundEvent) : base(soundEvent.Type.Identifier, SoundCategory.Ambient, new LegacyRandom()) {
            Looping = true;
            Relative = true;
        }

        public override void Tick() {
            if (_fade < 0) {
                Stop();
            }
            _fade += _fadeDirection;
            BaseVolume = Math.Clamp(_fade / (float)LoopSoundCrossFadeTime, 0.0F, 1.0F);
        }

        public void FadeOut() {
            _fade = Math.Min(_fade, LoopSoundCrossFadeTime);
            _fadeDirection = -1;
        }

        public void FadeIn() {
            _fade = Math.Max(0, _fade);
            _fadeDirection = 1;
        }
    }
}
