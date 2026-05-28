using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.Components.Types;

public record WritableBookContentComponent() : IDataComponent<WritableBookContentComponent.Data> {
    public override Identifier Identifier => "minecraft:writable_book_content";

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WritePrefixedArray(val.Contents, (val2, w) => {
                w.WriteString(val2.rawContent);
                w.WritePrefixedOptional(val2.filteredContent, (l2, w2) => w2.WriteString(l2));
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

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1 == val2;
    }
    public record Data(BookContent[] Contents);
    public class BookContent {
        public string rawContent;
        public string? filteredContent = null;
        public BookContent(string raw) { rawContent = raw; }
        public BookContent(string raw, string? filtered) { rawContent = raw; filteredContent = filtered; }
    }
    public static Data ConvertStringsToData(string[] rawStrings) {
        if (rawStrings == null) return new Data(Array.Empty<BookContent>());

        var contents = new BookContent[rawStrings.Length];
        for (int i = 0; i < rawStrings.Length; i++) {
            contents[i] = new BookContent(rawStrings[i]);
        }

        return new Data(contents);
    }
}