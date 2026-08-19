using ManagedServer.Terrain.Density;
using ManagedServer.Terrain.Features.Values;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;

namespace ManagedServer.Terrain.Carvers;

/// <summary>
/// What a carver reads and writes: one chunk, the aquifer under it, and the surface rules over it.
/// </summary>
/// <remarks>
/// Vanilla's <c>CarvingContext</c> is only the height range and the <c>topMaterial</c> hook, and threads
/// the chunk, the aquifer, the mask and the biome getter through every method beside it. All five are
/// fixed for the whole of one chunk's carving, so they sit here instead and the carve methods keep
/// vanilla's remaining arguments.
/// <p/>
/// A carver only ever <b>reads and writes inside the chunk being generated</b>: the ellipsoid clamps its
/// x and z to the chunk and the block accessors take chunk local coordinates. A carver whose tunnel
/// starts eight chunks away reaches this one by being replayed here from its own deterministic seed, not
/// by writing across a border, which is what makes the pass need no forks.
/// </remarks>
public sealed class CarvingContext(MinecraftRegistry registry, ChunkColumn chunk, CarvingMask mask,
    IAquifer aquifer, int chunkX, int chunkZ, int minGenY, int genDepth,
    CarvingContext.TopMaterialGetter topMaterial) {

    /// <summary>
    /// <c>SurfaceSystem.topMaterial</c>: what the surface rules would put at a position, asked for the
    /// dirt exposed under a carved out grass block. Null where no rule matches.
    /// </summary>
    public delegate uint? TopMaterialGetter(int blockX, int blockY, int blockZ, bool underFluid);

    public MinecraftRegistry Registry => registry;
    public ChunkColumn Chunk => chunk;
    public CarvingMask Mask => mask;
    public IAquifer Aquifer => aquifer;

    public int ChunkX => chunkX;
    public int ChunkZ => chunkZ;

    public int MinGenY => minGenY;
    public int GenDepth => genDepth;

    public GenerationHeightContext Heights => new(minGenY, genDepth);

    public uint? TopMaterial(int blockX, int blockY, int blockZ, bool underFluid) {
        return topMaterial(blockX, blockY, blockZ, underFluid);
    }

    public uint GetBlock(int blockX, int blockY, int blockZ) {
        return chunk.Read(blockX & 15, blockY, blockZ & 15);
    }

    public void SetBlock(int blockX, int blockY, int blockZ, uint stateId) {
        chunk.Write(blockX & 15, blockY, blockZ & 15, stateId);
    }
}

/// <summary>
/// <c>WorldCarver</c>: the shared ellipsoid cutter every carver shape is built out of.
/// </summary>
/// <remarks>
/// A carver is a walk: a position and a pair of rotations step forward a block at a time, and at each
/// step an ellipsoid is cut out of whatever of the chunk it overlaps. What distinguishes a cave from a
/// ravine is how the radii and the rotations change along that walk, not how a block is removed.
/// <p/>
/// <b>The whole pass is deliberately quadratic in a chunk's neighbourhood.</b> Every chunk within eight
/// replays its own carvers over this one, because a tunnel that started there may reach here.
/// <see cref="CanReach"/> and the distance test at the top of <see cref="CarveEllipsoid"/> are what
/// keep that affordable: a walk heading away from this chunk is abandoned rather than followed to its
/// end.
/// </remarks>
public abstract class WorldCarver<TConfig> where TConfig : CarverConfiguration {
    /// <summary>How many chunks out a carver may reach, in chunks. Every carver's is four.</summary>
    public virtual int Range => 4;

    /// <summary>Whether a carver starts in a chunk at all, which is the probability roll.</summary>
    public abstract bool IsStartChunk(TConfig configuration, RandomSource random);

    /// <summary>Runs one carver of one source chunk over the chunk being generated.</summary>
    public abstract void Carve(CarvingContext context, TConfig configuration, RandomSource random,
        int sourceChunkX, int sourceChunkZ);

