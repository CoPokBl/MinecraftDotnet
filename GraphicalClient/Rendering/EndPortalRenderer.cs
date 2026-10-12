using System.Numerics;
using System.Runtime.InteropServices;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Data.Generated;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>An end portal or end gateway block of a section, at its section local position, with the faces its renderer draws.</summary>
public readonly record struct EndPortalBlock(byte X, byte Y, byte Z, bool Gateway, byte Faces);

/// <summary>The end portal and gateway blocks of one meshed section, and where the section's lowest corner is.</summary>
public sealed record SectionEndPortals(int BaseX, int BaseY, int BaseZ, EndPortalBlock[] Blocks);

/// <summary>
/// <c>TheEndPortalRenderer</c> and <c>TheEndGatewayRenderer</c>: the faces of every end portal and gateway
/// near the camera, drawn as the <c>end_portal</c> geometry, and the two textures vanilla's
/// <c>rendertype_end_portal</c> layers over them. What a face looks like is the shader pack's to decide.
/// The gateway's beam is left out: no geometry kind expresses a scrolling texture, and the client does not
/// track a gateway's age or cooldown.
/// </summary>
public sealed unsafe class EndPortalRenderer : IDisposable {
    /// <summary><c>PORTAL_LAYERS</c> of the <c>end_portal</c> and <c>end_gateway</c> pipelines.</summary>
    public const int PortalLayers = 15, GatewayLayers = 16;

    /// <summary><c>BlockEntityRenderer.getViewDistance</c>, and <c>TheEndGatewayRenderer</c>'s override of it.</summary>
    private const int PortalViewDistance = 64, GatewayViewDistance = 256;

    /// <summary><c>TheEndPortalRenderer.TRANSFORMATION</c>: the unit cube squashed to y 0.375 to 0.75.</summary>
    private const float PortalBottom = 0.375F, PortalTop = 0.75F;

    private const byte VerticalFaces = 1 << (int)Face.Down | 1 << (int)Face.Up;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Vertex {
        public Vector3 Position;
        public uint Layers;
    }

    private readonly GL _gl;
    private readonly uint _vao, _vbo;
    private Vertex[] _vertices = new Vertex[256];
    private int _count, _uploaded, _capacity;

    /// <summary><c>textures/environment/end_sky.png</c>, sampled at the fragment's place on screen.</summary>
    public uint SkyTexture { get; }

    /// <summary><c>textures/entity/end_portal/end_portal.png</c>, which every parallax layer samples.</summary>
    public uint PortalTexture { get; }

    public EndPortalRenderer(GL gl, ResourcePackSource? pack) {
        _gl = gl;
        SkyTexture = CreateTexture(pack?.LoadFirstFrame("assets/minecraft/textures/environment/end_sky.png") ?? DevArt.EndSky());
        PortalTexture = CreateTexture(pack?.LoadFirstFrame("assets/minecraft/textures/entity/end_portal/end_portal.png") ?? DevArt.EndPortalStars());

        _vao = gl.CreateVertexArray();
        _vbo = gl.CreateBuffer();
        _gl.VertexArrayVertexBuffer(_vao, 0, _vbo, 0, (uint)sizeof(Vertex));
        gl.EnableVertexArrayAttrib(_vao, 0);
        gl.VertexArrayAttribFormat(_vao, 0, 3, VertexAttribType.Float, false, 0);
        gl.VertexArrayAttribBinding(_vao, 0, 0);
        gl.EnableVertexArrayAttrib(_vao, 1);
        gl.VertexArrayAttribIFormat(_vao, 1, 1, VertexAttribIType.UnsignedInt, 12);
        gl.VertexArrayAttribBinding(_vao, 1, 0);
    }

