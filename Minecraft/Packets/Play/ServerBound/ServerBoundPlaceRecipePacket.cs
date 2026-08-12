using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Sent when the player clicks a recipe in the recipe book to fill the crafting grid.</summary>
public class ServerBoundPlaceRecipePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:place_recipe";

    public required int WindowId { get; init; }

    /// <summary>The id the recipe was added with by <c>ClientBoundRecipeBookAddPacket</c>.</summary>
    public required int RecipeId { get; init; }

    /// <summary>Whether to craft as many as the inventory allows, rather than one.</summary>
    public required bool UseMaxItems { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w
            .WriteVarInt(WindowId)
            .WriteVarInt(RecipeId)
            .WriteBoolean(UseMaxItems);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundPlaceRecipePacket {
        WindowId = r.ReadVarInt(),
        RecipeId = r.ReadVarInt(),
        UseMaxItems = r.ReadBoolean()
    };
}
