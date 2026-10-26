using System.Numerics;

namespace GraphicalClient.Rendering.Entities;

/// <summary><c>PartPose</c>: a part's offset in sixteenths, rotation in radians (applied Z, Y, X) and scale.</summary>
public readonly record struct PartPose(float X, float Y, float Z, float XRot, float YRot, float ZRot, float XScale = 1, float YScale = 1, float ZScale = 1) {
    public static readonly PartPose Zero = OffsetAndRotation(0, 0, 0, 0, 0, 0);

    public static PartPose Offset(float x, float y, float z) => OffsetAndRotation(x, y, z, 0, 0, 0);
    public static PartPose Rotation(float x, float y, float z) => OffsetAndRotation(0, 0, 0, x, y, z);
    public static PartPose OffsetAndRotation(float x, float y, float z, float xRot, float yRot, float zRot) => new(x, y, z, xRot, yRot, zRot);

    public PartPose Translated(float x, float y, float z) => this with { X = X + x, Y = Y + y, Z = Z + z };
    public PartPose WithScale(float scale) => this with { XScale = scale, YScale = scale, ZScale = scale };
    public PartPose Scaled(float factor) => factor == 1 ? this : Scaled(factor, factor, factor);

    public PartPose Scaled(float x, float y, float z) =>
        this with { X = X * x, Y = Y * y, Z = Z * z, XScale = XScale * x, YScale = YScale * y, ZScale = ZScale * z };
}

/// <summary><c>CubeDeformation</c>: how far a cube grows past its nominal box on each axis, for overlay layers.</summary>
public readonly record struct CubeDeformation(float GrowX, float GrowY, float GrowZ) {
    public static readonly CubeDeformation None = new(0);

    public CubeDeformation(float grow) : this(grow, grow, grow) { }

    public CubeDeformation Extend(float factor) => new(GrowX + factor, GrowY + factor, GrowZ + factor);
    public CubeDeformation Extend(float x, float y, float z) => new(GrowX + x, GrowY + y, GrowZ + z);
}

/// <summary>A cube face; vanilla's <c>Direction</c> as cube visibility uses it.</summary>
[Flags]
public enum CubeFaces : byte {
    Down = 1, Up = 2, North = 4, South = 8, West = 16, East = 32, All = 63
}

/// <summary><c>CubeDefinition</c>.</summary>
public sealed record CubeDefinition(float XTexOffs, float YTexOffs, Vector3 Origin, Vector3 Dimensions, CubeDeformation Grow, bool Mirror,
    float XTexScale, float YTexScale, CubeFaces VisibleFaces) {
    public ModelPart.Cube Bake(int texWidth, int texHeight) => new(
        (int)XTexOffs, (int)YTexOffs, Origin.X, Origin.Y, Origin.Z, Dimensions.X, Dimensions.Y, Dimensions.Z,
        Grow.GrowX, Grow.GrowY, Grow.GrowZ, Mirror, texWidth * XTexScale, texHeight * YTexScale, VisibleFaces);
}

/// <summary><c>CubeListBuilder</c>: the texture offset and mirror flag carry over to every box added after them.</summary>
public sealed class CubeListBuilder {
    private readonly List<CubeDefinition> _cubes = [];
    private int _xTexOffs, _yTexOffs;
    private bool _mirror;

    public static CubeListBuilder Create() => new();

    public CubeListBuilder TexOffs(int x, int y) {
        _xTexOffs = x;
        _yTexOffs = y;
        return this;
    }

    public CubeListBuilder Mirror(bool mirror = true) {
        _mirror = mirror;
        return this;
    }

    private CubeListBuilder Add(float x, float y, float z, float w, float h, float d, CubeDeformation grow, bool mirror, float xTexScale = 1, float yTexScale = 1,
        CubeFaces faces = CubeFaces.All) {
        _cubes.Add(new CubeDefinition(_xTexOffs, _yTexOffs, new Vector3(x, y, z), new Vector3(w, h, d), grow, mirror, xTexScale, yTexScale, faces));
        return this;
    }

