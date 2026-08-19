using System.Text;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas.Chunks;

namespace Conformance;

/// <summary>
/// Scenes for <c>Conformance/heightmap.sh</c>, which runs vanilla's own <c>Heightmap.primeHeightmaps</c>
/// over them and diffs its answer against ours.
/// </summary>
/// <remarks>
/// This is the case CLAUDE.md's harness rule is really about. Every rule in
/// <see cref="HeightmapStates"/> is a reading of the jar: whether the predicate is
/// <c>blocksMotion()</c> alone or that <b>or</b> a fluid, whether leaves are excluded by class or by
/// tag, whether the stored number is the block's position or one above it, and how wide the entries
/// are. Our own tests would encode the same reading, so they cannot tell us it is wrong. Only the
/// real method can.
/// <p/>
/// The packet harness is not a substitute. It proves the client can parse the map we send, which it
/// can just as happily when every number in it is off by one.
/// </remarks>
public static class HeightmapSamples {
    private const int WorldHeight = ChunkData.VanillaOverworldHeight;
    private const int MinY = -64;

    /// <summary>A block written at a protocol y, which is what both sides index by.</summary>
    private readonly record struct Placed(int X, int Y, int Z, uint StateId);

    private sealed record Scene(string Name, List<Placed> Blocks);

    public static string BuildJson() {
        List<Scene> scenes = [
            Empty(),
            Solid(),
            Water(),
            Torch(),
            Leaves(),
            BottomSlab(),
            FullColumn(),
            Terrain()
        ];

        StringBuilder json = new();
        json.AppendLine("{");
        json.AppendLine($"  \"worldHeight\": {WorldHeight}, \"minY\": {MinY},");
        json.AppendLine("  \"scenes\": [");

        List<string> parts = [];
        foreach (Scene scene in scenes) {
            ChunkData chunk = new(WorldHeight) { MinY = MinY };
            foreach (Placed placed in scene.Blocks) {
                chunk.SetBlock(placed.X, placed.Y, placed.Z, placed.StateId);
            }

            Heightmaps maps = Heightmaps.Compute(chunk, VanillaRegistry.Data);

            StringBuilder part = new();
            part.Append($"    {{\"name\": \"{scene.Name}\", \"blocks\": [");
            part.Append(string.Join(", ", scene.Blocks.Select(b =>
                $"{{\"x\": {b.X}, \"y\": {b.Y}, \"z\": {b.Z}, \"state\": {b.StateId}}}")));
            part.Append("], ");

            // Our answers, as the flat per column values rather than as packed longs: the packing is
            // already pinned by the packet harness, and a per column diff says which column is wrong.
            part.Append($"\"worldSurface\": [{string.Join(",", maps.WorldSurface)}], ");
            part.Append($"\"motionBlocking\": [{string.Join(",", maps.MotionBlocking)}], ");
            part.Append($"\"motionBlockingNoLeaves\": [{string.Join(",", maps.MotionBlockingNoLeaves)}]}}");
            parts.Add(part.ToString());
        }

        json.AppendLine(string.Join(",\n", parts));
        json.AppendLine("  ]");
        json.AppendLine("}");
        return json.ToString();
    }

    public static int SceneCount => 8;

    /// <summary>Nothing anywhere: every column has to answer zero, not the world floor.</summary>
    private static Scene Empty() => new("empty", []);

    private static Scene Solid() => new("solid floor", Layer(64, Block.Stone));

    /// <summary>
    /// Water blocks nothing and is still motion blocking, through the fluid half of the predicate.
    /// Dropping that half is what would put rain through the surface of an ocean.
    /// </summary>
    private static Scene Water() {
        List<Placed> blocks = Layer(60, Block.Stone);
        blocks.AddRange(Layer(61, Block.Water));
        blocks.AddRange(Layer(62, Block.Water));
        return new Scene("water over stone", blocks);
    }

    /// <summary>A torch is a world surface and is not motion blocking.</summary>
    private static Scene Torch() {
        List<Placed> blocks = Layer(64, Block.Stone);
        blocks.Add(new Placed(3, 65, 3, Block.Torch.StateId));
        blocks.Add(new Placed(9, 70, 12, Block.Torch.StateId));
        return new Scene("torches over stone", blocks);
    }

    /// <summary>The one reason the third map exists.</summary>
    private static Scene Leaves() {
        List<Placed> blocks = Layer(64, Block.Stone);
        blocks.AddRange(Layer(80, Block.OakLeaves));
        blocks.Add(new Placed(1, 90, 1, Block.SpruceLeaves.StateId));
        return new Scene("leaf canopy", blocks);
    }

    /// <summary>
    /// A bottom slab, which is neither a full block nor air. Its shape is short and it still blocks
    /// motion, so it counts for all three.
    /// </summary>
    private static Scene BottomSlab() {
        List<Placed> blocks = Layer(64, Block.Stone);
        blocks.Add(new Placed(5, 65, 5, Block.OakSlab.StateId));
        blocks.Add(new Placed(6, 65, 6, Block.Snow.StateId));
        blocks.Add(new Placed(7, 65, 7, Block.ShortGrass.StateId));
        blocks.Add(new Placed(8, 65, 8, Block.Cobweb.StateId));
        return new Scene("short blocks over stone", blocks);
    }

    /// <summary>Filled to the roof, the case the entry width has to be wide enough for.</summary>
    private static Scene FullColumn() {
        List<Placed> blocks = [];
        for (int y = 0; y < WorldHeight; y++) {
            blocks.Add(new Placed(0, y, 0, Block.Stone.StateId));
        }

        blocks.Add(new Placed(1, 0, 0, Block.Stone.StateId));
        return new Scene("one column filled to the roof", blocks);
    }

    /// <summary>An uneven surface, so every column is a different answer.</summary>
    private static Scene Terrain() {
        List<Placed> blocks = [];
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                int top = 50 + (x * 7 + z * 3) % 40;
                for (int y = 0; y <= top; y++) {
                    blocks.Add(new Placed(x, y, z, Block.Stone.StateId));
                }

                if ((x + z) % 3 == 0) {
                    blocks.Add(new Placed(x, top + 1, z, Block.OakLeaves.StateId));
                }
                if ((x + z) % 5 == 0) {
                    blocks.Add(new Placed(x, top + 2, z, Block.Torch.StateId));
                }
            }
        }

        return new Scene("uneven terrain with leaves and torches", blocks);
    }

    private static List<Placed> Layer(int y, IBlock block) {
        List<Placed> blocks = [];
        for (int x = 0; x < 16; x++) {
            for (int z = 0; z < 16; z++) {
                blocks.Add(new Placed(x, y, z, block.StateId));
            }
        }

        return blocks;
    }
}
