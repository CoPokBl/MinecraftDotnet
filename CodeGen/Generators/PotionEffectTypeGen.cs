using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class PotionEffectTypeGen {
    
    public static string CreatePotionEffectTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            CodeGenUtils.GetFileRegEntries("potion_effect.json"),
            "SimplePotionEffectType", 
            "PotionEffectType",
            "PotionEffectTypes",
            "PotionEffectTypes");
    }
}
