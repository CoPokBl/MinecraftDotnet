using System.IO.Compression;
using System.Numerics;
using System.Text;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Rendering;
using GraphicalClient.Rendering.Pipeline;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Registry;
using Minecraft.Schemas;
using BakedQuad = GraphicalClient.Assets.ResourcePacks.BakedQuad;

namespace GraphicalClient.Testing.Lighting;

/// <summary>
/// Replays Conformance/blocklight.sh's fixture: scenes of states and chosen light, the middle block drawn
/// by the vanilla <c>ModelBlockRenderer</c> and <c>FluidRenderer</c>. Each scene's block models are baked
/// by <see cref="BlockModelBaker"/> and meshed by <see cref="SectionMesher"/>, and every vertex has to come
/// out where vanilla's did with the light coords it had and the colour the shader's helpers make of it.
/// </summary>
[TestFixture]
public class BlockLightConformanceTest {
    private const string Fixture = "Lighting/vanilla-block-light.bin.gz";
    private const int Size = 5;

    private sealed record Vertex(Vector3 Position, int Colour, int Light);

    private sealed record VanillaQuad(Vector3[] Positions, int Direction, int Cull, int Shade, int Emission);

    private sealed record Scene(string Name, float[] Cardinal, bool AmbientOcclusion, (int X, int Y, int Z) Centre, int[] States, byte[] Sky, byte[] Block,
        (string Json, int X, int Y)[] Parts, VanillaQuad[] Baked, Vertex[][] Drawn);

    private static List<Scene>? _scenes;
    private static BlockModel[]? _models;

    private static List<Scene> Scenes() => _scenes ??= Read(Path.Combine(TestContext.CurrentContext.TestDirectory, Fixture));

    private static MinecraftRegistry Registry => VanillaRegistry.Data;

    private static BlockModel[] Models() {
        if (_models != null) {
            return _models;
        }
        MinecraftRegistry registry = Registry;
        HashSet<Identifier> bars = registry.Blocks.Tags[Identifier.Parse("minecraft:bars")].GetValueIds(registry).ToHashSet();
        Dictionary<Identifier, int> keys = new();
        BlockModel[] models = new BlockModel[registry.Blocks.StatesCount];
        for (uint state = 0; state < models.Length; state++) {
            IBlock block = registry.Blocks.GetByStateId(state);
            models[state] = StateModel(block, state, bars, keys);
        }
        return _models = models;
    }

    private static BlockModel StateModel(IBlock block, uint state, IReadOnlySet<Identifier> bars, Dictionary<Identifier, int> keys) {
        if (!keys.TryGetValue(block.Identifier, out int key)) {
            key = keys.Count + 1;
            keys[block.Identifier] = key;
        }
        BlockModel model = new() { Geometry = BlockGeometry.None, BlockKey = key };
        BlockModels.ApplyState(model, block, state, bars);
        return model;
    }

    [Test]
    public void FixtureHasScenes() {
        Assert.That(Scenes(), Has.Count.GreaterThan(100));
        Assert.That(Scenes().Sum(s => s.Drawn.Length), Is.GreaterThan(1000));
    }

    /// <summary>The ambient occlusion remap names quad vertices by index, so the client's baker has to put corners in vanilla's order.</summary>
    [Test]
    public void BakedCornersAreInVanillaOrder() {
        List<string> failures = [];
        HashSet<string> seen = [];
        foreach (Scene scene in Scenes()) {
            string key = string.Join("|", scene.Parts.Select(p => $"{p.Json}{p.X},{p.Y}"));
            if (scene.Parts.Length == 0 || !seen.Add(key)) {
                continue;
            }
            List<BakedQuad> ours = Bake(scene).Parts.SelectMany(p => p.Options[0].Quads).ToList();
            if (ours.Count != scene.Baked.Length) {
                failures.Add($"{scene.Name}: {ours.Count} quads baked, vanilla {scene.Baked.Length}");
                continue;
            }
            foreach (VanillaQuad vanilla in scene.Baked) {
                BakedQuad? match = ours.FirstOrDefault(q => Same(q.Positions, vanilla.Positions));
                if (match == null) {
                    failures.Add($"{scene.Name}: no quad at {string.Join(" ", vanilla.Positions)}");
                    continue;
                }
                ours.Remove(match);
                if (match.Direction != vanilla.Direction || (match.CullFace ?? -1) != vanilla.Cull || (match.ShadeDirection ?? -1) != vanilla.Shade
                    || match.LightEmission != vanilla.Emission) {
                    failures.Add($"{scene.Name}: quad at {vanilla.Positions[0]} has direction {match.Direction} cull {match.CullFace} shade {match.ShadeDirection} "
                                 + $"emission {match.LightEmission}, vanilla {vanilla.Direction} {vanilla.Cull} {vanilla.Shade} {vanilla.Emission}");
                }
            }
        }
        Assert.That(failures, Is.Empty, string.Join("\n", failures.Take(40)));
    }

