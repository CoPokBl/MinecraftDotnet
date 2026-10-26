using System.Runtime.InteropServices;
using GraphicalClient.Assets;
using GraphicalClient.Rendering.Pipeline;

namespace GraphicalClient.Rendering;

/// <summary>One corner of a quad as the GPU reads it. 20 bytes.</summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BlockVertex {
    /// <summary>Section local position plus 16, in 1/1024ths of a block.</summary>
    public ushort X, Y, Z;
    public byte Face;
    public byte Flags;

    /// <summary>Texture coordinates in 1/2048ths of the texture, so a merged face can repeat it up to 31 times.</summary>
    public ushort U, V;
    public ushort Layer;
    /// <summary>Light levels times sixteen, so averaged corners keep their fraction.</summary>
    public byte Sky, Block;
    public uint Colour;

    public const int Size = 20;
}

/// <summary>A finished mesh, one vertex array per <see cref="RenderLayer"/>.</summary>
public sealed class SectionMesh {
    public int SectionX, SectionY, SectionZ;
    public int Version;
    public int Lod;

    /// <summary>The first <see cref="VertexCount"/> are the mesh; the array may be longer, and pooled.</summary>
    public BlockVertex[] Vertices = [];
    public int VertexCount;

    /// <summary>
    /// Quads per bucket, the vertices laid out bucket after bucket. A bucket is a <see cref="RenderLayer"/>
    /// and a facing: the six <see cref="Face"/>s, then <see cref="Unaligned"/> for anything that is not
    /// axis aligned. Facing is what lets the renderer skip the faces pointing away from the camera.
    /// </summary>
    public int[] BucketQuads = [];

    public const int Facings = 7;
    public const int Unaligned = 6;
    public const int Buckets = 3 * Facings;

    public static int Bucket(RenderLayer layer, int facing) => (int)layer * Facings + facing;

    /// <summary>Which faces of the section can see each other through it, see <see cref="VisibilityGraph"/>.</summary>
    public ulong Visibility;

    public EndPortalBlock[] EndPortals = [];
}

/// <summary>
/// Turns a section snapshot into quads: every block at full detail, or coarse cells for distant terrain.
/// Holds scratch buffers, so one per worker thread.
/// </summary>
public sealed partial class SectionMesher(BlockModels models) {
    /// <summary>Set in <see cref="BlockVertex.Flags"/> for the planes plants are drawn with.</summary>
    public const byte PlantFlag = 1;

    /// <summary>Set for a fluid's surface, whose corners need not be level.</summary>
    public const byte FluidSurfaceFlag = 2;

    /// <summary>Where the shader pack's material number sits in <see cref="BlockVertex.Flags"/>, above the two flags.</summary>
    public const int MaterialShift = 2;

    /// <summary>One whole texture in <see cref="BlockVertex.U"/> and <see cref="BlockVertex.V"/>.</summary>
    public const int UvUnit = 2048;

    private readonly BlockModel[] _models = models.ByState;
    private readonly List<BlockVertex>[] _buckets = Enumerable.Range(0, SectionMesh.Buckets).Select(_ => new List<BlockVertex>(512)).ToArray();
    private readonly FaceMerger _merger = new();
    private readonly VisibilityGraph _visibility = new();

    /// <summary>The material of what is being emitted, already shifted into place in the flags.</summary>
    private byte _materialBits;

    /// <summary>The plain water state, whose model carries the water texture.</summary>
    public int WaterState { get; set; }

    /// <summary>Where vertex arrays are rented from, or null to allocate each one.</summary>
    internal VertexArrayPool? Pool { get; init; }

    private List<BlockVertex> Target(RenderLayer layer, int facing) => _buckets[SectionMesh.Bucket(layer, facing)];

    private static byte MaterialBits(byte material) => (byte)(material << MaterialShift);

    public SectionMesh Mesh(SectionSnapshot snapshot) {
        foreach (List<BlockVertex> bucket in _buckets) {
            bucket.Clear();
        }
        if (snapshot.Lod > 0) {
            MeshCoarse(snapshot, 1 << snapshot.Lod);
        }
        else {
            MeshBlocks(snapshot);
        }

        // Coarse cells always merge: unmerged they would be one quad per block of a distant cell.
        ulong unmerged = snapshot.Lod > 0 ? 0 : snapshot.Materials.Unmerged;
        int total = 0;
        foreach (List<BlockVertex> bucket in _buckets) {
            _merger.Merge(bucket, unmerged);
            total += bucket.Count;
        }
        for (int face = 0; face < 6; face++) {
            _merger.SortBackToFront(_buckets[SectionMesh.Bucket(RenderLayer.Translucent, face)], face);
        }
        BlockVertex[] vertices = Pool?.Rent(total) ?? new BlockVertex[total];
        int[] quads = new int[SectionMesh.Buckets];
        int at = 0;
        for (int i = 0; i < SectionMesh.Buckets; i++) {
            _buckets[i].CopyTo(vertices, at);
            at += _buckets[i].Count;
            quads[i] = _buckets[i].Count / 4;
        }
        return new SectionMesh {
            SectionX = snapshot.SectionX,
            SectionY = snapshot.SectionY,
            SectionZ = snapshot.SectionZ,
            Version = snapshot.Version,
            Lod = snapshot.Lod,
            Vertices = vertices,
            VertexCount = total,
            BucketQuads = quads,
            Visibility = _visibility.Resolve(snapshot, _models),
            EndPortals = EndPortalRenderer.Scan(snapshot, _models)
        };
    }

