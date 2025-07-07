using Minecraft.Text;

namespace Minecraft.Schemas;

public record TabListEntry(Guid Uuid, TextComponent Text, int Latency = 1, GameMode GameMode = 0);
