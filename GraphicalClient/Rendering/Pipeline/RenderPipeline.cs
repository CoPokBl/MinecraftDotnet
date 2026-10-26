using System.Numerics;
using System.Runtime.InteropServices;
using Silk.NET.OpenGL;

namespace GraphicalClient.Rendering.Pipeline;

/// <summary>
/// The <c>Frame</c> uniform block, std140. Matrices are System.Numerics' row vector form uploaded
/// as is, which GLSL's column major reading turns into the usual <c>projection * view * v</c> order.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct FrameUniforms {
    public Matrix4x4 View;
    public Matrix4x4 Projection;
    public Matrix4x4 ViewProjection;
    public Matrix4x4 InverseView;
    public Matrix4x4 InverseProjection;
    public Matrix4x4 InverseViewProjection;
    public Matrix4x4 ShadowView;
    public Matrix4x4 ShadowProjection;

    /// <summary>World position of the camera, which every position passed to a shader is relative to; w is 1 under water.</summary>
    public Vector4 CameraPosition;

    /// <summary>Unit vector toward the sun; w is how much daylight there is, 0 to 1.</summary>
    public Vector4 SunDirection;
    public Vector4 SkyColour;
    public Vector4 FogColour;

    /// <summary>Fog start, fog end, render distance in blocks, and whether the dimension has a sky.</summary>
    public Vector4 FogRange;

    /// <summary>Time of day 0 to 1, seconds of game time, seconds since start, and the partial tick.</summary>
    public Vector4 Time;

    /// <summary>Width, height, and their reciprocals.</summary>
    public Vector4 Screen;

    /// <summary>Rain, thunder, sky darkening, and the dimension's ambient light.</summary>
    public Vector4 Weather;

    /// <summary>Last frame's <see cref="ViewProjection"/>, for positions relative to last frame's camera.</summary>
    public Matrix4x4 PreviousViewProjection;

    /// <summary>The camera's position minus last frame's, worked out in double precision; w is the seconds between the two.</summary>
    public Vector4 CameraMotion;

    /// <summary>
    /// Frame number wrapping at 65536, ticks into the day 0 to 24000, the moon phase 0 to 7, and ticks of
    /// game time 0 to 24000 with the partial tick, the clock vanilla's <c>GameTime</c> uniform counts.
    /// </summary>
    public Vector4 Counters;

    /// <summary>Block and sky light at the eye, 0 to 1, then both eased toward those, halving the gap each second.</summary>
    public Vector4 EyeLight;

    /// <summary>Light the items in the main hand and the off hand give off, 0 to 15, then 0 and 0.</summary>
    public Vector4 HeldLight;

    /// <summary>The camera's biome: temperature, downfall, 1 if it rains or snows there, and 0.</summary>
    public Vector4 Biome;

    /// <summary>The near and far planes of <see cref="Projection"/>, then 0 and 0.</summary>
    public Vector4 ClipPlanes;

    /// <summary>The dimension's <c>CardinalLighting</c>: the shade of a face looking down, up, north and south.</summary>
    public Vector4 CardinalLight0;

    /// <summary>The same for west and east, then 0 and 0.</summary>
    public Vector4 CardinalLight1;

    /// <summary><c>Lighting.Entry.LEVEL</c>'s two light directions, unit vectors in world space, that entities are shaded by.</summary>
    public Vector4 DiffuseLight0;
    public Vector4 DiffuseLight1;

    /// <summary><c>FogData</c>: the environmental start and end, then the render distance start and end, in blocks.</summary>
    public Vector4 FogDistances;

    /// <summary><c>FogData</c>'s sky end and cloud end, then 0 and 0.</summary>
    public Vector4 FogSkyClouds;

    /// <summary>The <c>visual/sunrise_sunset_color</c> attribute, RGBA.</summary>
    public Vector4 SunriseColour;

    /// <summary>The <c>visual/sun_angle</c>, <c>moon_angle</c> and <c>star_angle</c> attributes in degrees, and <c>star_brightness</c>.</summary>
    public Vector4 Celestial;
}