    /// <summary>
    /// Whether a position inside the ellipsoid's bounding box is inside the shape itself. The caves and
    /// the ravines answer this differently, which is most of what makes them look different.
    /// </summary>
    protected delegate bool CarveSkipChecker(CarvingContext context, double xd, double yd, double zd,
        int blockY);

    /// <summary>
    /// Cuts one ellipsoid out of the chunk.
    /// </summary>
    /// <remarks>
    /// The seven blocks left at the top are vanilla's <c>protectedBlocksOnTop</c>: a carver may not
    /// break the surface from below, so a cave never opens into the sky except where the terrain
    /// happens to have brought it there.
    /// <p/>
    /// The y loop is <b>top down and excludes its own lower bound</b>, both of which matter.
    /// Downwards is what lets one grass block seen high in a column decide that everything under it
    /// gets the surface fix-up, and the exclusive bound is off by one against the x and z loops on
    /// purpose.
    /// </remarks>
    protected bool CarveEllipsoid(CarvingContext context, TConfig configuration, double x, double y,
        double z, double horizontalRadius, double verticalRadius, CarveSkipChecker skipChecker) {

        double centerX = context.ChunkX * 16 + 8;
        double centerZ = context.ChunkZ * 16 + 8;
        double maxDelta = 16.0 + horizontalRadius * 2.0;

        if (Math.Abs(x - centerX) > maxDelta || Math.Abs(z - centerZ) > maxDelta) {
            return false;
        }

        int chunkMinX = context.ChunkX * 16;
        int chunkMinZ = context.ChunkZ * 16;

        int minXIndex = Math.Max(Mth.Floor(x - horizontalRadius) - chunkMinX - 1, 0);
        int maxXIndex = Math.Min(Mth.Floor(x + horizontalRadius) - chunkMinX, 15);
        int minY = Math.Max(Mth.Floor(y - verticalRadius) - 1, context.MinGenY + 1);
        int maxY = Math.Min(Mth.Floor(y + verticalRadius) + 1, context.MinGenY + context.GenDepth - 1 - 7);
        int minZIndex = Math.Max(Mth.Floor(z - horizontalRadius) - chunkMinZ - 1, 0);
        int maxZIndex = Math.Min(Mth.Floor(z + horizontalRadius) - chunkMinZ, 15);

        bool carved = false;
        bool debug = configuration.DebugSettings.DebugMode;

        for (int xIndex = minXIndex; xIndex <= maxXIndex; xIndex++) {
            int worldX = chunkMinX + xIndex;
            double xd = (worldX + 0.5 - x) / horizontalRadius;

            for (int zIndex = minZIndex; zIndex <= maxZIndex; zIndex++) {
                int worldZ = chunkMinZ + zIndex;
                double zd = (worldZ + 0.5 - z) / horizontalRadius;

                if (xd * xd + zd * zd >= 1.0) {
                    continue;
                }

                // Per column rather than per position, and set by the first grass block the walk down
                // meets, so the fix-up reaches the dirt under a cave mouth however deep it is.
                bool hasGrass = false;

                for (int worldY = maxY; worldY > minY; worldY--) {
                    double yd = (worldY - 0.5 - y) / verticalRadius;

                    if (skipChecker(context, xd, yd, zd, worldY)) {
                        continue;
                    }

                    if (context.Mask.Get(xIndex, worldY, zIndex) && !debug) {
                        continue;
                    }

                    context.Mask.Set(xIndex, worldY, zIndex);
                    carved |= CarveBlock(context, configuration, worldX, worldY, worldZ, ref hasGrass);
                }
            }
        }

        return carved;
    }

