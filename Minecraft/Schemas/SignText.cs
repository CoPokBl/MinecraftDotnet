using Minecraft.Data.Components.Codecs;
using Minecraft.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Schemas;

/// <summary><c>SignText</c>: four lines, their filtered copies, the dye and whether a glow ink sac has been used.</summary>
public sealed record SignText(TextComponent[] Messages, TextComponent[] FilteredMessages, DyeColor Color, bool HasGlowingText) {
    public static readonly SignText Empty = new(EmptyLines(), EmptyLines(), DyeColor.Black, false);

    private static readonly NbtCodec<TextComponent> Line = NbtCodecs.Text();

    private static TextComponent[] EmptyLines() => [TextComponent.Empty(), TextComponent.Empty(), TextComponent.Empty(), TextComponent.Empty()];

    public TextComponent[] GetMessages(bool shouldFilter) => shouldFilter ? FilteredMessages : Messages;

    public TextComponent GetMessage(int line, bool shouldFilter) => GetMessages(shouldFilter)[line];

    /// <summary><c>setMessage(int, Component)</c>: one line, filtered and not, in a new text.</summary>
    public SignText SetMessage(int line, TextComponent message) {
        TextComponent[] messages = (TextComponent[])Messages.Clone(), filtered = (TextComponent[])FilteredMessages.Clone();
        messages[line] = message;
        filtered[line] = message;
        return this with { Messages = messages, FilteredMessages = filtered };
    }

    /// <summary>
    /// <c>CODEC</c>. The filtered lines are left off when they are the lines, and the colour and glow
    /// are always written, <c>optionalAlwaysPresentFieldOf</c>.
    /// </summary>
    public CompoundTag ToNbt() {
        return new CompoundBuilder()
            .Tag("messages", Lines(Messages))
            .TagWhen("filtered_messages", Lines(FilteredMessages), !SameLines(Messages, FilteredMessages))
            .Enum("color", Color)
            .Bool("has_glowing_text", HasGlowingText)
            .Build();
    }

    /// <summary><c>DIRECT_CODEC</c>; the empty text when the tag is not one, as <c>orElseGet(SignText::new)</c>.</summary>
    public static SignText Read(INbtTag? tag) {
        if (tag is not CompoundTag compound || Lines(compound["messages"]) is not { } messages) {
            return Empty;
        }
        TextComponent[] filtered = Lines(compound["filtered_messages"]) ?? messages;
        DyeColor color = compound["color"] is StringTag name && NbtNode.NamesOf<DyeColor>().TryGetValue(name.Value, out DyeColor parsed) ? parsed : DyeColor.Black;
        bool glowing = compound["has_glowing_text"] is { } glow && glow.GetBoolean();
        return new SignText(messages, filtered, color, glowing);
    }

    /// <summary><c>STREAM_CODEC</c>: the lines, the filtered lines only where they differ, the dye by id, the glow.</summary>
    public DataWriter WriteData(DataWriter writer) {
        foreach (TextComponent message in Messages) {
            writer.WriteNbt(message);
        }

        writer.WriteBoolean(!SameLines(Messages, FilteredMessages));
        if (!SameLines(Messages, FilteredMessages)) {
            foreach (TextComponent message in FilteredMessages) {
                writer.WriteNbt(message);
            }
        }

        return writer.WriteVarInt((int)Color).WriteBoolean(HasGlowingText);
    }

    public static SignText ReadData(DataReader reader) {
        TextComponent[] messages = [reader.ReadText(), reader.ReadText(), reader.ReadText(), reader.ReadText()];
        TextComponent[] filtered = reader.ReadBoolean() ? [reader.ReadText(), reader.ReadText(), reader.ReadText(), reader.ReadText()] : messages;
        return new SignText(messages, filtered, (DyeColor)reader.ReadVarInt(), reader.ReadBoolean());
    }

    public bool Equals(SignText? other) {
        return other is not null && Color == other.Color && HasGlowingText == other.HasGlowingText
            && SameLines(Messages, other.Messages) && SameLines(FilteredMessages, other.FilteredMessages);
    }

    public override int GetHashCode() {
        return HashCode.Combine(Color, HasGlowingText, Messages.Length);
    }

    private static bool SameLines(TextComponent[] a, TextComponent[] b) {
        return ReferenceEquals(a, b) || a.Length == b.Length && a.Zip(b).All(pair => pair.First.ToJsonString() == pair.Second.ToJsonString());
    }

    private static ListTag Lines(TextComponent[] lines) {
        return new ListTag(lines.Select(line => Line.ToNbt(line, null!)).ToArray());
    }

    /// <summary><c>LINES_CODEC</c>: exactly four components.</summary>
    private static TextComponent[]? Lines(INbtTag? tag) {
        if (tag is not ListTag list || list.Tags.Length != 4) {
            return null;
        }
        try {
            return list.Tags.ToArray().Select(TextComponent.FromTag).ToArray();
        }
        catch (Exception e) when (e is not OutOfMemoryException) {
            // FromTag throws a bare Exception for content it does not know; the codec would fail the same way.
            return null;
        }
    }
}
