using Minecraft.Data.Biomes;
using Minecraft.Data.BlockEntityTypes;
using Minecraft.Data.Blocks;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// Somewhere to put blocks, and nothing else. What a fork hands out, since a fork is a sparse overlay
/// and has no opinion about biomes or about what it does not cover.
/// </summary>
public interface IBlockSetter {
    /// <summary>Absolute game y, negative included. Never protocol y.</summary>
    void SetBlock(int x, int y, int z, IBlock block);

    void SetBlock(Vec3<int> pos, IBlock block);

    /// <summary>
    /// By raw state id. Named apart from <see cref="SetBlock(int,int,int,IBlock)"/> deliberately: a
    /// bare number in a generator is a typo waiting to happen and an upstream renumbering waiting to
    /// happen twice, so writing one has to be spelled out rather than being the shortest way in.
    /// </summary>
    void SetBlockState(int x, int y, int z, uint stateId);

    void SetBlockState(Vec3<int> pos, uint stateId);
}

/// <summary>A block per position, in whichever coordinates the method taking it is documented in.</summary>
public delegate IBlock BlockSupplier(int x, int y, int z);

/// <summary>The same by state id, for a generator that has already resolved what it is placing.</summary>
public delegate uint BlockStateSupplier(int x, int y, int z);

/// <summary>
/// How an <see cref="IGenerationUnit"/> is written to.
/// </summary>
/// <remarks>
/// Two coordinate systems, and which one a method uses is in its name. The plain calls take
/// <b>absolute game</b> coordinates, the way the rest of the framework does. The <c>Relative</c> ones
/// are zero based against the unit's own <see cref="IGenerationUnit.AbsoluteStart"/> and skip the
/// bounds arithmetic entirely, which is what a generator walking its own unit wants.
/// <p/>
/// Reach for the bulk calls before the per position ones. <see cref="FillState(uint)"/> and
/// <see cref="FillHeightState"/> collapse whole sections to a single value in constant time, and
/// <see cref="SetColumnStates"/> writes a column with one bounds check rather than one per block. A
/// world with a flat stone floor costs a couple of dozen palette writes through those and about a
/// hundred thousand block writes through <see cref="IBlockSetter.SetBlock(int,int,int,IBlock)"/>.
/// </remarks>
public interface IUnitModifier : IBlockSetter {
    // --- relative to the unit's own start ----------------------------------

    void SetRelative(int x, int y, int z, IBlock block);

    void SetRelativeState(int x, int y, int z, uint stateId);

    // --- bulk --------------------------------------------------------------

    /// <summary>Every position in the unit, the supplier taking absolute coordinates.</summary>
    void SetAll(BlockSupplier supplier);

    void SetAllStates(BlockStateSupplier supplier);

    /// <summary>Every position in the unit, the supplier taking unit relative ones.</summary>
    void SetAllRelative(BlockSupplier supplier);

    void SetAllRelativeStates(BlockStateSupplier supplier);

    /// <summary>
    /// A whole column at once, bottom to top from <paramref name="startY"/>, in absolute coordinates.
    /// </summary>
    /// <remarks>
    /// The shape a noise generator produces, and the cheapest way in for one: vanilla's
    /// <c>fillFromNoise</c> works down a column, and giving that a column shaped entry point is the
    /// difference between it costing one bounds check per column and one per block.
    /// </remarks>
    void SetColumnStates(int x, int z, int startY, ReadOnlySpan<uint> states);

    // --- fills -------------------------------------------------------------

    void Fill(IBlock block);

    void FillState(uint stateId);

    /// <summary><paramref name="start"/> inclusive, <paramref name="end"/> exclusive.</summary>
    void Fill(Vec3<int> start, Vec3<int> end, IBlock block);

    void FillState(Vec3<int> start, Vec3<int> end, uint stateId);

    /// <summary>
    /// The unit's whole horizontal extent between two heights, <paramref name="minY"/> inclusive and
    /// <paramref name="maxY"/> <b>exclusive</b>.
    /// </summary>
    /// <remarks>
    /// Half open like every other range here, because one that is not is the kind of off by one that
    /// reads as correct forever.
    /// <p/>
    /// Sections wholly inside the range are filled in constant time and only the partial ones at each
    /// end are walked, so a stone floor up to y 60 costs two section walks whatever the world height.
    /// </remarks>
    void FillHeight(int minY, int maxY, IBlock block);

    void FillHeightState(int minY, int maxY, uint stateId);

    // --- biomes ------------------------------------------------------------

    /// <summary>
    /// Biomes are stored one per 4x4x4 cell. These take block coordinates and round down to the cell
    /// holding them, so writing all 64 positions of a cell is the same as writing one.
    /// </summary>
    void SetBiome(int x, int y, int z, IBiome biome);

    void SetBiome(Vec3<int> pos, IBiome biome);

    void FillBiome(IBiome biome);

    // --- block entities ----------------------------------------------------

    /// <summary>
    /// Attaches block entity data at a position, which the block written there is expected to want.
    /// </summary>
    /// <remarks>
    /// A separate call rather than something carried on <see cref="IBlock"/>, which holds no NBT. So
    /// the block setters never have to ask whether a block wants the slow path, and ordinary terrain
    /// never touches the map.
    /// </remarks>
    void SetBlockEntity(int x, int y, int z, IBlockEntityType type, INbtTag data);
}
