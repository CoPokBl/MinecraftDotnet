using Minecraft.NBT.Tags;

namespace Minecraft.NBT.Text;

public record HoverEvent(string Action, params INbtTag?[] Fields) {

    public static HoverEvent ShowText(TextComponent text) {
        return new HoverEvent("show_text", text.WithComponentName("value"));
    }

    public static HoverEvent ShowItem(string id, int count, CompoundTag? components = null) {
        return new HoverEvent("show_item", 
            new StringTag("id", id), 
            new IntegerTag("count", count),
            components?.WithName("components"));
    }

    public static HoverEvent ShowEntity(TextComponent name, string type, string uuid) {  // TODO: Untested (does the entity need to exist on client)
        return new HoverEvent("show_entity", 
            name.WithComponentName("name"),
            new StringTag("id", type),
            new StringTag("uuid", uuid));
    }
}