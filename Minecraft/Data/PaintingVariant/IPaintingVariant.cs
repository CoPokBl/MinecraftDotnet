using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.PaintingVariant;

public interface IPaintingVariant : IProtocolType, INetworkType<IPaintingVariant> {
    public Identifier AssetId { get; }
    public int Width { get; }
    public int Height { get; }
    public TextComponent? Title { get; }
    public TextComponent? Author { get; }

    public INbtTag ToNbt() {
        List<(string, INbtTag)> children = [
            ("asset_id", new StringTag(AssetId.ToString())),
            ("width", new IntegerTag(Width)),
            ("height", new IntegerTag(Height))
        ];

        if (Title != null) {
            children.Add(("title", Title.SerialiseToTag()));
        }

        if (Author != null) {
            children.Add(("author", Author.SerialiseToTag()));
        }

        return new CompoundTag(children.ToArray());
    }

    DataWriter INetworkType<IPaintingVariant>.WriteData(DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteVarInt(Width)
            .WriteVarInt(Height)
            .WriteString(AssetId.ToString())
            .WritePrefixedOptional(Title, (t, w) => w.WriteNbt(t))
            .WritePrefixedOptional(Author, (a, w) => w.WriteNbt(a));
    }

    public static IPaintingVariant FromNbt(Identifier ident, CompoundTag tag, MinecraftRegistry reg) {
        Identifier assetId = tag["asset_id"].GetString();
        int width = tag["width"].GetInteger();
        int height = tag["height"].GetInteger();

        TextComponent? title = tag.Contains("title") ? TextComponent.FromTag(tag["title"]) : null;
        TextComponent? author = tag.Contains("author") ? TextComponent.FromTag(tag["author"]) : null;

        return new SimplePaintingVariant(ident, assetId, width, height, title, author);
    }

    static IPaintingVariant INetworkType<IPaintingVariant>.ReadData(DataReader reader, MinecraftRegistry registry) {
        return ReadData(reader, registry);
    }
    
    public new static IPaintingVariant ReadData(DataReader reader, MinecraftRegistry registry) {
        int width = reader.ReadVarInt();
        int height = reader.ReadVarInt();
        Identifier assetId = reader.ReadString();
        TextComponent? title = reader.ReadPrefixedOptional(r => r.ReadText());
        TextComponent? author = reader.ReadPrefixedOptional(r => r.ReadText());
        return new SimplePaintingVariant(assetId, assetId, width, height, title, author);
    }
}
