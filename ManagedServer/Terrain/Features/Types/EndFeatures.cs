using System.Collections.Concurrent;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Data.Generated.BlockTypes;
using Minecraft.Placement;
using Minecraft.Schemas;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Schemas.Vec;
using Mth = Minecraft.Schemas.Mth;

namespace ManagedServer.Terrain.Features.Types;

/// <summary>
/// <c>EndSpikeFeature</c>: the obsidian pillars around the end's origin, each placed by the chunk its
/// centre is in.
/// </summary>
/// <remarks>
/// <b>The end crystal on top is not spawned</b>, as no entity is anywhere in the feature or structure
/// pass, but the yaw it is given is still drawn, and the bedrock and fire it stands on are written where
/// vanilla puts them. The beam target and invulnerability are the crystal's, so they parse and do
/// nothing.
/// </remarks>
public sealed record EndSpikeFeature(IReadOnlyList<EndSpikeFeature.Spike> Spikes) : ConfiguredFeature {
    public sealed record Spike(int CenterX, int CenterZ, int Radius, int Height, bool Guarded);

    private const int NumberOfSpikes = 10;
    private const int SpikeDistance = 42;

    /// <summary><c>SPIKE_CACHE</c>, keyed as vanilla keys it: sixteen bits drawn off the seed.</summary>
    private static readonly ConcurrentDictionary<long, Spike[]> SpikeCache = new();

    /// <summary><c>getSpikesForLevel</c>.</summary>
    public static IReadOnlyList<Spike> SpikesForSeed(long seed) {
        long key = new LegacyRandomSource(seed).NextLong() & 65535L;
        return SpikeCache.GetOrAdd(key, LoadSpikes);
    }

    /// <summary><c>SpikeCacheLoader.load</c>.</summary>
    private static Spike[] LoadSpikes(long key) {
        // Util.toShuffledList over 0 to 9, with a SingleThreadedRandomSource, which draws as a
        // LegacyRandomSource does.
        int[] sizes = new int[NumberOfSpikes];
        for (int i = 0; i < sizes.Length; i++) {
            sizes[i] = i;
        }

        LegacyRandomSource random = new(key);
        for (int i = sizes.Length; i > 1; i--) {
            int swapTo = random.NextInt(i);
            (sizes[i - 1], sizes[swapTo]) = (sizes[swapTo], sizes[i - 1]);
        }

        Spike[] spikes = new Spike[NumberOfSpikes];
        for (int i = 0; i < NumberOfSpikes; i++) {
            // At i 0 and 5 the angle is a multiple of pi, so sin is a rounding error either side of
            // zero and the floor makes it 0 and -1. Java's Math.sin rounds the same way.
            int x = Mth.Floor(SpikeDistance * Math.Cos(2.0 * (-Math.PI + (Math.PI / 10) * i)));
            int z = Mth.Floor(SpikeDistance * Math.Sin(2.0 * (-Math.PI + (Math.PI / 10) * i)));
            int size = sizes[i];
            int radius = 2 + size / 3;
            int height = 76 + size * 3;
            bool guarded = size == 1 || size == 2;
            spikes[i] = new Spike(x, z, radius, height, guarded);
        }

        return spikes;
    }

    public override bool Place(FeaturePlaceContext context) {
        IReadOnlyList<Spike> spikes = Spikes.Count == 0 ? SpikesForSeed(context.Level.Seed) : Spikes;

        foreach (Spike spike in spikes) {
            if (context.Origin.X >> 4 == spike.CenterX >> 4 && context.Origin.Z >> 4 == spike.CenterZ >> 4) {
                PlaceSpike(context.Level, context.Random, spike);
            }
        }

        return true;
    }

