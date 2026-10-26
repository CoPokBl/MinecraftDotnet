using ClientLib.World;
using Minecraft;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Sounds;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Sound;
using Block = Minecraft.Data.Generated.Block;
using SoundType = Minecraft.Data.Generated.SoundType;

namespace ClientLib.Particles;

/// <summary>A sound an <c>animateTick</c> plays for this client alone; nothing goes on the wire.</summary>
/// <param name="AtPlayer"><c>playPlayerSound</c>: the sound follows the local player rather than staying at the position.</param>
public readonly record struct AnimateTickSound(ISoundType Sound, SoundCategory Category, float Volume, float Pitch, double X, double Y, double Z,
    bool AtPlayer = false);

public sealed partial class AnimateTicks {
    private static readonly Identifier PaleOakLogs = "minecraft:pale_oak_logs";
    private static readonly Identifier PoplarLeafAmbienceBlocks = "minecraft:required_for_poplar_leaf_ambience";
    private static readonly Identifier Terracotta = "minecraft:terracotta";
    private static readonly Identifier DriedGhastSoundBlocks = "minecraft:triggers_ambient_dried_ghast_block_sounds";
    private static readonly Identifier DesertVegetationSoundBlocks = "minecraft:triggers_ambient_desert_dry_vegetation_block_sounds";
    private static readonly Identifier DesertSandSoundBlocks = "minecraft:triggers_ambient_desert_sand_block_sounds";

    /// <summary>Every <c>playLocalSound</c> and <c>playPlayerSound</c> the block and fluid animate ticks make.</summary>
    public event Action<AnimateTickSound>? SoundPlayed;


    /// <summary><c>Level.playLocalSound(x, y, z, ...)</c> with no distance delay, which every animate tick passes.</summary>
    private void Sound(ISoundType sound, SoundCategory category, double x, double y, double z, float volume, float pitch) =>
        SoundPlayed?.Invoke(new AnimateTickSound(sound, category, volume, pitch, x, y, z));

    /// <summary>
    /// <c>AmbientLeavesBlockSoundPlayer.playAmbientLeavesSounds</c> as poplar leaves register it: one in 300, and
    /// only once the counts reach exactly one satisfying block and three of the same leaves part way round.
    /// </summary>
    private void AmbientPoplarLeaves(ClientLevel level, ushort state, int x, int y, int z) {
        if (_random.NextInt(300) != 0) {
            return;
        }
        Identifier block = level.Registry.Blocks.GetByStateId(state).Identifier;
        int nearbyLogs = 0, nearbyLeaves = 0;
        foreach (int horizontal in Horizontal) {
            (int dx, _, int dz) = Steps[horizontal];
            ushort neighbour = level.GetState(x + dx, y, z + dz);
            if (InTag(level, PoplarLeafAmbienceBlocks, neighbour)) {
                nearbyLogs++;
            }
            if (level.Registry.Blocks.GetByStateId(neighbour).Identifier == block) {
                nearbyLeaves++;
            }
            if (nearbyLogs == 1 && nearbyLeaves == 3) {
                Sound(SoundType.PoplarLeavesAmbient, SoundCategory.Ambient, x, y, z, 1.0F, 1.0F);
                return;
            }
        }
    }

    #region AmbientDesertBlockSoundsPlayer

    /// <summary><c>playAmbientSandSounds</c>.</summary>
    private void AmbientSand(ClientLevel level, int x, int y, int z) {
        if (BlockAt(level, x, y + 1, z).Identifier != Block.Air.Identifier) {
            return;
        }
        if (_random.NextInt(2100) == 0 && ShouldPlayAmbientSandSound(level, x, y, z)) {
            Sound(SoundType.SandIdle, SoundCategory.Ambient, x, y, z, 1.0F, 1.0F);
        }
    }

