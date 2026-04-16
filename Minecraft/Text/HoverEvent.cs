using NBT;
using NBT.Tags;

namespace Minecraft.Text;

public record HoverEvent(string Action, params (string Key, INbtTag Tag)[] Fields) {

    public static HoverEvent ShowText(TextComponent text) {
        return new HoverEvent("show_text", ("value", text.SerialiseToTag()));
    }

    public static HoverEvent ShowItem(string id, int count, CompoundTag? components = null) {
        List<(string, INbtTag)> fields = [
            ("id", new StringTag(id)),
            ("count", new IntegerTag(count))
        ];
        if (components != null) {
            fields.Add(("components", components));
        }
        return new HoverEvent("show_item", fields.ToArray());
    }

    public static HoverEvent ShowEntity(TextComponent name, string type, string uuid) {  // TODO: Untested
        return new HoverEvent("show_entity",
            ("name", name.SerialiseToTag()),
            ("id", new StringTag(type)),
            ("uuid", new StringTag(uuid)));
    }
}
