using System.Numerics;
using GraphicalClient.Assets.ResourcePacks;
using GraphicalClient.Gui;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// <c>Panorama</c> and <c>CubeMap</c>: the six <c>panorama_N</c> faces from the resource pack turning behind
/// the menus, and the pack's overlay over them. A pack without real faces (the jar's are one pixel stand-ins
/// for those in the asset index) gets this client's own scrolling skyline instead.
/// </summary>
public sealed unsafe class PanoramaRenderer(GL gl) : IDisposable {
    private const string Base = "gui/title/background/panorama";

    /// <summary><c>CubeMapTexture.SUFFIXES</c>: the panorama files in the cube map's layer order, +X, -X, +Y, -Y, +Z, -Z.</summary>
    private static readonly int[] FaceFiles = [1, 3, 5, 4, 0, 2];

    private const string Vertex = """
        #version 450 core
        layout(location = 0) in vec3 aPos;
        uniform mat4 uMvp;
        out vec3 vDirection;
        void main() {
            gl_Position = uMvp * vec4(aPos, 1.0);
            vDirection = aPos;
        }
        """;

    private const string Fragment = """
        #version 450 core
        in vec3 vDirection;
        uniform samplerCube uCube;
        out vec4 fragColour;
        void main() {
            fragColour = texture(uCube, vDirection);
        }
        """;

    private ShaderProgram? _shader;
    private uint _texture, _vao, _vbo;
    private bool _loaded;
    private double _nextLoad;
    private GuiSprites? _loadedFrom;
    private float _spin;

    /// <summary><c>Panorama.extractRenderState</c>: turns by the frame's real time ticks, then draws over the whole GUI.</summary>
    public void Render(GuiContext context, float realtimeDeltaTicks, double nowSeconds) {
        float delta = realtimeDeltaTicks * (float)(context.Settings?.PanoramaSpeed ?? 1.0);
        _spin = WrapDegrees(_spin + delta * 0.1F);
        GuiSprites sprites = context.Sprites;
        if (sprites != _loadedFrom) {
            // A pack reload replaces the sprites, and the faces with them.
            Dispose();
            _loaded = false;
            _nextLoad = 0;
            _loadedFrom = sprites;
        }
        if (!_loaded && nowSeconds >= _nextLoad) {
            _loaded = Load(sprites);
            _nextLoad = nowSeconds + 2.0;
        }
        GuiRenderer gui = context.Gui;
        if (_loaded) {
            gui.Flush();
            DrawCube(gui.Width, gui.Height, 10.0F, -_spin);
            gui.Begin(gui.Width, gui.Height);
        }
        else {
            OwnArt(context, _spin);
        }
        context.Sprites.Stretched(gui, "gui/title/background/panorama_overlay", 0, 0, context.Width, context.Height, 0, 0, 1, 1);
    }

    private static float WrapDegrees(float degrees) {
        float wrapped = degrees % 360.0F;
        if (wrapped >= 180.0F) {
            wrapped -= 360.0F;
        }
        if (wrapped < -180.0F) {
            wrapped += 360.0F;
        }
        return wrapped;
    }

