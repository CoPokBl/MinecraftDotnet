using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record WritableBookContentComponent() : IDataComponent<WritableBookContentComponent.Data> {
    public override Identifier Identifier => "minecraft:writable_book_content";

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedArray(val.Contents, (val2, w) => {
                w.WriteString(val2.Raw);
                w.WritePrefixedOptional(val2.Filtered, (l2, w2) => w2.WriteString(l2));
        });
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        var contents = reader.ReadPrefixedArray<BookContent>(r => {
            string raw = r.ReadString();
            string? filtered = r.ReadPrefixedOptional(x => x.ReadString());
            return new BookContent(raw, filtered);
        });
        return new Data(contents);
    }

    public override bool ValuesEqual(Data val1, Data val2)
    {
        if (ReferenceEquals(val1, val2))
            return true;

        if (val1.Contents.Length != val2.Contents.Length)
            return false;

        return val1.Contents.SequenceEqual(val2.Contents);
    }
    public record Data(BookContent[] Contents);
    public record BookContent(string Raw, string? Filtered = null);
    public static Data ConvertStringsToData(string[]? rawStrings) {
        if (rawStrings == null) return new Data(Array.Empty<BookContent>());

        var contents = new BookContent[rawStrings.Length];
        for (int i = 0; i < rawStrings.Length; i++) {
            contents[i] = new BookContent(rawStrings[i]);
        }

        return new Data(contents);
    }
}