    /// <summary><c>playAmbientDryGrassSounds</c>, heard where the player is.</summary>
    private void AmbientDryGrass(ClientLevel level, int x, int y, int z) {
        if (_random.NextInt(200) == 0 && ShouldPlayDesertDryVegetationBlockSounds(level, x, y - 1, z) && client.Player is { } player) {
            SoundPlayed?.Invoke(new AnimateTickSound(SoundType.DryGrassAmbient, SoundCategory.Ambient, 1.0F, 1.0F,
                player.Position.X, player.Position.Y, player.Position.Z, true));
        }
    }

    /// <summary><c>playAmbientDeadBushSounds</c>: a third as often on red sand or terracotta.</summary>
    private void AmbientDeadBush(ClientLevel level, int x, int y, int z) {
        if (_random.NextInt(130) != 0) {
            return;
        }
        ushort below = StateAt(level, x, y - 1, z);
        if ((level.Registry.Blocks.GetByStateId(below).Identifier == Block.RedSand.Identifier || InTag(level, Terracotta, below)) && _random.NextInt(3) != 0) {
            return;
        }
        if (ShouldPlayDesertDryVegetationBlockSounds(level, x, y - 1, z)) {
            Sound(SoundType.DeadbushIdle, SoundCategory.Ambient, x, y, z, 1.0F, 1.0F);
        }
    }

    private bool ShouldPlayDesertDryVegetationBlockSounds(ClientLevel level, int x, int belowY, int z) =>
        InTag(level, DesertVegetationSoundBlocks, StateAt(level, x, belowY, z)) && InTag(level, DesertVegetationSoundBlocks, StateAt(level, x, belowY - 1, z));

    /// <summary>
    /// <c>shouldPlayAmbientSandSound</c>: sand eight blocks off in each horizontal direction. The post increment
    /// means all four sides have to find it, and the walk gives up once that can no longer happen.
    /// </summary>
    private bool ShouldPlayAmbientSandSound(ClientLevel level, int x, int y, int z) {
        int matchingBlocksFound = 0;
        int sidesChecked = 0;
        foreach (int horizontal in Horizontal) {
            (int sx, _, int sz) = Steps[horizontal];
            if (ColumnContainsTriggeringBlock(level, x + sx * 8, y, z + sz * 8) && matchingBlocksFound++ >= 3) {
                return true;
            }
            sidesChecked++;
            if (4 - sidesChecked + matchingBlocksFound < 3) {
                return false;
            }
        }
        return false;
    }

    /// <summary><c>columnContainsTriggeringBlock</c>: the surface, or within ten blocks of the height asked about when the surface is far from it.</summary>
    private bool ColumnContainsTriggeringBlock(ClientLevel level, int x, int y, int z) {
        int surfaceY = level.GetHeight(HeightmapType.WorldSurface, x, z) - 1;
        if (Math.Abs(surfaceY - y) > 5) {
            int cy = y + 6;
            ushort above = StateAt(level, x, cy, z);
            cy--;
            for (int i = 0; i < 10; i++) {
                ushort current = StateAt(level, x, cy, z);
                if (FactsOf(above).Air && InTag(level, DesertSandSoundBlocks, current)) {
                    return true;
                }
                above = current;
                cy--;
            }
            return false;
        }
        return FactsOf(StateAt(level, x, surfaceY + 1, z)).Air && InTag(level, DesertSandSoundBlocks, StateAt(level, x, surfaceY, z));
    }

    #endregion

    /// <summary><c>CreakingHeartBlock.isSurroundedByLogs</c>.</summary>
    private bool IsSurroundedByLogs(ClientLevel level, int x, int y, int z) {
        foreach ((int sx, int sy, int sz) in Steps) {
            if (!InTag(level, PaleOakLogs, StateAt(level, x + sx, y + sy, z + sz))) {
                return false;
            }
        }
        return true;
    }

    /// <summary>A boolean attribute at the block, which every caller here reads it at.</summary>
    private static bool BooleanAttribute(ClientLevel level, EnvironmentAttribute<bool> attribute, int x, int y, int z) =>
        level.Environment.Attributes.GetValue(attribute, x, y, z);
}
