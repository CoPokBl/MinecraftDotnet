using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.TrimPattern;

public interface ITrimPattern : IProtocolType, INetworkType<ITrimPattern> {
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
            tag["asset_id"]!.GetString(),
            TextComponent.FromTag(tag["description"]!),
            tag.Contains("decal") && tag["decal"]!.GetBoolean());
    }

    DataWriter INetworkType<ITrimPattern>.WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer.Write(AssetId).WriteNbt(Description).WriteBoolean(Decal);
    }

    static ITrimPattern INetworkType<ITrimPattern>.ReadData(DataReader reader, MinecraftRegistry registry) {
        return ReadData(reader, registry);
    }

    /// <remarks>
    /// An inline pattern has no registry name, so the asset it draws stands in as its identifier.
    /// </remarks>
    public new static ITrimPattern ReadData(DataReader reader, MinecraftRegistry registry) {
        Identifier assetId = reader.ReadString();
        return new SimpleTrimPattern(assetId, assetId, reader.ReadText(), reader.ReadBoolean());
    }
}
