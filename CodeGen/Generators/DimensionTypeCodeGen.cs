using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class DimensionTypeCodeGen {

    public static string CreateDimensionTypeEntries(JObject _) {
        JObject regJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("dimension_type.json"));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, JToken? value) in regJson) {
            if (value is not JObject obj) {
                Console.WriteLine("Warning: Invalid dimension type entry for key: " + key);
                continue;
            }

            string objJsonStr = obj.ToString(Formatting.None);
            fileEntries.Add($"public static readonly IDimensionType {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"IDimensionType.FromNbt(\"{key}\", (CompoundTag)INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"), VanillaRegistry.Data);");

            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.DimensionTypes.Add(DimensionType.{CodeGenUtils.NamespacedIdToPascalName(key)});");
        }

        CodeGenUtils.CreateVanillaEntriesFile(
            "DimensionType",
            "DimensionType;\nusing NBT;\nusing NBT.Tags",
            fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }
}
