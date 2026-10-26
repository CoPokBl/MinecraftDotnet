using System.Numerics;
using Minecraft.Data.Blocks;
using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Assets.ResourcePacks;

/// <summary>
/// Turns a pack's blockstate and block model files into quads, following
/// <c>BlockStateModelLoader</c>, <c>CuboidModelElement</c> and <c>FaceBakery</c>: parents and texture
/// references resolved, elements turned by their own rotation and then the variant's, and textures
/// held still against that turn where a variant asks for <c>uvlock</c>.
/// </summary>
public sealed class BlockModelBaker(PackFiles files) {
    private sealed record Element(Vector3 From, Vector3 To, Vector3 RotationOrigin, Mat3? Rotation, int? ShadeDirection, int LightEmission, ElementFace?[] Faces);

    private sealed record ElementFace(int? CullFace, int TintIndex, string Texture, Vector4? Uv, int Rotation);

    private sealed record UnbakedModel(string? Parent, Dictionary<string, (string Value, bool ForceTranslucent)> Textures, Element[]? Elements, bool? AmbientOcclusion,
        Dictionary<string, ItemTransform> Display, bool? SideLit);

    private static readonly string[] DisplayContexts = [
        "thirdperson_righthand", "thirdperson_lefthand", "firstperson_righthand", "firstperson_lefthand", "head", "gui", "ground", "fixed", "on_shelf"
    ];

    /// <summary>A blockstate file read once: its variant keys split, and each entry's part baked the first time a state asks for it.</summary>
    private sealed class ParsedBlockstate {
        public (KeyValuePair<string, string>[] Conditions, JToken Value)[]? Variants;
        public (JObject? When, JToken Apply)[]? Selectors;
        public BakedPart?[] Parts = [];
    }

    private readonly Dictionary<string, UnbakedModel?> _models = new();
    private readonly Dictionary<string, ParsedBlockstate?> _blockstates = new();
    private readonly Dictionary<(string Model, int X, int Y, int Z, bool UvLock), (BakedQuad[] Quads, bool Ao, string? Particle)> _baked = new();

    /// <summary>Problems met while loading, for the log; a broken file never stops the rest loading.</summary>
    public List<string> Warnings { get; } = [];

    /// <summary>The model a state draws, or null if the pack has no blockstate file for its block.</summary>
    public BakedBlockModel? Bake(IBlock state) => Bake(state.Identifier, StateProperties.Of(state));

    /// <summary>The model a blockstate file gives these properties, or null if the pack has no such file.</summary>
    public BakedBlockModel? Bake(Identifier id, IReadOnlyDictionary<string, string> properties) {
        ParsedBlockstate? blockstate = Blockstate(id);
        if (blockstate == null) {
            return null;
        }
        try {
            if (blockstate.Variants is { } variants) {
                for (int i = 0; i < variants.Length; i++) {
                    if (variants[i].Conditions.All(c => properties.TryGetValue(c.Key, out string? value) && value == c.Value)) {
                        BakedPart part = blockstate.Parts[i] ??= PartOf(variants[i].Value);
                        return new BakedBlockModel([part], false, part.Options[0].Particle);
                    }
                }
                return new BakedBlockModel([], false);
            }
            if (blockstate.Selectors is { } selectors) {
                List<BakedPart> parts = [];
                for (int i = 0; i < selectors.Length; i++) {
                    if (selectors[i].When is not { } when || ConditionHolds(when, properties)) {
                        parts.Add(blockstate.Parts[i] ??= PartOf(selectors[i].Apply));
                    }
                }
                string? particle = selectors.Length > 0 ? (blockstate.Parts[0] ??= PartOf(selectors[0].Apply)).Options[0].Particle : null;
                return new BakedBlockModel(parts.ToArray(), true, particle);
            }
        }
        catch (Exception e) when (e is InvalidCastException or NullReferenceException or FormatException or ArgumentException) {
            Warnings.Add($"{id}: {e.Message}");
        }
        return new BakedBlockModel([], false);
    }

