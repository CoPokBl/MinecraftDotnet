using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.CowVariant;

/// <remarks>
/// The spawn conditions a datapack gives a variant are server side, and vanilla's network codec
/// drops them, so they aren't part of this type.
/// </remarks>
public interface ICowVariant : IProtocolType {
    public CowVariantModel Model { get; }
    public Identifier AssetId { get; }
    public Identifier BabyAssetId { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_id", new StringTag(AssetId.ToString())),
            ("baby_asset_id", new StringTag(BabyAssetId.ToString()))
        ];

        // The default is left out, matching how the vanilla data writes it
        if (Model != CowVariantModel.Normal) {
            children.Add(("model", new StringTag(Model.ToProtocolString())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static ICowVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleCowVariant(
            ident,
            tag.Contains("model")
                ? CowVariantModelExtensions.ParseCowVariantModel(tag["model"]!.GetString())
                : CowVariantModel.Normal,
            tag["asset_id"]!.GetString(),
            tag["baby_asset_id"]!.GetString());
    }
}
