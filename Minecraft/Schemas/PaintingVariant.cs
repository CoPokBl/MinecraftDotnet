using Minecraft.Text;

namespace Minecraft.Schemas;

public record PaintingVariant(
    int Width,
    int Height,
    Identifier Asset,
    TextComponent? Title = null,
    TextComponent? Author = null) : IWritable {
    
    public static PaintingVariant Read(DataReader reader) {
        int width = reader.ReadVarInt();
        int height = reader.ReadVarInt();
        string asset = reader.ReadString();
        TextComponent? title = reader.ReadPrefixedOptional(r => r.ReadText());
        TextComponent? author = reader.ReadPrefixedOptional(r => r.ReadText());

        return new PaintingVariant(width, height, asset, title, author);
    }

    public void Write(DataWriter writer) {
        writer.WriteVarInt(Width)
              .WriteVarInt(Height)
              .WriteString(Asset)
              .WritePrefixedOptional(Title, (t, w) => w.WriteNbt(t))
              .WritePrefixedOptional(Author, (a, w) => w.WriteNbt(a));
    }
}
