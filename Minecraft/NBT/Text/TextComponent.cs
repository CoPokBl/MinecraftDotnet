using Minecraft.NBT.Tags;

namespace Minecraft.NBT.Text;

// https://minecraft.wiki/w/Text_component_format
public class TextComponent : CompoundTagSerialisable {
    public readonly List<TextComponent> Children = [];
    public TextContent Content = TextContent.Text("");
    public TextColor? Color;
    public string? Insertion;
    public string? Font;
    public ClickEvent? ClickEvent;
    public HoverEvent? HoverEvent;
    public bool? Bold;
    public bool? Italic;
    public bool? Underlined;
    public bool? Strikethrough;
    public bool? Obfuscated;
    public TextColor? ShadowColor;
    
    private TextComponent() { }

    public static TextComponent Empty() {
        return new TextComponent();
    }

    public static TextComponent Text(string msg) {
        return new TextComponent {
            Content = TextContent.Text(msg)
        };
    }

    public static TextComponent Containing(TextContent content) {
        return new TextComponent {
            Content = content
        };
    }

    public static implicit operator TextComponent(string msg) => Text(msg);

    public TextComponent With(TextComponent other) {
        Children.Add(other);
        return this;
    }

    public TextComponent WithColor(TextColor color) {
        Color = color;
        return this;
    }

    public TextComponent WithContent(TextContent content) {
        Content = content;
        return this;
    }

    public TextComponent WithInsertion(string msg) {
        Insertion = msg;
        return this;
    }

    public TextComponent WithClickEvent(ClickEvent ce) {
        ClickEvent = ce;
        return this;
    }

    public TextComponent WithHoverEvent(HoverEvent he) {
        HoverEvent = he;
        return this;
    }

    public TextComponent WithFont(string fontPath) {
        Font = fontPath;
        return this;
    }
    
    public TextComponent WithBold(bool bold = true) {
        Bold = bold;
        return this;
    }
    
    public TextComponent WithItalic(bool italic = true) {
        this.Italic = italic;
        return this;
    }
    
    public TextComponent WithUnderlined(bool underlined = true) {
        Underlined = underlined;
        return this;
    }
    
    public TextComponent WithStrikethrough(bool strikethrough = true) {
        Strikethrough = strikethrough;
        return this;
    }
    
    public TextComponent WithObfuscated(bool obfuscated = true) {
        Obfuscated = obfuscated;
        return this;
    }
    
    public TextComponent WithShadowColor(TextColor? shadowColor) {
        ShadowColor = shadowColor;
        return this;
    }
    
    public TextComponent WithFontEffects(bool? bold = null, bool? underlined = null, bool? italic = null, bool? strikethrough = null, bool? obfuscated = null, TextColor? shadowColor = null) {
        if (bold.HasValue) Bold = bold;
        if (underlined.HasValue) Underlined = underlined;
        if (italic.HasValue) Italic = italic;
        if (strikethrough.HasValue) Strikethrough = strikethrough;
        if (obfuscated.HasValue) Obfuscated = obfuscated;
        if (shadowColor != null) ShadowColor = shadowColor;
        return this;
    }

    public override CompoundTag SerialiseToTag() {
        List<ITag?> tags = [
            new StringTag("type", Content.Type)
        ];
        tags.AddRange(Content.Fields);  // add all the content fields

        if (Color != null) {
            tags.Add(new StringTag("color", Color.ToHex()));
        }

        if (Bold.HasValue) {
            tags.Add(new BooleanTag("bold", Bold.Value));
        }

        if (Underlined.HasValue) {
            tags.Add(new BooleanTag("underlined", Underlined.Value));
        }

        if (Italic.HasValue) {
            tags.Add(new BooleanTag("italic", Italic.Value));
        }

        if (Strikethrough.HasValue) {
            tags.Add(new BooleanTag("strikethrough", Strikethrough.Value));
        }

        if (Obfuscated.HasValue) {
            tags.Add(new BooleanTag("obfuscated", Obfuscated.Value));
        }

        if (Insertion != null) {
            tags.Add(new StringTag("insertion", Insertion));
        }

        if (ShadowColor != null) {
            tags.Add(new IntegerTag("shadow_color", ShadowColor.ToDecimal()));
        }

        if (Font != null) {
            tags.Add(new StringTag("font", Font));
        }

        if (ClickEvent != null) {
            List<ITag?> fields = [
                new StringTag("action", ClickEvent.Action)
            ];
            fields.AddRange(ClickEvent.Fields);
            tags.Add(new CompoundTag("click_event", fields.ToArray()));
        }

        if (HoverEvent != null) {
            List<ITag?> fields = [
                new StringTag("action", HoverEvent.Action)
            ];
            fields.AddRange(HoverEvent.Fields);
            tags.Add(new CompoundTag("hover_event", fields.ToArray()));
        }
        
        // children
        if (Children.Count > 0) {
            ListTag<CompoundTag> extra = new("extra", Children.Select(t => t.SerialiseToTag()).ToArray());
            tags.Add(extra);
        }
        
        return new CompoundTag(ComponentName, tags.ToArray());
    }

