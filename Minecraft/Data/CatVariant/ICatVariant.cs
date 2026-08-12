using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.CatVariant;

/// <remarks>
/// The spawn conditions a datapack gives a variant are server side, and vanilla's network codec
/// drops them, so they aren't part of this type.
/// </remarks>
public interface ICatVariant : IProtocolType {
    public Identifier AssetId { get; }
    public Identifier BabyAssetId { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_id", new StringTag(AssetId.ToString())),
            ("baby_asset_id", new StringTag(BabyAssetId.ToString()))
        ];

        return new CompoundTag(children.ToArray());
    }

    public static ICatVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleCatVariant(
            ident,
            tag["asset_id"]!.GetString(),
            tag["baby_asset_id"]!.GetString());
    }
}