/// <summary>What a geometry pass asks the client to draw, with the pass's program bound.</summary>
public interface IGeometryDrawer {
    void Draw(string geometry, string camera);

    /// <summary>
    /// True when <see cref="Draw"/> would draw nothing this frame, so a pass that only draws can be left
    /// out. False whenever that is not cheap to know.
    /// </summary>
    bool IsEmpty(string geometry) => false;
}

/// <summary>A pack turned into GL objects and run once per frame.</summary>
public sealed unsafe class RenderPipeline : IDisposable {
    private sealed class Target {
        public required TargetDefinition Definition;

        /// <summary>One texture, or for a history target two, of which <see cref="Current"/> was written last.</summary>
        public readonly uint[] Textures = new uint[2];
        public int Current;
        public uint Texture => Textures[Current];
        public uint Written => Definition.History ? Textures[1 - Current] : Textures[0];
        public int Width, Height;

        public void Wrote() {
            if (Definition.History) {
                Current = 1 - Current;
            }
        }
    }

    private enum PassKind : byte { Geometry, Fullscreen, Copy }

    /// <summary>What a pass input binds: a target, read through a sampler of its own when it is an alias, or a texture.</summary>
    private readonly record struct Input(Target? Target, uint Texture, uint Sampler);

    private sealed class CompiledPass {
        public required PassDefinition Definition;
        public PassKind Kind;
        public bool Shadow;
        public (BlendingFactor Src, BlendingFactor Dst, BlendingFactor SrcAlpha, BlendingFactor DstAlpha)? Blend;
        public ShaderProgram? Program;
        public uint Framebuffer;
        public int Width, Height;
        public Input[] Inputs = [];

        /// <summary>History targets it writes, with their attachment, which take the other texture each frame.</summary>
        public (Target Target, FramebufferAttachment Attachment)[] HistoryOutputs = [];

        /// <summary>Targets it writes that have mip chains to rebuild afterwards.</summary>
        public Target[] MipmappedOutputs = [];

        /// <summary>A ring of timer queries, so a result is read frames after it was asked for rather than stalling on it.</summary>
        public readonly uint[] Timers = new uint[TimerFrames];
        public double GpuMilliseconds;
        public int GpuSamples;
    }

    private static readonly Dictionary<string, (BlendingFactor, BlendingFactor, BlendingFactor, BlendingFactor)> BlendModes = new() {
        ["alpha"] = (BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha, BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha),
        ["additive"] = (BlendingFactor.One, BlendingFactor.One, BlendingFactor.One, BlendingFactor.One),
        ["premultiplied"] = (BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha, BlendingFactor.One, BlendingFactor.OneMinusSrcAlpha),
        ["multiply"] = (BlendingFactor.DstColor, BlendingFactor.Zero, BlendingFactor.DstColor, BlendingFactor.Zero),
        ["doubleMultiply"] = (BlendingFactor.DstColor, BlendingFactor.SrcColor, BlendingFactor.One, BlendingFactor.Zero)
    };

    private const int TimerFrames = 4;

    /// <summary>Units below this hold the textures every program gets; a pass's inputs follow them.</summary>
    private const int FirstInputUnit = 7;
    private int _frameIndex;

    private readonly GL _gl;
    private readonly Dictionary<string, Target> _targets = new();
    private readonly Dictionary<string, uint> _aliasSamplers = new();
    private readonly Dictionary<string, uint> _textures = new();

    /// <summary>Units a pass bound an alias's sampler on, to unbind before the next pass or the GUI uses them.</summary>
    private readonly List<uint> _boundSamplers = [];
    private readonly List<CompiledPass> _passes = [];
    private readonly uint _frameBuffer;
    private readonly uint _emptyVao;

