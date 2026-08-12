using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class RecipeBookCategoryCodeGen {
    public static string CreateRecipeBookCategories(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:recipe_book_category",
            "SimpleRecipeBookCategory",
            "RecipeBookCategory",
            "RecipeBookCategories",
            "RecipeBookCategories");
    }
}
