using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class RecipeDisplayTypeCodeGen {
    public static string CreateRecipeDisplayTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:recipe_display",
            "SimpleRecipeDisplayType",
            "RecipeDisplayType",
            "RecipeDisplayTypes",
            "RecipeDisplayTypes");
    }
}