    private ParsedBlockstate? Blockstate(Identifier id) {
        string key = id.ToString();
        if (_blockstates.TryGetValue(key, out ParsedBlockstate? parsed)) {
            return parsed;
        }
        byte[]? data = files.Read($"assets/{id.Namespace}/blockstates/{id.Key}.json");
        JObject? json = data == null ? null : Parse(data, key);
        if (json != null) {
            parsed = new ParsedBlockstate();
            if (json["variants"] is JObject variants) {
                // A variant key is prop=value pairs joined by commas, empty matching every state.
                parsed.Variants = variants.Properties().Select(p => (
                    p.Name.Length == 0 ? [] : p.Name.Split(',').Select(pair => pair.Split('=', 2)).Select(kv => KeyValuePair.Create(kv[0], kv.Length > 1 ? kv[1] : "")).ToArray(),
                    p.Value)).ToArray();
                parsed.Parts = new BakedPart?[parsed.Variants.Length];
            }
            else if (json["multipart"] is JArray multipart) {
                parsed.Selectors = multipart.OfType<JObject>().Select(selector => (selector["when"] as JObject, selector["apply"]!)).ToArray();
                parsed.Parts = new BakedPart?[parsed.Selectors.Length];
            }
        }
        _blockstates[key] = parsed;
        return parsed;
    }

    private JObject? Parse(byte[] data, string what) {
        try {
            return JObject.Parse(System.Text.Encoding.UTF8.GetString(data));
        }
        catch (Newtonsoft.Json.JsonException e) {
            Warnings.Add($"{what}: {e.Message}");
            return null;
        }
    }

    /// <summary>
    /// <c>CombinedCondition</c> and <c>KeyValueCondition</c>: every listed property must match, a value
    /// matches any of its <c>|</c> separated terms, and a term starting <c>!</c> matches anything else.
    /// </summary>
    private static bool ConditionHolds(JObject when, IReadOnlyDictionary<string, string> properties) {
        if (when["OR"] is JArray or) {
            return or.OfType<JObject>().Any(c => ConditionHolds(c, properties));
        }
        if (when["AND"] is JArray and) {
            return and.OfType<JObject>().All(c => ConditionHolds(c, properties));
        }
        foreach ((string key, JToken? token) in when) {
            string expected = token!.Type == JTokenType.Boolean ? token.Value<bool>() ? "true" : "false" : token.ToString();
            properties.TryGetValue(key, out string? actual);
            bool any = false;
            foreach (string term in expected.Split('|')) {
                any |= term.StartsWith('!') ? actual != term[1..] : actual == term;
            }
            if (!any) {
                return false;
            }
        }
        return true;
    }

    private BakedPart PartOf(JToken apply) {
        IEnumerable<JObject> variants = apply is JArray list ? list.OfType<JObject>() : [(JObject)apply];
        return new BakedPart(variants.Select(OptionOf).ToArray());
    }

    private BakedOption OptionOf(JObject variant) {
        string model = Normalise(variant.Value<string>("model") ?? "");
        int x = variant.Value<int?>("x") ?? 0, y = variant.Value<int?>("y") ?? 0, z = variant.Value<int?>("z") ?? 0;
        bool uvLock = variant.Value<bool?>("uvlock") ?? false;
        int weight = Math.Max(1, variant.Value<int?>("weight") ?? 1);
        if (!_baked.TryGetValue((model, x, y, z, uvLock), out (BakedQuad[] Quads, bool Ao, string? Particle) baked)) {
            baked = BakeModel(model, x, y, z, uvLock);
            _baked[(model, x, y, z, uvLock)] = baked;
        }
        return new BakedOption(baked.Quads, weight, baked.Ao, baked.Particle);
    }

    private static string Normalise(string id) => id.Contains(':') ? id : "minecraft:" + id;