    /// <summary>The sampler the terrain passes read the block atlas through, for a pack whose <c>terrainFilter</c> is linear; 0 otherwise.</summary>
    private readonly uint _terrainSampler;
    private int _screenWidth = -1, _screenHeight = -1;

    public ShaderPack Pack { get; }

    /// <summary>The size of the first fixed size depth target a shadow pass writes, which the shadow camera snaps to.</summary>
    public int ShadowMapSize { get; }

    public RenderPipeline(GL gl, ShaderPack pack) {
        _gl = gl;
        Pack = pack;
        if (pack.TerrainFilter is not ("nearest" or "linear")) {
            throw new InvalidDataException($"Unknown terrainFilter {pack.TerrainFilter}");
        }
        foreach (TargetDefinition target in pack.Targets) {
            if (target.Name == "screen") {
                throw new InvalidDataException("A target cannot be called screen");
            }
            if (target.Of == null) {
                // Throws for an unknown format here, where a failed load is reported, rather than mid frame.
                Format(target.Format);
                _targets[target.Name] = new Target { Definition = target };
            }
        }
        try {
            foreach (TargetDefinition alias in pack.Targets.Where(t => t.Of != null)) {
                if (!_targets.ContainsKey(alias.Of!)) {
                    throw new InvalidDataException($"Target {alias.Name} reads {alias.Of}, which the pack does not declare");
                }
                uint sampler = _gl.CreateSampler();
                Configure((name, value) => _gl.SamplerParameter(sampler, (SamplerParameterI)name, value), alias.Filter, false, TextureWrapMode.ClampToEdge, alias.Compare);
                _aliasSamplers[alias.Name] = sampler;
            }
            foreach (TextureDefinition texture in pack.Textures) {
                _textures[texture.Name] = CreateTexture(texture);
            }
            foreach (PassDefinition pass in pack.Passes) {
                _passes.Add(Compile(pass));
            }
        }
        catch {
            foreach (CompiledPass compiled in _passes) {
                compiled.Program?.Dispose();
            }
            DeleteSamplersAndTextures();
            throw;
        }
        ShadowMapSize = pack.Passes.Where(p => p.Camera == "shadow" && p.Depth != null)
            .Select(p => _targets[p.Depth!].Definition.Size?[0] ?? 2048).FirstOrDefault(2048);
        _frameBuffer = gl.CreateBuffer();
        gl.NamedBufferStorage(_frameBuffer, (nuint)sizeof(FrameUniforms), null, BufferStorageMask.DynamicStorageBit);
        _emptyVao = gl.CreateVertexArray();
        if (pack.TerrainFilter == "linear") {
            _terrainSampler = gl.CreateSampler();
            Configure((name, value) => _gl.SamplerParameter(_terrainSampler, (SamplerParameterI)name, value), "linear", true, TextureWrapMode.Repeat, false);
        }
    }

    /// <summary>Filtering, wrapping and depth comparison, set through a texture's or a sampler's parameters.</summary>
    private static void Configure(Action<TextureParameterName, int> set, string filter, bool mipmaps, TextureWrapMode wrap, bool compare) {
        bool nearest = filter == "nearest";
        set(TextureParameterName.TextureMinFilter, (int)(mipmaps
            ? nearest ? TextureMinFilter.NearestMipmapNearest : TextureMinFilter.LinearMipmapLinear
            : nearest ? TextureMinFilter.Nearest : TextureMinFilter.Linear));
        set(TextureParameterName.TextureMagFilter, (int)(nearest ? TextureMagFilter.Nearest : TextureMagFilter.Linear));
        set(TextureParameterName.TextureWrapS, (int)wrap);
        set(TextureParameterName.TextureWrapT, (int)wrap);
        if (compare) {
            set(TextureParameterName.TextureCompareMode, (int)TextureCompareMode.CompareRefToTexture);
            set(TextureParameterName.TextureCompareFunc, (int)DepthFunction.Lequal);
        }
    }