    [Test]
    public void VerticesMatchVanilla() {
        List<string> failures = [];
        int vertices = 0;
        foreach (Scene scene in Scenes()) {
            List<Vertex[]> ours = Mesh(scene);
            List<Vertex[]> unmatched = [..ours];
            foreach (Vertex[] vanilla in scene.Drawn) {
                Vertex[]? match = unmatched.FirstOrDefault(q => Same(q.Select(v => v.Position).ToArray(), vanilla.Select(v => v.Position).ToArray()));
                if (match == null) {
                    failures.Add($"{scene.Name}: vanilla drew a quad at {string.Join(" ", vanilla.Select(v => v.Position))} that is not in the mesh");
                    continue;
                }
                unmatched.Remove(match);
                for (int v = 0; v < 4; v++) {
                    vertices++;
                    int vanillaBlock = vanilla[v].Light & 0xFFFF, vanillaSky = vanilla[v].Light >> 16 & 0xFFFF;
                    int ourBlock = match[v].Light & 0xFFFF, ourSky = match[v].Light >> 16 & 0xFFFF;
                    if (vanillaBlock != ourBlock || vanillaSky != ourSky) {
                        failures.Add($"{scene.Name}: vertex {vanilla[v].Position} light block {ourBlock} sky {ourSky}, vanilla {vanillaBlock} {vanillaSky}");
                    }
                    if ((vanilla[v].Colour & 0xFFFFFF) != (match[v].Colour & 0xFFFFFF)) {
                        failures.Add($"{scene.Name}: vertex {vanilla[v].Position} colour {match[v].Colour & 0xFFFFFF:X6}, vanilla {vanilla[v].Colour & 0xFFFFFF:X6}");
                    }
                }
            }
            foreach (Vertex[] extra in unmatched) {
                failures.Add($"{scene.Name}: the mesh has a quad at {string.Join(" ", extra.Select(v => v.Position))} that vanilla did not draw");
            }
        }
        Assert.That(failures, Is.Empty, $"{failures.Count} differences over {vertices} matched vertices:\n" + string.Join("\n", failures.Take(60)));
    }

    private static bool Same(Vector3[] a, Vector3[] b) {
        for (int i = 0; i < 4; i++) {
            if (Vector3.Distance(a[i], b[i]) > 2.0F / 1024.0F) {
                return false;
            }
        }
        return true;
    }

    private static BakedBlockModel Bake(Scene scene) {
        MemoryPack pack = new();
        StringBuilder blockstate = new();
        if (scene.Parts.Length == 1) {
            blockstate.Append($"{{\"variants\": {{\"\": {{\"model\": \"test:block/p0\", \"x\": {scene.Parts[0].X}, \"y\": {scene.Parts[0].Y}}}}}}}");
        }
        else {
            blockstate.Append("{\"multipart\": [");
            blockstate.Append(string.Join(", ", scene.Parts.Select((p, i) => $"{{\"apply\": {{\"model\": \"test:block/p{i}\", \"x\": {p.X}, \"y\": {p.Y}}}}}")));
            blockstate.Append("]}");
        }
        pack.Files["assets/test/blockstates/scene.json"] = Encoding.UTF8.GetBytes(blockstate.ToString());
        for (int i = 0; i < scene.Parts.Length; i++) {
            pack.Files[$"assets/test/models/block/p{i}.json"] = Encoding.UTF8.GetBytes(scene.Parts[i].Json);
        }
        using PackFiles files = new([("test", pack)]);
        return new BlockModelBaker(files).Bake(Identifier.Parse("test:scene"), new Dictionary<string, string>())!;
    }

