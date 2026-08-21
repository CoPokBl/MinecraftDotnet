using Minecraft.Data.Components.Codecs;
using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Data.Components.Types;

/// <summary>
/// A signed book. The pages are text components rather than the plain strings
/// <see cref="WritableBookContentComponent"/> holds, because signing resolves them.
/// </summary>
public record WrittenBookContentComponent() : IDataComponent<WrittenBookContentComponent.Data> {
    public override Identifier Identifier => "minecraft:written_book_content";

    public override NbtCodec<Data>? Codec => Persistent;
    private static readonly NbtCodec<Data> Persistent = new(
        (val, _) => new CompoundBuilder()
            .Tag("title", Filterable.Write(val.Title.Raw, val.Title.Filtered,
                text => new StringTag(text)))
            .String("author", val.Author)
            .Int("generation", val.Generation, 0)
            .ListOrOmit("pages", val.Pages, page => Filterable.Write(page.Raw, page.Filtered,
                text => text.SerialiseToTag()))
            .Bool("resolved", val.Resolved, false)
            .Build(),
        (tag, _) => {
            NbtNode node = NbtNode.Of(tag, "minecraft:written_book_content");
            Data data = new(
                Filterable.Read(node.Require("title"), "minecraft:written_book_content",
                    text => text.GetString(),
                    (raw, filtered) => new Title(raw, filtered)),
                node.String("author"),
                node.Int("generation", 0),
                node.List("pages", page => Filterable.Read(page, "minecraft:written_book_content",
                    TextComponent.FromTag,
                    (raw, filtered) => new Page(raw, filtered))),
                node.Bool("resolved", false));
            node.AssertRead();
            return data;
        });

    public override DataWriter WriteData(Data val, DataWriter writer, MinecraftRegistry registry) {
        return writer
            .WriteString(val.Title.Raw)
            .WritePrefixedOptional(val.Title.Filtered, (t, w) => w.WriteString(t))
            .WriteString(val.Author)
            .WriteVarInt(val.Generation)
            .WritePrefixedArray(val.Pages, (page, w) => w
                .WriteNbt(page.Raw)
                .WritePrefixedOptional(page.Filtered, (t, wr) => wr.WriteNbt(t)))
            .WriteBoolean(val.Resolved);
    }

    public override object ReadData(DataReader reader, MinecraftRegistry registry) {
        Title title = new(reader.ReadString(), reader.ReadPrefixedOptional(r => r.ReadString()));
        string author = reader.ReadString();
        int generation = reader.ReadVarInt();
        Page[] pages = reader.ReadPrefixedArray(r =>
            new Page(r.ReadText(), r.ReadPrefixedOptional(re => re.ReadText())));
        return new Data(title, author, generation, pages, reader.ReadBoolean());
    }

    public override bool ValuesEqual(Data val1, Data val2) {
        return val1.Equals(val2);
    }

    /// <param name="Generation">
    /// Zero for the original, rising with each copy. Three is a copy of a copy, which cannot be
    /// copied again.
    /// </param>
    /// <param name="Resolved">
    /// Whether the pages have had their selectors and scores worked out. An unresolved book gets one
    /// pass the first time it is opened.
    /// </param>
    public record Data(Title Title, string Author, int Generation, Page[] Pages, bool Resolved) {
        public virtual bool Equals(Data? other) {
            return other != null && Title == other.Title && Author == other.Author &&
                   Generation == other.Generation && Resolved == other.Resolved &&
                   Pages.SequenceEqual(other.Pages);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Title, Author, Generation, Resolved, Pages.Length);
        }
    }

    /// <param name="Filtered">What a client with chat filtering on is shown instead.</param>
    public record Title(string Raw, string? Filtered = null);

    /// <inheritdoc cref="Title"/>
    public record Page(TextComponent Raw, TextComponent? Filtered = null) {
        public virtual bool Equals(Page? other) {
            return other != null && Raw.ToJsonString() == other.Raw.ToJsonString() &&
                   Filtered?.ToJsonString() == other.Filtered?.ToJsonString();
        }

        public override int GetHashCode() {
            return HashCode.Combine(Raw.ToJsonString(), Filtered?.ToJsonString());
        }
    }
}
