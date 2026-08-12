using Minecraft.Schemas;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.WolfVariant;

/// <summary>The three textures a wolf of one variant is drawn with, picked by how it's behaving.</summary>
public record WolfAssetInfo(Identifier Wild, Identifier Tame, Identifier Angry) {

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("wild", new StringTag(Wild.ToString())),
            ("tame", new StringTag(Tame.ToString())),
            ("angry", new StringTag(Angry.ToString())));
    }

    public static WolfAssetInfo FromNbt(INbtTag tag) {
        CompoundTag compound = (CompoundTag)tag;
        return new WolfAssetInfo(
            compound["wild"]!.GetString(),
            compound["tame"]!.GetString(),
            compound["angry"]!.GetString());
    }
}