    private static void PlaceSpike(IFeatureLevel level, RandomSource random, Spike spike) {
        int radius = spike.Radius;
        uint obsidian = Block.Obsidian.StateId;
        uint air = Block.Air.StateId;

        // BlockPos.betweenClosed, x fastest, then y, then z.
        for (int z = spike.CenterZ - radius; z <= spike.CenterZ + radius; z++) {
            for (int y = level.MinY; y <= spike.Height + 10; y++) {
                for (int x = spike.CenterX - radius; x <= spike.CenterX + radius; x++) {
                    long dx = x - spike.CenterX;
                    long dz = z - spike.CenterZ;
                    if (dx * dx + dz * dz <= radius * radius + 1 && y < spike.Height) {
                        level.SetState(x, y, z, obsidian);
                    } else if (y > 65) {
                        level.SetState(x, y, z, air);
                    }
                }
            }
        }

        if (spike.Guarded) {
            for (int dx = -2; dx <= 2; dx++) {
                for (int dz = -2; dz <= 2; dz++) {
                    for (int dy = 0; dy <= 3; dy++) {
                        bool isXSide = Math.Abs(dx) == 2;
                        bool isZSide = Math.Abs(dz) == 2;
                        bool top = dy == 3;
                        if (!isXSide && !isZSide && !top) {
                            continue;
                        }

                        bool xEdge = dx == -2 || dx == 2 || top;
                        bool zEdge = dz == -2 || dz == 2 || top;
                        IronBarsBlock bars = Block.IronBars with {
                            North = xEdge && dz != -2,
                            South = xEdge && dz != 2,
                            West = zEdge && dx != -2,
                            East = zEdge && dx != 2
                        };
                        level.SetState(spike.CenterX + dx, spike.Height + dy, spike.CenterZ + dz, bars.StateId);
                    }
                }
            }
        }

        // The crystal's snapTo yaw, the one draw the entity makes from this random.
        random.NextFloat();

        // Its block position is the centre one above the spike. BaseFireBlock.getState there reads the
        // bedrock just written below, which is sturdy and not a soul fire base, so the answer is always
        // plain fire with no faces set.
        int crystalY = spike.Height + 1;
        level.SetState(spike.CenterX, crystalY - 1, spike.CenterZ, Block.Bedrock.StateId);
        level.SetState(spike.CenterX, crystalY, spike.CenterZ, Block.Fire.StateId);
    }
}

/// <summary>
/// <c>EndGatewayFeature</c>: a gateway block in a bedrock frame, cleared around.
/// </summary>
/// <remarks>
/// The exit is the gateway block entity's, which nothing in this pass holds, so it parses and is not
/// written anywhere.
/// </remarks>
public sealed record EndGatewayFeature(Vec3<int>? Exit, bool Exact) : ConfiguredFeature {
    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;
        uint air = Block.Air.StateId;
        uint bedrock = Block.Bedrock.StateId;

        for (int z = origin.Z - 1; z <= origin.Z + 1; z++) {
            for (int y = origin.Y - 2; y <= origin.Y + 2; y++) {
                for (int x = origin.X - 1; x <= origin.X + 1; x++) {
                    bool sameX = x == origin.X;
                    bool sameY = y == origin.Y;
                    bool sameZ = z == origin.Z;
                    bool end = Math.Abs(y - origin.Y) == 2;
                    if (sameX && sameY && sameZ) {
                        level.SetState(x, y, z, Block.EndGateway.StateId);
                    } else if (sameY) {
                        level.SetState(x, y, z, air);
                    } else if (end && sameX && sameZ) {
                        level.SetState(x, y, z, bedrock);
                    } else if ((sameX || sameZ) && !end) {
                        level.SetState(x, y, z, bedrock);
                    } else {
                        level.SetState(x, y, z, air);
                    }
                }
            }
        }

        return true;
    }
}

/// <summary>
/// <c>EndIslandFeature</c>: a small inverted cone of end stone, the floating islands of the small end
/// islands biome.
/// </summary>
public sealed record EndIslandFeature : ConfiguredFeature {
    public static readonly EndIslandFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        RandomSource random = context.Random;
        Vec3<int> origin = context.Origin;
        uint endStone = Block.EndStone.StateId;
        float size = random.NextInt(3) + 4.0F;

        for (int y = 0; size > 0.5F; y--) {
            for (int x = Mth.Floor(-size); x <= Mth.Ceil(size); x++) {
                for (int z = Mth.Floor(-size); z <= Mth.Ceil(size); z++) {
                    if (x * x + z * z <= (size + 1.0F) * (size + 1.0F)) {
                        level.SetState(origin.X + x, origin.Y + y, origin.Z + z, endStone);
                    }
                }
            }

            size -= random.NextInt(2) + 0.5F;
        }

        return true;
    }
}

/// <summary>
/// <c>EndPlatformFeature</c>: the obsidian platform a player arrives on, with headroom cleared above.
/// </summary>
/// <remarks>
/// The same method <c>ServerPlayer</c> calls on every arrival, with nothing dropped; a block already
/// what it would be written as is left alone.
/// </remarks>
public sealed record EndPlatformFeature : ConfiguredFeature {
    public static readonly EndPlatformFeature Instance = new();

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;

        for (int dz = -2; dz <= 2; dz++) {
            for (int dx = -2; dx <= 2; dx++) {
                for (int dy = -1; dy < 3; dy++) {
                    int x = origin.X + dx;
                    int y = origin.Y + dy;
                    int z = origin.Z + dz;
                    IBlock block = dy == -1 ? Block.Obsidian : Block.Air;
                    if (level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier != block.Identifier) {
                        level.SetState(x, y, z, block.StateId);
                    }
                }
            }
        }