    private UnbakedModel? Model(string id) {
        if (_models.TryGetValue(id, out UnbakedModel? model)) {
            return model;
        }
        _models[id] = null;
        Identifier identifier = Identifier.Parse(id);
        byte[]? data = files.Read($"assets/{identifier.Namespace}/models/{identifier.Key}.json");
        JObject? json = data == null ? null : Parse(data, id);
        if (json == null) {
            if (data == null && !id.StartsWith("minecraft:builtin/", StringComparison.Ordinal)) {
                Warnings.Add($"Missing model {id}");
            }
            return null;
        }

        Dictionary<string, (string, bool)> textures = new();
        if (json["textures"] is JObject textureMap) {
            foreach ((string key, JToken? value) in textureMap) {
                textures[key] = value is JObject material
                    ? (material.Value<string>("sprite") ?? "", material.Value<bool?>("force_translucent") ?? false)
                    : (value!.ToString(), false);
            }
        }
        Element[]? elements = json["elements"] is JArray array ? array.OfType<JObject>().Select(ElementOf).ToArray() : null;
        string? parent = json.Value<string>("parent") is { } p ? Normalise(p) : null;
        Dictionary<string, ItemTransform> display = new();
        if (json["display"] is JObject displayJson) {
            foreach (string context in DisplayContexts) {
                if (displayJson[context] is JObject transform) {
                    display[context] = TransformOf(transform);
                }
            }
            // ItemTransforms.Deserializer: a left hand the file leaves out is its right hand, so the
            // parent's left hand is never reached once a right hand is given.
            foreach ((string left, string right) in new[] { ("thirdperson_lefthand", "thirdperson_righthand"), ("firstperson_lefthand", "firstperson_righthand") }) {
                if (!display.ContainsKey(left) && display.TryGetValue(right, out ItemTransform? fallback)) {
                    display[left] = fallback;
                }
            }
        }
        bool? sideLit = json.Value<string>("gui_light") is { } light ? light != "front" : null;
        model = new UnbakedModel(parent, textures, elements, json.Value<bool?>("ambientocclusion"), display, sideLit);
        _models[id] = model;
        return model;
    }

    /// <summary><c>ItemTransform.Deserializer</c>: translation in sixteenths, clamped to 5 blocks, scale to 4.</summary>
    private static ItemTransform TransformOf(JObject json) {
        Vector3 rotation = json["rotation"] != null ? Vector(json["rotation"]) : Vector3.Zero;
        Vector3 translation = json["translation"] != null ? Vector3.Clamp(Vector(json["translation"]) * 0.0625F, new Vector3(-5), new Vector3(5)) : Vector3.Zero;
        Vector3 scale = json["scale"] != null ? Vector3.Clamp(Vector(json["scale"]), new Vector3(-4), new Vector3(4)) : Vector3.One;
        return new ItemTransform(rotation, translation, scale);
    }

    /// <summary>
    /// An item model by identifier. One whose parents end at <c>builtin/generated</c> is its
    /// <c>layer0</c>, <c>layer1</c> and so on sprites; any other is its elements, unturned.
    /// </summary>
    public ItemModel? BakeItem(string id) {
        id = Normalise(id);
        if (Model(id) == null) {
            return null;
        }
        List<UnbakedModel> chain = Chain(id, out bool generated);
        Dictionary<string, ItemTransform> display = new();
        foreach (string context in DisplayContexts) {
            if (chain.FirstOrDefault(m => m.Display.ContainsKey(context)) is { } holder) {
                display[context] = holder.Display[context];
            }
        }
        bool sideLit = chain.FirstOrDefault(m => m.SideLit != null)?.SideLit ?? true;
        if (generated) {
            Dictionary<string, (string, bool)> textures = Resolve(chain).Textures;
            List<string?> layers = [];
            for (int i = 0; textures.ContainsKey("layer" + i); i++) {
                layers.Add(ResolveTexture("layer" + i, textures).Texture);
            }
            return new ItemModel([], layers.ToArray(), display, false);
        }
        return new ItemModel(BakeModel(id, 0, 0, 0, false).Quads, [], display, sideLit);
    }

