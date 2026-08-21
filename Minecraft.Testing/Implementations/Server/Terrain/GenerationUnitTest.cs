using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain.Generation;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Chunks.Palettes;
using Minecraft.Schemas.Vec;

namespace Minecraft.Testing.Implementations.Server.Terrain;

/// <summary>
/// What a generation unit covers, and which coordinates its setters speak.
/// </summary>
/// <remarks>
/// The unit is in <b>game</b> y, not the protocol y a chunk is indexed by. Confusing the two puts
/// terrain a world's depth from where it was asked for, which looks exactly like the generator not
/// having run.
/// </remarks>
public class GenerationUnitTest {
    private const int MinY = -64;
    private const int Height = ChunkData.VanillaOverworldHeight;

    /// <summary>Runs a generator over one chunk and hands back what it produced.</summary>
    internal static ChunkData Generate(IGenerator generator, int chunkX = 0, int chunkZ = 0) {
        ChunkData chunk = new(Height) { ChunkX = chunkX, ChunkZ = chunkZ, MinY = MinY };
        ChunkData data = chunk;
        new GeneratorTerrainProvider(generator).GetChunk(ref data);
        return data;
    }

    /// <summary>A generator that just runs a lambda, so a fixture is one expression.</summary>
    internal sealed class Lambda(Action<IGenerationUnit> body) : IGenerator {
        public void Generate(IGenerationUnit unit) => body(unit);
    }

    [Test]
    public void TheUnitSpansTheWholeWorldColumn() {
        IGenerationUnit? seen = null;
        Generate(new Lambda(unit => seen = unit), chunkX: 2, chunkZ: -3);

        Assert.That(seen, Is.Not.Null);
        Assert.Multiple(() => {
            Assert.That(seen!.AbsoluteStart, Is.EqualTo(new Vec3<int>(32, MinY, -48)));
            Assert.That(seen.AbsoluteEnd, Is.EqualTo(new Vec3<int>(48, MinY + Height, -32)));
            Assert.That(seen.Size, Is.EqualTo(new Vec3<int>(16, Height, 16)));
            Assert.That(seen.MinY, Is.EqualTo(MinY));
            Assert.That(seen.MaxY, Is.EqualTo(MinY + Height));
        });
    }

