using Minecraft.Schemas;

namespace Minecraft.Data.ArgumentParsers.Types;

public record ScoreboardSlotArgumentType() : TokenArgumentType {
    public override Identifier Identifier => "minecraft:scoreboard_slot";
}
