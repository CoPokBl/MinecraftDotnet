using ClientLib;
using ClientLib.Interaction;
using ClientLib.Maths;
using ClientLib.Player;
using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Sound;
using Attribute = Minecraft.Data.Generated.Attribute;

namespace GraphicalClient.Audio;

/// <summary>
/// The sounds the player's own movement makes, which a server plays to everyone but that player:
/// steps, swimming, the splash into water and landing, each <c>LocalPlayer.playSound</c> played where
/// the player stands; and the portal's trigger, which only the player hears. The splash's particle
/// draws from the entity's random go with the particles; that random is unseeded, so nothing can tell.
/// </summary>
public sealed class LocalPlayerSounds {
    // No generated type names block tags; these are matched against the tags the server sent.
    private static readonly Identifier InsideStepSoundBlocks = "minecraft:inside_step_sound_blocks";
    private static readonly Identifier CombinationStepSoundBlocks = "minecraft:combination_step_sound_blocks";
    private static readonly Identifier CrystalSoundBlocks = "minecraft:crystal_sound_blocks";

    private readonly ClientSounds _sounds;
    private readonly MinecraftClient _client;
    private readonly BlockTags _tags;
    private readonly LegacyRandom _random = new();

    private LocalPlayer? _player;
    private int _tickCount;
    private int _lastCrystalSoundPlayTick;
    private float _crystalSoundIntensity;

    public LocalPlayerSounds(ClientSounds sounds, MinecraftClient client) {
        _sounds = sounds;
        _client = client;
        _tags = new BlockTags(client);
    }

    /// <summary>
    /// Once a tick, before the client ticks: follows the <see cref="LocalPlayer"/> a login or respawn
    /// replaces, and counts its <c>Entity.tickCount</c>, which the amethyst chime reads.
    /// </summary>
    public void Tick() {
        LocalPlayer? player = _client.Player;
        if (player != _player) {
            if (_player != null) {
                _player.Stepped -= WalkingStepSound;
                _player.SwimStroke -= WaterSwimSound;
                _player.SplashedIntoWater -= DoWaterSplashEffect;
                _player.FellOn -= FallOn;
                _player.PortalTriggered -= PortalTrigger;
            }
            _player = player;
            _tickCount = 0;
            _lastCrystalSoundPlayTick = 0;
            _crystalSoundIntensity = 0.0F;
            if (player != null) {
                player.Stepped += WalkingStepSound;
                player.SwimStroke += WaterSwimSound;
                player.SplashedIntoWater += DoWaterSplashEffect;
                player.FellOn += FallOn;
                player.PortalTriggered += PortalTrigger;
            }
        }
        if (_player != null) {
            _tickCount++;
        }
    }

    private LocalPlayer Player => _player!;
    private ClientLevel Level => _client.Level!;

    private void PlaySound(ISoundType sound, float volume, float pitch) => _sounds.PlayFromPlayer(Player, sound, volume, pitch);

    /// <summary><c>Entity.walkingStepSound</c>.</summary>
    private void WalkingStepSound((int X, int Y, int Z) onPos, IBlock onState) {
        PlayStepSound(onPos, onState);
        if (ShouldPlayAmethystStepSound(onState)) {
            PlayAmethystStepSound();
        }
    }

    /// <summary><c>Player.playStepSound</c>.</summary>
    private void PlayStepSound((int X, int Y, int Z) onPos, IBlock onState) {
        if (Player.IsInWater) {
            WaterSwimSound();
            PlayMuffledStepSound(onState);
        }
        else {
            (int X, int Y, int Z) primaryStepSoundPos = GetPrimaryStepSoundBlockPos(onPos);
            if (onPos != primaryStepSoundPos) {
                IBlock primaryStepState = Level.GetBlock(primaryStepSoundPos.X, primaryStepSoundPos.Y, primaryStepSoundPos.Z);
                if (_tags.Contains(CombinationStepSoundBlocks, primaryStepState)) {
                    PlayCombinationStepSounds(primaryStepState, onState);
                }
                else {
                    EntityPlayStepSound(primaryStepState);
                }
            }
            else {
                EntityPlayStepSound(onState);
            }
        }
    }

    /// <summary><c>Entity.playStepSound</c>.</summary>
    private void EntityPlayStepSound(IBlock blockState) {
        BlockSoundGroup soundType = BlockSoundGroups.Of(blockState);
        PlaySound(soundType.Step, soundType.Volume * 0.15F, soundType.Pitch);
    }

