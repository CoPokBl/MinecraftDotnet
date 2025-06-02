using Minecraft.NBT.Tags;

namespace Minecraft.NBT.Text;

public record TextContent(string Type, params ITag?[] Fields) {

    public static TextContent Text(string msg) {
        return new TextContent("text", new StringTag("text", msg));
    }

    public static TextContent Keybind(string identifier) {
        return new TextContent("keybind", new StringTag("keybind", identifier));
    }
}