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
        layout(location = 3) in vec3 _lineDirection;
        layout(location = 4) in vec2 _lineWidthSide;

        vec3 vertexPosition() { return _position; }
        vec4 vertexColour() { return _colour; }
        vec2 vertexLight() { return _light; }
        vec3 vertexLineDirection() { return _lineDirection; }
        float vertexLineWidth() { return _lineWidthSide.x; }
        float vertexLineSide() { return _lineWidthSide.y; }
        """;

    private const string PortalInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in uint _layers;

        vec3 vertexPosition() { return _position; }
        int vertexPortalLayers() { return int(_layers); }
        """;

    /// <summary>
    /// One instance per particle, drawn as a four vertex strip. Everything that changes within a tick is worked out
    /// here from the age, so a particle costs the CPU nothing from frame to frame.
    /// </summary>
    private const string ParticleInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in vec3 _previous;
        layout(location = 2) in float _size;
        layout(location = 3) in uint _ageLife;
        layout(location = 4) in vec4 _rotation;
        layout(location = 5) in vec4 _uv;
        layout(location = 6) in vec4 _colour;
        layout(location = 7) in uint _packed;

        // w is the partial tick the instances are drawn at: the frame's, or one while they wait on a tick's.
        layout(std140, binding = 1) uniform ParticleFrame {
            vec4 _particleOrigin;
        };

        vec2 _particleCorner() { return vec2((gl_VertexID & 1) != 0 ? 1.0 : -1.0, (gl_VertexID & 2) != 0 ? 1.0 : -1.0); }
        float _particleTicks() { return float(_ageLife & 0xFFFFu) + _particleOrigin.w; }
        float particleLifetime() { return max(float(_ageLife >> 16u), 1.0); }
        float particleAge() { return _particleTicks() / particleLifetime(); }
        vec3 _particleRotate(vec4 q, vec3 v) { return v + 2.0 * cross(q.xyz, cross(q.xyz, v) + q.w * v); }

        float _particleSize() {
            float t = particleAge();
            switch ((_packed >> 14u) & 7u) {
                case 1u: return clamp(t * 32.0, 0.0, 1.0);
                case 2u: return 1.0 - t * t * 0.5;
                case 3u: return 1.0 - t * t;
                case 4u: return 1.0 - (1.0 - t) * (1.0 - t);
                case 5u: return 1.0 - _particleTicks() / (particleLifetime() * 1.5);
                case 6u: return clamp(t * 0.75, 0.0, 1.0);
                case 7u: return 7.1 * sin((_particleTicks() - 1.0) * 0.25 * 3.14159265);
            }
            return 1.0;
        }

        bool _particleFixed() { return ((_packed >> 12u) & 3u) == 2u; }

        vec3 vertexPosition() {
            vec2 corner = _particleCorner() * _size * _particleSize();
            vec3 offset;
            if (_particleFixed()) {
                offset = _particleRotate(_rotation, vec3(corner, 0.0));
            }
            else {
                float roll = mix(_rotation.x, _rotation.y, _particleOrigin.w);
                vec2 turned = vec2(corner.x * cos(roll) - corner.y * sin(roll), corner.x * sin(roll) + corner.y * cos(roll));
                vec3 right = inverseView[0].xyz;
                vec3 up = inverseView[1].xyz;
                if (((_packed >> 12u) & 3u) == 1u) {
                    right = normalize(vec3(right.x, 0.0, right.z));
                    up = vec3(0.0, 1.0, 0.0);
                }
                offset = right * turned.x + up * turned.y;
            }
            return mix(_previous, _position, _particleOrigin.w) + _particleOrigin.xyz + offset;
        }

        vec3 vertexUv() {
            vec2 corner = _particleCorner();
            uint layer = _packed & 0xFFFu;
            return vec3(corner.x > 0.0 ? _uv.z : _uv.x, corner.y > 0.0 ? _uv.y : _uv.w, layer == 0xFFFu ? -1.0 : float(layer));
        }

        vec4 vertexColour() {
            float t = particleAge();
            switch ((_packed >> 17u) & 3u) {
                case 1u: return vec4(_colour.rgb, 0.6 - (_particleTicks() - 1.0) * 0.125);
                case 2u: return vec4(_colour.rgb, 1.0 - clamp(t, 0.0, 1.0));
                case 3u: return vec4(_colour.rgb, 0.6 * clamp((t - 0.25) / 0.75, 0.0, 1.0));
            }
            return _colour;
        }

        bool vertexIsEmissive() { return ((_packed >> 19u) & 7u) == 1u; }

        vec2 vertexLight() {
            float sky = float((_packed >> 22u) & 15u);
            float block = float((_packed >> 26u) & 15u);
            float t = clamp(particleAge(), 0.0, 1.0);
            switch ((_packed >> 19u) & 7u) {
                case 1u: return vec2(15.0, 15.0);
                case 2u: return vec2(sky, 15.0);
                case 3u: return vec2(sky, min(block + t * 15.0, 15.0));
                case 4u: return vec2(sky, min(block + t * t * t * t * 15.0, 15.0));
                case 5u: return vec2(0.0, min(15.0, 15.9 * (t >= 0.9 ? (1.0 - t) / 0.1 : t <= 0.3 ? t / 0.3 : 1.0)));
            }
            return vec2(sky, block);
        }

        vec3 vertexNormal() { return _particleFixed() ? _particleRotate(_rotation, vec3(0.0, 0.0, 1.0)) : inverseView[2].xyz; }
        """;

    /// <summary>Both stages of a <c>weather</c> pass: the texture of whichever of rain and snow is being drawn.</summary>
    private static readonly string WeatherShared = $$"""
        layout(binding = {{Weather.WeatherRenderer.TextureUnit}}) uniform sampler2D weatherTexture;
        """;

    /// <summary>
    /// One instance per column, a four vertex strip. The column is a block offset from an origin near the camera,
    /// with its bottom and top; the offset of that origin, and the clock everything scrolls by, come once a frame.
    /// </summary>
    private static readonly string WeatherInputs = $$"""
        layout(location = 0) in ivec4 _column;
        layout(location = 1) in uvec4 _columnData;
        layout(location = 2) in vec4 _columnRandom;

        layout(std140, binding = {{Weather.WeatherRenderer.UniformBinding}}) uniform WeatherFrame {
            vec4 _weatherOrigin;
            vec4 _weatherCameraBlock;
            vec4 _weatherSettings;
        };

        vec2 _weatherCorner() { return vec2(float(gl_VertexID & 1), float((gl_VertexID >> 1) & 1)); }
        vec2 _weatherFromCamera() { return vec2(_column.xy) + _weatherCameraBlock.xz; }
        bool vertexIsSnow() { return _columnData.z != 0u; }

        vec3 vertexPosition() {
            vec2 corner = _weatherCorner();
            vec2 fromCamera = _weatherFromCamera();
            float distance = length(fromCamera);
            vec2 halfSize = distance > 0.0 ? vec2(-fromCamera.y, fromCamera.x) / distance * 0.5 : vec2(0.0);
            vec2 centre = vec2(_column.xy) + 0.5 + _weatherOrigin.xz + (corner.x > 0.5 ? halfSize : -halfSize);
            return vec3(centre.x, float(corner.y > 0.5 ? _column.w : _column.z) + _weatherOrigin.y, centre.y);
        }

        vec2 vertexUv() {
            vec2 corner = _weatherCorner();
            float ticks = _weatherOrigin.w;
            float v = (float(corner.y > 0.5 ? _column.z : _column.w) + _weatherCameraBlock.w) * 0.25;
            if (vertexIsSnow()) {
                return vec2(corner.x + fract(_columnRandom.x + ticks * _columnRandom.y),
                    v + fract(_columnRandom.z + ticks * _columnRandom.w - mod(ticks, 512.0) / 512.0));
            }
            return vec2(corner.x, v + fract(-(ticks + float(_columnData.w)) / 32.0 * _columnRandom.x));
        }

        vec4 vertexColour() {
            vec2 relative = vec2(_column.xy) + 0.5 + _weatherOrigin.xz;
            float fade = min(dot(relative, relative) / (_weatherSettings.y * _weatherSettings.y), 1.0);
            return vec4(1.0, 1.0, 1.0, mix(vertexIsSnow() ? 0.8 : 1.0, 0.5, fade) * _weatherSettings.x);
        }

        vec2 vertexLight() { return vec2(_columnData.xy); }

        vec3 vertexNormal() {
            vec2 fromCamera = _weatherFromCamera();
            float distance = length(fromCamera);
            return distance > 0.0 ? vec3(-fromCamera.x, 0.0, -fromCamera.y) / distance : vec3(0.0, 0.0, 1.0);
        }
        """;

    /// <summary>Both stages of a <c>clouds</c> pass: the layer, the cell map, and the trace through it.</summary>
    private static readonly string CloudShared = $$"""
        layout(std140, binding = {{Weather.CloudRenderer.UniformBinding}}) uniform CloudFrame {
            vec4 _cloudColour;
            vec4 _cloudCamera;
            vec4 _cloudShape;
            vec4 _cloudMap;
        };

        layout(binding = {{Weather.CloudRenderer.TextureUnit}}) uniform sampler2D cloudMap;

        vec4 cloudColour() { return _cloudColour; }
        float cloudFadeDistance() { return _cloudShape.y; }
        bool cloudIsFlat() { return _cloudShape.z > 0.5; }

        struct CloudHit {
            vec3 position;
            vec3 normal;
            float distance;
            uint face;
            bool inside;
            vec4 cell;
        };

        bool _cloudCell(ivec2 cell, out vec4 texel) {
            ivec2 size = ivec2(_cloudMap.xy);
            // GLSL leaves % undefined for negative operands.
            texel = texelFetch(cloudMap, cell - size * ivec2(floor(vec2(cell) / vec2(size))), 0);
            return texel.a * 255.0 >= 9.5;
        }

        bool cloudTrace(vec3 direction, out CloudHit hit) {
            hit = CloudHit(vec3(0.0), vec3(0.0), 0.0, 0u, false, vec4(0.0));
            vec3 origin = _cloudCamera.xyz;
            float cell = _cloudCamera.w;
            float far = _cloudShape.y;
            float thickness = _cloudShape.x;
            vec4 texel;
            bool vertical = abs(direction.y) < 1e-6;
            if (cloudIsFlat()) {
                float t = vertical ? -1.0 : -origin.y / direction.y;
                if (t <= 0.0 || t >= far || !_cloudCell(ivec2(floor((origin.xz + direction.xz * t) / cell)), texel)) {
                    return false;
                }
                hit = CloudHit(direction * t, vec3(0.0, direction.y > 0.0 ? -1.0 : 1.0, 0.0), t, direction.y > 0.0 ? 0u : 1u, false, texel);
                return true;
            }
            float enter = 0.0, exit = far, slabExit = 1e30;
            if (vertical) {
                if (origin.y < 0.0 || origin.y > thickness) {
                    return false;
                }
            }
            else {
                float a = -origin.y / direction.y, b = (thickness - origin.y) / direction.y;
                enter = max(min(a, b), 0.0);
                slabExit = max(a, b);
                exit = min(slabExit, far);
            }
            if (enter >= exit) {
                return false;
            }
            ivec2 at = ivec2(floor((origin.xz + direction.xz * enter) / cell));
            vec2 stepSign = vec2(direction.x >= 0.0 ? 1.0 : -1.0, direction.z >= 0.0 ? 1.0 : -1.0);
            vec2 next = vec2(1e30), delta = vec2(1e30);
            if (abs(direction.x) > 1e-7) {
                next.x = ((float(at.x) + max(stepSign.x, 0.0)) * cell - origin.x) / direction.x;
                delta.x = cell / abs(direction.x);
            }
            if (abs(direction.z) > 1e-7) {
                next.y = ((float(at.y) + max(stepSign.y, 0.0)) * cell - origin.z) / direction.z;
                delta.y = cell / abs(direction.z);
            }
            if (_cloudCell(at, texel)) {
                if (enter > 0.0) {
                    hit = CloudHit(direction * enter, vec3(0.0, direction.y > 0.0 ? -1.0 : 1.0, 0.0), enter, direction.y > 0.0 ? 0u : 1u, false, texel);
                    return true;
                }
                // Inside a cloud: the walls of its cell, seen from within, as vanilla's inside faces are.
                float t = min(min(next.x, next.y), slabExit);
                if (t >= far) {
                    return false;
                }
                vec3 normal = t == slabExit ? vec3(0.0, -sign(direction.y), 0.0) : next.x <= next.y ? vec3(-stepSign.x, 0.0, 0.0) : vec3(0.0, 0.0, -stepSign.y);
                uint face = t == slabExit ? (direction.y > 0.0 ? 1u : 0u) : next.x <= next.y ? (direction.x > 0.0 ? 5u : 4u) : (direction.z > 0.0 ? 3u : 2u);
                hit = CloudHit(direction * t, normal, t, face, true, texel);
                return true;
            }
            // From cell to cell along the ray while it is inside the layer: its far side is never past the fade.
            for (int i = 0; i < 512; i++) {
                bool alongX = next.x < next.y;
                float t = alongX ? next.x : next.y;
                if (t >= exit) {
                    return false;
                }
                if (alongX) {
                    at.x += int(stepSign.x);
                    next.x += delta.x;
                }
                else {
                    at.y += int(stepSign.y);
                    next.y += delta.y;
                }
                if (_cloudCell(at, texel)) {
                    vec3 normal = alongX ? vec3(-stepSign.x, 0.0, 0.0) : vec3(0.0, 0.0, -stepSign.y);
                    uint face = alongX ? (direction.x > 0.0 ? 4u : 5u) : (direction.z > 0.0 ? 2u : 3u);
                    hit = CloudHit(direction * t, normal, t, face, false, texel);
                    return true;
                }
            }
            return false;
        }
        """;

    /// <summary>
    /// The box the layer fills out to its fade distance, camera relative, from the vertex index: 36 corners, each face
    /// wound to face inward, so culling keeps the walls on its far side and every pixel the layer covers is drawn once.
    /// </summary>
    private const string CloudInputs = """
        vec3 vertexPosition() {
            const int corners[36] = int[36](0, 4, 1, 1, 4, 5, 2, 3, 6, 3, 7, 6, 0, 2, 4, 2, 6, 4, 1, 5, 3, 3, 5, 7, 0, 1, 2, 1, 3, 2, 4, 6, 5, 5, 6, 7);
            int corner = corners[gl_VertexID % 36];
            float reach = _cloudShape.y;
            return vec3((corner & 1) != 0 ? reach : -reach, _cloudShape.w + ((corner & 2) != 0 ? _cloudShape.x : 0.0), (corner & 4) != 0 ? reach : -reach);
        }
        """;

    /// <summary>
    /// A text display's glyphs, kept in font pixels; the display's pose comes per draw, as do the text's alpha, the
    /// background's colour and the light, so a display only sends its mesh again when the text changes.
    /// </summary>
    private const string TextInputs = """
        layout(location = 0) in vec3 _position;
        layout(location = 1) in vec2 _uv;
        layout(location = 2) in vec4 _colourLayer;
        layout(location = 3) in vec4 _row0;
        layout(location = 4) in vec4 _row1;
        layout(location = 5) in vec4 _row2;
        layout(location = 6) in uvec2 _backgroundLight;

        vec3 vertexPosition() {
            vec4 p = vec4(_position, 1.0);
            return vec3(dot(_row0, p), dot(_row1, p), dot(_row2, p));
        }
        vec2 vertexUv() { return _uv; }
        float vertexTextLayer() { return floor(_colourLayer.a * 255.0 + 0.5); }
        bool vertexIsBackground() { return vertexTextLayer() < 0.5; }
        vec4 vertexColour() {
            if (vertexIsBackground()) {
                uint argb = _backgroundLight.x;
                return vec4(float((argb >> 16u) & 255u), float((argb >> 8u) & 255u), float(argb & 255u), float(argb >> 24u)) / 255.0;
            }
            return vec4(_colourLayer.rgb, float(_backgroundLight.y & 255u) / 255.0);
        }
        vec2 vertexLight() { return vec2(float((_backgroundLight.y >> 8u) & 15u), float((_backgroundLight.y >> 12u) & 15u)); }
        vec3 vertexNormal() { return normalize(vec3(_row0.z, _row1.z, _row2.z)); }
        """;

    /// <summary>
    /// One instance per entity shadow: the box under the entity's feet the shadow can fall in, as 36 corners wound to
    /// face inward, so culling keeps the walls on its far side and every pixel the box covers is drawn once.
    /// </summary>
    private const string EntityShadowInputs = """
        layout(location = 0) in vec4 _shadowCentreRadius;
        layout(location = 1) in vec4 _shadowPowerBottom;
        layout(location = 2) in vec4 _shadowUv;

        vec3 shadowCentre() { return _shadowCentreRadius.xyz; }
        float shadowRadius() { return _shadowCentreRadius.w; }
        float shadowPower() { return _shadowPowerBottom.x; }
        float shadowBottom() { return _shadowPowerBottom.y; }
        vec4 shadowUv() { return _shadowUv; }
        vec3 vertexPosition() {
            const int corners[36] = int[36](0, 4, 1, 1, 4, 5, 2, 3, 6, 3, 7, 6, 0, 2, 4, 2, 6, 4, 1, 5, 3, 3, 5, 7, 0, 1, 2, 1, 3, 2, 4, 6, 5, 5, 6, 7);
            int corner = corners[gl_VertexID % 36];
            vec3 centre = shadowCentre();
            float radius = shadowRadius();
            return vec3(centre.x + ((corner & 1) != 0 ? radius : -radius), (corner & 2) != 0 ? centre.y + 0.1 : shadowBottom(),
                centre.z + ((corner & 4) != 0 ? radius : -radius));
        }
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
            : pass.Geometry is "entities" or "entities_translucent" or "entities_additive" or "hand" or "crumbling" or "water_mask" or "glint" or "hand_glint"
                or "entity_outline" ? "ENTITY"
            : pass.Geometry == "end_portal" ? "PORTAL"
            : pass.Geometry is "particles" or "particles_translucent" ? "PARTICLE"
            : pass.Geometry == "weather" ? "WEATHER"
            : pass.Geometry == "clouds" ? "CLOUDS"
            : pass.Geometry is "text" or "text_see_through" ? "TEXT"
            : pass.Geometry == "entity_shadows" ? "ENTITY_SHADOW"
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
        header.Append(kind switch { "WEATHER" => WeatherShared + "\n", "CLOUDS" => CloudShared + "\n", _ => "" });

        string vertexInputs = kind switch {
            "TERRAIN" => TerrainInputs,
            "ENTITY" => glint ? EntityInputs + "\n" + GlintInputs : EntityInputs,
            "COLOURED" => ColouredInputs,
            "PORTAL" => PortalInputs,
            "PARTICLE" => ParticleInputs,
            "WEATHER" => WeatherInputs,
            "CLOUDS" => CloudInputs,
            "TEXT" => TextInputs,
            "ENTITY_SHADOW" => EntityShadowInputs,
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
