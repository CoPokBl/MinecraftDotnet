using Minecraft.NBT.Tags;

namespace Minecraft.NBT.Text;

// https://minecraft.wiki/w/Text_component_format
public class TextComponent : ITag {
    private readonly List<TextComponent> _children = [];
    private string? _componentName;  // name for this NBT tag when it gets serialised (so it can be nested)
    private TextContent _content = TextContent.Text("");
    private TextColor? _color;
    private string? _insertion;
    private string? _font;  // TODO
    private ClickEvent? _clickEvent;
    private HoverEvent? _hoverEvent;
    private bool? _bold;  // TODO
    private bool? _italic;  // TODO
    private bool? _underlined;  // TODO
    private bool? _strikethrough;  // TODO
    private bool? _obfuscated;  // TODO
    private TextColor? _shadowColor;  // TODO
    
    private TextComponent() { }

    public static TextComponent Empty() {
        return new TextComponent();
    }

    public static TextComponent Text(string msg) {
        return new TextComponent {
            _content = TextContent.Text(msg)
        };
    }

    public static TextComponent Content(TextContent content) {
        return new TextComponent {
            _content = content
        };
    }
    
    public static TextComponent Color(TextColor colour) {
        return new TextComponent {
            _color = colour
        };
    }


    public TextComponent With(TextComponent other) {
        _children.Add(other);
        return this;
    }

    public TextComponent WithColor(TextColor color) {
        _color = color;
        return this;
    }

    public TextComponent WithContent(TextContent content) {
        _content = content;
        return this;
    }

    public TextComponent WithInsertion(string msg) {
        _insertion = msg;
        return this;
    }

    public TextComponent WithClickEvent(ClickEvent ce) {
        _clickEvent = ce;
        return this;
    }

    public TextComponent WithHoverEvent(HoverEvent he) {
        _hoverEvent = he;
        return this;
    }

    public TextComponent WithFont(string fontPath) {
        _font = fontPath;
        return this;
    }
    
    public TextComponent WithBold(bool bold) {
        _bold = bold;
        return this;
    }
    
    public TextComponent WithItalic(bool italic) {
        this._italic = italic;
        return this;
    }
    
    public TextComponent WithUnderlined(bool underlined) {
        _underlined = underlined;
        return this;
    }
    
    public TextComponent WithStrikethrough(bool strikethrough) {
        _strikethrough = strikethrough;
        return this;
    }
    
    public TextComponent WithObfuscated(bool obfuscated) {
        _obfuscated = obfuscated;
        return this;
    }
    
    public TextComponent WithShadowColor(TextColor? shadowColor) {
        _shadowColor = shadowColor;
        return this;
    }
    
    public TextComponent WithFontEffects(bool? bold = null, bool? underlined = null, bool? italic = null, bool? strikethrough = null, bool? obfuscated = null, TextColor? shadowColor = null) {
        if (bold.HasValue) _bold = bold;
        if (underlined.HasValue) _underlined = underlined;
        if (italic.HasValue) _italic = italic;
        if (strikethrough.HasValue) _strikethrough = strikethrough;
        if (obfuscated.HasValue) _obfuscated = obfuscated;
        if (shadowColor != null) _shadowColor = shadowColor;
        return this;
    }

    /// <summary>
    /// Internal method that is used to format the NBT to be used in packets.
    /// <p>
    /// It is not recommended to change this unless you know what you're doing.
    /// </summary>
    /// <param name="name">The name to give this tag.</param>
    /// <returns>This TextComponent with its name changed.</returns>
    public TextComponent WithComponentName(string? name) {
        _componentName = name;
        return this;
    }

    public CompoundTag SerialiseToTag() {
        List<ITag?> tags = [
            new StringTag("type", _content.Type)
        ];
        tags.AddRange(_content.Fields);  // add all the content fields

        if (_color != null) {
            tags.Add(new StringTag("color", _color.ToHex()));
        }

        if (_bold.HasValue) {
            tags.Add(new BooleanTag("bold", _bold.Value));
        }

        if (_underlined.HasValue) {
            tags.Add(new BooleanTag("underlined", _underlined.Value));
        }

        if (_italic.HasValue) {
            tags.Add(new BooleanTag("italic", _italic.Value));
        }

        if (_strikethrough.HasValue) {
            tags.Add(new BooleanTag("strikethrough", _strikethrough.Value));
        }

        if (_obfuscated.HasValue) {
            tags.Add(new BooleanTag("obfuscated", _obfuscated.Value));
        }

        if (_insertion != null) {
            tags.Add(new StringTag("insertion", _insertion));
        }

        if (_clickEvent != null) {
            List<ITag?> fields = [
                new StringTag("action", _clickEvent.Action)
            ];
            fields.AddRange(_clickEvent.Fields);
            tags.Add(new CompoundTag("click_event", fields.ToArray()));
        }

        if (_hoverEvent != null) {
            List<ITag?> fields = [
                new StringTag("action", _hoverEvent.Action)
            ];
            fields.AddRange(_hoverEvent.Fields);
            tags.Add(new CompoundTag("hover_event", fields.ToArray()));
        }
        
        // children
        if (_children.Count > 0) {
            ListTag<CompoundTag> extra = new("extra", _children.Select(t => t.SerialiseToTag()).ToArray());
            tags.Add(extra);
        }
        
        return new CompoundTag(_componentName, tags.ToArray());
    }

    public byte GetPrefix() {
        return NbtTagPrefix.Compound;
    }

    public byte[] Serialise(bool noType = false) {
        return SerialiseToTag().Serialise(noType);
    }
}