    public CubeListBuilder AddBox(float x, float y, float z, float w, float h, float d) => Add(x, y, z, w, h, d, CubeDeformation.None, _mirror);
    public CubeListBuilder AddBox(float x, float y, float z, float w, float h, float d, CubeFaces faces) => Add(x, y, z, w, h, d, CubeDeformation.None, _mirror, faces: faces);
    public CubeListBuilder AddBox(float x, float y, float z, float w, float h, float d, bool mirror) => Add(x, y, z, w, h, d, CubeDeformation.None, mirror);
    public CubeListBuilder AddBox(float x, float y, float z, float w, float h, float d, CubeDeformation grow) => Add(x, y, z, w, h, d, grow, _mirror);

    public CubeListBuilder AddBox(float x, float y, float z, float w, float h, float d, CubeDeformation grow, float xTexScale, float yTexScale) =>
        Add(x, y, z, w, h, d, grow, _mirror, xTexScale, yTexScale);

    /// <summary>The named overloads: the name is a comment in vanilla, and the offset sets the builder's for later boxes too.</summary>
    public CubeListBuilder AddBox(string name, float x, float y, float z, float w, float h, float d) => AddBox(x, y, z, w, h, d);

    public CubeListBuilder AddBox(string name, float x, float y, float z, float w, float h, float d, CubeDeformation grow) => AddBox(x, y, z, w, h, d, grow);

    public CubeListBuilder AddBox(string name, float x, float y, float z, int w, int h, int d, int xTexOffs, int yTexOffs) =>
        TexOffs(xTexOffs, yTexOffs).AddBox(x, y, z, w, h, d);

    public CubeListBuilder AddBox(string name, float x, float y, float z, int w, int h, int d, CubeDeformation grow, int xTexOffs, int yTexOffs) =>
        TexOffs(xTexOffs, yTexOffs).AddBox(x, y, z, w, h, d, grow);

    public IReadOnlyList<CubeDefinition> Cubes => _cubes;
}

/// <summary><c>PartDefinition</c>: children keep their insertion order; replacing a child keeps the old one's children.</summary>
public sealed class PartDefinition {
    private readonly IReadOnlyList<CubeDefinition> _cubes;
    private readonly List<(string Name, PartDefinition Part)> _children = [];

    public PartPose Pose { get; }

    internal PartDefinition(IReadOnlyList<CubeDefinition> cubes, PartPose pose) {
        _cubes = cubes;
        Pose = pose;
    }

    public IReadOnlyList<(string Name, PartDefinition Part)> Children => _children;

    public PartDefinition AddOrReplaceChild(string name, CubeListBuilder cubes, PartPose pose) =>
        AddOrReplaceChild(name, new PartDefinition(cubes.Cubes.ToList(), pose));

    public PartDefinition AddOrReplaceChild(string name, PartDefinition child) {
        int index = _children.FindIndex(c => c.Name == name);
        if (index >= 0) {
            foreach ((string n, PartDefinition p) in _children[index].Part._children) {
                if (child._children.All(c => c.Name != n)) {
                    child._children.Add((n, p));
                }
            }
            _children[index] = (name, child);
        }
        else {
            _children.Add((name, child));
        }
        return child;
    }

    public PartDefinition GetChild(string name) => _children.First(c => c.Name == name).Part;

    public PartDefinition ClearChild(string name) => AddOrReplaceChild(name, CubeListBuilder.Create(), GetChild(name).Pose);

    public PartDefinition ClearRecursively() {
        foreach (string name in _children.Select(c => c.Name).ToList()) {
            ClearChild(name).ClearRecursively();
        }
        return this;
    }

    public PartDefinition Transformed(Func<PartPose, PartPose> function) {
        PartDefinition part = new(_cubes, function(Pose));
        part._children.AddRange(_children);
        return part;
    }

    public ModelPart Bake(int texWidth, int texHeight) {
        ModelPart part = new(_cubes.Select(c => c.Bake(texWidth, texHeight)).ToList(),
            _children.Select(c => (c.Name, c.Part.Bake(texWidth, texHeight))).ToList());
        part.InitialPose = Pose;
        part.LoadPose(Pose);
        return part;
    }
}

/// <summary><c>MeshDefinition</c>.</summary>
public sealed class MeshDefinition {
    public PartDefinition Root { get; }

    public MeshDefinition() : this(new PartDefinition([], PartPose.Zero)) { }

    private MeshDefinition(PartDefinition root) {
        Root = root;
    }

