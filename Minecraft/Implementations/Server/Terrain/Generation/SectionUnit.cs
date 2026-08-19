using Minecraft.Data.BlockEntityTypes;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// One 16x16x16 section of a unit, and the only place a block actually gets written.
/// </summary>
/// <remarks>
/// The absolute setters mask their coordinates down to the section; the relative ones do not, which is
/// the whole reason both exist. A generator that walks its own unit in local space through
/// <see cref="SetRelativeState"/> or <see cref="SetAllRelativeStates"/> pays nothing for coordinate
/// translation.
/// <p/>
/// Masking with <c>&amp; 15</c> is right for negative coordinates too, and relies on sections being
/// aligned to multiples of 16 in absolute coordinates.
/// <see cref="GeneratorTerrainProvider"/> checks that the world's min y is.
/// </remarks>
internal sealed class SectionUnit : GenerationUnitBase {
    private readonly GenerationSection _section;
    private readonly IForkSink _forks;

    public SectionUnit(GenerationSection section, Vec3<int> start, int minY, int maxY,
        MinecraftRegistry registry, IForkSink forks)
        : base(start, start + ChunkSection.Size, minY, maxY, registry) {

        _section = section;
        _forks = forks;
    }

    /// <summary>The buffer behind this unit, for the provider that has to commit it.</summary>
    public GenerationSection Section => _section;

    public override IReadOnlyList<IGenerationUnit> Subdivide() => [this];

    public override IGenerationUnit Fork(Vec3<int> start, Vec3<int> end) => _forks.Fork(start, end);

    public override void Fork(Action<IBlockSetter> build) => _forks.Fork(build);

    public override bool ReadForkedWrites(ForkedBlock into) => _forks.ReadForkedWrites(into);

    public override void SetBlockState(int x, int y, int z, uint stateId) {
        _section.SetBlock(x & 15, y & 15, z & 15, stateId);
    }

    public override void SetRelativeState(int x, int y, int z, uint stateId) {
        _section.SetBlock(x, y, z, stateId);
    }

    public override void SetAllStates(BlockStateSupplier supplier) {
        int baseX = AbsoluteStart.X, baseY = AbsoluteStart.Y, baseZ = AbsoluteStart.Z;
        _section.SetAllLocal((x, y, z) => supplier(baseX + x, baseY + y, baseZ + z));
    }

    public override void SetAllRelativeStates(BlockStateSupplier supplier) {
        _section.SetAllLocal((x, y, z) => supplier(x, y, z));
    }

    public override void SetColumnStates(int x, int z, int startY, ReadOnlySpan<uint> states) {
        // Clipped to this section, so an area unit can hand the same column to each of its sections
        // and let them take their own slice.
        int from = Math.Max(startY, AbsoluteStart.Y);
        int to = Math.Min(startY + states.Length, AbsoluteEnd.Y);
        if (from >= to) {
            return;
        }

        _section.SetColumn(x & 15, z & 15, from - AbsoluteStart.Y, states.Slice(from - startY, to - from));
    }

    public override void FillState(uint stateId) {
        _section.Fill(stateId);
    }

    public override void FillHeightState(int minY, int maxY, uint stateId) {
        int from = Math.Max(minY, AbsoluteStart.Y);
        int to = Math.Min(maxY, AbsoluteEnd.Y);
        if (from >= to) {
            return;
        }

        _section.SetRange(from - AbsoluteStart.Y, to - AbsoluteStart.Y, stateId);
    }

    public override void SetBiome(int x, int y, int z, uint biomeId) {
        _section.SetBiome((x & 15) / ChunkSection.BiomeDimension, (y & 15) / ChunkSection.BiomeDimension,
            (z & 15) / ChunkSection.BiomeDimension, biomeId);
    }

    public override void FillBiome(uint biomeId) {
        _section.FillBiome(biomeId);
    }

    public override void SetBlockEntity(int x, int y, int z, IBlockEntityType type, INbtTag data) {
        _section.SetBlockEntity(x & 15, y & 15, z & 15, type, data);
    }
}