    private bool Load(GuiSprites sprites) {
        TextureImage?[] faces = FaceFiles.Select(i => sprites.Texture($"{Base}_{i}")).ToArray();
        if (faces.Any(face => face == null || face.Width <= 1 || face.Width != faces[0]!.Width || face.Height != faces[0]!.Height)) {
            return false;
        }
        _texture = gl.GenTexture();
        gl.BindTexture(TextureTarget.TextureCubeMap, _texture);
        for (int i = 0; i < 6; i++) {
            TextureImage face = faces[i]!;
            // copyRect(..., flipY true): each face goes in bottom row first.
            byte[] flipped = new byte[face.Rgba.Length];
            int row = face.Width * 4;
            for (int y = 0; y < face.Height; y++) {
                Array.Copy(face.Rgba, y * row, flipped, (face.Height - 1 - y) * row, row);
            }
            fixed (byte* p = flipped) {
                gl.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, InternalFormat.Rgba8, (uint)face.Width, (uint)face.Height, 0, PixelFormat.Rgba,
                    PixelType.UnsignedByte, p);
            }
        }
        // TextureMetadataSection(blur true, clamp false): linear filtering.
        gl.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        gl.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
        gl.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
        gl.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);
        gl.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (int)TextureWrapMode.ClampToEdge);

        _shader = new ShaderProgram(gl, Vertex, Fragment);
        // CubeMap.initializeVertices, each quad as two triangles.
        float[] quads = [
            -1, -1, 1, -1, 1, 1, 1, 1, 1, 1, -1, 1,
            1, -1, 1, 1, 1, 1, 1, 1, -1, 1, -1, -1,
            1, -1, -1, 1, 1, -1, -1, 1, -1, -1, -1, -1,
            -1, -1, -1, -1, 1, -1, -1, 1, 1, -1, -1, 1,
            -1, -1, -1, -1, -1, 1, 1, -1, 1, 1, -1, -1,
            -1, 1, 1, -1, 1, -1, 1, 1, -1, 1, 1, 1
        ];
        List<float> triangles = [];
        for (int quad = 0; quad < 6; quad++) {
            foreach (int corner in (int[])[0, 1, 2, 0, 2, 3]) {
                triangles.AddRange(quads.AsSpan(quad * 12 + corner * 3, 3).ToArray());
            }
        }
        _vao = gl.CreateVertexArray();
        _vbo = gl.CreateBuffer();
        float[] data = triangles.ToArray();
        fixed (float* p = data) {
            gl.NamedBufferData(_vbo, (nuint)(data.Length * sizeof(float)), p, GLEnum.StaticDraw);
        }
        gl.VertexArrayVertexBuffer(_vao, 0, _vbo, 0, 3 * sizeof(float));
        gl.EnableVertexArrayAttrib(_vao, 0);
        gl.VertexArrayAttribFormat(_vao, 0, 3, VertexAttribType.Float, false, 0);
        gl.VertexArrayAttribBinding(_vao, 0, 0);
        return true;
    }

    /// <summary>
    /// <c>CubeMap.render</c>: an 85 degree view from inside the cube, turned upside down by <c>rotationX(PI)</c>
    /// as vanilla's model view is, then tilted and spun.
    /// </summary>
    private void DrawCube(int width, int height, float rotX, float rotY) {
        Matrix4x4 modelView = Matrix4x4.CreateRotationY(rotY * MathF.PI / 180.0F) * Matrix4x4.CreateRotationX(rotX * MathF.PI / 180.0F)
                              * Matrix4x4.CreateRotationX(MathF.PI);
        Matrix4x4 projection = Matrix4x4.CreatePerspectiveFieldOfView(85.0F * MathF.PI / 180.0F, height == 0 ? 1 : (float)width / height, 0.05F, 10.0F);
        Matrix4x4 mvp = modelView * projection;
        gl.Disable(EnableCap.Blend);
        _shader!.Use();
        gl.UniformMatrix4(gl.GetUniformLocation(_shader.Handle, "uMvp"), 1, false, (float*)&mvp);
        _shader.Set("uCube", 0);
        gl.ActiveTexture(TextureUnit.Texture0);
        gl.BindTexture(TextureTarget.TextureCubeMap, _texture);
        gl.BindVertexArray(_vao);
        gl.DrawArrays(PrimitiveType.Triangles, 0, 36);
        gl.BindVertexArray(0);
    }

    /// <summary>This client's own backdrop: a dusk sky over block hills, sliding with the spin.</summary>
    private static void OwnArt(GuiContext context, float spin) {
        GuiRenderer gui = context.Gui;
        int w = context.Width, h = context.Height;
        const int bands = 24;
        for (int i = 0; i < bands; i++) {
            float t = i / (float)(bands - 1);
            uint r = (uint)(24 + t * 70), g = (uint)(40 + t * 80), b = (uint)(86 + t * 70);
            gui.Rect(0, h * i / (float)bands, w, h / (float)bands + 1, 0xFF000000 | r << 16 | g << 8 | b);
        }
        const int column = 8;
        float offset = (spin + 180.0F) / 360.0F * 64 * column;
        for (int layer = 0; layer < 2; layer++) {
            uint colour = layer == 0 ? 0xFF2E4A3A : 0xFF1C2E24;
            float speed = layer == 0 ? 0.5F : 1.0F;
            float shift = offset * speed % column;
            int first = (int)Math.Floor(offset * speed / column);
            for (int x = -1; x <= w / column + 1; x++) {
                int hill = Hill(first + x, layer);
                float top = h * (layer == 0 ? 0.55F : 0.7F) - hill * column;
                gui.Rect(x * column - shift, top, column, h - top, colour);
            }
        }
    }

    private static int Hill(int x, int layer) {
        uint hash = (uint)(x * 73856093 ^ layer * 19349663);
        hash ^= hash >> 13;
        hash *= 0x5bd1e995;
        hash ^= hash >> 15;
        return (int)(hash % 5) + (int)(2 * MathF.Sin(x * 0.3F + layer) + 2);
    }

    public void Dispose() {
        if (_texture != 0) {
            gl.DeleteTexture(_texture);
            gl.DeleteVertexArray(_vao);
            gl.DeleteBuffer(_vbo);
            _shader?.Dispose();
            _texture = 0;
        }
    }
}
