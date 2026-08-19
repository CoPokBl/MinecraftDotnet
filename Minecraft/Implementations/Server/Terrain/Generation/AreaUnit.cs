using Minecraft.Data.BlockEntityTypes;
using Minecraft.Registry;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using NBT;

namespace Minecraft.Implementations.Server.Terrain.Generation;

/// <summary>
/// A box of whole sections. Pure routing: it holds no blocks of its own and every write lands in one
/// of its <see cref="SectionUnit"/>s.
/// </summary>
/// <remarks>
/// A whole chunk is one of these, one section wide and deep and as tall as the world.
/// <p/>
/// Finding the section for a position is three shifts and a multiply-add into a fixed array, with no
/// hashing and no search. The bulk methods do not route per position at all: they hand the whole
/// operation to every section and let each clip it to itself, which keeps the constant time fill
/// available. A <see cref="FillHeightState"/> across a 384 high world is 24 calls, of which those
/// inside the range collapse to a single palette value and those outside it return immediately.
/// </remarks>
internal sealed class AreaUnit : GenerationUnitBase {
    private readonly SectionUnit[] _sections;
    private readonly int _width;
    private readonly int _height;
    private readonly IForkSink _forks;

    /// <param name="sections">
    /// Ordered z major then y then x, matching <see cref="IndexOf"/>. The caller builds them, since
    /// a chunk's come from its own <see cref="ChunkSection"/>s and a fork's come from the context.
    /// </param>
    public AreaUnit(SectionUnit[] sections, int width, int height, int depth, Vec3<int> start,
        int minY, int maxY, MinecraftRegistry registry, IForkSink forks)
        : base(start, start + new Vec3<int>(width, height, depth) * ChunkSection.Size, minY, maxY,
            registry) {

        if (sections.Length != width * height * depth) {
            throw new ArgumentException(
                $"Expected {width * height * depth} sections, got {sections.Length}.", nameof(sections));
        }

        _sections = sections;
        _width = width;
        _height = height;
        _forks = forks;
    }

    public IReadOnlyList<SectionUnit> Sections => _sections;

    public override IReadOnlyList<IGenerationUnit> Subdivide() => _sections;

    public override IGenerationUnit Fork(Vec3<int> start, Vec3<int> end) => _forks.Fork(start, end);

    public override void Fork(Action<IBlockSetter> build) => _forks.Fork(build);

    public override bool ReadForkedWrites(ForkedBlock into) => _forks.ReadForkedWrites(into);

    private int IndexOf(int sectionX, int sectionY, int sectionZ) {
        return sectionZ * _width * _height + sectionY * _width + sectionX;
    }

    /// <summary>The section holding an absolute position, or null when it is outside the unit.</summary>
    private SectionUnit? At(int x, int y, int z) {
        int sx = (x - AbsoluteStart.X) >> 4;
        int sy = (y - AbsoluteStart.Y) >> 4;
        int sz = (z - AbsoluteStart.Z) >> 4;

        if (sx < 0 || sy < 0 || sz < 0 || sx >= _width || sy >= _height
            || sz >= _sections.Length / (_width * _height)) {
            return null;
        }

        return _sections[IndexOf(sx, sy, sz)];
    }

    public override void SetBlockState(int x, int y, int z, uint stateId) {
        At(x, y, z)?.SetBlockState(x, y, z, stateId);
    }

    public override void SetRelativeState(int x, int y, int z, uint stateId) {
        SetBlockState(AbsoluteStart.X + x, AbsoluteStart.Y + y, AbsoluteStart.Z + z, stateId);
    }

    public override void SetAllStates(BlockStateSupplier supplier) {
        foreach (SectionUnit section in _sections) {
            section.SetAllStates(supplier);
        }
    }

    public override void SetAllRelativeStates(BlockStateSupplier supplier) {
        // Rebased per section so each one runs its own tight local loop, rather than the loop
        // re-resolving which section it is in on every position.
        foreach (SectionUnit section in _sections) {
            int dx = section.AbsoluteStart.X - AbsoluteStart.X;
            int dy = section.AbsoluteStart.Y - AbsoluteStart.Y;
            int dz = section.AbsoluteStart.Z - AbsoluteStart.Z;
            section.SetAllRelativeStates((x, y, z) => supplier(dx + x, dy + y, dz + z));
        }
    }

    public override void SetColumnStates(int x, int z, int startY, ReadOnlySpan<uint> states) {
        foreach (SectionUnit section in _sections) {
            if (section.AbsoluteStart.X >> 4 == x >> 4 && section.AbsoluteStart.Z >> 4 == z >> 4) {
                section.SetColumnStates(x, z, startY, states);
            }
        }
    }

    public override void FillState(uint stateId) {
        foreach (SectionUnit section in _sections) {
            section.FillState(stateId);
        }
    }

    public override void FillHeightState(int minY, int maxY, uint stateId) {
        foreach (SectionUnit section in _sections) {
            section.FillHeightState(minY, maxY, stateId);
        }
    }

    public override void SetBiome(int x, int y, int z, uint biomeId) {
        At(x, y, z)?.SetBiome(x, y, z, biomeId);
    }

    public override void FillBiome(uint biomeId) {
        foreach (SectionUnit section in _sections) {
            section.FillBiome(biomeId);
        }
    }

    public override void SetBlockEntity(int x, int y, int z, IBlockEntityType type, INbtTag data) {
        At(x, y, z)?.SetBlockEntity(x, y, z, type, data);
    }
}
