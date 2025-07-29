using System.Text;
using NBT;
using NBT.Tags;

namespace Minecraft.Text;

// https://minecraft.wiki/w/Text_component_format
public class TextComponent : CompoundTagSerialisable {
    public const char LegacyColorCodePrefix = '§';  // Prefix char to specify a colour in legacy text formats
    public const char LegacyColorCodeNotationPrefix = '&';  // Prefix char to specify a colour in legacy text formats (alternative notation)
    public const string ValidColorCodes = "0123456789abcdefklmnor";
    
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
    
    public static TextComponent Translatable(string key, string? fallback = null, TextComponent[]? with = null) {
        return new TextComponent {
            Content = TextContent.Translatable(key, fallback, with)
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
        Italic = italic;
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
    
    public TextComponent WithDecoration(TextDecoration decoration, bool enabled = true) {
        switch (decoration) {
            case TextDecoration.Bold: WithBold(enabled); break;
            case TextDecoration.Italic: WithItalic(enabled); break;
            case TextDecoration.Underlined: WithUnderlined(enabled); break;
            case TextDecoration.Strikethrough: WithStrikethrough(enabled); break;
            case TextDecoration.Obfuscated: WithObfuscated(enabled); break;
            default: throw new ArgumentOutOfRangeException(nameof(decoration), decoration, null);
        }
        return this;
    }

    public TextComponent WithDecorations(params TextDecoration[] decorations) {
        foreach (TextDecoration decoration in decorations) {
            WithDecoration(decoration);
        }
        return this;
    }
    
    public TextComponent ClearDecorations() {
        Bold = null;
        Italic = null;
        Underlined = null;
        Strikethrough = null;
        Obfuscated = null;
        return this;
    }
    
    public TextComponent SetAllDecorations(bool val) {
        Bold = val;
        Italic = val;
        Underlined = val;
        Strikethrough = val;
        Obfuscated = val;
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
        List<INbtTag?> tags = [
            new StringTag("type", Content.Type)
        ];
        tags.AddRange(Content.Fields);  // add all the content fields

        if (Color != null) {
            tags.Add(new StringTag("color", Color.Value.ToHex()));
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
            tags.Add(new IntegerTag("shadow_color", ShadowColor.Value.ToDecimal()));
        }

        if (Font != null) {
            tags.Add(new StringTag("font", Font));
        }

        if (ClickEvent != null) {
            List<INbtTag?> fields = [
                new StringTag("action", ClickEvent.Action)
            ];
            fields.AddRange(ClickEvent.Fields);
            tags.Add(new CompoundTag("click_event", fields.ToArray()));
        }

        if (HoverEvent != null) {
            List<INbtTag?> fields = [
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

    public static TextComponent FromTag(INbtTag tag) {
        if (tag is StringTag str) {  // direct string
            return Text(str.Value);
        }
        
        if (tag is not CompoundTag compound) {
            throw new ArgumentException($"Tag is not compound, it is {tag.GetType().Name}, {tag.ToJsonString()}", nameof(tag));
        }

        TextComponent textComponent = Empty();
        
        // alright, let's work out what content it has
        Dictionary<string, INbtTag> fields = compound.ChildrenMap;

        if (fields.Count == 1 && fields[""] is StringTag strTag) {
            // special case, if the tag has only one field with an empty name, it's a string
            // I couldn't find any documentation on this, but it seems to be used by EmortalMC at least.
            // so by extension, Minestom and Adventure, so we support it.
            return Text(strTag.Value);
        }

        fields.TryGetValue("type", out INbtTag? contentTypeTag);
        string? contentType = ((StringTag?)contentTypeTag)?.Value;
        if (contentType == null) {
                 if (fields.ContainsKey("text")) contentType = "text";
            else if (fields.ContainsKey("translate")) contentType = "translatable";
            else if (fields.ContainsKey("score")) contentType = "score";
            else if (fields.ContainsKey("selector"))  contentType = "selector";
            else if (fields.ContainsKey("keybind"))  contentType = "keybind";
            else if (fields.ContainsKey("nbt")) throw new NotImplementedException("NBT content type not implemented");
            else throw new Exception("Unknown content type, no type field found and no known content fields present");
        }
        
        if (contentType == "text") {
            textComponent.Content = TextContent.Text(((StringTag)fields["text"]).Value);
        }
        else if (contentType == "translatable") {
            string key = ((StringTag)fields["translate"]).Value;
            string? fallback = null;
            TextComponent[]? with = null;
            if (fields.TryGetValue("fallback", out INbtTag? fallbackTag)) {
                fallback = ((StringTag)fallbackTag).Value;
            }
            if (fields.TryGetValue("with", out INbtTag? withTag)) {
                with = ((ListTag)withTag).Tags.Select(FromTag).ToArray();
            }
            textComponent.Content = TextContent.Translatable(key, fallback, with);
        }
        else if (contentType == "score") {
            Dictionary<string, INbtTag> scoreFields = ((CompoundTag)fields["score"]).ChildrenMap;
            textComponent.Content = TextContent.ScoreboardValue(
                ((StringTag)scoreFields["name"]).Value, 
                ((StringTag)scoreFields["objective"]).Value);
        }
        else if (contentType == "selector") {
            string selector = ((StringTag)fields["selector"]).Value;
            TextComponent? separator = null;
            if (fields.TryGetValue("separator", out INbtTag? separatorTag)) {
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
        if (fields.TryGetValue("font", out INbtTag? fontTag)) {
            textComponent.WithFont(fontTag.GetString());
        }

        if (fields.TryGetValue("color", out INbtTag? colorTag)) {
            textComponent.WithColor(TextColor.Parse(colorTag.GetString()));
        }

        if (fields.TryGetValue("bold", out INbtTag? bold)) {
            textComponent.WithBold(bold.GetBoolean());
        }
        
        if (fields.TryGetValue("italic", out INbtTag? italic)) {
            textComponent.WithItalic(italic.GetBoolean());
        }
        
        if (fields.TryGetValue("underlined", out INbtTag? underlined)) {
            textComponent.WithUnderlined(underlined.GetBoolean());
        }
        
        if (fields.TryGetValue("strikethrough", out INbtTag? strikethrough)) {
            textComponent.WithStrikethrough(strikethrough.GetBoolean());
        }
        
        if (fields.TryGetValue("obfuscated", out INbtTag? obfuscated)) {
            textComponent.WithObfuscated(obfuscated.GetBoolean());
        }
        
        if (fields.TryGetValue("shadow_color", out INbtTag? shadowColorTag)) {
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
        if (fields.TryGetValue("insertion", out INbtTag? insertionTag)) {
            textComponent.WithInsertion(insertionTag.GetString());
        }

        if (fields.TryGetValue("click_event", out INbtTag? clickEventTag)) {
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
        
        if (fields.TryGetValue("hover_event", out INbtTag? hoverEventTag)) {
            CompoundTag ct = (CompoundTag)hoverEventTag;
            string action = ct["action"]!.GetString();

            switch (action) {
                case "show_text": 
                    textComponent.WithHoverEvent(HoverEvent.ShowText(FromTag(ct["value"]!)));
                    break;
                
                case "show_item":
                    int count = 1;
                    if (ct.ChildrenMap.TryGetValue("count", out INbtTag? countTag)) {
                        count = countTag.GetInteger();
                    }

                    ct.ChildrenMap.TryGetValue("components", out INbtTag? componentsTag);
                    textComponent.WithHoverEvent(HoverEvent.ShowItem(ct["id"]!.GetString(), count, (CompoundTag?)componentsTag));
                    break;
                
                case "show_entity":
                    throw new NotImplementedException();

                default: throw new Exception("Unknown click event type");
            }
        }
        
        // extras (aka children)
        if (fields.TryGetValue("extra", out INbtTag? extrasTag)) {
            ListTag extrasList = (ListTag)extrasTag;
            textComponent.Children.Clear();
            foreach (INbtTag extraTag in extrasList.Tags) {
                textComponent.Children.Add(FromTag(extraTag));
            }
        }
        
        // yay, finally we're done, return the fully constructed object.
        return textComponent;
    }

    public static TextComponent FromLegacyString(string message) {
        TextComponent component = Empty();
        StringBuilder currentSection = new();
        
        TextColor colour = TextColor.White;
        TextDecoration? decoration = null;

        for (int i = 0; i < message.Length; i++) {
            if (message[i] != LegacyColorCodeNotationPrefix || i == message.Length-1 || !ValidColorCodes.Contains(message[i + 1])) {
                currentSection.Append(message[i]);
                continue;
            }
            
            // Apply previous section
            if (currentSection.Length != 0) {
                ApplyCurrentSection();
                currentSection.Clear();
            }

            i++;  // skip the color code character
            
            char modifier = message[i];
            decoration = null;
            switch (modifier) {
                case '0':
                    colour = TextColor.Black;
                    break;
                case '1':
                    colour = TextColor.DarkBlue;
                    break;
                case '2':
                    colour = TextColor.DarkGreen;
                    break;
                case '3':
                    colour = TextColor.DarkAqua;
                    break;
                case '4':
                    colour = TextColor.DarkRed;
                    break;
                case '5':
                    colour = TextColor.DarkPurple;
                    break;
                case '6':
                    colour = TextColor.Gold;
                    break;
                case '7':
                    colour = TextColor.Gray;
                    break;
                case '8':
                    colour = TextColor.DarkGray;
                    break;
                case '9':
                    colour = TextColor.Blue;
                    break;
                case 'a':
                    colour = TextColor.Green;
                    break;
                case 'b':
                    colour = TextColor.Aqua;
                    break;
                case 'c':
                    colour = TextColor.Red;
                    break;
                case 'd':
                    colour = TextColor.LightPurple;
                    break;
                case 'e':
                    colour = TextColor.Yellow;
                    break;
                case 'f':
                    colour = TextColor.White;
                    break;
                case 'k':
                    decoration = TextDecoration.Obfuscated;
                    break;
                case 'l':
                    decoration = TextDecoration.Bold;
                    break;
                case 'm':
                    decoration = TextDecoration.Strikethrough;
                    break;
                case 'n':
                    decoration = TextDecoration.Underlined;
                    break;
                case 'o':
                    decoration = TextDecoration.Italic;
                    break;
                case 'r':
                    decoration = null;
                    colour = TextColor.White;
                    break;
            }
        }

        if (currentSection.Length != 0) {
            ApplyCurrentSection();
        }
        
        return component;

        // Helper method to apply the current section to the component
        void ApplyCurrentSection() {
            TextComponent newSec = Text(currentSection.ToString()).WithColor(colour);
            if (decoration != null) {
                newSec.WithDecoration(decoration.Value);
            }
            else {
                newSec.SetAllDecorations(false);
            }
            component.With(newSec);
        }
    }
}
