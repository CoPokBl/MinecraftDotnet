using Minecraft.Data.Biomes;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// The half of a unit that is the same whatever it covers: turning an <see cref="IBlock"/> into a
/// state id, a <see cref="Vec3{T}"/> into three ints, and a biome into a registry index.
/// </summary>
/// <remarks>
/// Everything here funnels into a handful of abstract state level primitives, so a subclass writes
/// those and gets the whole surface. Two subclasses only, <see cref="SectionUnit"/> and
/// <see cref="AreaUnit"/>, which keeps the call sites in a generator's inner loop cheap to dispatch.
/// </remarks>
internal abstract class GenerationUnitBase : IGenerationUnit, IUnitModifier {
    protected GenerationUnitBase(Vec3<int> start, Vec3<int> end, int minY, int maxY,
        MinecraftRegistry registry) {

        AbsoluteStart = start;
        AbsoluteEnd = end;
        MinY = minY;
        MaxY = maxY;
        Registry = registry;
    }

    public IUnitModifier Modifier => this;
    public Vec3<int> AbsoluteStart { get; }
    public Vec3<int> AbsoluteEnd { get; }
    public Vec3<int> Size => AbsoluteEnd - AbsoluteStart;
    public int MinY { get; }
    public int MaxY { get; }
    public MinecraftRegistry Registry { get; }

    public abstract IReadOnlyList<IGenerationUnit> Subdivide();

    public abstract IGenerationUnit Fork(Vec3<int> start, Vec3<int> end);
    public abstract void Fork(Action<IBlockSetter> build);
    public abstract bool ReadForkedWrites(ForkedBlock into);
    public abstract ChunkData? ReadNeighbour(int chunkX, int chunkZ, ForkedBlock forked);

    // --- primitives a subclass provides ------------------------------------

    public abstract void SetBlockState(int x, int y, int z, uint stateId);
    public abstract void SetRelativeState(int x, int y, int z, uint stateId);
    public abstract void SetAllStates(BlockStateSupplier supplier);
    public abstract void SetAllRelativeStates(BlockStateSupplier supplier);
    public abstract void SetColumnStates(int x, int z, int startY, ReadOnlySpan<uint> states);
    public abstract void FillState(uint stateId);
    public abstract void FillHeightState(int minY, int maxY, uint stateId);
    public abstract void SetBiome(int x, int y, int z, uint biomeId);
    public abstract void FillBiome(uint biomeId);
    public abstract void SetBlockEntity(int x, int y, int z, IBlockEntityType type, INbtTag data);

    // --- the rest, in terms of those ---------------------------------------

    public void SetBlock(int x, int y, int z, IBlock block) => SetBlockState(x, y, z, block.StateId);

    public void SetBlock(Vec3<int> pos, IBlock block) => SetBlockState(pos.X, pos.Y, pos.Z, block.StateId);

    public void SetBlockState(Vec3<int> pos, uint stateId) => SetBlockState(pos.X, pos.Y, pos.Z, stateId);

    public void SetRelative(int x, int y, int z, IBlock block) => SetRelativeState(x, y, z, block.StateId);

    public void SetAll(BlockSupplier supplier) {
        SetAllStates((x, y, z) => supplier(x, y, z).StateId);
    }

    public void SetAllRelative(BlockSupplier supplier) {
        SetAllRelativeStates((x, y, z) => supplier(x, y, z).StateId);
    }

    public void Fill(IBlock block) => FillState(block.StateId);

    public void Fill(Vec3<int> start, Vec3<int> end, IBlock block) {
        FillState(start, end, block.StateId);
    }

    /// <summary>
    /// Clipped to the unit, so a caller can name a box larger than the unit and have the overlap
    /// written. That is what makes a feature that straddles a boundary expressible without the caller
    /// working out which part is here.
    /// </summary>
    public void FillState(Vec3<int> start, Vec3<int> end, uint stateId) {
        int x0 = Math.Max(start.X, AbsoluteStart.X), x1 = Math.Min(end.X, AbsoluteEnd.X);
        int y0 = Math.Max(start.Y, AbsoluteStart.Y), y1 = Math.Min(end.Y, AbsoluteEnd.Y);
        int z0 = Math.Max(start.Z, AbsoluteStart.Z), z1 = Math.Min(end.Z, AbsoluteEnd.Z);

        // A box covering the unit's whole footprint is a height fill, which has the section fast path.
        if (x0 == AbsoluteStart.X && x1 == AbsoluteEnd.X && z0 == AbsoluteStart.Z && z1 == AbsoluteEnd.Z) {
            FillHeightState(y0, y1, stateId);
            return;
        }

        for (int y = y0; y < y1; y++) {
            for (int z = z0; z < z1; z++) {
                for (int x = x0; x < x1; x++) {
                    SetBlockState(x, y, z, stateId);
                }
            }
        }
    }

    public void FillHeight(int minY, int maxY, IBlock block) => FillHeightState(minY, maxY, block.StateId);

    public void SetBiome(int x, int y, int z, IBiome biome) {
        SetBiome(x, y, z, ChunkData.BiomeId(biome, Registry));
    }

    public void SetBiome(Vec3<int> pos, IBiome biome) => SetBiome(pos.X, pos.Y, pos.Z, biome);

    public void FillBiome(IBiome biome) => FillBiome(ChunkData.BiomeId(biome, Registry));
}
