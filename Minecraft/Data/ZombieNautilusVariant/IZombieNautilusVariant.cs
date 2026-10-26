using Minecraft.Registry;
using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.ZombieNautilusVariant;

/// <remarks>
/// The spawn conditions a datapack gives a variant are server side, and vanilla's network codec
/// drops them, so they aren't part of this type.
/// </remarks>
public interface IZombieNautilusVariant : IProtocolType {
    public ZombieNautilusVariantModel Model { get; }
    public Identifier AssetId { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_id", new StringTag(AssetId.ToString()))
        ];

        // The default is left out, matching how the vanilla data writes it
        if (Model != ZombieNautilusVariantModel.Normal) {
            children.Add(("model", new StringTag(Model.ToProtocolString())));
        }

        return new CompoundTag(children.ToArray());
    }

    public static IZombieNautilusVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleZombieNautilusVariant(
            ident,
            tag.Contains("model")
                ? ZombieNautilusVariantModelExtensions.ParseZombieNautilusVariantModel(tag["model"]!.GetString())
                : ZombieNautilusVariantModel.Normal,
            tag["asset_id"]!.GetString());
    }
}