    /// <summary><c>Entity.getPrimaryStepSoundBlockPos</c>: a carpet or a snow layer on top sounds instead of the block under it.</summary>
    private (int X, int Y, int Z) GetPrimaryStepSoundBlockPos((int X, int Y, int Z) affectingPos) {
        (int X, int Y, int Z) abovePos = (affectingPos.X, affectingPos.Y + 1, affectingPos.Z);
        IBlock aboveState = Level.GetBlock(abovePos.X, abovePos.Y, abovePos.Z);
        return !_tags.Contains(InsideStepSoundBlocks, aboveState) && !_tags.Contains(CombinationStepSoundBlocks, aboveState) ? affectingPos : abovePos;
    }

    /// <summary><c>Entity.playCombinationStepSounds</c>.</summary>
    private void PlayCombinationStepSounds(IBlock primaryStepSound, IBlock secondaryStepSound) {
        BlockSoundGroup primaryStepSoundType = BlockSoundGroups.Of(primaryStepSound);
        PlaySound(primaryStepSoundType.Step, primaryStepSoundType.Volume * 0.15F, primaryStepSoundType.Pitch);
        PlayMuffledStepSound(secondaryStepSound);
    }

    /// <summary><c>Entity.playMuffledStepSound</c>.</summary>
    private void PlayMuffledStepSound(IBlock blockState) {
        BlockSoundGroup secondaryStepSoundType = BlockSoundGroups.Of(blockState);
        PlaySound(secondaryStepSoundType.Step, secondaryStepSoundType.Volume * 0.05F, secondaryStepSoundType.Pitch * 0.8F);
    }

    /// <summary><c>Entity.shouldPlayAmethystStepSound</c>.</summary>
    private bool ShouldPlayAmethystStepSound(IBlock affectingState) =>
        _tags.Contains(CrystalSoundBlocks, affectingState) && _tickCount >= _lastCrystalSoundPlayTick + 20;

    /// <summary><c>Entity.playAmethystStepSound</c>.</summary>
    private void PlayAmethystStepSound() {
        _crystalSoundIntensity = _crystalSoundIntensity * (float)Math.Pow(0.997, _tickCount - _lastCrystalSoundPlayTick);
        _crystalSoundIntensity = Math.Min(1.0F, _crystalSoundIntensity + 0.07F);
        float pitch = 0.5F + _crystalSoundIntensity * _random.NextFloat() * 1.2F;
        float volume = 0.1F + _crystalSoundIntensity * 1.2F;
        PlaySound(SoundType.AmethystBlockChime, volume, pitch);
        _lastCrystalSoundPlayTick = _tickCount;
    }

    /// <summary><c>Entity.waterSwimSound</c>. A player is never ridden, so the speed is its own.</summary>
    private void WaterSwimSound() {
        float volumeModifier = 0.35F;
        Vec3d deltaMovement = Player.DeltaMovement;
        float speed = Math.Min(
            1.0F,
            (float)Math.Sqrt(deltaMovement.X * deltaMovement.X * 0.2F + deltaMovement.Y * deltaMovement.Y + deltaMovement.Z * deltaMovement.Z * 0.2F)
            * volumeModifier);
        PlaySwimSound(speed);
    }

    /// <summary><c>Entity.playSwimSound</c> with <c>Player.getSwimSound</c>.</summary>
    private void PlaySwimSound(float volume) => PlaySound(SoundType.PlayerSwim, volume, 1.0F + (_random.NextFloat() - _random.NextFloat()) * 0.4F);

    /// <summary><c>LocalPlayer.handlePortalTransitionEffect</c>'s <c>SimpleSoundInstance.forLocalAmbience</c>.</summary>
    private void PortalTrigger(float pitch) => _sounds.Engine.Play(SoundInstance.ForLocalAmbience(SoundType.PortalTrigger.Identifier, pitch, 0.25F));

    /// <summary><c>Player.doWaterSplashEffect</c> over <c>Entity.doWaterSplashEffect</c>.</summary>
    private void DoWaterSplashEffect() {
        if (Player.IsSpectator) {
            return;
        }
        float volumeModifier = 0.2F;
        Vec3d movement = Player.DeltaMovement;
        float speed = Math.Min(1.0F, (float)Math.Sqrt(movement.X * movement.X * 0.2F + movement.Y * movement.Y + movement.Z * movement.Z * 0.2F) * volumeModifier);
        PlaySound(speed < 0.25F ? SoundType.PlayerSplash : SoundType.PlayerSplashHighSpeed, speed, 1.0F + (_random.NextFloat() - _random.NextFloat()) * 0.4F);
    }