    private uint CreateTexture(TextureDefinition definition) {
        if (definition.Type != "noise") {
            throw new InvalidDataException($"Texture {definition.Name}: unknown type {definition.Type}");
        }
        int size = Math.Clamp(definition.Size, 1, 4096);
        byte[] pixels = new byte[size * size * 4];
        // Seeded, so a reload draws the same noise and nothing built on it jumps.
        new Random(size).NextBytes(pixels);
        uint texture = _gl.CreateTexture(TextureTarget.Texture2D);
        _gl.TextureStorage2D(texture, 1, SizedInternalFormat.Rgba8, (uint)size, (uint)size);
        fixed (byte* p = pixels) {
            _gl.TextureSubImage2D(texture, 0, 0, 0, (uint)size, (uint)size, PixelFormat.Rgba, PixelType.UnsignedByte, p);
        }
        Configure((name, value) => _gl.TextureParameter(texture, name, value), definition.Filter, false, TextureWrapMode.Repeat, false);
        return texture;
    }

    private uint CreateTargetTexture(TargetDefinition definition, int w, int h) {
        uint texture = _gl.CreateTexture(TextureTarget.Texture2D);
        uint levels = definition.Mipmaps ? (uint)BitOperations.Log2((uint)Math.Max(w, h)) + 1 : 1;
        _gl.TextureStorage2D(texture, levels, Format(definition.Format), (uint)w, (uint)h);
        Configure((name, value) => _gl.TextureParameter(texture, name, value), definition.Filter, definition.Mipmaps, TextureWrapMode.ClampToEdge, definition.Compare);
        return texture;
    }

    private static SizedInternalFormat Format(string name) => name switch {
        "r8" => SizedInternalFormat.R8,
        "rg8" => SizedInternalFormat.RG8,
        "rgba16" => SizedInternalFormat.Rgba16,
        "r16f" => SizedInternalFormat.R16f,
        "rgba8" => SizedInternalFormat.Rgba8,
        "rgba16f" => SizedInternalFormat.Rgba16f,
        "rgba32f" => SizedInternalFormat.Rgba32f,
        "r11g11b10f" => SizedInternalFormat.R11fG11fB10f,
        "rg16f" => SizedInternalFormat.RG16f,
        "r32f" => SizedInternalFormat.R32f,
        "rgb10a2" => SizedInternalFormat.Rgb10A2,
        "depth24" => SizedInternalFormat.DepthComponent24,
        "depth32f" => SizedInternalFormat.DepthComponent32f,
        _ => throw new InvalidDataException($"Unknown target format {name}")
    };

    private Target RequireTarget(PassDefinition pass, string? name) {
        if (name == null || !_targets.TryGetValue(name, out Target? target)) {
            throw new InvalidDataException($"Pass {pass.Name} names target {name ?? "(none)"}, which the pack does not declare");
        }
        return target;
    }

    private CompiledPass Compile(PassDefinition pass) {
        CompiledPass compiled = new() {
            Definition = pass,
            Kind = pass.Type switch { "copy" => PassKind.Copy, "fullscreen" => PassKind.Fullscreen, _ => PassKind.Geometry },
            Shadow = pass.Camera == "shadow",
            Blend = BlendModes.TryGetValue(pass.Blend, out var blend) ? blend : null
        };
        if (compiled.Kind == PassKind.Copy) {
            Target from = RequireTarget(pass, pass.From), to = RequireTarget(pass, pass.To);
            if (from.Definition.Format != to.Definition.Format) {
                throw new InvalidDataException($"Pass {pass.Name} copies {from.Definition.Name} into {to.Definition.Name}, which have different formats");
            }
            compiled.MipmappedOutputs = to.Definition.Mipmaps ? [to] : [];
        }
        else {
            CompileProgram(compiled);
        }
        fixed (uint* timers = compiled.Timers) {
            _gl.CreateQueries(QueryTarget.TimeElapsed, TimerFrames, timers);
        }
        return compiled;
    }

