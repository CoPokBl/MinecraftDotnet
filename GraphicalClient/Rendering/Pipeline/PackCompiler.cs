using System.Text;
using System.Text.RegularExpressions;

namespace GraphicalClient.Rendering.Pipeline;

/// <summary>
/// Turns a pack's GLSL into programs. Every stage gets a preamble with the version, the pass's
/// defines, the <c>Frame</c> uniform block and the standard samplers; a geometry pass's vertex stage
/// also gets that geometry's inputs and helpers, so a pack never deals with vertex packing.
/// </summary>
public static partial class PackCompiler {
    /// <summary>
    /// The uniform block every program sees at binding 0. Positions in it are camera relative, as all
    /// geometry is: the camera sits at the origin and <c>cameraPosition</c> says where that is.
    /// </summary>
    public const string FrameBlock = """
        layout(std140, binding = 0) uniform Frame {
            mat4 view;
            mat4 projection;
            mat4 viewProjection;
            mat4 inverseView;
            mat4 inverseProjection;
            mat4 inverseViewProjection;
            mat4 shadowView;
            mat4 shadowProjection;
            vec4 cameraPosition;
            vec4 sunDirection;
            vec4 skyColour;
            vec4 fogColour;
            vec4 fogRange;
            vec4 time;
            vec4 screen;
            vec4 weather;
            mat4 previousViewProjection;
            vec4 cameraMotion;
            vec4 counters;
            vec4 eyeLight;
            vec4 heldLight;
            vec4 biome;
            vec4 clipPlanes;
        };

        uniform sampler2DArray blockAtlas;
        uniform sampler2D lightmap;
        uniform sampler2D entityAtlas;
        uniform sampler2D endSky;
        uniform sampler2D endPortal;
        uniform sampler2D glintItem;
        uniform sampler2D glintArmor;
        uniform vec3 endPortalColours[16];
        """;

    private const string TerrainInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in uvec2 _faceFlags;
        layout(location = 2) in vec2 _uv;
        layout(location = 3) in float _layer;
        layout(location = 4) in vec2 _light;
        layout(location = 5) in vec4 _colour;
        layout(location = 6) in vec3 _origin;

        vec3 vertexPosition() { return _position / 1024.0 - 16.0 + _origin; }
        vec3 vertexUv() { return vec3(_uv / 2048.0, _layer); }
        vec2 vertexLight() { return _light / 16.0; }
        vec3 vertexTint() { return _colour.rgb; }
        float vertexOcclusion() { return _colour.a; }
        uint vertexFace() { return _faceFlags.x; }
        bool vertexIsPlant() { return (_faceFlags.y & 1u) != 0u; }
        bool vertexIsFluidSurface() { return (_faceFlags.y & 2u) != 0u; }
        uint vertexMaterial() { return _faceFlags.y >> 2u; }
        vec3 vertexNormal() {
            const vec3 normals[6] = vec3[6](vec3(0, -1, 0), vec3(0, 1, 0), vec3(0, 0, -1), vec3(0, 0, 1), vec3(-1, 0, 0), vec3(1, 0, 0));
            return normals[min(_faceFlags.x, 5u)];
        }
        float vertexFaceShade() {
            const float shades[6] = float[6](0.5, 1.0, 0.8, 0.8, 0.6, 0.6);
            return shades[min(_faceFlags.x, 5u)];
        }
        """;

    private const string EntityInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in vec2 _uv;
        layout(location = 2) in vec4 _colour;
        layout(location = 3) in vec2 _light;
        layout(location = 4) in vec3 _normal;
        layout(location = 5) in vec2 _overlay;

        vec3 vertexPosition() { return _position; }
        vec2 vertexUv() { return _uv; }
        vec4 vertexColour() { return _colour; }
        vec2 vertexLight() { return _light / 16.0; }
        vec3 vertexNormal() { return _normal; }
        float vertexRedOverlay() { return _overlay.x; }
        float vertexWhiteOverlay() { return _overlay.y; }
        """;

    private const string GlintInputs = """
        bool vertexIsArmorGlint() { return _overlay.x > 0.5; }
        """;

    private const string ColouredInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in vec4 _colour;
        layout(location = 2) in vec2 _light;

        vec3 vertexPosition() { return _position; }
        vec4 vertexColour() { return _colour; }
        vec2 vertexLight() { return _light; }
        """;

    private const string PortalInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in uint _layers;

        vec3 vertexPosition() { return _position; }
        int vertexPortalLayers() { return int(_layers); }
        """;

