using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Implementations.Server.Terrain;

/// <summary>
/// What a generated chunk's sections actually come out as.
/// </summary>
/// <remarks>
/// These assert on the <b>palette shape</b>, not just on the blocks. The blocks come out right either
/// way, so a fast path degrading into a per position loop passes a contents-only test while costing
/// the thing the API exists for, and a consumer cannot see the difference.
/// </remarks>
public class GenerationCommitTest {
    private const int MinY = -64;

    private static ChunkData Generate(Action<IGenerationUnit> body) {
        return GenerationUnitTest.Generate(new GenerationUnitTest.Lambda(body));
    }

    /// <summary>A section nobody wrote to is air, and cost no buffer to say so.</summary>
    [Test]
    public void UntouchedSectionsStayUniformAir() {
        ChunkData chunk = Generate(_ => { });

        foreach (ChunkSection section in chunk.Sections) {
            Assert.That(section.UniformState, Is.EqualTo(0u));
        }
    }

    [Test]
    public void AUniformSectionCommitsAsASingleValue() {
        ChunkData chunk = Generate(unit => unit.Modifier.FillHeight(MinY, MinY + 16, Block.Stone));

        Assert.That(chunk.Sections[0].UniformState, Is.EqualTo(Block.Stone.StateId));
        Assert.That(chunk.Sections[0].Palette, Is.InstanceOf<SingleValuePalette>());
    }

    [Test]
    public void AFewStatesCommitAsAnIndirectPalette() {
        ChunkData chunk = Generate(unit => {
            unit.Modifier.FillHeight(MinY, MinY + 16, Block.Stone);
            unit.Modifier.SetBlock(0, MinY, 0, Block.Dirt);
        });

        Assert.That(chunk.Sections[0].Palette, Is.InstanceOf<IndirectPalette>());
    }

    /// <summary>Past what eight bits can index, a section has to go direct.</summary>
    [Test]
    public void TooManyStatesCommitAsADirectPalette() {
        ChunkData chunk = Generate(unit => {
            unit.Modifier.SetAllRelativeStates((x, y, z) => (uint)((x + y * 16 + z * 256) % 400) + 1);
        });

        Assert.That(chunk.Sections[0].Palette, Is.InstanceOf<DirectPalette>());
    }

    /// <summary>
    /// The chunk store packs every chunk after generating it. Committing straight to a palette leaves
    /// nothing to pack, which is where most of the saving is: packing re-scans every section with a
    /// linear search per position.
    /// </summary>
    [Test]
    public void PackingAGeneratedChunkIsANoOp() {
        ChunkData chunk = Generate(unit => {
            unit.Modifier.FillHeight(MinY, 0, Block.Stone);
            unit.Modifier.SetBlock(3, 1, 4, Block.Dirt);
        });

        Palette[] before = chunk.Sections.Select(s => s.Palette).ToArray();
        chunk.PackData();

        for (int i = 0; i < before.Length; i++) {
            Assert.That(chunk.Sections[i].Palette, Is.SameAs(before[i]),
                $"section {i} was repacked, so it had been left unpacked");
        }
    }

    /// <summary>
    /// A palette is never written through once built, which is what lets a section share one with its
    /// clones and makes snapshotting a chunk per send free. A <c>Palette.Set</c> would break this.
    /// </summary>
    [Test]
    public void CloningAGeneratedChunkDoesNotShareMutableState() {
        ChunkData chunk = Generate(unit => unit.Modifier.FillHeight(MinY, 0, Block.Stone));
        ChunkData clone = chunk.Clone();

        chunk.SetBlock(0, 0, 0, Block.DiamondBlock.StateId);

        Assert.Multiple(() => {
            Assert.That(clone.GetBlock(0, 0, 0), Is.EqualTo(Block.Stone.StateId), "the clone moved");
            Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.DiamondBlock.StateId));
        });
    }

    /// <summary>
    /// The sections are replaced wholesale rather than through <c>ChunkData.SetBlock</c>, so the
    /// generator has to say the heightmaps are stale. Missing that ships a chunk claiming its surface
    /// is at zero, and rain falls through the world.
    /// </summary>
    [Test]
    public void HeightmapsSeeGeneratedTerrain() {
        ChunkData chunk = Generate(unit => unit.Modifier.FillHeight(MinY, -4, Block.Stone));

        Heightmaps maps = Heightmaps.Compute(chunk, VanillaRegistry.Data);

        // Filled up to but not including game y -4, so the top block is at -5, protocol 59.
        Assert.That(maps.WorldSurface[0], Is.EqualTo(60));
    }

    /// <summary>A block entity is filed where <c>World</c>'s own accessors look for it.</summary>
    [Test]
    public void BlockEntitiesAreFiledChunkLocalWithGameY() {
        ChunkData chunk = GenerationUnitTest.Generate(
            new GenerationUnitTest.Lambda(unit => {
                unit.Modifier.SetBlock(20, -4, 5, Block.Chest);
                unit.Modifier.SetBlockEntity(20, -4, 5, BlockEntityType.Chest, new NBT.Tags.CompoundTag());
            }),
            chunkX: 1);

        Assert.That(chunk.BlockEntities.Keys, Is.EquivalentTo(new[] { new Vec3<int>(4, -4, 5) }));
    }
}
