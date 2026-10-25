using System.Numerics;
using System.Runtime.InteropServices;
using ClientLib.Maths;
using ClientLib.World;
using GraphicalClient.Assets;
using GraphicalClient.Assets.ResourcePacks;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Weather;

/// <summary>
/// Rain and snow on the columns round the camera, as <c>WeatherEffectRenderer</c> lays them out, drawn as the
/// <c>weather</c> geometry: one instance per column, a quad turned square to the line from the camera's block.
/// The columns are found once a tick or when the camera changes block, which is what the heightmap, the
/// biome and the light they read can change with; everything that moves within a tick, the scroll, the drift
/// and the fade with distance, is worked out on the GPU.
/// </summary>
public sealed unsafe class WeatherRenderer : IDisposable {
    /// <summary>Where both stages of a <c>weather</c> pass find <c>weatherTexture</c>.</summary>
    public const int TextureUnit = 30;

    /// <summary>Where the <c>weather</c> geometry's helpers find the frame's offsets.</summary>
    public const int UniformBinding = 2;

    private const int MaxRadius = 10;
    private const int MaxColumns = (2 * MaxRadius + 1) * (2 * MaxRadius + 1);

    /// <summary>One column, its block relative to <see cref="_origin"/>.</summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    private struct Column {
        public short X, Z, Bottom, Top;
        public byte Sky, Block, Snow, TickOffset;

