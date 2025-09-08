using Minecraft.Schemas.Objectives;
using Minecraft.Text;

namespace ManagedServer.Scoreboards;

public record ScoreboardEntry(
    string Name, 
    int Value, 
    TextComponent? DisplayName = null, 
    INumberFormat? NumberFormat = null);