    private void CompileProgram(CompiledPass compiled) {
        PassDefinition pass = compiled.Definition;
        List<Target> outputs = pass.Outputs.Where(o => o != "screen").Select(o => RequireTarget(pass, o)).ToList();
        if (pass.Depth != null) {
            RequireTarget(pass, pass.Depth);
        }
        compiled.Inputs = pass.Inputs.Select(name =>
            _targets.TryGetValue(name, out Target? target) ? new Input(target, 0, 0)
            : _aliasSamplers.TryGetValue(name, out uint sampler) ? new Input(_targets[Pack.Targets.First(t => t.Name == name).Of!], 0, sampler)
            : _textures.TryGetValue(name, out uint texture) ? new Input(null, texture, 0)
            : throw new InvalidDataException($"Pass {pass.Name} reads {name}, which the pack does not declare")).ToArray();

        PackCompiler.PassSources sources = PackCompiler.Sources(Pack, pass);
        try {
            compiled.Program = new ShaderProgram(_gl, sources.Vertex, sources.Fragment);
        }
        catch (InvalidOperationException e) {
            throw new InvalidDataException($"Pass {pass.Name}: {sources.Locate(e.Message)}", e);
        }
        ShaderProgram program = compiled.Program;
        program.Use();
        program.Set("blockAtlas", 0);
        program.Set("lightmap", 1);
        program.Set("entityAtlas", 2);
        program.Set("endSky", 3);
        program.Set("endPortal", 4);
        program.Set("glintItem", 5);
        program.Set("glintArmor", 6);
        program.Set("endPortalColours", EndPortalPalette.Colours);
        for (int i = 0; i < pass.Inputs.Count; i++) {
            program.Set(pass.Inputs[i], FirstInputUnit + i);
        }

        List<(Target, FramebufferAttachment)> history = [];
        for (int i = 0; i < pass.Outputs.Count; i++) {
            if (pass.Outputs[i] != "screen" && _targets[pass.Outputs[i]].Definition.History) {
                history.Add((_targets[pass.Outputs[i]], FramebufferAttachment.ColorAttachment0 + i));
            }
        }
        if (pass.Depth != null && _targets[pass.Depth].Definition.History) {
            history.Add((_targets[pass.Depth], FramebufferAttachment.DepthAttachment));
        }
        compiled.HistoryOutputs = history.ToArray();
        compiled.MipmappedOutputs = outputs.Where(t => t.Definition.Mipmaps).ToArray();
    }

    /// <summary>Creates or recreates whatever follows the window size.</summary>
    private void EnsureSize(int width, int height) {
        if (width == _screenWidth && height == _screenHeight) {
            return;
        }
        _screenWidth = width;
        _screenHeight = height;

        foreach (Target target in _targets.Values) {
            (int w, int h) = target.Definition.Size is { Length: 2 } fixedSize
                ? (fixedSize[0], fixedSize[1])
                : (Math.Max(1, (int)(width * target.Definition.Scale)), Math.Max(1, (int)(height * target.Definition.Scale)));
            if (target.Texture != 0 && target.Width == w && target.Height == h) {
                continue;
            }
            target.Width = w;
            target.Height = h;
            target.Current = 0;
            for (int t = 0; t < (target.Definition.History ? 2 : 1); t++) {
                if (target.Textures[t] != 0) {
                    _gl.DeleteTexture(target.Textures[t]);
                }
                target.Textures[t] = CreateTargetTexture(target.Definition, w, h);
            }
        }

        foreach (CompiledPass pass in _passes) {
            if (pass.Framebuffer != 0) {
                _gl.DeleteFramebuffer(pass.Framebuffer);
                pass.Framebuffer = 0;
            }
            List<string> outputs = pass.Definition.Outputs;
            if (pass.Kind == PassKind.Copy) {
                Target from = _targets[pass.Definition.From!], to = _targets[pass.Definition.To!];
                if (from.Width != to.Width || from.Height != to.Height) {
                    throw new InvalidDataException($"Pass {pass.Definition.Name} copies between targets of different sizes");
                }
            }
            else if (outputs.Count == 1 && outputs[0] == "screen" || outputs.Count == 0 && pass.Definition.Depth == null) {
                (pass.Width, pass.Height) = (width, height);
            }
            else {
                CreateFramebuffer(pass);
            }
        }
    }

