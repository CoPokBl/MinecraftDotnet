using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Recipes;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>
/// Shows a recipe's ingredients greyed out in an open crafting grid, after the player clicks it
/// in the recipe book.
/// </summary>
public class ClientBoundPlaceGhostRecipePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:place_ghost_recipe";

    public required int WindowId { get; init; }
    public required RecipeDisplay Recipe { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(WindowId)
            .Write(Recipe, reg);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundPlaceGhostRecipePacket {
        WindowId = r.ReadVarInt(),
        Recipe = r.Read<RecipeDisplay>(reg)
    };
}
