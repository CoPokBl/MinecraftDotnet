using ClientLib.World;
using Minecraft.Data.Blocks;
using Minecraft.Data.Blocks.Properties;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Data.Sounds;
using Minecraft.Schemas.Sound;

namespace GraphicalClient.Audio;

/// <summary>
/// The sound half of <c>LevelEventHandler</c>, one per level as vanilla keeps it. The particle half is
/// <c>ParticleEngine.LevelEvent</c>; the random draws that only feed particles are left out here,
/// which nothing can observe since the level's random is unseeded.
/// </summary>
public sealed class LevelEventHandler(ClientSounds sounds, ClientLevel level, Func<(double X, double Y, double Z)> camera) {
    private static readonly Func<LegacyRandom, float> Even = _ => 1.0F;
    private static readonly Func<LegacyRandom, float> Raised = _ => 1.2F;
    private static readonly Func<LegacyRandom, float> Varied = random => (random.NextFloat() - random.NextFloat()) * 0.2F + 1.0F;
    private static readonly Func<LegacyRandom, float> Slight = random => random.NextFloat() * 0.1F + 0.9F;
    private static readonly Func<LegacyRandom, float> Fizz = random => 2.6F + (random.NextFloat() - random.NextFloat()) * 0.8F;

    /// <summary>
    /// The events whose whole sound half is one <c>playLocalSound</c> at the block's centre, in the
    /// switch's own arithmetic; <c>Delayed</c> is its <c>distanceDelay</c>.
    /// </summary>
    private static readonly Dictionary<int, (ISoundType Sound, SoundCategory Category, float Volume, Func<LegacyRandom, float> Pitch, bool Delayed)> AtBlock = new() {
        [1000] = (SoundType.DispenserDispense, SoundCategory.Blocks, 1.0F, Even, false),
        [1001] = (SoundType.DispenserFail, SoundCategory.Blocks, 1.0F, Raised, false),
        [1002] = (SoundType.DispenserLaunch, SoundCategory.Blocks, 1.0F, Raised, false),
        [1004] = (SoundType.FireworkRocketShoot, SoundCategory.Neutral, 1.0F, Raised, false),
        [1015] = (SoundType.GhastWarn, SoundCategory.Hostile, 10.0F, Varied, false),
        [1016] = (SoundType.GhastShoot, SoundCategory.Hostile, 10.0F, Varied, false),
        [1017] = (SoundType.EnderDragonShoot, SoundCategory.Hostile, 10.0F, Varied, false),
        [1018] = (SoundType.BlazeShoot, SoundCategory.Hostile, 2.0F, Varied, false),
        [1019] = (SoundType.ZombieAttackWoodenDoor, SoundCategory.Hostile, 2.0F, Varied, false),
        [1020] = (SoundType.ZombieAttackIronDoor, SoundCategory.Hostile, 2.0F, Varied, false),
        [1021] = (SoundType.ZombieBreakWoodenDoor, SoundCategory.Hostile, 2.0F, Varied, false),
        [1022] = (SoundType.WitherBreakBlock, SoundCategory.Hostile, 2.0F, Varied, false),
        [1024] = (SoundType.WitherShoot, SoundCategory.Hostile, 2.0F, Varied, false),
        [1025] = (SoundType.BatTakeoff, SoundCategory.Neutral, 0.05F, Varied, false),
        [1026] = (SoundType.ZombieInfect, SoundCategory.Hostile, 2.0F, Varied, false),
        [1027] = (SoundType.ZombieVillagerConverted, SoundCategory.Hostile, 2.0F, Varied, false),
        [1029] = (SoundType.AnvilDestroy, SoundCategory.Blocks, 1.0F, Slight, false),
        [1030] = (SoundType.AnvilUse, SoundCategory.Blocks, 1.0F, Slight, false),
        [1031] = (SoundType.AnvilLand, SoundCategory.Blocks, 0.3F, Slight, false),
        [1033] = (SoundType.ChorusFlowerGrow, SoundCategory.Blocks, 1.0F, Even, false),
        [1034] = (SoundType.ChorusFlowerDeath, SoundCategory.Blocks, 1.0F, Even, false),
        [1035] = (SoundType.BrewingStandBrew, SoundCategory.Blocks, 1.0F, Even, false),
        [1039] = (SoundType.PhantomBite, SoundCategory.Hostile, 0.3F, Slight, false),
        [1040] = (SoundType.ZombieConvertedToDrowned, SoundCategory.Hostile, 2.0F, Varied, false),
        [1041] = (SoundType.HuskConvertedToZombie, SoundCategory.Hostile, 2.0F, Varied, false),
        [1042] = (SoundType.GrindstoneUse, SoundCategory.Blocks, 1.0F, Slight, false),
        [1043] = (SoundType.BookPageTurn, SoundCategory.Blocks, 1.0F, Slight, false),
        [1044] = (SoundType.SmithingTableUse, SoundCategory.Blocks, 1.0F, Slight, false),
        [1045] = (SoundType.PointedDripstoneLand, SoundCategory.Blocks, 2.0F, Slight, false),
        [1046] = (SoundType.PointedDripstoneDripLavaIntoCauldron, SoundCategory.Blocks, 2.0F, Slight, false),
        [1047] = (SoundType.PointedDripstoneDripWaterIntoCauldron, SoundCategory.Blocks, 2.0F, Slight, false),
        [1048] = (SoundType.SkeletonConvertedToStray, SoundCategory.Hostile, 2.0F, Varied, false),
        [1049] = (SoundType.CrafterCraft, SoundCategory.Blocks, 1.0F, Even, false),
        [1050] = (SoundType.CrafterFail, SoundCategory.Blocks, 1.0F, Even, false),
        [1051] = (SoundType.WindChargeThrow, SoundCategory.Blocks, 0.5F, random => 0.4F / (random.NextFloat() * 0.4F + 0.8F), false),
        [1052] = (SoundType.SulfurSpikeLand, SoundCategory.Blocks, 2.0F, Slight, false),
        [1501] = (SoundType.LavaExtinguish, SoundCategory.Blocks, 0.5F, Fizz, false),
        [1502] = (SoundType.RedstoneTorchBurnout, SoundCategory.Blocks, 0.5F, Fizz, false),
        [1503] = (SoundType.EndPortalFrameFill, SoundCategory.Blocks, 1.0F, Even, false),
        [1505] = (SoundType.BoneMealUse, SoundCategory.Blocks, 1.0F, Even, false),
        [2002] = (SoundType.SplashPotionBreak, SoundCategory.Neutral, 1.0F, Slight, false),
        [2007] = (SoundType.SplashPotionBreak, SoundCategory.Neutral, 1.0F, Slight, false),
        [3000] = (SoundType.EndGatewaySpawn, SoundCategory.Blocks, 10.0F, random => (1.0F + (random.NextFloat() - random.NextFloat()) * 0.2F) * 0.7F, false),
        [3001] = (SoundType.EnderDragonGrowl, SoundCategory.Hostile, 64.0F, random => 0.8F + random.NextFloat() * 0.3F, false),
        [3003] = (SoundType.HoneycombWaxOn, SoundCategory.Blocks, 1.0F, Even, false),
        [3012] = (SoundType.TrialSpawnerSpawnMob, SoundCategory.Blocks, 1.0F, Varied, true),
        [3013] = (SoundType.TrialSpawnerDetectPlayer, SoundCategory.Blocks, 1.0F, Varied, true),
        [3014] = (SoundType.TrialSpawnerEjectItem, SoundCategory.Blocks, 1.0F, Varied, true),
        [3016] = (SoundType.VaultDeactivate, SoundCategory.Blocks, 1.0F, Varied, true),
        [3018] = (SoundType.CobwebPlace, SoundCategory.Blocks, 1.0F, Varied, true),
        [3019] = (SoundType.TrialSpawnerDetectPlayer, SoundCategory.Blocks, 1.0F, Varied, true),
        [3021] = (SoundType.TrialSpawnerSpawnItem, SoundCategory.Blocks, 1.0F, Varied, true)
    };

