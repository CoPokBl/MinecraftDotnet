using ClientLib.World;
using Minecraft;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.Sounds;
using Minecraft.Data.Timelines;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Sound;
using NBT;
using NBT.Tags;
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

    private Dictionary<IEnvironmentAttribute, TimelineTrack[]>? _tracks;
    private Dictionary<Identifier, int[]>? _tracksTimelineTags;

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

    #region Boolean environment attributes

    /// <summary>One attribute's track in one of the dimension's timelines, its keyframes in order.</summary>
    private sealed record TimelineTrack(Identifier Clock, int? Period, (int Ticks, bool Value)[] Keyframes, EnvironmentAttributeOperation Operation);

    /// <summary>
    /// <c>EnvironmentAttributeSystem.getValue</c> for a boolean attribute: the dimension's value, the biome's at the quart
    /// cell, then each of the dimension's timelines on its clock. The weather layers set neither boolean read here.
    /// </summary>
    private bool BooleanAttribute(ClientLevel level, ClientChunk? chunk, IEnvironmentAttribute attribute, int x, int y, int z) {
        bool value = false;
        if (level.DimensionType.Attributes?[attribute.Identifier.ToString()] is { } dimension) {
            value = ApplyBoolean(EnvironmentAttributeEntry.FromNbt(attribute, dimension, level.Registry), value);
        }
        if (chunk != null) {
            int section = Math.Clamp((y - level.MinY) >> 4, 0, level.SectionCount - 1);
            int biome = chunk.GetBiome(x & 15, section, (y - level.MinY) & 15, z & 15);
            if (biome >= 0 && biome < level.Registry.Biomes.Count && level.Registry.Biomes[biome].Attributes[attribute] is { } fromBiome) {
                value = ApplyBoolean(fromBiome, value);
            }
        }
        foreach (TimelineTrack track in TracksOf(level, attribute)) {
            value = Modify(track.Operation, value, Sample(track, level.Clocks.GetTotalTicks(track.Clock)));
        }
        return value;
    }

    private static bool ApplyBoolean(EnvironmentAttributeEntry entry, bool subject) => entry switch {
        EnvironmentAttributeEntry.Constant { Value: EnvironmentAttributeValue.Boolean constant } => constant.Value,
        EnvironmentAttributeEntry.Modified modified => Modify(modified.Operation, subject, modified.Argument.AsBool()),
        _ => subject
    };

    /// <summary><c>BooleanModifier</c>, and the override every type has.</summary>
    private static bool Modify(EnvironmentAttributeOperation operation, bool subject, bool argument) => operation switch {
        EnvironmentAttributeOperation.And => subject && argument,
        EnvironmentAttributeOperation.Nand => !(subject && argument),
        EnvironmentAttributeOperation.Or => subject || argument,
        EnvironmentAttributeOperation.Nor => !(subject || argument),
        EnvironmentAttributeOperation.Xor => subject ^ argument,
        EnvironmentAttributeOperation.Xnor => subject == argument,
        _ => argument
    };

    /// <summary>
    /// <c>KeyframeTrackSampler.sample</c> with a boolean's step lerp, which only ever lands on a segment's start: the
    /// last keyframe at or before the time, wrapping round to the last of all within a period.
    /// </summary>
    private static bool Sample(TimelineTrack track, long ticks) {
        (int Ticks, bool Value)[] keyframes = track.Keyframes;
        long time = track.Period is { } period ? (ticks % period + period) % period : ticks;
        bool value = track.Period != null ? keyframes[^1].Value : keyframes[0].Value;
        foreach ((int at, bool keyframe) in keyframes) {
            if (at > time) {
                break;
            }
            value = keyframe;
        }
        return value;
    }

    private TimelineTrack[] TracksOf(ClientLevel level, IEnvironmentAttribute attribute) {
        Dictionary<Identifier, int[]>? timelineTags = client.Tags.GetValueOrDefault("minecraft:timeline");
        if (_tracks == null || !ReferenceEquals(timelineTags, _tracksTimelineTags)) {
            _tracks = new Dictionary<IEnvironmentAttribute, TimelineTrack[]>();
            _tracksTimelineTags = timelineTags;
        }
        if (_tracks.TryGetValue(attribute, out TimelineTrack[]? known)) {
            return known;
        }
        List<TimelineTrack> tracks = [];
        foreach (ITimeline timeline in DimensionTimelines(level)) {
            if (timeline.Data["tracks"] is not CompoundTag all || all[attribute.Identifier.ToString()] is not CompoundTag track
                || track["keyframes"] is not { } keyframes || timeline.Data["clock"] is not StringTag clock) {
                continue;
            }
            (int, bool)[] frames = keyframes.AsList().OfType<CompoundTag>().Select(k => (k["ticks"].AsInt(), k["value"].AsBool())).ToArray();
            if (frames.Length == 0) {
                continue;
            }
            int? period = timeline.Data["period_ticks"] is { } periodTag ? periodTag.AsInt() : null;
            EnvironmentAttributeOperation operation = track["modifier"] is StringTag modifier
                ? EnvironmentAttributeOperationExtensions.ParseEnvironmentAttributeOperation(modifier.Value)
                : EnvironmentAttributeOperation.Override;
            tracks.Add(new TimelineTrack(clock.Value, period, frames, operation));
        }
        return _tracks[attribute] = tracks.ToArray();
    }

    /// <summary>The dimension type's <c>timelines</c> holder set: a tag the server sent, one id, or a list of them.</summary>
    private IEnumerable<ITimeline> DimensionTimelines(ClientLevel level) {
        IEnumerable<string> names = level.DimensionType.Timelines switch {
            StringTag single => [single.Value],
            ListTag list => list.AsList().OfType<StringTag>().Select(s => s.Value),
            _ => []
        };
        foreach (string name in names) {
            if (name.StartsWith('#')) {
                if (client.Tags.GetValueOrDefault("minecraft:timeline")?.GetValueOrDefault(name[1..]) is { } ids) {
                    foreach (int id in ids) {
                        if (level.Registry.Timelines.Contains(id)) {
                            yield return level.Registry.Timelines[id];
                        }
                    }
                }
            }
            else if (level.Registry.Timelines.Contains(name)) {
                yield return level.Registry.Timelines[name];
            }
        }
    }

    #endregion
}
