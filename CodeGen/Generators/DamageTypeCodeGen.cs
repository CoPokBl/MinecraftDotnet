using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class DamageTypeCodeGen {

    public static string CreateDamageTypeEntries(JObject _) {
        JObject regJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("damage_type.json"));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, JToken? value) in regJson) {
            if (value is not JObject obj) {
                Console.WriteLine("Warning: Invalid damage type entry for key: " + key);
                continue;
            }

            string objJsonStr = obj.ToString(Formatting.None);
            fileEntries.Add($"public static readonly IDamageType {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"IDamageType.FromNbt(\"{key}\", (CompoundTag)INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"), VanillaRegistry.Data);");

            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.DamageTypes.Add(DamageType.{CodeGenUtils.NamespacedIdToPascalName(key)});");
        }

        CodeGenUtils.CreateVanillaEntriesFile(
            "DamageType",
            "DamageType;\nusing NBT;\nusing NBT.Tags",
            fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }
}
