using Minecraft.Data.RecipeBookCategories;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class RecipeBookCategoryRegistry : MappedRegistry<RecipeBookCategoryRegistry, IRecipeBookCategory> {
    public override Identifier RegistryId => "minecraft:recipe_book_category";
}