    public static TextComponent FromTag(ITag tag) {
        if (tag is StringTag str) {  // direct string
            return Text(str.Value);
        }
        
        if (tag is not CompoundTag compound) {
            throw new ArgumentException("Tag is not compound", nameof(tag));
        }

        TextComponent textComponent = Empty();
        
        // alright, let's work out what content it has
        Dictionary<string, ITag> fields = compound.ChildrenMap;

        fields.TryGetValue("type", out ITag? contentTypeTag);
        string? contentType = ((StringTag?)contentTypeTag)?.Value;
        if (contentType == null) {
                 if (fields.ContainsKey("text")) contentType = "text";
            else if (fields.ContainsKey("translate")) contentType = "translatable";
            else if (fields.ContainsKey("score")) contentType = "score";
            else if (fields.ContainsKey("selector"))  contentType = "selector";
            else if (fields.ContainsKey("keybind"))  contentType = "keybind";
            else if (fields.ContainsKey("nbt")) throw new NotImplementedException("NBT content type not implemented");
            else throw new Exception("Unknown content type");
        }
        
        if (contentType == "text") {
            textComponent.Content = TextContent.Text(((StringTag)fields["text"]).Value);
        }
        else if (contentType == "translatable") {
            string key = ((StringTag)fields["translate"]).Value;
            string? fallback = null;
            TextComponent[]? with = null;
            if (fields.TryGetValue("fallback", out ITag? fallbackTag)) {
                fallback = ((StringTag)fallbackTag).Value;
            }
            if (fields.TryGetValue("with", out ITag? withTag)) {
                with = ((ListTag)withTag).Tags.Select(FromTag).ToArray();
            }
            textComponent.Content = TextContent.Translatable(key, fallback, with);
        }
        else if (contentType == "score") {
            Dictionary<string, ITag> scoreFields = ((CompoundTag)fields["score"]).ChildrenMap;
            textComponent.Content = TextContent.ScoreboardValue(
                ((StringTag)scoreFields["name"]).Value, 
                ((StringTag)scoreFields["objective"]).Value);
        }
        else if (contentType == "selector") {
            string selector = ((StringTag)fields["selector"]).Value;
            TextComponent? separator = null;
            if (fields.TryGetValue("separator", out ITag? separatorTag)) {
                separator = FromTag(separatorTag);
            }
            textComponent.Content = TextContent.EntityNames(selector, separator);
        }
        else if (contentType == "keybind") {
            textComponent.Content = TextContent.Text(((StringTag)fields["keybind"]).Value);
        }
        else if (contentType == "nbt") {
            throw new NotImplementedException("NBT content type not implemented");
        }
        else {
            throw new Exception("Unknown content type");
        }
        
        // okay, now we have done all the content we need to get all
        // optional fields.
        if (fields.TryGetValue("font", out ITag? fontTag)) {
            textComponent.WithFont(fontTag.GetString());
        }

        if (fields.TryGetValue("color", out ITag? colorTag)) {
            textComponent.WithColor(TextColor.Parse(colorTag.GetString()));
        }

        if (fields.TryGetValue("bold", out ITag? bold)) {
            textComponent.WithBold(bold.GetBoolean());
        }
        
        if (fields.TryGetValue("italic", out ITag? italic)) {
            textComponent.WithItalic(italic.GetBoolean());
        }
        
        if (fields.TryGetValue("underlined", out ITag? underlined)) {
            textComponent.WithUnderlined(underlined.GetBoolean());
        }
        
        if (fields.TryGetValue("strikethrough", out ITag? strikethrough)) {
            textComponent.WithStrikethrough(strikethrough.GetBoolean());
        }
        
        if (fields.TryGetValue("obfuscated", out ITag? obfuscated)) {
            textComponent.WithObfuscated(obfuscated.GetBoolean());
        }
        
        if (fields.TryGetValue("shadow_color", out ITag? shadowColorTag)) {
            // can be list or int
            if (shadowColorTag is IntegerTag intShadowTag) {
                textComponent.WithShadowColor(TextColor.FromDecimal(intShadowTag.Value));
            }
            else if (shadowColorTag is ListTag listShadowTag) {
                textComponent.WithShadowColor(TextColor.Rgb(
                    listShadowTag.Tags[0].GetFloat(), 
                    listShadowTag.Tags[1].GetFloat(), 
                    listShadowTag.Tags[2].GetFloat()));
            }
            else throw new Exception("Invalid field type for shadow color");
        }
        
        // now some interactivity things
        if (fields.TryGetValue("insertion", out ITag? insertionTag)) {
            textComponent.WithInsertion(insertionTag.GetString());
        }

        if (fields.TryGetValue("click_event", out ITag? clickEventTag)) {
            CompoundTag ct = (CompoundTag)clickEventTag;
            string action = ct["action"]!.GetString();

            switch (action) {
                case "open_url": 
                    textComponent.WithClickEvent(ClickEvent.OpenUrl(ct["url"]!.GetString()));
                    break;

                case "open_file": 
                    textComponent.WithClickEvent(ClickEvent.OpenFile(ct["path"]!.GetString()));
                    break;
                
                case "run_command": 
                    textComponent.WithClickEvent(ClickEvent.RunCommand(ct["command"]!.GetString()));
                    break;
                
                case "suggest_command": 
                    textComponent.WithClickEvent(ClickEvent.SuggestCommand(ct["command"]!.GetString()));
                    break;
                
                case "change_page": 
                    textComponent.WithClickEvent(ClickEvent.ChangePage(ct["page"]!.GetInteger()));
                    break;
                
                case "copy_to_clipboard": 
                    textComponent.WithClickEvent(ClickEvent.RunCommand(ct["value"]!.GetString()));
                    break;
                
                case "show_dialog":
                case "custom": 
                    throw new NotImplementedException();

                default: throw new Exception("Unknown click event type");
            }
        }
        
        if (fields.TryGetValue("hover_event", out ITag? hoverEventTag)) {
            CompoundTag ct = (CompoundTag)hoverEventTag;
            string action = ct["action"]!.GetString();

            switch (action) {
                case "show_text": 
                    textComponent.WithHoverEvent(HoverEvent.ShowText(FromTag(ct["value"]!)));
                    break;
                
                case "show_item":
                    int count = 1;
                    if (ct.ChildrenMap.TryGetValue("count", out ITag? countTag)) {
                        count = countTag.GetInteger();
                    }

                    ct.ChildrenMap.TryGetValue("components", out ITag? componentsTag);
                    textComponent.WithHoverEvent(HoverEvent.ShowItem(ct["id"]!.GetString(), count, (CompoundTag?)componentsTag));
                    break;
                
                case "show_entity":
                    throw new NotImplementedException();

                default: throw new Exception("Unknown click event type");
            }
        }
        
        // extras (aka children)
        if (fields.TryGetValue("extra", out ITag? extrasTag)) {
            ListTag extrasList = (ListTag)extrasTag;
            textComponent.Children.Clear();
            foreach (ITag extraTag in extrasList.Tags) {
                textComponent.Children.Add(FromTag(extraTag));
            }
        }
        
        // yay, finally we're done, return the fully constructed object.
        return textComponent;
    }
}