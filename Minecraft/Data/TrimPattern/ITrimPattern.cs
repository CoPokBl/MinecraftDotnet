using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.TrimPattern;

public interface ITrimPattern : IProtocolType {
    public Identifier AssetId { get; }
    public TextComponent Description { get; }
    public bool Decal { get; }

    public INbtTag ToNbt() {
        return new CompoundTag(
            ("asset_id", new StringTag(AssetId.ToString())),
            ("description", Description.SerialiseToTag()),
            ("decal", new BooleanTag(Decal)));
    }

    public static ITrimPattern FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        return new SimpleTrimPattern(
            ident,
            tag["asset_id"].GetString(),
            TextComponent.FromTag(tag["description"]),
            tag.Contains("decal") && tag["decal"].GetBoolean());
    }
}