    /// <summary>
    /// A write at the bottom of the world lands in section zero. Read as protocol y this coordinate
    /// would be 64 blocks up.
    /// </summary>
    [Test]
    public void GameYIsTranslatedToProtocolY() {
        ChunkData chunk = Generate(new Lambda(unit => {
            unit.Modifier.SetBlock(0, MinY, 0, Block.Stone);
            unit.Modifier.SetBlock(1, 0, 0, Block.Dirt);
            unit.Modifier.SetBlock(2, -60, 0, Block.Cobblestone);
        }));

        Assert.Multiple(() => {
            Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.Stone.StateId), "world floor");
            Assert.That(chunk.GetBlock(1, 64, 0), Is.EqualTo(Block.Dirt.StateId), "game y zero");
            Assert.That(chunk.GetBlock(2, 4, 0), Is.EqualTo(Block.Cobblestone.StateId), "just off the floor");
        });
    }

    /// <summary>The relative setters are zero based against the unit's own corner.</summary>
    [Test]
    public void RelativeAndAbsoluteAgreeAtTheCorner() {
        ChunkData chunk = Generate(new Lambda(unit => {
            unit.Modifier.SetRelative(0, 0, 0, Block.Stone);
            unit.Modifier.SetBlock(unit.AbsoluteStart + new Vec3<int>(1, 1, 1), Block.Dirt);
            unit.Modifier.SetRelative(1, 1, 1, Block.Cobblestone);  // over the top of the last one
        }), chunkX: 1);

        Assert.Multiple(() => {
            Assert.That(chunk.GetBlock(0, 0, 0), Is.EqualTo(Block.Stone.StateId));
            Assert.That(chunk.GetBlock(1, 1, 1), Is.EqualTo(Block.Cobblestone.StateId));
        });
    }

    /// <summary>A write outside the unit is dropped rather than landing in the wrong section.</summary>
    [Test]
    public void WritesOutsideTheUnitAreDropped() {
        ChunkData chunk = Generate(new Lambda(unit => {
            unit.Modifier.SetBlock(-1, 0, 0, Block.Stone);              // the chunk to the west
            unit.Modifier.SetBlock(16, 0, 0, Block.Stone);              // the chunk to the east
            unit.Modifier.SetBlock(0, MinY - 1, 0, Block.Stone);        // under the world
            unit.Modifier.SetBlock(0, MinY + Height, 0, Block.Stone);   // over it
            unit.Modifier.SetBlock(0, 0, 0, Block.Dirt);                // and one that is in range
        }));

        Assert.That(chunk.GetBlock(0, 64, 0), Is.EqualTo(Block.Dirt.StateId));

        // Nothing else in the chunk moved, which a stray write landing in the wrong section breaks.
        for (int i = 0; i < chunk.Sections.Length; i++) {
            uint? uniform = chunk.Sections[i].UniformState;
            Assert.That(i == 4 || uniform == 0, Is.True, $"section {i} was written to");
        }
    }

    /// <summary>Subdividing gives one unit per section, in order from the bottom of the world.</summary>
    [Test]
    public void SubdivideGivesOneUnitPerSection() {
        IReadOnlyList<IGenerationUnit>? sections = null;
        Generate(new Lambda(unit => sections = unit.Subdivide()));

        Assert.That(sections, Is.Not.Null);
        Assert.That(sections!, Has.Count.EqualTo(Height / ChunkSection.Size));

        for (int i = 0; i < sections.Count; i++) {
            Assert.That(sections[i].AbsoluteStart.Y, Is.EqualTo(MinY + i * ChunkSection.Size),
                $"section {i}");
            Assert.That(sections[i].Size, Is.EqualTo(new Vec3<int>(16, 16, 16)));
        }

        // A section is already the smallest unit there is.
        Assert.That(sections[0].Subdivide(), Has.Count.EqualTo(1));
    }

    /// <summary>A column is written bottom upwards from the y it names, and clipped to the world.</summary>
    [Test]
    public void ColumnsAreWrittenUpwards() {
        uint[] states = [Block.Stone.StateId, Block.Dirt.StateId, Block.GrassBlock.StateId];

        ChunkData chunk = Generate(new Lambda(unit => {
            unit.Modifier.SetColumnStates(3, 5, -2, states);

            // Straddling a section boundary, which is the case the per section clipping is for.
            unit.Modifier.SetColumnStates(4, 5, -1, [Block.Cobblestone.StateId, Block.Cobblestone.StateId]);
        }));

        Assert.Multiple(() => {
            Assert.That(chunk.GetBlock(3, 62, 5), Is.EqualTo(Block.Stone.StateId));
            Assert.That(chunk.GetBlock(3, 63, 5), Is.EqualTo(Block.Dirt.StateId));
            Assert.That(chunk.GetBlock(3, 64, 5), Is.EqualTo(Block.GrassBlock.StateId));

            Assert.That(chunk.GetBlock(4, 63, 5), Is.EqualTo(Block.Cobblestone.StateId));
            Assert.That(chunk.GetBlock(4, 64, 5), Is.EqualTo(Block.Cobblestone.StateId));
        });
    }

    /// <summary>Biomes are stored per 4x4x4 cell, so the whole cell takes the value.</summary>
    [Test]
    public void BiomesAreWrittenPerCell() {
        ChunkData chunk = Generate(new Lambda(unit => {
            unit.Modifier.FillBiome(Biome.Plains);
            unit.Modifier.SetBiome(1, 1, 1, Biome.Desert);
        }));

        uint desert = ChunkData.BiomeId(Biome.Desert);
        uint plains = ChunkData.BiomeId(Biome.Plains);

        Assert.Multiple(() => {
            // Everything in the same 4x4x4 cell as the write.
            Assert.That(chunk.GetBiome(0, 64 + 0, 0), Is.EqualTo(desert));
            Assert.That(chunk.GetBiome(3, 64 + 3, 3), Is.EqualTo(desert));

            // And the cell next door is untouched.
            Assert.That(chunk.GetBiome(4, 64, 0), Is.EqualTo(plains));
            Assert.That(chunk.GetBiome(0, 0, 0), Is.EqualTo(plains));
        });
    }

    /// <summary>
    /// A whole chunk of one biome collapses to a single value palette, which is what makes writing
    /// biomes at all affordable.
    /// </summary>
    [Test]
    public void FillingABiomeIsASingleValuePalette() {
        ChunkData chunk = Generate(new Lambda(unit => unit.Modifier.FillBiome(Biome.Desert)));

        foreach (ChunkSection section in chunk.Sections) {
            Assert.That(section.BiomesPalette, Is.InstanceOf<SingleValuePalette>());
        }
    }
}
