using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.TrimMaterial;

public interface ITrimMaterial : IProtocolType {
    /// <summary>
    /// The suffix the client sticks on a trim pattern's texture name to find this material's
    /// version of it.
    /// </summary>
    public string AssetName { get; }

    /// <summary>Name shown on a trimmed item's tooltip, coloured to match the material.</summary>
    public TextComponent Description { get; }

    /// <summary>
    /// Asset names to use instead of <see cref="AssetName"/> on particular armour, keyed by
    /// equipment asset id. Armour made of the same material as the trim would be invisible
    /// otherwise, so those combinations get a darker variant.
    /// </summary>
    public IReadOnlyDictionary<Identifier, string> OverrideArmorAssets { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_name", new StringTag(AssetName)),
            ("description", Description.SerialiseToTag())
        ];

        if (OverrideArmorAssets.Count > 0) {
            children.Add(("override_armor_assets", new CompoundTag(OverrideArmorAssets
                .Select(o => (o.Key.ToString(), (INbtTag)new StringTag(o.Value)))
                .ToArray())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static ITrimMaterial FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        Dictionary<Identifier, string> overrides = [];
        if (tag.Contains("override_armor_assets")) {
            foreach ((string key, INbtTag value) in ((CompoundTag)tag["override_armor_assets"]!).Children) {
                overrides[key] = value.GetString();
            }
        }

        return new SimpleTrimMaterial(
            ident,
            tag["asset_name"]!.GetString(),
            TextComponent.FromTag(tag["description"]!),
            overrides);
    }
}
