using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.WolfVariant;

/// <remarks>
/// The spawn conditions a datapack gives a variant are server side, and vanilla's network codec
/// drops them, so they aren't part of this type.
/// </remarks>
public interface IWolfVariant : IProtocolType {
    public WolfAssetInfo Assets { get; }
    public WolfAssetInfo BabyAssets { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("assets", Assets.ToNbt()),
            ("baby_assets", BabyAssets.ToNbt()));
    }

    public static IWolfVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleWolfVariant(
            ident,
            WolfAssetInfo.FromNbt(tag["assets"]!),
            WolfAssetInfo.FromNbt(tag["baby_assets"]!));
    }
}