        /// <summary>Rain: its speed. Snow: where it starts across and down the texture, and how fast it drifts each way.</summary>
        public Vector4 Random;
    }

    /// <summary>The <c>WeatherFrame</c> block the helpers read.</summary>
    [StructLayout(LayoutKind.Sequential)]
    private struct Frame {
        /// <summary>The origin block's corner relative to the camera; w is game ticks, wrapped as vanilla wraps them, with the partial tick.</summary>
        public Vector4 Origin;

        /// <summary>The origin block less the camera's block; w is the origin's y modulo 4, which the texture repeats over.</summary>
        public Vector4 CameraBlock;

        /// <summary>The rain level and the radius, in blocks.</summary>
        public Vector4 Settings;
    }

    private readonly GL _gl;
    private readonly uint _instances, _uniforms;
    private uint _vao;
    private readonly Column[] _columns = new Column[MaxColumns];
    private int _rain, _snow, _snowStart = MaxColumns;
    private Frame _frame;
    private bool _columnsChanged;
    private readonly LegacyRandomSource _random = new(0);

    private ClientLevel? _level;
    private (int X, int Y, int Z) _origin;
    private long _builtTick = long.MinValue;
    private int _builtRadius;
    private bool _builtForceSnow;

    public uint RainTexture { get; }
    public uint SnowTexture { get; }

    /// <summary>Columns drawn this frame, rain and snow.</summary>
    public (int Rain, int Snow) Columns => (_rain, _snow);

    public bool IsEmpty => _rain + _snow == 0;

    public WeatherRenderer(GL gl, ResourcePackSource? pack) {
        _gl = gl;
        RainTexture = CreateTexture(pack?.LoadFirstFrame("assets/minecraft/textures/environment/rain.png") ?? WeatherArt.Rain());
        SnowTexture = CreateTexture(pack?.LoadFirstFrame("assets/minecraft/textures/environment/snow.png") ?? WeatherArt.Snow());
        _instances = gl.CreateBuffer();
        gl.NamedBufferStorage(_instances, (nuint)(MaxColumns * sizeof(Column)), null, BufferStorageMask.DynamicStorageBit);
        _uniforms = gl.CreateBuffer();
        gl.NamedBufferStorage(_uniforms, (nuint)sizeof(Frame), null, BufferStorageMask.DynamicStorageBit);
    }

    /// <summary>As vanilla samples its weather textures: nearest, repeating, no mipmaps.</summary>
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
    /// Finds the columns again when the tick, the camera's block or the radius has changed, and works out the
    /// frame's offsets. <paramref name="forceSnow"/> turns rain to snow, for the test flag. No GL calls.
    /// </summary>
    public void Prepare(ClientLevel level, Vec3d camera, float partialTick, float rainLevel, int radius, bool forceSnow) {
        if (rainLevel <= 0.0F) {
            _rain = _snow = 0;
            _builtTick = long.MinValue;
            return;
        }
        radius = Math.Clamp(radius, 1, MaxRadius);
        (int X, int Y, int Z) block = (Mth.Floor(camera.X), Mth.Floor(camera.Y), Mth.Floor(camera.Z));
        if (level != _level || level.GameTime != _builtTick || block != _origin || radius != _builtRadius || forceSnow != _builtForceSnow) {
            _level = level;
            _builtTick = level.GameTime;
            _origin = block;
            _builtRadius = radius;
            _builtForceSnow = forceSnow;
            Build(level, radius, forceSnow);
        }
        float ticks = (level.GameTime & 131071L) + (level.TickRateManager.RunsNormally ? partialTick : 0.0F);
        _frame = new Frame {
            Origin = new Vector4((float)(_origin.X - camera.X), (float)(_origin.Y - camera.Y), (float)(_origin.Z - camera.Z), ticks),
            CameraBlock = new Vector4(_origin.X - block.X, _origin.Y - block.Y, _origin.Z - block.Z, (_origin.Y % 4 + 4) % 4),
            Settings = new Vector4(rainLevel, radius, 0, 0)
        };
    }

    /// <summary><c>WeatherEffectRenderer.extractRenderState</c>, rain columns first and snow after them.</summary>
    private void Build(ClientLevel level, int radius, bool forceSnow) {
        (int cameraX, int cameraY, int cameraZ) = _origin;
        _snowStart = MaxColumns;
        _rain = _snow = 0;
        _columnsChanged = true;
        for (int z = cameraZ - radius; z <= cameraZ + radius; z++) {
            for (int x = cameraX - radius; x <= cameraX + radius; x++) {
                int terrainHeight = level.GetHeight(HeightmapType.MotionBlocking, x, z);
                int y0 = Math.Max(cameraY - radius, terrainHeight);
                int y1 = Math.Max(cameraY + radius, terrainHeight);
                if (y1 == y0) {
                    continue;
                }
                BiomeClimate.Precipitation precipitation = level.GetPrecipitationAt(x, cameraY, z);
                if (precipitation == BiomeClimate.Precipitation.None) {
                    continue;
                }
                bool snow = forceSnow || precipitation == BiomeClimate.Precipitation.Snow;
                _random.SetSeed(x * x * 3121 + x * 45238971 ^ z * z * 418711 + z * 13761);
                int lightY = Math.Max(cameraY, terrainHeight);
                int sky = level.GetSkyLight(x, lightY, z), blockLight = level.GetBlockLight(x, lightY, z);
                Column column = new() {
                    X = (short)(x - cameraX), Z = (short)(z - cameraZ), Bottom = (short)(y0 - cameraY), Top = (short)(y1 - cameraY),
                    Snow = (byte)(snow ? 1 : 0), TickOffset = (byte)(x * x * 3121 + x * 45238971 + z * z * 418711 + z * 13761 & 0xFF)
                };
                if (snow) {
                    // createSnowColumnInstance's draws, in its order, and its brightening of the light.
                    float uStart = (float)_random.NextDouble();
                    float uDrift = 0.01F * (float)_random.NextGaussian();
                    float vStart = (float)_random.NextDouble();
                    float vDrift = (float)_random.NextGaussian() * 0.001F;
                    column.Random = new Vector4(uStart, uDrift, vStart, vDrift);
                    column.Sky = (byte)((sky * 3 + 15) / 4);
                    column.Block = (byte)((blockLight * 3 + 15) / 4);
                    _columns[--_snowStart] = column;
                    _snow++;
                }
                else {
                    column.Random = new Vector4(3.0F + _random.NextFloat(), 0, 0, 0);
                    column.Sky = (byte)sky;
                    column.Block = (byte)blockLight;
                    _columns[_rain++] = column;
                }
            }
        }
    }

    /// <summary>Sends the columns, when they were found again, and the frame's offsets.</summary>
    public void Upload() {
        if (IsEmpty) {
            return;
        }
        if (_columnsChanged) {
            _columnsChanged = false;
            fixed (Column* columns = _columns) {
                if (_rain > 0) {
                    _gl.NamedBufferSubData(_instances, 0, (nuint)(_rain * sizeof(Column)), columns);
                }
                if (_snow > 0) {
                    _gl.NamedBufferSubData(_instances, _snowStart * sizeof(Column), (nuint)(_snow * sizeof(Column)), columns + _snowStart);
                }
            }
        }
        Frame frame = _frame;
        _gl.NamedBufferSubData(_uniforms, 0, (nuint)sizeof(Frame), &frame);
    }

    public void Draw() {
        if (IsEmpty) {
            return;
        }
        _gl.BindVertexArray(VertexArray());
        _gl.BindBufferBase(BufferTargetARB.UniformBuffer, UniformBinding, _uniforms);
        if (_rain > 0) {
            _gl.BindTextureUnit(TextureUnit, RainTexture);
            _gl.DrawArraysInstancedBaseInstance(PrimitiveType.TriangleStrip, 0, 4, (uint)_rain, 0);
        }
        if (_snow > 0) {
            _gl.BindTextureUnit(TextureUnit, SnowTexture);
            _gl.DrawArraysInstancedBaseInstance(PrimitiveType.TriangleStrip, 0, 4, (uint)_snow, (uint)(MaxColumns - _snow));
        }
        _gl.BindVertexArray(0);
    }

    /// <summary>Made at the first draw: a vertex array belongs to the context that made it, and this may be built on another.</summary>
    private uint VertexArray() {
        if (_vao != 0) {
            return _vao;
        }
        _vao = _gl.CreateVertexArray();
        _gl.VertexArrayVertexBuffer(_vao, 0, _instances, 0, (uint)sizeof(Column));
        _gl.VertexArrayBindingDivisor(_vao, 0, 1);
        _gl.EnableVertexArrayAttrib(_vao, 0);
        _gl.VertexArrayAttribIFormat(_vao, 0, 4, VertexAttribIType.Short, 0);
        _gl.VertexArrayAttribBinding(_vao, 0, 0);
        _gl.EnableVertexArrayAttrib(_vao, 1);
        _gl.VertexArrayAttribIFormat(_vao, 1, 4, VertexAttribIType.UnsignedByte, 8);
        _gl.VertexArrayAttribBinding(_vao, 1, 0);
        _gl.EnableVertexArrayAttrib(_vao, 2);
        _gl.VertexArrayAttribFormat(_vao, 2, 4, VertexAttribType.Float, false, 12);
        _gl.VertexArrayAttribBinding(_vao, 2, 0);
        return _vao;
    }

    public void Dispose() {
        _gl.DeleteVertexArray(_vao);
        _gl.DeleteBuffer(_instances);
        _gl.DeleteBuffer(_uniforms);
        _gl.DeleteTexture(RainTexture);
        _gl.DeleteTexture(SnowTexture);
    }
}