    /// <summary><c>Block.fallOn</c> and its overrides, for the blocks whose landing sounds differ.</summary>
    private void FallOn((int X, int Y, int Z) pos, IBlock state, double fallDistance) {
        if (BlockClasses.Is(state.Identifier, BlockClass.BedBlock)) {
            CauseFallDamage(fallDistance * 0.5, 1.0F);
        }
        else if (BlockClasses.Is(state.Identifier, BlockClass.HayBlock)) {
            CauseFallDamage(fallDistance, 0.2F);
        }
        else if (BlockClasses.Is(state.Identifier, BlockClass.PointedDripstoneBlock)) {
            if (state is PointedDripstoneBlock { VerticalDirection: VerticalDirection.Up, Thickness: SpeleothemThickness.Tip }) {
                CauseFallDamage(fallDistance + 2.5, 2.0F);
            }
            else {
                CauseFallDamage(fallDistance, 1.0F);
            }
        }
        else if (BlockClasses.Is(state.Identifier, BlockClass.SlimeBlock)) {
            // Entity.isSuppressingBounce is isShiftKeyDown.
            if (!Player.KeyPresses.Shift) {
                CauseFallDamage(fallDistance, 0.0F);
            }
        }
        else if (BlockClasses.Is(state.Identifier, BlockClass.HoneyBlock)) {
            PlaySound(SoundType.HoneyBlockSlide, 1.0F, 1.0F);
            if (CauseFallDamage(fallDistance, 0.2F)) {
                BlockSoundGroup soundType = BlockSoundGroups.Of(state);
                PlaySound(soundType.Fall, soundType.Volume * 0.5F, soundType.Pitch * 0.75F);
            }
        }
        else if (BlockClasses.Is(state.Identifier, BlockClass.PowderSnowBlock)) {
            if (!(fallDistance < 4.0)) {
                PlaySound(fallDistance < 7.0 ? SoundType.PlayerSmallFall : SoundType.PlayerBigFall, 1.0F, 1.0F);
            }
        }
        else {
            CauseFallDamage(fallDistance, 1.0F);
        }
    }

    /// <summary>
    /// <c>Player.causeFallDamage</c> over <c>LivingEntity.causeFallDamage</c>, as far as the sounds. The
    /// impulse that excuses a wind charge's fall is only ever set on a server, so a client always takes
    /// the whole distance.
    /// </summary>
    private bool CauseFallDamage(double fallDistance, float damageModifier) {
        if (Player.MayFly) {
            return false;
        }
        int dmg = CalculateFallDamage(fallDistance, damageModifier);
        if (dmg > 0) {
            PlaySound(dmg > 4 ? SoundType.PlayerBigFall : SoundType.PlayerSmallFall, 1.0F, 1.0F);
            PlayBlockFallSound();
            return true;
        }
        return false;
    }

    /// <summary><c>LivingEntity.calculateFallDamage</c>. A player is not in <c>fall_damage_immune</c>.</summary>
    private int CalculateFallDamage(double fallDistance, float damageModifier) {
        double baseDamage = fallDistance + 1.0E-6 - Player.AttributeValue(Attribute.SafeFallDistance);
        return (int)Math.Floor(baseDamage * damageModifier * Player.AttributeValue(Attribute.FallDamageMultiplier));
    }

    /// <summary><c>LivingEntity.playBlockFallSound</c>.</summary>
    private void PlayBlockFallSound() {
        if (Player.Get(EntityDataFields.Entity.Silent)) {
            return;
        }
        int xx = (int)Math.Floor(Player.Position.X);
        int yy = (int)Math.Floor(Player.Position.Y - 0.2F);
        int zz = (int)Math.Floor(Player.Position.Z);
        IBlock state = Level.GetBlock(xx, yy, zz);
        if (!state.Air) {
            BlockSoundGroup soundType = BlockSoundGroups.Of(state);
            PlaySound(soundType.Fall, soundType.Volume * 0.5F, soundType.Pitch * 0.75F);
        }
    }
}
