using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ChickenVariant;

/// <remarks>
/// The spawn conditions a datapack gives a variant are server side, and vanilla's network codec
/// drops them, so they aren't part of this type.
/// </remarks>
public interface IChickenVariant : IProtocolType {
    public ChickenVariantModel Model { get; }
    public Identifier AssetId { get; }
    public Identifier BabyAssetId { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_id", new StringTag(AssetId.ToString())),
            ("baby_asset_id", new StringTag(BabyAssetId.ToString()))
        ];

        // The default is left out, matching how the vanilla data writes it
        if (Model != ChickenVariantModel.Normal) {
            children.Add(("model", new StringTag(Model.ToProtocolString())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static IChickenVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleChickenVariant(
            ident,
            tag.Contains("model")
                ? ChickenVariantModelExtensions.ParseChickenVariantModel(tag["model"]!.GetString())
                : ChickenVariantModel.Normal,
            tag["asset_id"]!.GetString(),
            tag["baby_asset_id"]!.GetString());
    }
}