    /// <summary>
    /// <c>FaceBakery.bakeQuad</c> for one face of an unturned box, in sixteenths, as
    /// <c>ItemModelGenerator</c> bakes an extruded sprite.
    /// </summary>
    public static BakedQuad BakeFace(Vector3 from, Vector3 to, Vector4 uv, int direction, string? texture, int tintIndex) {
        ElementFace?[] faces = new ElementFace?[6];
        ElementFace face = new(null, tintIndex, "", uv, 0);
        faces[direction] = face;
        return BakeQuad(new Element(from, to, Vector3.Zero, null, null, 0, faces), face, direction, Mat3.Identity, false, texture, false);
    }

    private static Vector3 Vector(JToken? token) {
        JArray array = (JArray)token!;
        return new Vector3(array[0].Value<float>(), array[1].Value<float>(), array[2].Value<float>());
    }

    private static Element ElementOf(JObject json) {
        Vector3 from = Vector(json["from"]), to = Vector(json["to"]);
        Mat3? rotation = null;
        Vector3 origin = Vector3.Zero;
        if (json["rotation"] is JObject r) {
            origin = Vector(r["origin"]) * 0.0625F;
            Mat3 matrix;
            if (r["axis"] != null || r["angle"] != null) {
                float angle = r.Value<float>("angle");
                matrix = (r.Value<string>("axis") ?? "y").ToLowerInvariant() switch {
                    "x" => Mat3.RotationX(angle),
                    "z" => Mat3.RotationZ(angle),
                    _ => Mat3.RotationY(angle)
                };
            }
            else {
                // EulerXYZRotation: JOML's rotationZYX, so X is applied first.
                matrix = Mat3.RotationZ(r.Value<float?>("z") ?? 0) * Mat3.RotationY(r.Value<float?>("y") ?? 0) * Mat3.RotationX(r.Value<float?>("x") ?? 0);
            }
            if ((r.Value<bool?>("rescale") ?? false) && !matrix.IsIdentity) {
                matrix = matrix.Scaled(new Vector3(RescaleFactor(matrix, 0), RescaleFactor(matrix, 1), RescaleFactor(matrix, 2)));
            }
            rotation = matrix;
        }
        ElementFace?[] faces = new ElementFace?[6];
        if (json["faces"] is JObject faceMap) {
            foreach ((string name, JToken? value) in faceMap) {
                if (Directions.Parse(name) is not { } direction || value is not JObject face) {
                    continue;
                }
                Vector4? uv = face["uv"] is JArray u ? new Vector4(u[0].Value<float>(), u[1].Value<float>(), u[2].Value<float>(), u[3].Value<float>()) : null;
                faces[direction] = new ElementFace(Directions.Parse(face.Value<string>("cullface")), face.Value<int?>("tintindex") ?? -1,
                    face.Value<string>("texture") ?? "", uv, (((face.Value<int?>("rotation") ?? 0) % 360 + 360) % 360) / 90);
            }
        }
        return new Element(from, to, origin, rotation, Directions.Parse(json.Value<string>("shade_direction_override")), json.Value<int?>("light_emission") ?? 0, faces);
    }

    /// <summary><c>CuboidRotation.scaleFactorForAxis</c>: stretches a turned element back across the block.</summary>
    private static float RescaleFactor(Mat3 rotation, int axis) {
        Vector3 unit = axis switch { 0 => Vector3.UnitX, 1 => Vector3.UnitY, _ => Vector3.UnitZ };
        Vector3 turned = rotation.Transform(unit);
        return 1.0F / Math.Max(Math.Max(Math.Abs(turned.X), Math.Abs(turned.Y)), Math.Abs(turned.Z));
    }

    /// <summary>
    /// The model and its parents, child first, up to the first that is missing, repeated, or
    /// <c>builtin/generated</c>, which is no file but marks an extruded sprite.
    /// </summary>
    private List<UnbakedModel> Chain(string id, out bool generated) {
        List<UnbakedModel> chain = [];
        HashSet<string> seen = [];
        generated = false;
        for (string? at = id; at != null && seen.Add(at); ) {
            if (at == "minecraft:builtin/generated") {
                generated = true;
                break;
            }
            if (Model(at) is not { } model) {
                break;
            }
            chain.Add(model);
            at = model.Parent;
        }
        return chain;
    }