    private void CreateFramebuffer(CompiledPass pass) {
        List<string> outputs = pass.Definition.Outputs;
        uint fbo = _gl.CreateFramebuffer();
        GLEnum[] buffers = new GLEnum[outputs.Count];
        int w = 0, h = 0;
        for (int i = 0; i < outputs.Count; i++) {
            Target target = _targets[outputs[i]];
            _gl.NamedFramebufferTexture(fbo, FramebufferAttachment.ColorAttachment0 + i, target.Texture, 0);
            buffers[i] = GLEnum.ColorAttachment0 + i;
            (w, h) = (target.Width, target.Height);
        }
        if (pass.Definition.Depth is { } depthName) {
            Target depth = _targets[depthName];
            _gl.NamedFramebufferTexture(fbo, FramebufferAttachment.DepthAttachment, depth.Texture, 0);
            if (outputs.Count == 0) {
                (w, h) = (depth.Width, depth.Height);
            }
        }
        fixed (GLEnum* p = buffers) {
            _gl.NamedFramebufferDrawBuffers(fbo, (uint)buffers.Length, p);
        }
        GLEnum status = _gl.CheckNamedFramebufferStatus(fbo, FramebufferTarget.Framebuffer);
        if (status != GLEnum.FramebufferComplete) {
            throw new InvalidDataException($"Pass {pass.Definition.Name}: framebuffer incomplete ({status})");
        }
        pass.Framebuffer = fbo;
        (pass.Width, pass.Height) = (w, h);
    }

    /// <param name="drawShadows">False to skip the passes drawn from the shadow camera and keep what they drew last time.</param>
    public void Execute(ref FrameUniforms frame, IGeometryDrawer geometry, uint blockAtlas, uint lightmap, uint entityAtlas, uint endSky, uint endPortal,
        uint glintItem, uint glintArmor,
        int width, int height, bool drawShadows) {
        EnsureSize(width, height);
        frame.Screen = new Vector4(width, height, 1.0F / width, 1.0F / height);
        fixed (FrameUniforms* p = &frame) {
            _gl.NamedBufferSubData(_frameBuffer, 0, (nuint)sizeof(FrameUniforms), p);
        }
        _gl.BindBufferBase(BufferTargetARB.UniformBuffer, 0, _frameBuffer);
        ReadOnlySpan<uint> shared = [blockAtlas, lightmap, entityAtlas, endSky, endPortal, glintItem, glintArmor];
        for (int unit = 0; unit < shared.Length; unit++) {
            _gl.BindTextureUnit((uint)unit, shared[unit]);
        }

        int slot = _frameIndex % TimerFrames;
        bool readable = _frameIndex >= TimerFrames;
        _frameIndex++;
        foreach (CompiledPass pass in _passes) {
            if (!drawShadows && pass.Shadow && pass.Definition.Update != "always" || pass.Definition.When is { } when && geometry.IsEmpty(when) || DrawsNothing(pass, geometry)) {
                continue;
            }
            uint timer = pass.Timers[slot];
            if (readable) {
                _gl.GetQueryObject(timer, QueryObjectParameterName.ResultAvailable, out int available);
                if (available != 0) {
                    _gl.GetQueryObject(timer, QueryObjectParameterName.Result, out ulong nanoseconds);
                    pass.GpuMilliseconds += nanoseconds / 1e6;
                    pass.GpuSamples++;
                }
            }
            _gl.BeginQuery(QueryTarget.TimeElapsed, timer);
            Run(pass, geometry);
            _gl.EndQuery(QueryTarget.TimeElapsed);
        }
        UnbindSamplers();

        _gl.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
        _gl.Viewport(0, 0, (uint)width, (uint)height);
        _gl.BindVertexArray(0);
        _gl.Disable(EnableCap.Blend);
        _gl.DepthMask(true);
        _gl.DepthFunc(DepthFunction.Less);
        _gl.Disable(EnableCap.PolygonOffsetFill);
        _gl.Disable(EnableCap.DepthClamp);
        _gl.DepthRange(0.0, 1.0);
    }