    public MeshDefinition Transformed(Func<PartPose, PartPose> function) => new(Root.Transformed(function));

    public MeshDefinition Apply(MeshTransformer transformer) => transformer(this);
}

/// <summary><c>MeshTransformer</c>.</summary>
public delegate MeshDefinition MeshTransformer(MeshDefinition mesh);

public static class MeshTransformers {
    public static readonly MeshTransformer Identity = mesh => mesh;

    /// <summary><c>MeshTransformer.scaling</c>: shrinks about the feet rather than the origin.</summary>
    public static MeshTransformer Scaling(float factor) {
        float yOffset = 24.016F * (1.0F - factor);
        return mesh => mesh.Transformed(pose => pose.Scaled(factor).Translated(0, yOffset, 0));
    }
}

/// <summary><c>BabyModelTransform</c>: a baby is the adult's parts shrunk, the head by less than the body.</summary>
public sealed record BabyModelTransform(bool ScaleHead, float BabyYHeadOffset, float BabyZHeadOffset, float BabyHeadScale, float BabyBodyScale, float BodyYOffset,
    IReadOnlySet<string> HeadParts) {
    public BabyModelTransform(IReadOnlySet<string> headParts) : this(false, 5.0F, 2.0F, headParts) { }

    public BabyModelTransform(bool scaleHead, float babyYHeadOffset, float babyZHeadOffset, IReadOnlySet<string> headParts)
        : this(scaleHead, babyYHeadOffset, babyZHeadOffset, 2.0F, 2.0F, 24.0F, headParts) { }

    public MeshDefinition Apply(MeshDefinition mesh) {
        float headScale = ScaleHead ? 1.5F / BabyHeadScale : 1.0F;
        float bodyScale = 1.0F / BabyBodyScale;
        MeshDefinition baby = new();
        foreach ((string name, PartDefinition part) in mesh.Root.Children) {
            baby.Root.AddOrReplaceChild(name, part.Transformed(HeadParts.Contains(name)
                ? p => p.Translated(0, BabyYHeadOffset, BabyZHeadOffset).Scaled(headScale)
                : p => p.Translated(0, BodyYOffset, 0).Scaled(bodyScale)));
        }
        return baby;
    }

    public static implicit operator MeshTransformer(BabyModelTransform transform) => transform.Apply;
}

/// <summary><c>LayerDefinition</c>: a mesh and the size of the texture its UVs are in.</summary>
public sealed class LayerDefinition {
    private readonly MeshDefinition _mesh;
    public int TexWidth { get; }
    public int TexHeight { get; }

    private LayerDefinition(MeshDefinition mesh, int texWidth, int texHeight) {
        _mesh = mesh;
        TexWidth = texWidth;
        TexHeight = texHeight;
    }

    public static LayerDefinition Create(MeshDefinition mesh, int texWidth, int texHeight) => new(mesh, texWidth, texHeight);

    public LayerDefinition Apply(MeshTransformer transformer) => new(transformer(_mesh), TexWidth, TexHeight);

    public ModelPart BakeRoot() => _mesh.Root.Bake(TexWidth, TexHeight);
}

/// <summary>
/// <c>ModelPart</c>: a baked part whose pose a model's <c>setupAnim</c> changes each frame, and which it
/// resets to <see cref="InitialPose"/> first.
/// </summary>
public sealed class ModelPart {
    public float X, Y, Z;
    public float XRot, YRot, ZRot;
    public float XScale = 1, YScale = 1, ZScale = 1;
    public bool Visible = true;
    public bool SkipDraw;
    public PartPose InitialPose;

    private readonly Cube[] _cubes;
    private readonly List<(string Name, ModelPart Part)> _children;

    public IReadOnlyList<Cube> Cubes => _cubes;

    public ModelPart(IReadOnlyList<Cube> cubes, List<(string Name, ModelPart Part)> children) {
        _cubes = [.. cubes];
        _children = children;
    }

    public IEnumerable<ModelPart> Children => _children.Select(c => c.Part);

    public ModelPart GetChild(string name) {
        foreach ((string n, ModelPart part) in _children) {
            if (n == name) {
                return part;
            }
        }
        throw new KeyNotFoundException($"Can't find part {name}");
    }

