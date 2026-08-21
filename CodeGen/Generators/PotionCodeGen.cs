using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class PotionCodeGen {

    public static string CreatePotions(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:potion",
            "SimplePotion",
            "Potion",
            "Potions",
            "Potions");
    }
}
