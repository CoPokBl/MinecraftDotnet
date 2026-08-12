using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when the player opens, closes or filters one of the recipe book's tabs.</summary>
public class ServerBoundChangeRecipeBookSettingsPacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:recipe_book_change_settings";

    public required RecipeBookType BookType { get; init; }
    public required bool Open { get; init; }
    public required bool Filtering { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt((int)BookType)
            .WriteBoolean(Open)
            .WriteBoolean(Filtering);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundChangeRecipeBookSettingsPacket {
        BookType = (RecipeBookType)r.ReadVarInt(),
        Open = r.ReadBoolean(),
        Filtering = r.ReadBoolean()
    };

    public enum RecipeBookType {
        Crafting = 0,
        Furnace = 1,
        BlastFurnace = 2,
        Smoker = 3
    }
}
