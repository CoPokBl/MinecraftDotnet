using Minecraft.Schemas;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Rendering.Entities.Vanilla;

/// <summary>An equipment asset's layers per layer type, read from <c>assets/&lt;ns&gt;/equipment/&lt;path&gt;.json</c>.</summary>
public sealed class EquipmentClientInfo {
    public static readonly EquipmentClientInfo Missing = new(new Dictionary<LayerType, List<Layer>>(), []);

    private readonly Dictionary<LayerType, List<Layer>> _layers;

    private EquipmentClientInfo(Dictionary<LayerType, List<Layer>> layers, List<TrimOverride> trimOverrides) {
        _layers = layers;
        TrimOverrides = trimOverrides;
    }

    public IReadOnlyList<Layer> GetLayers(LayerType type) => _layers.TryGetValue(type, out List<Layer>? layers) ? layers : [];

    /// <summary><c>trim_overrides</c>, in order: the first that matches a trim decides its texture and palette.</summary>
    public IReadOnlyList<TrimOverride> TrimOverrides { get; }

    /// <summary>
    /// <c>EquipmentClientInfo.CODEC</c>, leniently: a layer type this build does not know is skipped rather
    /// than failing the whole asset, and a malformed asset reads as <see cref="Missing"/>, which is what
    /// <c>EquipmentAssetManager</c> answers for an asset it could not load.
    /// </summary>
    public static EquipmentClientInfo Parse(byte[] json) {
        try {
            JObject root = JObject.Parse(System.Text.Encoding.UTF8.GetString(json));
            Dictionary<LayerType, List<Layer>> layers = new();
            if (root["layers"] is not JObject byType) {
                return Missing;
            }
            foreach ((string name, JToken? list) in byType) {
                if (!LayerTypes.TryGetValue(name, out LayerType type) || list is not JArray entries) {
                    continue;
                }
                List<Layer> parsed = [];
                foreach (JToken entry in entries) {
                    if (entry is not JObject layer || layer["texture"]?.Value<string>() is not { } texture) {
                        continue;
                    }
                    Dyeable? dyeable = null;
                    if (layer["dyeable"] is JObject dye) {
                        dyeable = new Dyeable(ReadRgb(dye["color_when_undyed"]));
                    }
                    parsed.Add(new Layer(Identifier.Parse(texture), dyeable, layer["use_player_texture"]?.Value<bool>() ?? false));
                }
                layers[type] = parsed;
            }
            List<TrimOverride> overrides = [];
            if (root["trim_overrides"] is JArray trimOverrides) {
                foreach (JObject entry in trimOverrides.OfType<JObject>()) {
                    if (ParseTrimOverride(entry) is { } parsed) {
                        overrides.Add(parsed);
                    }
                }
            }
            return new EquipmentClientInfo(layers, overrides);
        }
        catch (Exception e) when (e is Newtonsoft.Json.JsonException or FormatException or InvalidCastException or ArgumentException) {
            return Missing;
        }
    }

    /// <summary>
    /// <c>TrimOverride.CODEC</c>, which needs one of a texture or a palette, over a <c>TrimPredicate</c> that needs
    /// one of a material or a pattern. One that fails either is skipped here, where vanilla fails the asset.
    /// </summary>
    private static TrimOverride? ParseTrimOverride(JObject entry) {
        if (entry["when"] is not JObject when) {
            return null;
        }
        Identifier? material = when["material"]?.Value<string>() is { } m ? (Identifier?)Identifier.Parse(m) : null;
        Identifier? pattern = when["pattern"]?.Value<string>() is { } p ? (Identifier?)Identifier.Parse(p) : null;
        Identifier? texture = entry["texture"]?.Value<string>() is { } t ? (Identifier?)Identifier.Parse(t) : null;
        Identifier? palette = entry["palette"]?.Value<string>() is { } c ? (Identifier?)Identifier.Parse(c) : null;
        return material == null && pattern == null || texture == null && palette == null ? null : new TrimOverride(material, pattern, texture, palette);
    }

    /// <summary><c>EquipmentClientInfo.TrimOverride</c> with its <c>TrimPredicate</c> folded in.</summary>
    public sealed record TrimOverride(Identifier? Material, Identifier? Pattern, Identifier? Texture, Identifier? Palette) {
        /// <summary>
        /// <c>TrimPredicate.matches</c>, by <c>Holder.is</c>. An inline material or pattern has no key, and is
        /// matched by the id that stands in for one.
        /// </summary>
        public bool Matches(Minecraft.Data.Components.Types.TrimComponent.Data trim) =>
            (Material == null || trim.Material.Identifier == Material) && (Pattern == null || trim.Pattern.Identifier == Pattern);
    }

    /// <summary><c>ExtraCodecs.RGB_COLOR_CODEC</c>: a packed integer, or three floats from 0 to 1.</summary>
    private static int? ReadRgb(JToken? token) {
        switch (token) {
            case null:
                return null;
            case JArray { Count: 3 } rgb:
                int Channel(int i) => (int)MathF.Floor(rgb[i].Value<float>() * 255.0F) & 0xFF;
                return Channel(0) << 16 | Channel(1) << 8 | Channel(2);
            default:
                return token.Value<int>();
        }
    }

    public sealed record Dyeable(int? ColorWhenUndyed);

    public sealed record Layer(Identifier TextureId, Dyeable? Dyeable, bool UsePlayerTexture) {
        public string GetTextureLocation(LayerType type) =>
            $"{TextureId.Namespace}:textures/entity/equipment/{SerializedName(type)}/{TextureId.Key}.png";
    }

    public enum LayerType {
        Humanoid, HumanoidLeggings, HumanoidBaby, Wings, WolfBody, HorseBody, LlamaBody, PigSaddle, StriderSaddle, CamelSaddle, CamelHuskSaddle,
        HorseSaddle, DonkeySaddle, MuleSaddle, ZombieHorseSaddle, SkeletonHorseSaddle, HappyGhastBody, NautilusSaddle, NautilusBody
    }

    /// <summary>The serialised name of each layer type is its own name in snake case.</summary>
    private static readonly Dictionary<LayerType, string> SerializedNames =
        Enum.GetValues<LayerType>().ToDictionary(type => type, type => Regex.Replace(type.ToString(), "(?<!^)([A-Z])", "_$1").ToLowerInvariant());

    private static readonly Dictionary<string, LayerType> LayerTypes = SerializedNames.ToDictionary(pair => pair.Value, pair => pair.Key);

    private static string SerializedName(LayerType type) => SerializedNames[type];

    /// <summary><c>LayerType.trimAssetPrefix</c>.</summary>
    public static string TrimAssetPrefix(LayerType type) => "trims/entity/" + SerializedName(type);
}