    private void MeshBlocks(SectionSnapshot snap) {
        BlockMaterials materials = snap.Materials;
        for (int y = 0; y < 16; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    ushort state = snap.States[SectionSnapshot.Index(x, y, z)];
                    BlockModel model = _models[state];
                    if (model.HasWater || model.IsLava) {
                        _materialBits = MaterialBits(materials.FluidOf(state));
                        MeshFluid(snap, x, y, z, model);
                    }
                    _materialBits = MaterialBits(materials.Of(state));
                    switch (model.Geometry) {
                        case BlockGeometry.Shape:
                            MeshShape(snap, x, y, z, model);
                            break;
                        case BlockGeometry.Cross:
                            MeshCross(snap, x, y, z, model);
                            break;
                        case BlockGeometry.Model:
                            MeshModel(snap, x, y, z, model);
                            break;
                    }
                }
            }
        }
    }

    private static (float U, float V) Uv(int face, float x, float y, float z) => face switch {
        0 => (x, 1 - z),
        1 => (x, z),
        2 => (1 - x, 1 - y),
        3 => (x, 1 - y),
        4 => (z, 1 - y),
        _ => (1 - z, 1 - y)
    };

    private static uint TintOf(SectionSnapshot snap, TintKind kind, int x, int y, int z) {
        if (kind == TintKind.None || snap.Tints.Length == 0) {
            return 0xFFFFFF;
        }
        ushort biome = snap.Biomes[(y >> 2) << 4 | (z >> 2) << 2 | x >> 2];
        if (biome >= snap.Tints.Length) {
            return 0xFFFFFF;
        }
        BiomeColours.Tints tints = snap.Tints[biome];
        return kind switch {
            TintKind.Grass => tints.Grass,
            TintKind.Foliage => tints.Foliage,
            TintKind.DryFoliage => tints.DryFoliage,
            _ => tints.Water
        };
    }

    /// <summary>A face's colour: the biome's where the model tints that face, else the one the state fixes.</summary>
    private static uint FaceTint(SectionSnapshot snap, BlockModel model, int face, int x, int y, int z) =>
        (model.TintFaces & (1 << face)) != 0 ? TintOf(snap, model.Tint, x, y, z) : model.FixedTints[face];

    private static uint QuadTint(SectionSnapshot snap, MeshQuad quad, int x, int y, int z) =>
        quad.Tint.Kind == TintKind.None ? quad.Tint.Rgb : TintOf(snap, quad.Tint.Kind, x, y, z);

    /// <param name="occlusion">Ambient occlusion, 1 for none; it travels in the colour's alpha.</param>
    /// <param name="tint">The biome colour, 0xRRGGBB, in the colour's other three channels.</param>
    private BlockVertex Vertex(float x, float y, float z, float u, float v, ushort layer, float sky, float block, float occlusion, int face,
        uint tint = 0xFFFFFF, byte flags = 0) {
        int r = (int)((tint >> 16) & 0xFF);
        int g = (int)((tint >> 8) & 0xFF);
        int b = (int)(tint & 0xFF);
        int a = Math.Clamp((int)(occlusion * 255.0F), 0, 255);
        return new BlockVertex {
            X = (ushort)((x + 16.0F) * 1024.0F),
            Y = (ushort)((y + 16.0F) * 1024.0F),
            Z = (ushort)((z + 16.0F) * 1024.0F),
            Face = (byte)face,
            Flags = (byte)(flags | _materialBits),
            U = (ushort)(Math.Clamp(u, 0.0F, 1.0F) * UvUnit),
            V = (ushort)(Math.Clamp(v, 0.0F, 1.0F) * UvUnit),
            Layer = layer,
            Sky = (byte)Math.Clamp((int)(sky * 16.0F), 0, 240),
            Block = (byte)Math.Clamp((int)(block * 16.0F), 0, 240),
            Colour = (uint)(a << 24 | b << 16 | g << 8 | r)
        };
    }
}