    /// <summary>A pass that only draws, with nothing to draw, which can be left out whole, its timer query with it.</summary>
    private static bool DrawsNothing(CompiledPass pass, IGeometryDrawer geometry) {
        PassDefinition definition = pass.Definition;
        return pass.Kind == PassKind.Geometry && definition.Geometry != null && definition.Clear == null && !definition.ClearDepth
            && pass.HistoryOutputs.Length == 0 && pass.MipmappedOutputs.Length == 0 && geometry.IsEmpty(definition.Geometry);
    }

    private void Run(CompiledPass pass, IGeometryDrawer geometry) {
        PassDefinition definition = pass.Definition;
        if (pass.Kind == PassKind.Copy) {
            Target from = _targets[definition.From!], to = _targets[definition.To!];
            _gl.CopyImageSubData(from.Texture, CopyImageSubDataTarget.Texture2D, 0, 0, 0, 0,
                to.Written, CopyImageSubDataTarget.Texture2D, 0, 0, 0, 0, (uint)from.Width, (uint)from.Height, 1);
            to.Wrote();
            FinishOutputs(pass);
            return;
        }
        foreach ((Target target, FramebufferAttachment attachment) in pass.HistoryOutputs) {
            _gl.NamedFramebufferTexture(pass.Framebuffer, attachment, target.Written, 0);
        }
        _gl.BindFramebuffer(FramebufferTarget.Framebuffer, pass.Framebuffer);
        _gl.Viewport(0, 0, (uint)pass.Width, (uint)pass.Height);
        _gl.DepthMask(true);
        Clear(pass);
        ApplyState(pass);
        pass.Program!.Use();
        UnbindSamplers();
        if (_terrainSampler != 0 && definition.Geometry?.StartsWith("terrain") == true) {
            _gl.BindSampler(0, _terrainSampler);
            _boundSamplers.Add(0);
        }
        for (int i = 0; i < pass.Inputs.Length; i++) {
            Input input = pass.Inputs[i];
            uint unit = (uint)(FirstInputUnit + i);
            _gl.BindTextureUnit(unit, input.Target?.Texture ?? input.Texture);
            if (input.Sampler != 0) {
                _gl.BindSampler(unit, input.Sampler);
                _boundSamplers.Add(unit);
            }
        }

        if (pass.Kind == PassKind.Fullscreen) {
            _gl.BindVertexArray(_emptyVao);
            _gl.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
        else if (definition.Geometry != null) {
            geometry.Draw(definition.Geometry, definition.Camera);
        }
        FinishOutputs(pass);
    }

    private void Clear(CompiledPass pass) {
        PassDefinition definition = pass.Definition;
        if (definition.Clear is { Length: 4 } clear) {
            if (pass.Framebuffer == 0) {
                _gl.ClearColor(clear[0], clear[1], clear[2], clear[3]);
                _gl.Clear(ClearBufferMask.ColorBufferBit);
            }
            else {
                fixed (float* c = clear) {
                    for (int i = 0; i < definition.Outputs.Count; i++) {
                        _gl.ClearNamedFramebuffer(pass.Framebuffer, BufferKind.Color, i, c);
                    }
                }
            }
        }
        if (definition.ClearDepth) {
            if (pass.Framebuffer == 0) {
                _gl.Clear(ClearBufferMask.DepthBufferBit);
            }
            else {
                float one = 1.0F;
                _gl.ClearNamedFramebuffer(pass.Framebuffer, BufferKind.Depth, 0, &one);
            }
        }
    }

    /// <summary>Swaps the history targets a pass wrote and rebuilds the mip chains of the targets that have them.</summary>
    private void FinishOutputs(CompiledPass pass) {
        foreach ((Target target, _) in pass.HistoryOutputs) {
            target.Wrote();
        }
        foreach (Target target in pass.MipmappedOutputs) {
            _gl.GenerateTextureMipmap(target.Texture);
        }
    }

    private void UnbindSamplers() {
        foreach (uint unit in _boundSamplers) {
            _gl.BindSampler(unit, 0);
        }
        _boundSamplers.Clear();
    }

    private void Toggle(EnableCap capability, bool enabled) {
        if (enabled) {
            _gl.Enable(capability);
        }
        else {
            _gl.Disable(capability);
        }
    }

    private void ApplyState(CompiledPass compiled) {
        PassDefinition pass = compiled.Definition;
        bool geometry = compiled.Kind != PassKind.Fullscreen;
        Toggle(EnableCap.DepthTest, pass.DepthTest && geometry);
        _gl.DepthFunc(pass.DepthFunc switch {
            "equal" => DepthFunction.Equal,
            "lequal" => DepthFunction.Lequal,
            _ => DepthFunction.Less
        });
        _gl.DepthMask(pass.DepthWrite && geometry);
        Toggle(EnableCap.CullFace, pass.Cull && geometry);
        Toggle(EnableCap.Blend, compiled.Blend != null);
        if (compiled.Blend is var (src, dst, srcAlpha, dstAlpha)) {
            _gl.BlendFuncSeparate(src, dst, srcAlpha, dstAlpha);
        }
        if (pass.DepthRange is [var near, var far]) {
            _gl.DepthRange(near, far);
        }
        else {
            _gl.DepthRange(0.0, 1.0);
        }
        Toggle(EnableCap.DepthClamp, pass.DepthClamp);
        bool offset = pass.PolygonOffset is [_, _] && geometry;
        Toggle(EnableCap.PolygonOffsetFill, offset);
        if (offset) {
            _gl.PolygonOffset(pass.PolygonOffset![0], pass.PolygonOffset[1]);
        }
    }

    /// <summary>GPU milliseconds per pass, averaged since the last call.</summary>
    public string GpuReport() {
        System.Text.StringBuilder text = new();
        double total = 0;
        foreach (CompiledPass pass in _passes) {
            double ms = pass.GpuMilliseconds / Math.Max(1, pass.GpuSamples);
            total += ms;
            text.Append($"{pass.Definition.Name} {ms:F2} ");
            pass.GpuMilliseconds = 0;
            pass.GpuSamples = 0;
        }
        return $"gpu {total:F2} ({text.ToString().TrimEnd()})";
    }

    private void DeleteSamplersAndTextures() {
        foreach (uint sampler in _aliasSamplers.Values) {
            _gl.DeleteSampler(sampler);
        }
        foreach (uint texture in _textures.Values) {
            _gl.DeleteTexture(texture);
        }
    }

    public void Dispose() {
        DeleteSamplersAndTextures();
        foreach (CompiledPass pass in _passes) {
            pass.Program?.Dispose();
            fixed (uint* timers = pass.Timers) {
                _gl.DeleteQueries(TimerFrames, timers);
            }
            if (pass.Framebuffer != 0) {
                _gl.DeleteFramebuffer(pass.Framebuffer);
            }
        }
        foreach (Target target in _targets.Values) {
            foreach (uint texture in target.Textures) {
                if (texture != 0) {
                    _gl.DeleteTexture(texture);
                }
            }
        }
        _gl.DeleteBuffer(_frameBuffer);
        _gl.DeleteVertexArray(_emptyVao);
        if (_terrainSampler != 0) {
            _gl.DeleteSampler(_terrainSampler);
        }
    }
}