    /// <summary>
    /// Decides one block: whether it may be replaced, what replaces it, and whether the block below
    /// needs the surface rules run over it again.
    /// </summary>
    protected virtual bool CarveBlock(CarvingContext context, TConfig configuration, int blockX,
        int blockY, int blockZ, ref bool hasGrass) {

        uint existing = context.GetBlock(blockX, blockY, blockZ);
        Identifier block = context.Registry.Blocks.GetByStateId(existing).Identifier;

        if (block.Equals(Block.GrassBlock.Identifier) || block.Equals(Block.Mycelium.Identifier)) {
            hasGrass = true;
        }

        bool debug = configuration.DebugSettings.DebugMode;

        if (!configuration.Replaceable.Contains(block) && !debug) {
            return false;
        }

        if (GetCarveState(context, configuration, blockX, blockY, blockZ) is not { } state) {
            return false;
        }

        context.SetBlock(blockX, blockY, blockZ, state);

        // Vanilla marks a carved position holding a fluid for post processing, which is the fluid
        // simulation being asked to flow from it. There is no block tick scheduler in the generator, so
        // an aquifer a carver opens into stays exactly as wide as the carver left it. Same gap the
        // springs and the lakes document.

        if (!hasGrass) {
            return true;
        }

        IBlock below = context.Registry.Blocks.GetByStateId(context.GetBlock(blockX, blockY - 1, blockZ));

        if (!below.Identifier.Equals(Block.Dirt.Identifier)) {
            return true;
        }

        bool underFluid = context.Registry.Blocks.GetByStateId(state).Fluid != null;

        if (context.TopMaterial(blockX, blockY - 1, blockZ, underFluid) is { } topMaterial) {
            context.SetBlock(blockX, blockY - 1, blockZ, topMaterial);
        }

        return true;
    }

    /// <summary>
    /// What a carved position becomes: lava below the configured level, and otherwise whatever the
    /// aquifer says is there at zero density.
    /// </summary>
    /// <remarks>
    /// Null from the aquifer means the position stays as it is, which is how an aquifer walls a cave
    /// off rather than flooding it.
    /// </remarks>
    private static uint? GetCarveState(CarvingContext context, TConfig configuration, int blockX,
        int blockY, int blockZ) {

        if (blockY <= configuration.LavaLevel.ResolveY(context.Heights)) {
            return Block.Lava.StateId;
        }

        uint? state = context.Aquifer.ComputeSubstance(new SinglePointContext(blockX, blockY, blockZ), 0.0);

        if (state is null) {
            return configuration.DebugSettings.DebugMode ? configuration.DebugSettings.BarrierState : null;
        }

        return configuration.DebugSettings.DebugMode
            ? DebugStateOf(context, configuration, state.Value)
            : state;
    }

    /// <summary>
    /// The debug rendering: the three substances a carver can leave become three marker blocks, and
    /// anything else is left alone.
    /// </summary>
    private static uint DebugStateOf(CarvingContext context, TConfig configuration, uint state) {
        Identifier block = context.Registry.Blocks.GetByStateId(state).Identifier;

        if (block.Equals(Block.Air.Identifier)) {
            return configuration.DebugSettings.AirState;
        }

        if (block.Equals(Block.Water.Identifier)) {
            uint water = configuration.DebugSettings.WaterState;
            IBlock waterBlock = context.Registry.Blocks.GetByStateId(water);

            return waterBlock is Minecraft.Data.Blocks.Properties.IWaterlogged waterlogged
                ? waterlogged.WithWaterlogged(true).StateId
                : water;
        }

        return block.Equals(Block.Lava.Identifier) ? configuration.DebugSettings.LavaState : state;
    }

    /// <summary>
    /// Whether a walk still has any chance of touching the chunk, given how many steps it has left.
    /// </summary>
    /// <remarks>
    /// The remaining steps are subtracted as a <b>distance</b>, so this is "could the walk reach here
    /// if it went straight at us from now on". It is what turns 289 replayed chunks of carvers into a
    /// handful that do any work.
    /// </remarks>
    protected static bool CanReach(int chunkX, int chunkZ, double x, double z, int currentStep,
        int totalSteps, float thickness) {

        double xd = x - (chunkX * 16 + 8);
        double zd = z - (chunkZ * 16 + 8);
        double remaining = totalSteps - currentStep;
        double reach = thickness + 2.0f + 16.0f;

        return xd * xd + zd * zd - remaining * remaining <= reach * reach;
    }
}
