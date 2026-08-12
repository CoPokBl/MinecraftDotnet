using Minecraft.Schemas;
using Minecraft.Text;

namespace Minecraft.Data.TrimMaterial;

public record SimpleTrimMaterial(
    Identifier Identifier,
    string AssetName,
    TextComponent Description,
    IReadOnlyDictionary<Identifier, string> OverrideArmorAssets) : ITrimMaterial {

    public SimpleTrimMaterial(Identifier identifier, string assetName, TextComponent description)
        : this(identifier, assetName, description, new Dictionary<Identifier, string>()) { }
}
