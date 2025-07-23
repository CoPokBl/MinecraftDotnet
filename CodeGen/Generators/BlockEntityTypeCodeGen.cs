using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public class BlockEntityTypeCodeGen {

    public static string CreateBlockEntityTypes(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:block_entity_type", 
            "SimpleBlockEntityType", 
            "BlockEntityType",
            "BlockEntityTypes",
            "BlockEntityTypes");
    }
}