    private static List<Vertex[]> Mesh(Scene scene) {
        BlockModel[] models = (BlockModel[])Models().Clone();
        uint centreState = (uint)scene.States[Index(2, 2, 2)];
        if (scene.Parts.Length > 0) {
            BlockModel centre = StateModel(Registry.Blocks.GetByStateId(centreState), centreState,
                Registry.Blocks.Tags[Identifier.Parse("minecraft:bars")].GetValueIds(Registry).ToHashSet(), new Dictionary<Identifier, int>());
            centre.BlockKey = models[centreState].BlockKey;
            centre.Geometry = BlockGeometry.Model;
            centre.Layer = RenderLayer.Solid;
            centre.Multipart = scene.Parts.Length > 1;
            centre.Parts = Bake(scene).Parts.Select(part => new MeshPart {
                Options = part.Options.Select(option => new MeshOption {
                    Quads = option.Quads.Select(ToMeshQuad).ToArray(),
                    Weight = option.Weight,
                    AmbientOcclusion = option.AmbientOcclusion
                }).ToArray(),
                TotalWeight = part.TotalWeight
            }).ToArray();
            models[centreState] = centre;
        }

        // Unmerged, or the centre's faces would merge with those of a neighbour of the same state, which
        // the mesher draws too.
        SectionSnapshot snapshot = new() { Materials = Unmerged(models.Length) };
        for (int dy = 0; dy < Size; dy++) {
            for (int dz = 0; dz < Size; dz++) {
                for (int dx = 0; dx < Size; dx++) {
                    int cell = Index(dx, dy, dz);
                    int index = SectionSnapshot.Index(scene.Centre.X + dx - 2, scene.Centre.Y + dy - 2, scene.Centre.Z + dz - 2);
                    snapshot.States[index] = (ushort)scene.States[cell];
                    snapshot.Light[index] = (byte)(scene.Sky[cell] << 4 | scene.Block[cell]);
                }
            }
        }

        SectionMesher mesher = new(models) { WaterState = (int)Block.Water.StateId, AmbientOcclusion = scene.AmbientOcclusion };
        SectionMesh mesh = mesher.Mesh(snapshot);
        List<Vertex[]> quads = [];
        Vector3 low = new Vector3(scene.Centre.X, scene.Centre.Y, scene.Centre.Z) - new Vector3(1e-4F);
        Vector3 high = low + new Vector3(1 + 2e-4F);
        for (int q = 0; q < mesh.VertexCount / 4; q++) {
            Vertex[] quad = new Vertex[4];
            Vector3 centroid = Vector3.Zero;
            for (int v = 0; v < 4; v++) {
                BlockVertex vertex = mesh.Vertices[q * 4 + v];
                Vector3 position = new(vertex.X / 1024.0F - 16, vertex.Y / 1024.0F - 16, vertex.Z / 1024.0F - 16);
                centroid += position / 4;
                quad[v] = new Vertex(position, Colour(vertex, scene.Cardinal), vertex.Block | vertex.Sky << 16);
            }
            // A neighbour of the same state is meshed too, and its face on the shared boundary looks into this cell.
            Vector3 normal = Vector3.Cross(quad[1].Position - quad[0].Position, quad[2].Position - quad[0].Position);
            Vector3 inward = new Vector3(scene.Centre.X + 0.5F, scene.Centre.Y + 0.5F, scene.Centre.Z + 0.5F) - centroid;
            bool onBoundary = MathF.Abs(MathF.Abs(inward.X) - 0.5F) < 3e-4F || MathF.Abs(MathF.Abs(inward.Y) - 0.5F) < 3e-4F || MathF.Abs(MathF.Abs(inward.Z) - 0.5F) < 3e-4F;
            if (Vector3.Clamp(centroid, low, high) == centroid && !(onBoundary && Vector3.Dot(normal, inward) > 0)) {
                quads.Add(quad);
            }
        }
        return quads;
    }

