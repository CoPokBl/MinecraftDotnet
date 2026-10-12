using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Lighting;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;

namespace ManagedServer.Testing.Lighting;

/// <summary>
/// The engine's <see cref="ILightColumn"/> input against its <see cref="ChunkData"/> input, which the
/// conformance test pins to vanilla: the same blocks must light the same whichever form they arrive in.
/// </summary>
public class LightColumnTest {
    private sealed class Column(LightSection[] sections) : ILightColumn {
        public int SectionCount => sections.Length;
        public LightSection Section(int index) => sections[index];
    }

    private static readonly IBlock[] Scatter = [
        Block.Stone, Block.Glass, Block.Torch, Block.Glowstone, Block.Water, Block.OakSlab, Block.OakLeaves, Block.Lantern, Block.Dirt
    ];

    private static ChunkData Build(int seed) {
        ChunkData chunk = new(384);
        Random random = new(seed);
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                for (int y = 0; y < 60; y++) {
                    chunk.SetBlock(x, y, z, Block.Stone);
                }
            }
        }
        for (int i = 0; i < 600; i++) {
            chunk.SetBlock(random.Next(16), 55 + random.Next(40), random.Next(16), Scatter[random.Next(Scatter.Length)]);
        }
        return chunk;
    }

    /// <summary>
    /// The direct form for even chunks and the palette form for odd ones, so both of the column's
    /// non-uniform paths are compared.
    /// </summary>
    private static Column ToColumn(ChunkData chunk, bool palette) {
        LightSection[] sections = new LightSection[chunk.Sections.Length];
        uint[] flat = new uint[4096];
        for (int s = 0; s < sections.Length; s++) {
            chunk.Sections[s].FillFlatStateIds(flat);
            if (flat.All(state => state == flat[0])) {
                sections[s] = new LightSection(flat[0], null, 0, null, null);
                continue;
            }
            if (!palette) {
                sections[s] = new LightSection(0, null, 0, null, flat.Select(state => (ushort)state).ToArray());
                continue;
            }
            List<ushort> entries = [];
            byte[] indices = new byte[4096];
            for (int i = 0; i < 4096; i++) {
                int index = entries.IndexOf((ushort)flat[i]);
                if (index < 0) {
                    index = entries.Count;
                    entries.Add((ushort)flat[i]);
                }
                indices[i] = (byte)index;
            }
            sections[s] = new LightSection(0, entries.ToArray(), entries.Count, indices, null);
        }
        return new Column(sections);
    }

    [Test]
    public void ColumnLightsAsChunkDataDoes() {
        Dictionary<Vec2<int>, ChunkData> chunks = new();
        Dictionary<Vec2<int>, Column> columns = new();
        for (int x = -1; x <= 1; x++) {
            for (int z = -1; z <= 1; z++) {
                Vec2<int> pos = new(x, z);
                chunks[pos] = Build(x * 31 + z * 7 + 5);
                columns[pos] = ToColumn(chunks[pos], (x + z & 1) != 0);
            }
        }

        foreach (bool sky in new[] { true, false }) {
            Vec2<int> centre = new(0, 0);
            LightData expected = new CalculatedLightingProvider().GetLighting(centre, chunks[centre], p => chunks.GetValueOrDefault(p), VanillaRegistry.Data, sky);
            LightData actual = new CalculatedLightingProvider().GetLighting(centre, columns[centre], p => columns.GetValueOrDefault(p), sky);
            Assert.Multiple(() => {
                Assert.That(actual.SkyLightMask, Is.EqualTo(expected.SkyLightMask), "sky mask");
                Assert.That(actual.EmptySkyLightMask, Is.EqualTo(expected.EmptySkyLightMask), "empty sky mask");
                Assert.That(actual.BlockLightMask, Is.EqualTo(expected.BlockLightMask), "block mask");
                Assert.That(actual.EmptyBlockLightMask, Is.EqualTo(expected.EmptyBlockLightMask), "empty block mask");
                Assert.That(actual.SkyLight, Is.EqualTo(expected.SkyLight), "sky light");
                Assert.That(actual.BlockLight, Is.EqualTo(expected.BlockLight), "block light");
            });
        }
    }
}