    public void LoadPose(PartPose pose) {
        (X, Y, Z, XRot, YRot, ZRot) = (pose.X, pose.Y, pose.Z, pose.XRot, pose.YRot, pose.ZRot);
        (XScale, YScale, ZScale) = (pose.XScale, pose.YScale, pose.ZScale);
    }

    public void ResetPose() => LoadPose(InitialPose);

    public void SetPos(float x, float y, float z) => (X, Y, Z) = (x, y, z);

    public void SetRotation(float x, float y, float z) => (XRot, YRot, ZRot) = (x, y, z);

    public void CopyFrom(ModelPart other) {
        (XScale, YScale, ZScale) = (other.XScale, other.YScale, other.ZScale);
        (XRot, YRot, ZRot) = (other.XRot, other.YRot, other.ZRot);
        (X, Y, Z) = (other.X, other.Y, other.Z);
    }

    public void OffsetPos(Vector3 offset) => (X, Y, Z) = (X + offset.X, Y + offset.Y, Z + offset.Z);
    public void OffsetRotation(Vector3 offset) => (XRot, YRot, ZRot) = (XRot + offset.X, YRot + offset.Y, ZRot + offset.Z);
    public void OffsetScale(Vector3 offset) => (XScale, YScale, ZScale) = (XScale + offset.X, YScale + offset.Y, ZScale + offset.Z);

    /// <summary>Every part in the tree, this one first, as <c>getAllParts</c> lists them.</summary>
    public List<ModelPart> AllParts() {
        List<ModelPart> parts = [this];
        Collect(parts);
        return parts;
    }

    private void Collect(List<ModelPart> into) {
        foreach ((_, ModelPart child) in _children) {
            into.Add(child);
        }
        foreach ((_, ModelPart child) in _children) {
            child.Collect(into);
        }
    }

    /// <summary><c>createPartLookup</c>: every part by name, "root" included, for keyframe animations.</summary>
    public Dictionary<string, ModelPart> PartLookup() {
        Dictionary<string, ModelPart> parts = new() { ["root"] = this };
        AddAll(parts);
        return parts;
    }

    private void AddAll(Dictionary<string, ModelPart> into) {
        foreach ((string name, ModelPart child) in _children) {
            into.TryAdd(name, child);
        }
        foreach ((_, ModelPart child) in _children) {
            child.AddAll(into);
        }
    }

    /// <summary><c>translateAndRotate</c>.</summary>
    public void TranslateAndRotate(PoseStack pose) {
        pose.Translate(X / 16.0F, Y / 16.0F, Z / 16.0F);
        if (XRot != 0 || YRot != 0 || ZRot != 0) {
            pose.RotateZYX(ZRot, YRot, XRot);
        }
        if (XScale != 1 || YScale != 1 || ZScale != 1) {
            pose.Scale(XScale, YScale, ZScale);
        }
    }

    /// <summary><c>getExtentsForGui</c>: every vertex of the tree, through its poses.</summary>
    public void GetExtentsForGui(PoseStack pose, Action<Vector3> output) {
        if (Cubes.Count == 0 && _children.Count == 0) {
            return;
        }
        pose.Push();
        TranslateAndRotate(pose);
        foreach (Cube cube in Cubes) {
            foreach (Polygon polygon in cube.Polygons) {
                foreach (Vertex vertex in polygon.Vertices) {
                    output(Vector3.Transform(new Vector3(vertex.X / 16.0F, vertex.Y / 16.0F, vertex.Z / 16.0F), pose.Matrix));
                }
            }
        }
        foreach ((_, ModelPart child) in _children) {
            child.GetExtentsForGui(pose, output);
        }
        pose.Pop();
    }

    public void Render(PoseStack pose, IModelSink sink, ModelDrawState draw) {
        if (!Visible || (_cubes.Length == 0 && _children.Count == 0)) {
            return;
        }
        pose.Push();
        TranslateAndRotate(pose);
        if (!SkipDraw) {
            foreach (Cube cube in _cubes) {
                cube.Compile(pose, sink, draw);
            }
        }
        foreach ((_, ModelPart child) in _children) {
            child.Render(pose, sink, draw);
        }
        pose.Pop();
    }

