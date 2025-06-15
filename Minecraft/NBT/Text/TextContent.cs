using Minecraft.NBT.Tags;

namespace Minecraft.NBT.Text;

public record TextContent(string Type, params ITag?[] Fields) {

    public static TextContent Text(string msg) {
        return new TextContent("text", new StringTag("text", msg));
    }

    public static TextContent Keybind(string identifier) {
        return new TextContent("keybind", new StringTag("keybind", identifier));
    }

    public static TextContent Translatable(string key, string? fallback = null, TextComponent[]? with = null) {
        List<ITag> tags = [
            new StringTag("translate", key)
        ];
        if (fallback != null) {
            tags.Add(new StringTag("fallback", fallback));
        }
        if (with != null) {
            tags.Add(new ListTag<CompoundTag>(null, with.Select(t => t.SerialiseToTag()).ToArray()));
        }
        return new TextContent("translatable", tags.ToArray());
    }

    public static TextContent ScoreboardValue(string name, string objective) {
        return new TextContent("score", 
            new CompoundTag("score", 
                new StringTag("name", name), 
                new StringTag("objective", objective)));
    }

    public static TextContent EntityNames(string selector, TextComponent? separator = null) {
        List<ITag> tags = [
            new StringTag("selector", selector)
        ];
        if (separator != null) {
            tags.Add(separator.WithComponentName("separator"));
        }
        return new TextContent("selector", tags.ToArray());
    }

    public static TextContent NbtValues() {
        throw new NotImplementedException();
    }
}