    /// <summary>Walks to the root and back, so a child's textures and settings override its parents'.</summary>
    private static (Element[] Elements, Dictionary<string, (string, bool)> Textures, bool Ao) Resolve(List<UnbakedModel> chain) {
        Element[] elements = chain.FirstOrDefault(m => m.Elements != null)?.Elements ?? [];
        bool ao = chain.FirstOrDefault(m => m.AmbientOcclusion != null)?.AmbientOcclusion ?? true;
        Dictionary<string, (string, bool)> textures = new();
        for (int i = chain.Count - 1; i >= 0; i--) {
            foreach ((string key, (string, bool) value) in chain[i].Textures) {
                textures[key] = value;
            }
        }
        return (elements, textures, ao);
    }

    /// <summary>
    /// <c>TextureSlots</c>: a face names a slot, with or without a leading <c>#</c>, and a slot holds either
    /// a texture or <c>#</c> and another slot's name.
    /// </summary>
    private static (string? Texture, bool ForceTranslucent) ResolveTexture(string slot, Dictionary<string, (string Value, bool Force)> textures) {
        bool force = false;
        string name = slot.StartsWith('#') ? slot[1..] : slot;
        for (int depth = 0; depth < 32; depth++) {
            if (!textures.TryGetValue(name, out (string Value, bool Force) entry)) {
                return (null, force);
            }
            force |= entry.Force;
            if (!entry.Value.StartsWith('#')) {
                return entry.Value.Length == 0 ? (null, force) : (Normalise(entry.Value), force);
            }
            name = entry.Value[1..];
        }
        return (null, force);
    }

    // FaceInfo's corners per direction, as MIN (0) or MAX (1) of x, y and z.
    private static readonly int[,,] FaceCorners = Rendering.BlockFaces.FaceInfo;

    // BlockMath's per face frames, VANILLA_UV_TRANSFORM_LOCAL_TO_GLOBAL.
    private static readonly Mat3[] LocalToGlobal = [
        Mat3.RotationX(90), Mat3.RotationX(-90), Mat3.RotationY(180), Mat3.Identity, Mat3.RotationY(-90), Mat3.RotationY(90)
    ];

    private (BakedQuad[] Quads, bool Ao, string? Particle) BakeModel(string id, int x, int y, int z, bool uvLock) {
        (Element[] elements, Dictionary<string, (string, bool)> textures, bool ao) = Resolve(Chain(id, out _));
        // Quadrant.fromXYZAngles: the blockstate's rotations are clockwise, so negative about each axis, X first.
        Mat3 rotation = Mat3.RotationZ(-z) * Mat3.RotationY(-y) * Mat3.RotationX(-x);
        List<BakedQuad> quads = [];
        foreach (Element element in elements) {
            for (int d = 0; d < 6; d++) {
                if (element.Faces[d] is not { } face) {
                    continue;
                }
                (string? texture, bool force) = ResolveTexture(face.Texture, textures);
                quads.Add(BakeQuad(element, face, d, rotation, uvLock, texture, force));
            }
        }
        return (quads.ToArray(), ao, ResolveTexture("particle", textures).Texture);
    }

    private static Vector4 DefaultUv(Vector3 from, Vector3 to, int facing) => facing switch {
        0 => new Vector4(from.X, 16 - to.Z, to.X, 16 - from.Z),
        1 => new Vector4(from.X, from.Z, to.X, to.Z),
        2 => new Vector4(16 - to.X, 16 - to.Y, 16 - from.X, 16 - from.Y),
        3 => new Vector4(from.X, 16 - to.Y, to.X, 16 - from.Y),
        4 => new Vector4(from.Z, 16 - to.Y, to.Z, 16 - from.Y),
        _ => new Vector4(16 - to.Z, 16 - to.Y, 16 - from.Z, 16 - from.Y)
    };