    /// <summary>The vertex stage a fullscreen pass gets when its pack does not supply one.</summary>
    public const string FullscreenVertex = """
        out vec2 texCoord;
        void main() {
            vec2 position = vec2((gl_VertexID << 1) & 2, gl_VertexID & 2);
            texCoord = position;
            gl_Position = vec4(position * 2.0 - 1.0, 0.0, 1.0);
        }
        """;

    /// <summary>
    /// A pass's two stages, ready to compile. <see cref="Files"/> names the source string numbers that
    /// the <c>#line</c> directives give each file, which is how the driver's errors refer to them.
    /// </summary>
    public sealed record PassSources(string Vertex, string Fragment, IReadOnlyList<string> Files) {
        /// <summary>Rewrites the driver's <c>file(line)</c> or <c>file:line</c> locations into the pack's file names.</summary>
        public string Locate(string log) => ErrorLocation().Replace(log, match => {
            int file = int.Parse(match.Groups["file"].Value);
            return file < Files.Count ? $"{Files[file]}:{match.Groups["line"].Value}" : match.Value;
        });
    }

    public static PassSources Sources(ShaderPack pack, PassDefinition pass) {
        string kind = pass.Type == "fullscreen" ? "FULLSCREEN"
            : pass.Geometry?.StartsWith("terrain") == true ? "TERRAIN"
            : pass.Geometry is "entities" or "entities_translucent" or "hand" or "crumbling" or "water_mask" or "glint" or "hand_glint" or "entity_outline" ? "ENTITY"
            : pass.Geometry == "end_portal" ? "PORTAL"
            : "COLOURED";
        StringBuilder header = new();
        header.AppendLine("#version 450 core");
        header.AppendLine($"#define GEOMETRY_{kind} 1");
        bool glint = pass.Geometry is "glint" or "hand_glint";
        if (glint) {
            header.AppendLine("#define GEOMETRY_GLINT 1");
        }
        header.AppendLine($"#define PASS_{Identifierise(pass.Name)} 1");
        if (pass.Camera == "shadow") {
            header.AppendLine("#define SHADOW_PASS 1");
        }
        foreach ((string key, string value) in pass.Defines) {
            header.AppendLine($"#define {key} {value}");
        }
        header.AppendLine(FrameBlock);

        string vertexInputs = kind switch {
            "TERRAIN" => TerrainInputs,
            "ENTITY" => glint ? EntityInputs + "\n" + GlintInputs : EntityInputs,
            "COLOURED" => ColouredInputs,
            "PORTAL" => PortalInputs,
            _ => ""
        };
        string? vertex = pack.ReadFile(pass.Program + ".vsh");
        if (vertex == null && kind != "FULLSCREEN") {
            throw new InvalidDataException($"Pass {pass.Name}: {pass.Program}.vsh not found");
        }
        string fragment = pack.ReadFile(pass.Program + ".fsh") ?? throw new InvalidDataException($"Pass {pass.Name}: {pass.Program}.fsh not found");

        List<string> files = [];
        string vertexBody = vertex == null ? FullscreenVertex : Include(pack, pass.Program + ".vsh", vertex, files, 0);
        string fragmentBody = Include(pack, pass.Program + ".fsh", fragment, files, 0);
        return new PassSources(header + vertexInputs + "\n" + vertexBody, header + "\n" + fragmentBody, files);
    }

    private static string Include(ShaderPack pack, string name, string source, List<string> files, int depth) {
        if (depth > 16) {
            throw new InvalidDataException("Includes nest too deep");
        }
        int index = files.Count;
        files.Add(name);
        StringBuilder result = new();
        result.Append($"#line 1 {index}\n");
        string[] lines = source.Split('\n');
        for (int i = 0; i < lines.Length; i++) {
            Match match = IncludeLine().Match(lines[i]);
            if (!match.Success) {
                result.Append(lines[i]).Append('\n');
                continue;
            }
            string path = match.Groups[1].Value;
            string included = pack.ReadFile(path) ?? throw new InvalidDataException($"{name}:{i + 1}: include {path} not found");
            result.Append(Include(pack, path, included, files, depth + 1));
            result.Append($"#line {i + 2} {index}\n");
        }
        return result.ToString();
    }

    private static string Identifierise(string name) => Regex.Replace(name.ToUpperInvariant(), "[^A-Z0-9_]", "_");

    [GeneratedRegex("^\\s*#include\\s+\"([^\"]+)\"\\s*$")]
    private static partial Regex IncludeLine();

    /// <summary>NVIDIA writes <c>0(12)</c>, Mesa and AMD <c>0:12(</c>.</summary>
    [GeneratedRegex(@"\b(?<file>\d+)(?:\((?<line>\d+)\)|:(?<line>\d+)(?=\())")]
    private static partial Regex ErrorLocation();
}