    /// <summary>
    /// A texture as vanilla's <c>AbstractTexture</c> samples one by default: repeating, nearest, no mipmaps.
    /// The layers' coordinates run far outside 0 to 1, so the repeat is what tiles them.
    /// </summary>
    private uint CreateTexture(TextureImage image) {
        uint texture = _gl.CreateTexture(TextureTarget.Texture2D);
        _gl.TextureStorage2D(texture, 1, SizedInternalFormat.Rgba8, (uint)image.Width, (uint)image.Height);
        fixed (byte* p = image.Rgba) {
            _gl.TextureSubImage2D(texture, 0, 0, 0, (uint)image.Width, (uint)image.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        _gl.TextureParameter(texture, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        _gl.TextureParameter(texture, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        _gl.TextureParameter(texture, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        _gl.TextureParameter(texture, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        return texture;
    }

    /// <summary>
    /// The portal and gateway blocks of a section snapshot. <c>AbstractEndPortalRenderer.extractRenderState</c>
    /// asks the block entity which faces to draw: <c>TheEndPortalBlockEntity.shouldRenderFace</c> is the two
    /// on the vertical axis whatever is next to them, and <c>TheEndGatewayBlockEntity</c>'s is
    /// <c>Block.shouldRenderFace</c> against the neighbour, which the neighbour's whole face occluding decides.
    /// Runs on a mesher thread.
    /// </summary>
    public static EndPortalBlock[] Scan(SectionSnapshot snapshot, BlockModel[] models) {
        ushort portal = (ushort)Block.EndPortal.StateId, gateway = (ushort)Block.EndGateway.StateId;
        ushort[] states = snapshot.States;
        List<EndPortalBlock>? found = null;
        for (int y = 0; y < 16; y++) {
            for (int z = 0; z < 16; z++) {
                for (int x = 0; x < 16; x++) {
                    ushort state = states[SectionSnapshot.Index(x, y, z)];
                    if (state == portal) {
                        (found ??= []).Add(new EndPortalBlock((byte)x, (byte)y, (byte)z, false, VerticalFaces));
                    }
                    else if (state == gateway) {
                        byte faces = 0;
                        for (int face = 0; face < 6; face++) {
                            (int dx, int dy, int dz) = BlockFaces.Steps[face];
                            BlockModel neighbour = models[states[SectionSnapshot.Index(x + dx, y + dy, z + dz)]];
                            if ((neighbour.OccludesFaces & (1 << (face ^ 1))) == 0) {
                                faces |= (byte)(1 << face);
                            }
                        }
                        (found ??= []).Add(new EndPortalBlock((byte)x, (byte)y, (byte)z, true, faces));
                    }
                }
            }
        }
        return found?.ToArray() ?? [];
    }

    /// <summary>
    /// The frame's faces, camera relative: every block <c>BlockEntityRenderer.shouldRender</c> keeps, its
    /// centre closer than the view distance, that is in the frustum. No GL calls.
    /// </summary>
    public void Collect(IEnumerable<SectionEndPortals> sections, Camera camera) {
        _count = 0;
        Frustum frustum = Frustum.FromMatrix(camera.View * camera.CullProjection);
        double cx = camera.Position.X, cy = camera.Position.Y, cz = camera.Position.Z;
        foreach (SectionEndPortals section in sections) {
            foreach (EndPortalBlock block in section.Blocks) {
                double x = section.BaseX + block.X - cx, y = section.BaseY + block.Y - cy, z = section.BaseZ + block.Z - cz;
                double centreX = x + 0.5, centreY = y + 0.5, centreZ = z + 0.5;
                int distance = block.Gateway ? GatewayViewDistance : PortalViewDistance;
                if (centreX * centreX + centreY * centreY + centreZ * centreZ >= distance * distance) {
                    continue;
                }
                Vector3 origin = new((float)x, (float)y, (float)z);
                if (!frustum.Intersects(origin, origin + Vector3.One)) {
                    continue;
                }
                uint layers = (uint)(block.Gateway ? GatewayLayers : PortalLayers);
                for (int face = 0; face < 6; face++) {
                    if ((block.Faces & (1 << face)) != 0) {
                        AddFace(origin, face, layers, !block.Gateway);
                    }
                }
            }
        }
    }

    private void AddFace(Vector3 origin, int face, uint layers, bool portal) {
        if (_count + 6 > _vertices.Length) {
            Array.Resize(ref _vertices, _vertices.Length * 2);
        }
        foreach (int corner in (ReadOnlySpan<int>)[0, 1, 2, 2, 3, 0]) {
            Vector3 position = new(BlockFaces.Corners[face, corner, 0], BlockFaces.Corners[face, corner, 1], BlockFaces.Corners[face, corner, 2]);
            if (portal) {
                position.Y = PortalBottom + position.Y * (PortalTop - PortalBottom);
            }
            _vertices[_count++] = new Vertex { Position = origin + position, Layers = layers };
        }
    }

    /// <summary>Sends the frame's faces to the GPU.</summary>
    public void Upload() {
        _uploaded = _count;
        if (_count == 0) {
            return;
        }
        _capacity = Math.Max(_count, _capacity);
        // Fresh storage every frame: the last frame's draws may still be reading the old.
        _gl.NamedBufferData(_vbo, (nuint)(_capacity * sizeof(Vertex)), null, GLEnum.StreamDraw);
        fixed (Vertex* v = _vertices) {
            _gl.NamedBufferSubData(_vbo, 0, (nuint)(_count * sizeof(Vertex)), v);
        }
    }

    public void Draw() {
        if (_uploaded == 0) {
            return;
        }
        _gl.BindVertexArray(_vao);
        _gl.DrawArrays(PrimitiveType.Triangles, 0, (uint)_uploaded);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
        _gl.DeleteTexture(SkyTexture);
        _gl.DeleteTexture(PortalTexture);
    }
}