    /// <summary><c>FaceBakery.bakeQuad</c>.</summary>
    private static BakedQuad BakeQuad(Element element, ElementFace face, int facing, Mat3 blockRotation, bool uvLock, string? texture, bool force) {
        Vector4 uvs = face.Uv ?? DefaultUv(element.From, element.To, facing);
        Mat3? uvTransform = uvLock && !blockRotation.IsIdentity ? InverseFaceTransform(blockRotation, facing) : null;
        Vector3 middle = new(0.5F);
        Vector3[] positions = new Vector3[4];
        Vector2[] texels = new Vector2[4];
        for (int i = 0; i < 4; i++) {
            Vector3 vertex = new(
                FaceCorners[facing, i, 0] == 0 ? element.From.X : element.To.X,
                FaceCorners[facing, i, 1] == 0 ? element.From.Y : element.To.Y,
                FaceCorners[facing, i, 2] == 0 ? element.From.Z : element.To.Z);
            vertex /= 16.0F;
            if (element.Rotation is { } elementRotation) {
                vertex = elementRotation.Transform(vertex - element.RotationOrigin) + element.RotationOrigin;
            }
            if (!blockRotation.IsIdentity) {
                vertex = blockRotation.Transform(vertex - middle) + middle;
            }
            // CuboidFace.UVs.getVertexU and getVertexV, after the face's own quarter turns.
            int corner = (i + face.Rotation) % 4;
            float u = (corner is 0 or 1 ? uvs.X : uvs.Z) / 16.0F;
            float v = (corner is 0 or 3 ? uvs.Y : uvs.W) / 16.0F;
            if (uvTransform is { } transform) {
                Vector3 turned = transform.Transform(new Vector3(u - 0.5F, v - 0.5F, 0));
                (u, v) = (turned.X + 0.5F, turned.Y + 0.5F);
            }
            positions[i] = vertex;
            texels[i] = new Vector2(u, v);
        }

        int? direction = Directions.Closest(Vector3.Cross(positions[1] - positions[0], positions[2] - positions[0]));
        if (element.Rotation == null && direction is { } finalDirection) {
            RecalculateWinding(positions, texels, finalDirection);
        }
        int? cull = face.CullFace is { } c ? Directions.Nearest(blockRotation.Transform(Directions.Normals[c])) : null;
        return new BakedQuad(positions, texels, texture, force, cull, direction ?? 1, face.TintIndex, element.ShadeDirection, element.LightEmission);
    }

    /// <summary>
    /// <c>BlockMath.getFaceTransformation</c>, inverted: maps a face's texture coordinates back through
    /// the variant's rotation so the texture keeps its orientation in the world.
    /// </summary>
    private static Mat3 InverseFaceTransform(Mat3 rotation, int side) {
        Mat3 faceAction = rotation * LocalToGlobal[side];
        int newSide = Directions.Nearest(faceAction.Transform(Vector3.UnitZ));
        Mat3 result = LocalToGlobal[newSide].Transposed * faceAction;
        return result.Transposed;
    }

    /// <summary><c>FaceBakery.recalculateWinding</c>: puts the corners back in <c>FaceInfo</c>'s order for the direction the quad ended up facing.</summary>
    private static void RecalculateWinding(Vector3[] positions, Vector2[] uvs, int direction) {
        Vector3 min = new(999), max = new(-999);
        foreach (Vector3 p in positions) {
            min = Vector3.Min(min, p);
            max = Vector3.Max(max, p);
        }
        for (int vertex = 0; vertex < 4; vertex++) {
            Vector3 wanted = new(
                FaceCorners[direction, vertex, 0] == 0 ? min.X : max.X,
                FaceCorners[direction, vertex, 1] == 0 ? min.Y : max.Y,
                FaceCorners[direction, vertex, 2] == 0 ? min.Z : max.Z);
            int found = -1;
            for (int i = vertex; i < 4 && found < 0; i++) {
                if (positions[i] == wanted) {
                    found = i;
                }
            }
            if (found < 0) {
                return;
            }
            (positions[found], positions[vertex]) = (positions[vertex], positions[found]);
            (uvs[found], uvs[vertex]) = (uvs[vertex], uvs[found]);
        }
    }
}