    private readonly LegacyRandom _random = new();
    private readonly Dictionary<(int X, int Y, int Z), SoundInstance> _playingJukeboxSongs = new();

    /// <summary><c>globalLevelEvent</c>: heard from two blocks off in the event's direction, wherever it is.</summary>
    public void GlobalLevelEvent(int type, int x, int y, int z, int data) {
        ISoundType? sound = type switch {
            1023 => SoundType.WitherSpawn,
            1028 => SoundType.EnderDragonDeath,
            1038 => SoundType.EndPortalSpawn,
            _ => null
        };
        if (sound == null) {
            return;
        }
        (double cx, double cy, double cz) = camera();
        double dx = x + 0.5 - cx, dy = y + 0.5 - cy, dz = z + 0.5 - cz;
        // Vec3.normalize.
        double length = Math.Sqrt(dx * dx + dy * dy + dz * dz);
        if (length < 1.0E-5F) {
            dx = dy = dz = 0.0;
        }
        else {
            dx /= length;
            dy /= length;
            dz /= length;
        }
        sounds.Play(sound, SoundCategory.Hostile, type == 1028 ? 5.0F : 1.0F, 1.0F, cx + dx * 2.0, cy + dy * 2.0, cz + dz * 2.0);
    }

    /// <summary><c>levelEvent</c>.</summary>
    public void LevelEvent(int eventType, int x, int y, int z, int data) {
        LegacyRandom random = _random;
        if (AtBlock.TryGetValue(eventType, out var simple)) {
            sounds.PlayAtBlock(x, y, z, simple.Sound, simple.Category, simple.Volume, simple.Pitch(random), simple.Delayed);
            return;
        }
        switch (eventType) {
            case 1009:
                if (data == 0) {
                    sounds.PlayAtBlock(x, y, z, SoundType.FireExtinguish, SoundCategory.Blocks, 0.5F, 2.6F + (random.NextFloat() - random.NextFloat()) * 0.8F);
                }
                else if (data == 1) {
                    sounds.PlayAtBlock(x, y, z, SoundType.GenericExtinguishFire, SoundCategory.Blocks, 0.7F, 1.6F + (random.NextFloat() - random.NextFloat()) * 0.4F);
                }
                break;
            case 1010:
                if (data >= 0 && level.Registry.JukeboxSongs.Contains(data)) {
                    PlayJukeboxSong(level.Registry.JukeboxSongs.Get(data).SoundEvent.Type, x, y, z);
                }
                break;
            case 1011:
                StopJukeboxSong(x, y, z);
                break;
            case 1032:
                sounds.Engine.Play(SoundInstance.ForLocalAmbience(SoundType.PortalTravel.Identifier, random.NextFloat() * 0.4F + 0.8F, 0.25F));
                break;
            case 1500:
                // ComposterBlock.handleFill.
                sounds.PlayAtBlock(x, y, z, data > 0 ? SoundType.ComposterFillSuccess : SoundType.ComposterFill, SoundCategory.Blocks, 1.0F, 1.0F);
                break;
            case 2001:
                if (StateById(data) is { Air: false } state) {
                    BlockSoundGroup soundType = BlockSoundGroups.Of(state);
                    sounds.PlayAtBlock(x, y, z, soundType.Break, SoundCategory.Blocks, (soundType.Volume + 1.0F) / 2.0F, soundType.Pitch * 0.8F);
                }
                break;
            case 2006:
                if (data == 1) {
                    sounds.PlayAtBlock(x, y, z, SoundType.DragonFireballExplode, SoundCategory.Hostile, 1.0F, random.NextFloat() * 0.1F + 0.9F);
                }
                break;
            case 3006: {
                int count = data >> 6;
                if (count > 0) {
                    if (random.NextFloat() < 0.3F + count * 0.1F) {
                        float volume = 0.15F + 0.02F * count * count * random.NextFloat();
                        float pitch = 0.4F + 0.3F * count * random.NextFloat();
                        sounds.PlayAtBlock(x, y, z, SoundType.SculkCharge, SoundCategory.Blocks, volume, pitch);
                    }
                }
                else {
                    sounds.PlayAtBlock(x, y, z, SoundType.SculkCharge, SoundCategory.Blocks, 1.0F, 1.0F);
                }
                break;
            }
            case 3007:
                // SculkShriekerBlock.TOP_Y is the top of its collision shape, half a block up.
                if (level.GetBlock(x, y, z) is not IWaterlogged { Waterlogged: true }) {
                    sounds.PlayAtBlock(x, y, z, SoundType.SculkShriekerShriek, SoundCategory.Blocks, 2.0F, 0.6F + random.NextFloat() * 0.4F);
                }
                break;
            case 3008:
                // BrushableBlock.getBrushCompletedSound. Both suspicious blocks register their brushing sound as
                // the completed sound too, so BRUSH_SAND_COMPLETED is never played.
                if (ItemUseSounds.BrushSoundOf(StateById(data)) is { } completed) {
                    sounds.PlayAtBlock(x, y, z, completed, SoundCategory.Players, 1.0F, 1.0F);
                }
                break;
            case 3015:
                // getBlockEntity(pos) instanceof VaultBlockEntity: a vault always has its block entity.
                if (level.GetBlock(x, y, z) is VaultBlock) {
                    sounds.PlayAtBlock(x, y, z, SoundType.VaultActivate, SoundCategory.Blocks, 1.0F, Varied(random), true);
                }
                break;
            case 3020:
                sounds.PlayAtBlock(x, y, z, SoundType.TrialSpawnerOminousActivate, SoundCategory.Blocks, data == 0 ? 0.3F : 1.0F, Varied(random), true);
                break;
        }
    }

    /// <summary><c>Block.stateById</c>: an id the registry does not know is air.</summary>
    private IBlock StateById(int id) => (uint)id < level.Registry.Blocks.StatesCount ? level.Registry.Blocks.GetByStateId((uint)id) : Block.Air;

    /// <summary>
    /// <c>playJukeboxSong</c>, <c>SimpleSoundInstance.forJukeboxSong</c>. The now playing line and the
    /// nearby entities told to dance are not sound and are left out.
    /// </summary>
    private void PlayJukeboxSong(ISoundType sound, int x, int y, int z) {
        StopJukeboxSong(x, y, z);
        SoundInstance instance = SoundInstance.At(sound.Identifier, SoundCategory.Records, 4.0F, 1.0F, new LegacyRandom(), x + 0.5, y + 0.5, z + 0.5);
        _playingJukeboxSongs[(x, y, z)] = instance;
        sounds.Engine.Play(instance);
    }

    private void StopJukeboxSong(int x, int y, int z) {
        if (_playingJukeboxSongs.Remove((x, y, z), out SoundInstance? removed)) {
            sounds.Engine.Stop(removed);
        }
    }
}
