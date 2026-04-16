using NBT;
using NBT.Tags;

namespace Minecraft.Text;

public record TextContent(string Type, params (string Key, INbtTag Tag)[] Fields) {

    public static TextContent Text(string msg) {
        return new TextContent("text", ("text", new StringTag(msg)));
    }

    public static TextContent Keybind(string identifier) {
        return new TextContent("keybind", ("keybind", new StringTag(identifier)));
    }

    public static TextContent Translatable(string key, string? fallback = null, TextComponent[]? with = null) {
        List<(string, INbtTag)> tags = [
            ("translate", new StringTag(key))
        ];
        if (fallback != null) {
            tags.Add(("fallback", new StringTag(fallback)));
        }
        if (with != null) {
            tags.Add(("with", new ListTag<CompoundTag>(with.Select(t => t.SerialiseToTag()).ToArray())));
        }
        return new TextContent("translatable", tags.ToArray());
    }

    public static TextContent ScoreboardValue(string name, string objective) {
        return new TextContent("score",
            ("score", new CompoundTag(
                ("name", new StringTag(name)),
                ("objective", new StringTag(objective)))));
    }

    public static TextContent EntityNames(string selector, TextComponent? separator = null) {
        List<(string, INbtTag)> tags = [
            ("selector", new StringTag(selector))
        ];
        if (separator != null) {
            tags.Add(("separator", separator.SerialiseToTag()));
        }
        return new TextContent("selector", tags.ToArray());
    }

    public static TextContent NbtValues() {
        throw new NotImplementedException();
    }
}