        return true;
    }
}

/// <summary>
/// <c>ChorusPlantFeature</c>: a whole grown chorus plant, by <c>ChorusFlowerBlock.generatePlant</c>.
/// </summary>
public sealed record ChorusPlantFeature : ConfiguredFeature {
    public static readonly ChorusPlantFeature Instance = new();

    private static readonly Identifier SupportsChorusPlant = "minecraft:supports_chorus_plant";

    private const int MaxHorizontalSpread = 8;

    public override bool Place(FeaturePlaceContext context) {
        IFeatureLevel level = context.Level;
        Vec3<int> origin = context.Origin;
        if (!level.IsEmptyBlock(origin.X, origin.Y, origin.Z)
            || !level.Blocks.IsIn(SupportsChorusPlant, level.GetState(origin.X, origin.Y - 1, origin.Z))) {

            return false;
        }

        SetPlant(level, origin);
        GrowTreeRecursive(level, origin, context.Random, origin, 0);
        return true;
    }

    private static void GrowTreeRecursive(IFeatureLevel level, Vec3<int> current, RandomSource random,
        Vec3<int> startPos, int depth) {

        int height = random.NextInt(4) + 1;
        if (depth == 0) {
            height++;
        }

        for (int i = 0; i < height; i++) {
            Vec3<int> target = current.WithY(current.Y + i + 1);
            if (!AllNeighborsEmpty(level, target, null)) {
                return;
            }

            SetPlant(level, target);
            SetPlant(level, target.WithY(target.Y - 1));
        }

        bool placedStem = false;
        if (depth < 4) {
            int stems = random.NextInt(4);
            if (depth == 0) {
                stems++;
            }

            for (int i = 0; i < stems; i++) {
                BlockFace direction = Directions.Horizontal[random.NextInt(Directions.Horizontal.Length)];
                Vec3<int> target = current.WithY(current.Y + height).GetBlockTowards(direction);
                if (Math.Abs(target.X - startPos.X) < MaxHorizontalSpread
                    && Math.Abs(target.Z - startPos.Z) < MaxHorizontalSpread
                    && level.IsEmptyBlock(target.X, target.Y, target.Z)
                    && level.IsEmptyBlock(target.X, target.Y - 1, target.Z)
                    && AllNeighborsEmpty(level, target, direction.Opposite())) {

                    placedStem = true;
                    SetPlant(level, target);
                    SetPlant(level, target.GetBlockTowards(direction.Opposite()));
                    GrowTreeRecursive(level, target, random, startPos, depth + 1);
                }
            }
        }

        if (!placedStem) {
            level.SetState(current.X, current.Y + height, current.Z, (Block.ChorusFlower with { Age = 5 }).StateId);
        }
    }

    /// <summary>A chorus plant connected as <c>ChorusPlantBlock.getStateWithConnections</c> reads its neighbours.</summary>
    private static void SetPlant(IFeatureLevel level, Vec3<int> pos) {
        bool Connects(int x, int y, int z) {
            Identifier id = level.Registry.Blocks.GetByStateId(level.GetState(x, y, z)).Identifier;
            return id == Block.ChorusPlant.Identifier || id == Block.ChorusFlower.Identifier;
        }

        uint below = level.GetState(pos.X, pos.Y - 1, pos.Z);
        ChorusPlantBlock plant = Block.ChorusPlant with {
            Down = Connects(pos.X, pos.Y - 1, pos.Z) || level.Blocks.IsIn(SupportsChorusPlant, below),
            Up = Connects(pos.X, pos.Y + 1, pos.Z),
            North = Connects(pos.X, pos.Y, pos.Z - 1),
            East = Connects(pos.X + 1, pos.Y, pos.Z),
            South = Connects(pos.X, pos.Y, pos.Z + 1),
            West = Connects(pos.X - 1, pos.Y, pos.Z)
        };
        level.SetState(pos.X, pos.Y, pos.Z, plant.StateId);
    }

    private static bool AllNeighborsEmpty(IFeatureLevel level, Vec3<int> pos, BlockFace? ignore) {
        foreach (BlockFace direction in Directions.Horizontal) {
            if (direction == ignore) {
                continue;
            }

            Vec3<int> neighbour = pos.GetBlockTowards(direction);
            if (!level.IsEmptyBlock(neighbour.X, neighbour.Y, neighbour.Z)) {
                return false;
            }
        }

        return true;
    }
}
