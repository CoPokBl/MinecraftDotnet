using System.Numerics;
using System.Runtime.InteropServices;
using ClientLib.Maths;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Weather;

/// <summary>
/// The cloud layer, drawn as the <c>clouds</c> geometry. Nothing is meshed, unlike vanilla's <c>CloudRenderer</c>:
/// the geometry is the box the layer fills out to the fade distance, of which only the far walls are drawn, and each
/// of their pixels traces its ray through the cell map on the GPU. That is one lookup where the ray meets the
/// layer's top or underside, and a walk from cell to cell only while it runs inside the layer, whatever the cloud
/// range, and it finds every side a cell shows where vanilla's mesh has one.
/// </summary>
public sealed unsafe class CloudRenderer : IDisposable {
    /// <summary>Where both stages of a <c>clouds</c> pass find <c>cloudMap</c>.</summary>
    public const int TextureUnit = 31;

    /// <summary>Where the <c>clouds</c> geometry's helpers find the layer.</summary>
    public const int UniformBinding = 3;

    /// <summary><c>CELL_SIZE_IN_BLOCKS</c> and the layer's height.</summary>
    private const float CellSize = 12.0F, Thickness = 4.0F;

    /// <summary>The <c>CloudFrame</c> block the helpers read.</summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct Frame {
        /// <summary>sRGB and alpha.</summary>
        public Vector4 Colour;

        /// <summary>The camera in the map's space, in blocks: across, above the layer's underside, and down; w is the cell size.</summary>
        public Vector4 Camera;

        /// <summary>The layer's thickness, the distance it has faded out by, 1 for the flat layer, and the camera relative underside.</summary>
        public Vector4 Shape;

        /// <summary>The map's width and height in cells.</summary>
        public Vector4 Map;
    }

    private readonly GL _gl;
    private readonly uint _uniforms;
    private readonly int _width, _height;
    private uint _vao;
    private Frame _frame;
    private bool _visible;

    /// <summary>
    /// <c>textures/environment/clouds.png</c>, or this client's own map: a cell is cloud where the texel's alpha is
    /// at least 10, as <c>CloudRenderer.isCellEmpty</c> has it.
    /// </summary>
    public uint MapTexture { get; }

    public bool IsEmpty => !_visible;

    public CloudRenderer(GL gl, ResourcePackSource? pack) {
        _gl = gl;
        TextureImage map = pack?.LoadFirstFrame("assets/minecraft/textures/environment/clouds.png") ?? WeatherArt.Clouds();
        (_width, _height) = (map.Width, map.Height);
        MapTexture = gl.CreateTexture(TextureTarget.Texture2D);
        gl.TextureStorage2D(MapTexture, 1, SizedInternalFormat.Rgba8, (uint)map.Width, (uint)map.Height);
        fixed (byte* p = map.Rgba) {
            gl.TextureSubImage2D(MapTexture, 0, 0, 0, (uint)map.Width, (uint)map.Height, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        gl.TextureParameter(MapTexture, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
        gl.TextureParameter(MapTexture, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
        gl.TextureParameter(MapTexture, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        gl.TextureParameter(MapTexture, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
        _uniforms = gl.CreateBuffer();
        gl.NamedBufferStorage(_uniforms, (nuint)sizeof(Frame), null, BufferStorageMask.DynamicStorageBit);
    }

    /// <summary>
    /// <c>CloudRenderer.render</c>'s placement: the map drifts 0.03 blocks a tick toward the west, wrapping every 400
    /// ticks a cell, and is shifted 3.96 blocks south. <paramref name="fadeDistance"/> is <c>FogData.cloudEnd</c>. No GL calls.
    /// </summary>
    public void Prepare(Vec3d camera, long gameTime, float partialTick, CloudStatus status, Vector4 colour, float height, float fadeDistance) {
        _visible = status != CloudStatus.Off && colour.W > 0.0F && fadeDistance > 0.0F;
        if (!_visible) {
            return;
        }
        float cloudOffset = gameTime % (_width * 400L) + partialTick;
        double cloudX = camera.X + cloudOffset * 0.030000001F;
        double cloudZ = camera.Z + 3.96F;
        double widthBlocks = _width * (double)CellSize, heightBlocks = _height * (double)CellSize;
        cloudX -= Math.Floor(cloudX / widthBlocks) * widthBlocks;
        cloudZ -= Math.Floor(cloudZ / heightBlocks) * heightBlocks;
        _frame = new Frame {
            Colour = colour,
            Camera = new Vector4((float)cloudX, (float)(camera.Y - height), (float)cloudZ, CellSize),
            Shape = new Vector4(Thickness, fadeDistance, status == CloudStatus.Fast ? 1.0F : 0.0F, (float)(height - camera.Y)),
            Map = new Vector4(_width, _height, 0, 0)
        };
    }

    public void Upload() {
        if (_visible) {
            Frame frame = _frame;
            _gl.NamedBufferSubData(_uniforms, 0, (nuint)sizeof(Frame), &frame);
        }
    }

    /// <summary>The box's 36 corners come from the vertex index, so the vertex array is empty.</summary>
    public void Draw() {
        if (!_visible) {
            return;
        }
        if (_vao == 0) {
            _vao = _gl.CreateVertexArray();
        }
        _gl.BindVertexArray(_vao);
        _gl.BindBufferBase(BufferTargetARB.UniformBuffer, UniformBinding, _uniforms);
        _gl.BindTextureUnit(TextureUnit, MapTexture);
        _gl.DrawArrays(PrimitiveType.Triangles, 0, 36);
        _gl.BindVertexArray(0);
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_uniforms);
        _gl.DeleteTexture(MapTexture);
    }
}