    /// <summary><c>ModelPart.Cube</c>: six polygons in vanilla's vertex and texture order.</summary>
    public sealed class Cube {
        public readonly Polygon[] Polygons;

        public Cube(int xTexOffs, int yTexOffs, float minX, float minY, float minZ, float width, float height, float depth,
            float growX, float growY, float growZ, bool mirror, float xTexSize, float yTexSize, CubeFaces visibleFaces) {
            float maxX = minX + width, maxY = minY + height, maxZ = minZ + depth;
            minX -= growX;
            minY -= growY;
            minZ -= growZ;
            maxX += growX;
            maxY += growY;
            maxZ += growZ;
            if (mirror) {
                (maxX, minX) = (minX, maxX);
            }

            Vertex t0 = new(minX, minY, minZ, 0, 0), t1 = new(maxX, minY, minZ, 0, 8), t2 = new(maxX, maxY, minZ, 8, 8), t3 = new(minX, maxY, minZ, 8, 0);
            Vertex l0 = new(minX, minY, maxZ, 0, 0), l1 = new(maxX, minY, maxZ, 0, 8), l2 = new(maxX, maxY, maxZ, 8, 8), l3 = new(minX, maxY, maxZ, 8, 0);
            float u0 = xTexOffs, u1 = xTexOffs + depth, u2 = xTexOffs + depth + width, u22 = xTexOffs + depth + width + width;
            float u3 = xTexOffs + depth + width + depth, u4 = xTexOffs + depth + width + depth + width;
            float v0 = yTexOffs, v1 = yTexOffs + depth, v2 = yTexOffs + depth + height;

            List<Polygon> polygons = [];
            if ((visibleFaces & CubeFaces.Down) != 0) polygons.Add(new Polygon([l1, l0, t0, t1], u1, v0, u2, v1, xTexSize, yTexSize, mirror, new Vector3(0, -1, 0)));
            if ((visibleFaces & CubeFaces.Up) != 0) polygons.Add(new Polygon([t2, t3, l3, l2], u2, v1, u22, v0, xTexSize, yTexSize, mirror, new Vector3(0, 1, 0)));
            if ((visibleFaces & CubeFaces.West) != 0) polygons.Add(new Polygon([t0, l0, l3, t3], u0, v1, u1, v2, xTexSize, yTexSize, mirror, new Vector3(-1, 0, 0)));
            if ((visibleFaces & CubeFaces.North) != 0) polygons.Add(new Polygon([t1, t0, t3, t2], u1, v1, u2, v2, xTexSize, yTexSize, mirror, new Vector3(0, 0, -1)));
            if ((visibleFaces & CubeFaces.East) != 0) polygons.Add(new Polygon([l1, t1, t2, l2], u2, v1, u3, v2, xTexSize, yTexSize, mirror, new Vector3(1, 0, 0)));
            if ((visibleFaces & CubeFaces.South) != 0) polygons.Add(new Polygon([l0, l1, l2, l3], u3, v1, u4, v2, xTexSize, yTexSize, mirror, new Vector3(0, 0, 1)));
            Polygons = polygons.ToArray();
        }

        public void Compile(PoseStack pose, IModelSink sink, ModelDrawState draw) {
            Matrix4x4 matrix = pose.Matrix;
            Span<Vector3> corners = stackalloc Vector3[4];
            foreach (Polygon polygon in Polygons) {
                Vector3 normal = pose.TransformNormal(polygon.Normal);
                Vector3[] positions = polygon.Positions;
                for (int i = 0; i < 4; i++) {
                    corners[i] = Vector3.Transform(positions[i], matrix);
                }
                sink.Quad(corners, polygon.Uvs, normal, draw);
            }
        }
    }

    /// <summary><c>ModelPart.Polygon</c>: the face's texture rectangle mapped to its corners, reversed when mirrored.</summary>
    public sealed class Polygon {
        public readonly Vertex[] Vertices;
        public readonly Vector3 Normal;

        /// <summary><see cref="Vertices"/> in blocks rather than sixteenths, and their texture coordinates.</summary>
        public readonly Vector3[] Positions;
        public readonly Vector2[] Uvs;

