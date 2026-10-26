using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class SlotDisplayTypeCodeGen {
    public static string CreateSlotDisplayTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson,
            "minecraft:slot_display",
            "SimpleSlotDisplayType",
            "SlotDisplayType",
            "SlotDisplayTypes",
            "SlotDisplayTypes");
    }
}
