using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class ConsumeEffectGen {
    
    public static string CreateConsumeEffects(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleAndComplexRegistryEntries(
            CodeGenUtils.BuildRegularRegistryEntries(registriesJson, "minecraft:consume_effect_type"),
            "SimpleConsumeEffect", 
            JObject.Parse(CodeGenUtils.ReadEmbeddedFile("complex_consume_effects.json")),
            "ConsumeEffect",
            "ConsumeEffects",
            "ConsumeEffects");
    }
}
