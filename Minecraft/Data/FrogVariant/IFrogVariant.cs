using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.FrogVariant;

/// <remarks>
/// The spawn conditions a datapack gives a variant are server side, and vanilla's network codec
/// drops them, so they aren't part of this type.
/// </remarks>
public interface IFrogVariant : IProtocolType {
    public Identifier AssetId { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_id", new StringTag(AssetId.ToString()))
        ];

        return new CompoundTag(children.ToArray());
    }

    public static IFrogVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleFrogVariant(
            ident,
            tag["asset_id"]!.GetString());
    }
}
