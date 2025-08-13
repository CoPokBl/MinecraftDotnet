using Minecraft.Registry;
using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record GameModeArgumentType(int ProtocolId) : ArgumentParser<GameMode>(ProtocolId) {
    public override Identifier Identifier => "minecraft:gamemode";
    
    public override GameMode Parse(ref string str, MinecraftRegistry _) {
        string[] parts = str.Split(' ', 2);
        if (parts.Length < 1) throw new ArgumentException("Invalid game mode format");

        string modeStr = parts[0].Trim();
        str = parts.Length > 1 ? parts[1].Trim() : string.Empty;

        return modeStr switch {
            "survival" => GameMode.Survival,
            "creative" => GameMode.Creative,
            "adventure" => GameMode.Adventure,
            "spectator" => GameMode.Spectator,
            _ => throw new ArgumentException($"Unknown game mode: {modeStr}")
        };
    }

    public override string Format(GameMode value) => value switch {
        GameMode.Survival => "survival",
        GameMode.Creative => "creative",
        GameMode.Adventure => "adventure",
        GameMode.Spectator => "spectator",
        _ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
    };
}
