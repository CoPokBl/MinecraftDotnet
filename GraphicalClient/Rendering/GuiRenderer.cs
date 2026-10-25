using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering;

/// <summary>
/// Batches screen space quads, coloured or textured, and draws them in one call per texture. Pixel
/// coordinates with the origin top left, as the HUD is laid out.
/// </summary>
public sealed unsafe class GuiRenderer : IDisposable {
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct GuiVertex {
        public float X, Y, U, V;
        public uint Colour;

        /// <summary>0 for a plain rectangle, which then shares a batch with whatever texture is bound rather than flushing it.</summary>
        public float Textured;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct GlintVertex {
        public float X, Y, U, V, GlintU, GlintV;
    }

    private readonly GL _gl;
    private readonly ShaderProgram _shader, _glintShader;
    private readonly uint _glintVao, _glintVbo;
    private readonly uint _vao;
    private readonly uint _vbo;
    private readonly uint _white;
    private GuiVertex[] _vertices = new GuiVertex[4096];
    private int _count;
    private uint _texture;

    public int Width { get; private set; }
    public int Height { get; private set; }

    /// <summary>The HUD's pixel scale, vanilla's GUI scale: 1 HUD pixel is this many screen pixels.</summary>
    public int Scale { get; private set; } = 2;

    /// <summary>Extra magnification on top of <see cref="Scale"/>, for titles. Coordinates are in zoomed pixels.</summary>
    public float Zoom { get; set; } = 1.0F;

    /// <summary>A transform of HUD pixels applied to every quad until reset, as a <c>pose</c> turns the title screen's splash.</summary>
    public Matrix3x2 Pose { get; set; } = Matrix3x2.Identity;

    /// <summary><c>Window.getGuiScaledWidth</c>: rounded up, so a layout centred on it lands where vanilla's does.</summary>
    public int ScaledWidth => (Width + Scale - 1) / Scale;

    /// <inheritdoc cref="ScaledWidth"/>
    public int ScaledHeight => (Height + Scale - 1) / Scale;

    public GuiRenderer(GL gl) {
        _gl = gl;
        _shader = new ShaderProgram(gl, Shaders.GuiVertex, Shaders.GuiFragment);
        _vao = gl.GenVertexArray();
        gl.BindVertexArray(_vao);
        _vbo = gl.GenBuffer();
        gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);
        uint stride = (uint)sizeof(GuiVertex);
        gl.EnableVertexAttribArray(0);
        gl.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, stride, (void*)0);
        gl.EnableVertexAttribArray(1);
        gl.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, stride, (void*)8);
        gl.EnableVertexAttribArray(2);
        gl.VertexAttribPointer(2, 4, VertexAttribPointerType.UnsignedByte, true, stride, (void*)16);
        gl.EnableVertexAttribArray(3);
        gl.VertexAttribPointer(3, 1, VertexAttribPointerType.Float, false, stride, (void*)20);
        gl.BindVertexArray(0);

        _glintShader = new ShaderProgram(gl, Shaders.GuiGlintVertex, Shaders.GuiGlintFragment);
        _glintVao = gl.CreateVertexArray();
        _glintVbo = gl.CreateBuffer();
        gl.VertexArrayVertexBuffer(_glintVao, 0, _glintVbo, 0, (uint)sizeof(GlintVertex));
        for (uint i = 0; i < 3; i++) {
            gl.EnableVertexArrayAttrib(_glintVao, i);
            gl.VertexArrayAttribFormat(_glintVao, i, 2, VertexAttribType.Float, false, i * 8);
            gl.VertexArrayAttribBinding(_glintVao, i, 0);
        }

        _white = gl.GenTexture();
        gl.BindTexture(TextureTarget.Texture2D, _white);
        uint pixel = 0xFFFFFFFF;
        gl.TexImage2D(TextureTarget.Texture2D, 0, InternalFormat.Rgba8, 1, 1, 0, PixelFormat.Rgba, PixelType.UnsignedByte, &pixel);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        _texture = _white;
    }

    /// <summary>Vanilla's automatic GUI scale: the largest that keeps the screen at least 320 by 240 HUD pixels.</summary>
    public void Begin(int width, int height) {
        Width = width;
        Height = height;
        int scale = 1;
        while (scale < 4 && width / (scale + 1) >= 320 && height / (scale + 1) >= 240) {
            scale++;
        }
        Scale = scale;
        Zoom = 1.0F;
        Pose = Matrix3x2.Identity;
        _count = 0;
        _texture = _white;
        _gl.Disable(EnableCap.DepthTest);
        _gl.Disable(EnableCap.CullFace);
        _gl.Enable(EnableCap.Blend);
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    /// <summary>A rectangle in HUD pixels, colour as 0xAARRGGBB.</summary>
    public void Rect(float x, float y, float w, float h, uint argb) => Quad(x, y, w, h, 0, 0, 1, 1, argb, 0);

    public void Textured(uint texture, float x, float y, float w, float h, float u0, float v0, float u1, float v1, uint argb = 0xFFFFFFFF) {
        UseTexture(texture);
        Quad(x, y, w, h, u0, v0, u1, v1, argb);
    }

    /// <summary>A texture whose colour is already multiplied by its alpha, as vanilla's <c>GUI_TEXTURED_PREMULTIPLIED_ALPHA</c> blits a picture in picture.</summary>
    public void TexturedPremultiplied(uint texture, float x, float y, float w, float h, float u0, float v0, float u1, float v1) {
        Flush();
        UseTexture(texture);
        Quad(x, y, w, h, u0, v0, u1, v1, 0xFFFFFFFF);
        _gl.BlendFunc(BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha);
        Flush();
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    /// <summary>A whole texture added to what is behind it, as vanilla's <c>BlendFunction.ADDITIVE</c> blends.</summary>
    public void TexturedAdditive(uint texture, float x, float y, float w, float h, uint argb) {
        Flush();
        UseTexture(texture);
        Quad(x, y, w, h, 0, 0, 1, 1, argb);
        _gl.BlendFunc(BlendingFactor.One, BlendingFactor.One);
        Flush();
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    /// <summary>Part of a texture added to what is behind it by its alpha, as vanilla's <c>MOJANG_LOGO</c> pipeline blends.</summary>
    public void TexturedLighten(uint texture, float x, float y, float w, float h, float u0, float v0, float u1, float v1, uint argb) {
        Flush();
        UseTexture(texture);
        Quad(x, y, w, h, u0, v0, u1, v1, argb);
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.One);
        Flush();
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    /// <summary>A whole texture that darkens what is behind it by its colour, as vanilla's <c>VIGNETTE</c> pipeline blends.</summary>
    public void TexturedVignette(uint texture, float x, float y, float w, float h, uint argb) {
        Flush();
        UseTexture(texture);
        Quad(x, y, w, h, 0, 0, 1, 1, argb);
        _gl.BlendFuncSeparate(BlendingFactor.Zero, BlendingFactor.OneMinusSrcColor, BlendingFactor.Zero, BlendingFactor.One);
        Flush();
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    /// <summary>A textured quad by its four corners in screen pixels rather than HUD pixels, for geometry projected from a 3D scene.</summary>
    public void ScreenQuad(uint texture, ReadOnlySpan<Vector2> corners, ReadOnlySpan<Vector2> uvs, uint argb) {
        UseTexture(texture);
        uint abgr = Abgr(argb);
        Span<GuiVertex> v = stackalloc GuiVertex[4];
        for (int i = 0; i < 4; i++) {
            v[i] = new GuiVertex { X = corners[i].X, Y = corners[i].Y, U = uvs[i].X, V = uvs[i].Y, Colour = abgr, Textured = 1 };
        }
        Add(v[0], v[1], v[2], v[3]);
    }

    private void Quad(float x, float y, float w, float h, float u0, float v0, float u1, float v1, uint argb, float textured = 1) {
        float s = Scale * Zoom;
        uint abgr = Abgr(argb);
        if (!Pose.IsIdentity) {
            Vector2 a = Vector2.Transform(new Vector2(x, y), Pose) * s, b = Vector2.Transform(new Vector2(x + w, y), Pose) * s;
            Vector2 c = Vector2.Transform(new Vector2(x + w, y + h), Pose) * s, d = Vector2.Transform(new Vector2(x, y + h), Pose) * s;
            Add(new GuiVertex { X = a.X, Y = a.Y, U = u0, V = v0, Colour = abgr, Textured = textured }, new GuiVertex { X = b.X, Y = b.Y, U = u1, V = v0, Colour = abgr, Textured = textured },
                new GuiVertex { X = c.X, Y = c.Y, U = u1, V = v1, Colour = abgr, Textured = textured }, new GuiVertex { X = d.X, Y = d.Y, U = u0, V = v1, Colour = abgr, Textured = textured });
            return;
        }
        Add(new GuiVertex { X = x * s, Y = y * s, U = u0, V = v0, Colour = abgr, Textured = textured },
            new GuiVertex { X = (x + w) * s, Y = y * s, U = u1, V = v0, Colour = abgr, Textured = textured },
            new GuiVertex { X = (x + w) * s, Y = (y + h) * s, U = u1, V = v1, Colour = abgr, Textured = textured },
            new GuiVertex { X = x * s, Y = (y + h) * s, U = u0, V = v1, Colour = abgr, Textured = textured });
    }

    /// <summary>
    /// The enchantment glint over an icon already drawn from <paramref name="mask"/>, as vanilla's <c>GLINT</c>
    /// blend adds it: each channel of the glint, times the strength, times itself. <paramref name="glintUvs"/>
    /// run clockwise from the top left, already through the glint's texturing.
    /// </summary>
    public void Glint(uint mask, float x, float y, float w, float h, (float U0, float V0, float U1, float V1) uv, uint glint,
        ReadOnlySpan<Vector2> glintUvs, float strength) {
        Flush();
        float s = Scale * Zoom;
        GlintVertex a = new() { X = x * s, Y = y * s, U = uv.U0, V = uv.V0, GlintU = glintUvs[0].X, GlintV = glintUvs[0].Y };
        GlintVertex b = new() { X = (x + w) * s, Y = y * s, U = uv.U1, V = uv.V0, GlintU = glintUvs[1].X, GlintV = glintUvs[1].Y };
        GlintVertex c = new() { X = (x + w) * s, Y = (y + h) * s, U = uv.U1, V = uv.V1, GlintU = glintUvs[2].X, GlintV = glintUvs[2].Y };
        GlintVertex d = new() { X = x * s, Y = (y + h) * s, U = uv.U0, V = uv.V1, GlintU = glintUvs[3].X, GlintV = glintUvs[3].Y };
        ReadOnlySpan<GlintVertex> vertices = [a, b, c, c, d, a];
        fixed (GlintVertex* p = vertices) {
            _gl.NamedBufferData(_glintVbo, (nuint)(vertices.Length * sizeof(GlintVertex)), p, GLEnum.StreamDraw);
        }
        _glintShader.Use();
        _glintShader.Set("uScreen", new Vector2(Width, Height));
        _glintShader.Set("uMask", 0);
        _glintShader.Set("uGlint", 1);
        _glintShader.Set("uStrength", strength);
        _gl.BindTextureUnit(0, mask);
        _gl.BindTextureUnit(1, glint);
        _gl.BlendFunc(BlendingFactor.SrcColor, BlendingFactor.One);
        _gl.BindVertexArray(_glintVao);
        _gl.DrawArrays(PrimitiveType.Triangles, 0, 6);
        _gl.BindVertexArray(0);
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
        _gl.ActiveTexture(TextureUnit.Texture0);
    }

    private static uint Abgr(uint argb) => (argb & 0xFF00FF00) | (argb >> 16 & 0xFF) | (argb & 0xFF) << 16;

    /// <summary>A quad as two triangles, a b c and c d a.</summary>
    private void Add(in GuiVertex a, in GuiVertex b, in GuiVertex c, in GuiVertex d) {
        if (_count + 6 > _vertices.Length) {
            Array.Resize(ref _vertices, _vertices.Length * 2);
        }
        _vertices[_count++] = a;
        _vertices[_count++] = b;
        _vertices[_count++] = c;
        _vertices[_count++] = c;
        _vertices[_count++] = d;
        _vertices[_count++] = a;
    }

    private void UseTexture(uint texture) {
        if (texture != _texture) {
            Flush();
            _texture = texture;
        }
    }

    /// <summary>Draws what is batched with blending that inverts what is behind it, as the crosshair does.</summary>
    public void FlushInverted() {
        _gl.BlendFuncSeparate(BlendingFactor.OneMinusDstColor, BlendingFactor.OneMinusSrcColor, BlendingFactor.One, BlendingFactor.Zero);
        Flush();
        _gl.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
    }

    public void Flush() {
        if (_count == 0) {
            return;
        }
        _shader.Use();
        _shader.Set("uScreen", new Vector2(Width, Height));
        _shader.Set("uTexture", 0);
        _gl.ActiveTexture(TextureUnit.Texture0);
        _gl.BindTexture(TextureTarget.Texture2D, _texture);
        _gl.BindVertexArray(_vao);
        _gl.BindBuffer(BufferTargetARB.ArrayBuffer, _vbo);
        fixed (GuiVertex* p = _vertices) {
            _gl.BufferData(BufferTargetARB.ArrayBuffer, (nuint)(_count * sizeof(GuiVertex)), p, BufferUsageARB.StreamDraw);
        }
        _gl.DrawArrays(PrimitiveType.Triangles, 0, (uint)_count);
        _gl.BindVertexArray(0);
        _count = 0;
    }

    /// <summary><c>GuiGraphics.enableScissor</c>: only what falls inside the rectangle, in HUD pixels, is drawn until <see cref="DisableScissor"/>.</summary>
    public void EnableScissor(int x0, int y0, int x1, int y1) {
        Flush();
        _gl.Enable(EnableCap.ScissorTest);
        _gl.Scissor(x0 * Scale, Height - y1 * Scale, (uint)Math.Max(0, (x1 - x0) * Scale), (uint)Math.Max(0, (y1 - y0) * Scale));
    }

    public void DisableScissor() {
        Flush();
        _gl.Disable(EnableCap.ScissorTest);
    }

    public void End() {
        Flush();
        _gl.Disable(EnableCap.Blend);
        _gl.Enable(EnableCap.DepthTest);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_vbo);
        _gl.DeleteTexture(_white);
        _gl.DeleteVertexArray(_glintVao);
        _gl.DeleteBuffer(_glintVbo);
        _glintShader.Dispose();
        _shader.Dispose();
    }
}
