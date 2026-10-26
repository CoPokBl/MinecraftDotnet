using Minecraft.Data.RecipeDisplayTypes;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;

namespace Minecraft.Registry.SubRegistries;

public class RecipeDisplayTypeRegistry : MappedRegistry<RecipeDisplayTypeRegistry, IRecipeDisplayType> {
    public override Identifier RegistryId => "minecraft:recipe_display";
}
