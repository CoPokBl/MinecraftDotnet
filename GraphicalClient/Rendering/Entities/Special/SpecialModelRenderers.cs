using Minecraft.Schemas;
using Newtonsoft.Json.Linq;

namespace GraphicalClient.Rendering.Entities.Special;

/// <summary>
/// <c>SpecialModelRenderers</c>: the <c>type</c> of a <c>minecraft:special</c> item model's <c>model</c>
/// field, each read into its unbaked renderer. A type missing here is one not ported, and the item
/// definition is read as though the special model were absent.
/// </summary>
public static class SpecialModelRenderers {
    private static readonly Dictionary<Identifier, Func<JObject, ISpecialModelUnbaked?>> IdMapper = new() {
        ["minecraft:shield"] = _ => ShieldSpecialRenderer.Unbaked.Instance,
        ["minecraft:trident"] = _ => TridentSpecialRenderer.Unbaked.Instance
    };

    static SpecialModelRenderers() => BlockEntities.BlockEntitySpecialRenderers.AddTo(IdMapper);

    /// <summary><c>CODEC</c>; null for a type not ported or a field it could not read.</summary>
    public static ISpecialModelUnbaked? Parse(JObject json) {
        if (json.Value<string>("type") is not { } type) {
            return null;
        }
        return IdMapper.TryGetValue(Identifier.Parse(type), out Func<JObject, ISpecialModelUnbaked?>? codec) ? codec(json) : null;
    }
}
