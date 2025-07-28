using Minecraft.Schemas;
using Minecraft.Text;

namespace ClientLib;

public record PlayerInfoEntry(
    Guid Uuid, 
    string Name, 
    Dictionary<string, (string Value, string? Signature)> Properties,
    GameMode GameMode = GameMode.Survival,
    bool Listed = true,
    int Latency = 0,
    TextComponent? DisplayName = null,
    int ListPriority = 0,
    bool HatVisible = true);