    /// <summary>
    /// What vanilla's integer colour arithmetic makes of a vertex: the occlusion gray scaled by the
    /// shade the vertex names, <c>ARGB.scaleRGB</c>'s truncation, which <c>vertexFaceShade</c> reproduces.
    /// </summary>
    private static int Colour(BlockVertex vertex, float[] cardinal) {
        int shade = vertex.Face >> SectionMesher.ShadeShift;
        float scale = shade switch {
            SectionMesher.FluidSideZShade => cardinal[1] * cardinal[2],
            SectionMesher.FluidSideXShade => cardinal[1] * cardinal[4],
            _ => cardinal[shade]
        };
        int gray = (int)(vertex.Colour >> 24);
        int channel = Math.Clamp((int)(gray * scale), 0, 255);
        return channel << 16 | channel << 8 | channel;
    }

    private static BlockMaterials Unmerged(int states) =>
        (BlockMaterials)typeof(BlockMaterials).GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)[0]
            .Invoke([new byte[states], new byte[states], 1UL]);

    private static MeshQuad ToMeshQuad(BakedQuad quad) => new() {
        Positions = quad.Positions,
        Uvs = quad.Uvs,
        Layer = RenderLayer.Solid,
        Cull = (sbyte)(quad.CullFace ?? -1),
        Facing = SectionMesh.Unaligned,
        Direction = (byte)quad.Direction,
        Tint = new TintSource(TintKind.None),
        Emission = (byte)quad.LightEmission,
        ShadeOverride = (sbyte)(quad.ShadeDirection ?? -1)
    };

    private static int Index(int x, int y, int z) => (y * Size + z) * Size + x;

    private sealed class MemoryPack : PackFiles.IPack {
        public readonly Dictionary<string, byte[]> Files = new();

        public byte[]? Read(string path) => Files.GetValueOrDefault(path);

        public bool Exists(string path) => Files.ContainsKey(path);

        public IEnumerable<string> Paths(string prefix) => Files.Keys.Where(k => k.StartsWith(prefix, StringComparison.Ordinal));

        public void Dispose() { }
    }

    private static List<Scene> Read(string path) {
        using FileStream file = File.OpenRead(path);
        using GZipStream zip = new(file, CompressionMode.Decompress);
        using BinaryReader reader = new(zip);
        string magic = Encoding.ASCII.GetString(reader.ReadBytes(8));
        Assert.That(magic, Is.EqualTo("MCBLKLT1"));
        int count = Int(reader);
        List<Scene> scenes = [];
        for (int s = 0; s < count; s++) {
            string name = Utf(reader);
            float[] cardinal = Enumerable.Range(0, 6).Select(_ => Float(reader)).ToArray();
            bool ambientOcclusion = reader.ReadByte() != 0;
            (int, int, int) centre = (reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
            int[] states = new int[Size * Size * Size];
            byte[] sky = new byte[states.Length], block = new byte[states.Length];
            for (int i = 0; i < states.Length; i++) {
                states[i] = Int(reader);
                sky[i] = reader.ReadByte();
                block[i] = reader.ReadByte();
            }
            (string, int, int)[] parts = new (string, int, int)[Int(reader)];
            for (int i = 0; i < parts.Length; i++) {
                parts[i] = (Utf(reader), Int(reader), Int(reader));
            }
            VanillaQuad[] baked = new VanillaQuad[Int(reader)];
            for (int i = 0; i < baked.Length; i++) {
                Vector3[] positions = Enumerable.Range(0, 4).Select(_ => new Vector3(Float(reader), Float(reader), Float(reader))).ToArray();
                baked[i] = new VanillaQuad(positions, (sbyte)reader.ReadByte(), (sbyte)reader.ReadByte(), (sbyte)reader.ReadByte(), (sbyte)reader.ReadByte());
            }
            Vertex[][] drawn = new Vertex[Int(reader)][];
            for (int i = 0; i < drawn.Length; i++) {
                drawn[i] = Enumerable.Range(0, 4).Select(_ => new Vertex(new Vector3(Float(reader), Float(reader), Float(reader)), Int(reader), Int(reader))).ToArray();
            }
            scenes.Add(new Scene(name, cardinal, ambientOcclusion, centre, states, sky, block, parts, baked, drawn));
        }
        return scenes;
    }

    private static int Int(BinaryReader reader) => System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(reader.ReadBytes(4));

    private static float Float(BinaryReader reader) => BitConverter.Int32BitsToSingle(Int(reader));

    private static string Utf(BinaryReader reader) {
        int length = System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(reader.ReadBytes(2));
        return Encoding.UTF8.GetString(reader.ReadBytes(length));
    }
}