        public Polygon(Vertex[] vertices, float u0, float v0, float u1, float v1, float xTexSize, float yTexSize, bool mirror, Vector3 normal) {
            // A mirrored cube's X faces swap sides, so their normals swap with them.
            Normal = mirror && normal.X != 0 ? -normal : normal;
            Vertices = [
                vertices[0].Remap(u1 / xTexSize, v0 / yTexSize),
                vertices[1].Remap(u0 / xTexSize, v0 / yTexSize),
                vertices[2].Remap(u0 / xTexSize, v1 / yTexSize),
                vertices[3].Remap(u1 / xTexSize, v1 / yTexSize)
            ];
            if (mirror) {
                Array.Reverse(Vertices);
            }
            Positions = Array.ConvertAll(Vertices, v => new Vector3(v.X / 16.0F, v.Y / 16.0F, v.Z / 16.0F));
            Uvs = Array.ConvertAll(Vertices, v => new Vector2(v.U, v.V));
        }
    }

    public readonly record struct Vertex(float X, float Y, float Z, float U, float V) {
        public Vertex Remap(float u, float v) => this with { U = u, V = v };
    }
}

/// <summary>Where a model's quads go: one call per face, corners in the pose's space, texture coordinates 0 to 1.</summary>
public interface IModelSink {
    void Quad(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, Vector3 normal, ModelDrawState draw);

    /// <summary>The glint over a quad drawn at the same corners, its texture coordinates before the glint's texturing; dropped where nothing glints.</summary>
    void Glint(ReadOnlySpan<Vector3> corners, ReadOnlySpan<Vector2> uvs, GlintType type) { }
}

public static class ModelSinkExtensions {
    /// <summary>A rectangle in the pose's XY plane, facing up through the pose as the billboarded sprites set their normal.</summary>
    public static void FlatQuad(this IModelSink sink, PoseStack pose, float x0, float y0, float x1, float y1, float u0, float v0, float u1, float v1, ModelDrawState draw) {
        Matrix4x4 matrix = pose.Matrix;
        ReadOnlySpan<Vector3> corners = [
            Vector3.Transform(new Vector3(x0, y0, 0.0F), matrix), Vector3.Transform(new Vector3(x1, y0, 0.0F), matrix),
            Vector3.Transform(new Vector3(x1, y1, 0.0F), matrix), Vector3.Transform(new Vector3(x0, y1, 0.0F), matrix)
        ];
        ReadOnlySpan<Vector2> uvs = [new(u0, v1), new(u1, v1), new(u1, v0), new(u0, v0)];
        sink.Quad(corners, uvs, pose.TransformNormal(Vector3.UnitY), draw);
    }
}

/// <summary>What a draw call carries besides geometry: the texture, the tint, light and the hurt overlay.</summary>
public readonly record struct ModelDrawState(EntityTexture Texture, uint Argb, float SkyLight, float BlockLight, float RedOverlay, float WhiteOverlay = 0) {
    /// <summary>
    /// Leaves the quad out of the glowing outline, as vanilla's render types without an outline do: eyes,
    /// emissive, swirling and custom geometry.
    /// </summary>
    public bool NoOutline { get; init; }

    /// <summary>Vanilla's <c>EMISSIVE</c> render types: the lightmap is left out, so the light coordinates mean nothing.</summary>
    public bool Emissive { get; init; }

    /// <summary>
    /// Vanilla's <c>NO_CARDINAL_LIGHTING</c> render types (eyes, swirls, the breeze's wind, beams, leashes): not shaded
    /// by the two directional lights, so the normal means nothing.
    /// </summary>
    public bool Unshaded { get; init; }

    /// <summary>Lit as <paramref name="state"/> is, without an overlay.</summary>
    public ModelDrawState(EntityTexture texture, EntityRenderState state, uint argb = 0xFFFFFFFF) : this(texture, argb, state.SkyLight, state.BlockLight, 0) { }
}

/// <summary><c>ARGB</c>.</summary>
public static class Argb {
    /// <summary><c>ARGB.multiply</c>: each channel the product of the two, over 255.</summary>
    public static uint Multiply(uint a, uint b) {
        uint Channel(int shift) => ((a >> shift) & 0xFF) * ((b >> shift) & 0xFF) / 255;
        return Channel(24) << 24 | Channel(16) << 16 | Channel(8) << 8 | Channel(0);
    }
}
