using System.Reflection;
using Newtonsoft.Json;

namespace GraphicalClient.Rendering.Pipeline;

/// <summary>A render target a pack declares: a texture the passes draw into and read from.</summary>
public sealed class TargetDefinition {
    [JsonProperty("name")] public string Name = "";

    /// <summary>
    /// <c>r8</c>, <c>rg8</c>, <c>rgba8</c>, <c>rgb10a2</c>, <c>rgba16</c>, <c>r16f</c>, <c>rg16f</c>, <c>rgba16f</c>,
    /// <c>r32f</c>, <c>rgba32f</c>, <c>r11g11b10f</c>, <c>depth24</c> or <c>depth32f</c>.
    /// </summary>
    [JsonProperty("format")] public string Format = "rgba8";

    /// <summary>Size as a fraction of the window, when <see cref="Size"/> is not given.</summary>
    [JsonProperty("scale")] public float Scale = 1.0F;

    /// <summary>A fixed size in pixels, for targets that do not follow the window, a shadow map say.</summary>
    [JsonProperty("size")] public int[]? Size;

    /// <summary>Whether reads filter between texels. Depth targets used as shadow maps compare instead.</summary>
    [JsonProperty("filter")] public string Filter = "linear";

    /// <summary>For depth targets read as shadow maps: sample with hardware depth comparison.</summary>
    [JsonProperty("compare")] public bool Compare;

    /// <summary>
    /// Another target, read under this name with this entry's <see cref="Filter"/> and <see cref="Compare"/>
    /// instead of its own. It has no texture of its own, so it is only ever an input.
    /// </summary>
    [JsonProperty("of")] public string? Of;

    /// <summary>
    /// Kept from frame to frame in two textures that swap: until a pass writes it this frame a read
    /// sees what the last frame left, and after that, what this frame wrote.
    /// </summary>
    [JsonProperty("history")] public bool History;

    /// <summary>Gives the target a mip chain, rebuilt after each pass that writes it.</summary>
    [JsonProperty("mipmaps")] public bool Mipmaps;
}

/// <summary>A texture the client fills once when the pack loads, read by passes like a target.</summary>
public sealed class TextureDefinition {
    [JsonProperty("name")] public string Name = "";

    /// <summary><c>noise</c>: independent random values in all four channels of every texel.</summary>
    [JsonProperty("type")] public string Type = "noise";

    /// <summary>Width and height in texels.</summary>
    [JsonProperty("size")] public int Size = 256;

    [JsonProperty("filter")] public string Filter = "linear";
}

/// <summary>A number that terrain vertices of the named blocks carry, for the pack to treat them differently.</summary>
public sealed class MaterialDefinition {
    /// <summary>1 to 63; 0 is every block no material names.</summary>
    [JsonProperty("id")] public int Id;

    /// <summary>
    /// Block names, with or without their namespace, each optionally followed by <c>:property=value</c>
    /// pairs that the state must have: <c>lantern:hanging=true</c>.
    /// </summary>
    [JsonProperty("blocks")] public List<string> Blocks = [];

    /// <summary>
    /// False keeps these blocks' faces out of the merging of alike neighbouring faces into one quad,
    /// which a pack that moves vertices per block needs, at the cost of more quads.
    /// </summary>
    [JsonProperty("merge")] public bool Merge = true;
}

/// <summary>One step of a pack's frame.</summary>
public sealed class PassDefinition {
    [JsonProperty("name")] public string Name = "";

    /// <summary>
    /// <c>geometry</c> draws one of the client's geometry kinds; <c>fullscreen</c> runs the program over the
    /// outputs; <c>copy</c> copies one target into another.
    /// </summary>
    [JsonProperty("type")] public string Type = "geometry";

    /// <summary>For a <c>copy</c> pass: the target copied from, and the one copied into, of the same format and size.</summary>
    [JsonProperty("from")] public string? From;
    [JsonProperty("to")] public string? To;

    /// <summary>
    /// For a geometry pass: <c>terrain_solid</c>, <c>terrain_cutout</c>, <c>terrain_translucent</c>,
    /// <c>entities</c>, <c>entities_translucent</c>, <c>water_mask</c>, <c>hand</c>, <c>crumbling</c>, <c>glint</c>, <c>hand_glint</c>,
    /// <c>entity_outline</c>, <c>lines</c> or <c>end_portal</c>.
    /// </summary>
    [JsonProperty("geometry")] public string? Geometry;

    /// <summary>A geometry kind: the pass, of any type, is skipped on frames when it has nothing to draw.</summary>
    [JsonProperty("when")] public string? When;

    /// <summary><c>main</c> or <c>shadow</c>: whose view the geometry is drawn from and culled for.</summary>
    [JsonProperty("camera")] public string Camera = "main";

    /// <summary>Base name of the program: <c>name.vsh</c> and <c>name.fsh</c> in the pack's shader folder.</summary>
    [JsonProperty("program")] public string Program = "";

