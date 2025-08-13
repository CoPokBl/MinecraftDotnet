using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class ArgumentTypeCodeGen {

    public static string CreateArgumentTypeEntries(JObject registriesJson) {
        return CodeGenUtils.CreateIdentifiedFilesRegistryEntries(
            CodeGenUtils.BuildRegularRegistryEntries(registriesJson, "minecraft:command_argument_type"),
            "CommandArgumentType",
            "CommandArgumentTypes",
            "ArgumentParsers.Types");
    }
}
