using Minecraft.Schemas;
using Minecraft.Schemas.Recipes;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Restores which recipe book tabs the player had open.</summary>
public class ClientBoundRecipeBookSettingsPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:recipe_book_settings";

    public required RecipeBookSettings Settings { get; init; }

    protected override DataWriter WriteData(DataWriter w) {
        return w.Write(Settings);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, _) => new ClientBoundRecipeBookSettingsPacket {
        Settings = RecipeBookSettings.Read(r)
    };
}
