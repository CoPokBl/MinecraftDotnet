using Minecraft.Schemas;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Removes recipes from the player's recipe book.</summary>
public class ClientBoundRecipeBookRemovePacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:recipe_book_remove";

    /// <summary>Ids the recipes were added with by <see cref="ClientBoundRecipeBookAddPacket"/>.</summary>
    public required int[] RecipeIds { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.WritePrefixedArray(RecipeIds, (id, writer) => writer.WriteVarInt(id));
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundRecipeBookRemovePacket {
        RecipeIds = r.ReadPrefixedArray(reader => reader.ReadVarInt())
    };
}
