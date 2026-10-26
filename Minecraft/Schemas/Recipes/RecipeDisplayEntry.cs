using Minecraft.Data;
using Minecraft.Data.RecipeBookCategories;
using Minecraft.Registry;
using Minecraft.Schemas.Tags;

namespace Minecraft.Schemas.Recipes;

/// <summary>One recipe as it appears in the recipe book.</summary>
public class RecipeDisplayEntry : INetworkType<RecipeDisplayEntry> {
    /// <summary>
    /// Identifies the recipe for the rest of the session. Recipes are removed and placed by this
    /// id rather than by their datapack name.
    /// </summary>
    public required int Id { get; init; }

    public required RecipeDisplay Display { get; init; }

    /// <summary>
    /// Groups recipes that produce the same thing, such as the four plank recipes, so the book
    /// shows them as one cycling entry. Null when the recipe stands alone.
    /// </summary>
    public int? Group { get; init; }

    public required IRecipeBookCategory Category { get; init; }

    /// <summary>
    /// What the player needs in their inventory before the book will offer the recipe, or null
    /// when it can never be placed automatically.
    /// </summary>
    public IdSet[]? CraftingRequirements { get; init; }

    public DataWriter WriteData(DataWriter w, MinecraftRegistry reg) {
        return w
            .WriteVarInt(Id)
            .Write(Display, reg)
            // An absent group is a zero, so present ones are offset by one.
            .WriteVarInt((Group ?? -1) + 1)
            .WriteVarInt(reg.RecipeBookCategories.GetProtocolId(Category))
            .WritePrefixedOptional(CraftingRequirements,
                (requirements, writer) => writer.WritePrefixedArray(requirements, reg));
    }

    public static RecipeDisplayEntry ReadData(DataReader r, MinecraftRegistry reg) {
        int id = r.ReadVarInt();
        RecipeDisplay display = r.Read<RecipeDisplay>(reg);
        int group = r.ReadVarInt() - 1;
        return new RecipeDisplayEntry {
            Id = id,
            Display = display,
            Group = group == -1 ? null : group,
            Category = reg.RecipeBookCategories[r.ReadVarInt()],
            CraftingRequirements = r.ReadPrefixedOptional(reader => reader.ReadPrefixedArray<IdSet>(reg))
        };
    }
}
