using Minecraft.Registry;
using Minecraft.Schemas;
using Minecraft.Schemas.Recipes;

namespace Minecraft.Packets.Play.ClientBound;

/// <summary>Adds recipes to the player's recipe book.</summary>
public class ClientBoundRecipeBookAddPacket : ClientBoundPacket {
    public override Identifier Identifier => "minecraft:recipe_book_add";

    public required Entry[] Entries { get; init; }

    /// <summary>Whether these replace the book's contents rather than being added to them.</summary>
    public required bool Replace { get; init; }

    protected override DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WritePrefixedArray(Entries, (entry, writer) => writer
                .Write(entry.Contents, reg)
                .WriteUnsignedByte((byte)((entry.Notification ? 1 : 0) | (entry.Highlight ? 2 : 0))))
            .WriteBoolean(Replace);
    }

    public static readonly PacketDataDeserialiser Deserialiser = (r, reg) => new ClientBoundRecipeBookAddPacket {
        Entries = r.ReadPrefixedArray(reader => {
            RecipeDisplayEntry contents = r.Read<RecipeDisplayEntry>(reg);
            byte flags = (byte)reader.Read();
            return new Entry(contents, (flags & 1) != 0, (flags & 2) != 0);
        }),
        Replace = r.ReadBoolean()
    };

    /// <param name="Contents">The recipe itself.</param>
    /// <param name="Notification">Whether to show the "new recipes unlocked" toast.</param>
    /// <param name="Highlight">Whether to highlight the recipe in the book.</param>
    public record Entry(RecipeDisplayEntry Contents, bool Notification, bool Highlight);
}
