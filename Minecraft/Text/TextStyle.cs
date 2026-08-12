using NBT;
using NBT.Tags;

namespace Minecraft.Text;

/// <summary>
/// The formatting half of a text component on its own, with no content attached. Registry data
/// that decorates text it doesn't own carries one of these, chat types style the message the
/// client builds rather than shipping a finished component.
/// </summary>
/// <remarks>
/// Click and hover events are part of vanilla's <c>Style</c> too, but they only mean anything on
/// a component that is actually rendered, so they live on <see cref="TextComponent"/> and not
/// here.
/// </remarks>
public record TextStyle {
    public TextColor? Color { get; init; }
    public TextColor? ShadowColor { get; init; }
    public bool? Bold { get; init; }
    public bool? Italic { get; init; }
    public bool? Underlined { get; init; }
    public bool? Strikethrough { get; init; }
    public bool? Obfuscated { get; init; }
    public string? Font { get; init; }
    public string? Insertion { get; init; }

    /// <summary>A style that changes nothing, which is what an absent style field means.</summary>
    public static readonly TextStyle Empty = new();

    public bool IsEmpty => Color == null && ShadowColor == null && Bold == null && Italic == null
                           && Underlined == null && Strikethrough == null && Obfuscated == null
                           && Font == null && Insertion == null;

    public CompoundTag ToNbt() {
        List<(string, INbtTag)> children = [];

        if (Color != null) {
            children.Add(("color", new StringTag(Color.Value.ToHex())));
        }

        if (Bold.HasValue) {
            children.Add(("bold", new BooleanTag(Bold.Value)));
        }

        if (Italic.HasValue) {
            children.Add(("italic", new BooleanTag(Italic.Value)));
        }

        if (Underlined.HasValue) {
            children.Add(("underlined", new BooleanTag(Underlined.Value)));
        }

        if (Strikethrough.HasValue) {
            children.Add(("strikethrough", new BooleanTag(Strikethrough.Value)));
        }

        if (Obfuscated.HasValue) {
            children.Add(("obfuscated", new BooleanTag(Obfuscated.Value)));
        }

        if (ShadowColor != null) {
            children.Add(("shadow_color", new IntegerTag(ShadowColor.Value.ToDecimal())));
        }

        if (Font != null) {
            children.Add(("font", new StringTag(Font)));
        }

        if (Insertion != null) {
            children.Add(("insertion", new StringTag(Insertion)));
        }

        return new CompoundTag(children.ToArray());
    }

    public static TextStyle FromNbt(INbtTag tag) {
        if (tag is not CompoundTag compound) {
            throw new ArgumentException($"Style must be a compound, got {tag.GetType().Name}", nameof(tag));
        }

        return new TextStyle {
            Color = compound.Contains("color") ? TextColor.Parse(compound["color"]!.GetString()) : null,
            Bold = compound.Contains("bold") ? compound["bold"]!.GetBoolean() : null,
            Italic = compound.Contains("italic") ? compound["italic"]!.GetBoolean() : null,
            Underlined = compound.Contains("underlined") ? compound["underlined"]!.GetBoolean() : null,
            Strikethrough = compound.Contains("strikethrough") ? compound["strikethrough"]!.GetBoolean() : null,
            Obfuscated = compound.Contains("obfuscated") ? compound["obfuscated"]!.GetBoolean() : null,
            ShadowColor = compound.Contains("shadow_color")
                ? TextColor.FromDecimal(compound["shadow_color"]!.GetInteger())
                : null,
            Font = compound.Contains("font") ? compound["font"]!.GetString() : null,
            Insertion = compound.Contains("insertion") ? compound["insertion"]!.GetString() : null
        };
    }
}