    [JsonProperty("defines")] public Dictionary<string, string> Defines = new();

    /// <summary>Targets and textures bound as samplers, each under its own name.</summary>
    [JsonProperty("inputs")] public List<string> Inputs = [];

    /// <summary>Colour targets written, in output location order; <c>screen</c> is the window.</summary>
    [JsonProperty("outputs")] public List<string> Outputs = [];

    [JsonProperty("depth")] public string? Depth;

    /// <summary>RGBA to clear the colour outputs to before the pass, if given.</summary>
    [JsonProperty("clear")] public float[]? Clear;

    [JsonProperty("clearDepth")] public bool ClearDepth;

    /// <summary><c>none</c>, <c>alpha</c>, <c>additive</c>, <c>premultiplied</c> or <c>multiply</c>.</summary>
    [JsonProperty("blend")] public string Blend = "none";

    /// <summary><c>[factor, units]</c> for <c>glPolygonOffset</c>, or none.</summary>
    [JsonProperty("polygonOffset")] public float[]? PolygonOffset;

    /// <summary><c>[near, far]</c> for <c>glDepthRange</c>, or the whole range.</summary>
    [JsonProperty("depthRange")] public float[]? DepthRange;

    /// <summary>Clamp depth rather than clip at the near and far planes.</summary>
    [JsonProperty("depthClamp")] public bool DepthClamp;

    /// <summary><c>less</c>, <c>lequal</c> or <c>equal</c>: what the depth test passes.</summary>
    [JsonProperty("depthFunc")] public string DepthFunc = "less";

    [JsonProperty("depthTest")] public bool DepthTest = true;
    [JsonProperty("depthWrite")] public bool DepthWrite = true;
    [JsonProperty("cull")] public bool Cull = true;
}

/// <summary>
/// A shader pack: render targets, and the passes that fill them in order. The client's own look is a
/// pack in exactly this format, so anything it does a user pack can redo.
/// </summary>
public sealed class ShaderPack {
    [JsonProperty("name")] public string Name = "Unnamed";

    /// <summary>How far from the camera the shadow camera covers, in blocks, for passes drawn from it.</summary>
    [JsonProperty("shadowDistance")] public float ShadowDistance = 96.0F;

    /// <summary>
    /// <c>changed</c> draws the shadow camera's passes only when the light, the area it covers or the
    /// terrain in it has changed, and keeps what they drew otherwise; <c>always</c> draws them every frame,
    /// for packs that put moving things in them.
    /// </summary>
    [JsonProperty("shadowUpdate")] public string ShadowUpdate = "changed";

    /// <summary>
    /// Degrees the sun's path is tilted toward the north or south, about the east west axis, so it is not
    /// overhead at noon. The sun direction every program sees and the shadow camera both follow it.
    /// </summary>
    [JsonProperty("sunPathRotation")] public float SunPathRotation;

    [JsonProperty("targets")] public List<TargetDefinition> Targets = [];

    [JsonProperty("textures")] public List<TextureDefinition> Textures = [];

    [JsonProperty("materials")] public List<MaterialDefinition> Materials = [];

    [JsonIgnore] public bool UsesShadowCamera => Passes.Exists(p => p.Camera == "shadow");
    [JsonProperty("passes")] public List<PassDefinition> Passes = [];

    /// <summary>Reads a file of the pack by its path inside the pack's shader folder.</summary>
    [JsonIgnore] public Func<string, string?> ReadFile = _ => null;

    public static ShaderPack FromDirectory(string directory) {
        ShaderPack pack = JsonConvert.DeserializeObject<ShaderPack>(File.ReadAllText(Path.Combine(directory, "pack.json")))
                          ?? throw new InvalidDataException("pack.json is empty");
        string shaders = Path.Combine(directory, "shaders");
        pack.ReadFile = path => {
            string full = Path.GetFullPath(Path.Combine(shaders, path.TrimStart('/')));
            return full.StartsWith(Path.GetFullPath(shaders), StringComparison.Ordinal) && File.Exists(full) ? File.ReadAllText(full) : null;
        };
        return pack;
    }

    /// <summary>The pack built into the client, from its embedded resources.</summary>
    public static ShaderPack BuiltIn() {
        Assembly assembly = typeof(ShaderPack).Assembly;
        const string prefix = "GraphicalClient.Shaders.Default.";
        string? Read(string name) {
            using Stream? stream = assembly.GetManifestResourceStream(prefix + name.TrimStart('/').Replace('/', '.'));
            return stream == null ? null : new StreamReader(stream).ReadToEnd();
        }
        ShaderPack pack = JsonConvert.DeserializeObject<ShaderPack>(Read("pack.json") ?? throw new InvalidOperationException("The built in pack is missing"))!;
        pack.ReadFile = name => Read("shaders." + name.TrimStart('/'));
        return pack;
    }
}
