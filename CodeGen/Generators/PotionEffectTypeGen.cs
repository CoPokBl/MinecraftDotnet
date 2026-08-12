using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class PotionEffectTypeGen {
    
    public static string CreatePotionEffectTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:mob_effect",
            "SimplePotionEffectType", 
            "PotionEffectType",
            "PotionEffectTypes",
            "PotionEffectTypes");
    }
}
