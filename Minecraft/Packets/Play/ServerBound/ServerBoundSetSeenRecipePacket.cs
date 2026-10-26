using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ServerBound;

/// <summary>Clears the "new" highlight on a recipe once the player has looked at it.</summary>
public class ServerBoundSetSeenRecipePacket : ServerBoundPacket {
    public override Identifier Identifier => "minecraft:recipe_book_seen_recipe";

    /// <summary>The id the recipe was added with by <c>ClientBoundRecipeBookAddPacket</c>.</summary>
    public required int RecipeId { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WriteVarInt(RecipeId);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ServerBoundSetSeenRecipePacket {
        RecipeId = r.ReadVarInt()
    };
}
