using Minecraft.Schemas;
using Minecraft.Text;

namespace ManagedServer.TabList;

public record TabListEntry(Guid Uuid, TextComponent Text, int Latency, GameMode GameMode, string Username, PlayerSkin? Skin) {
    
    public static TabListEntry FromText(TextComponent text) {
        return new TabListEntry(Guid.NewGuid(), text, 0, GameMode.Survival, "asd", null);
    }
}
