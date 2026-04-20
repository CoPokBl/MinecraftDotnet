using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class PaintingVariantCodeGen {

    public static string CreatePaintingVariantEntries(JObject _) {
        JObject regJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("painting_variant.json"));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, JToken? value) in regJson) {
            if (value is not JObject obj) {
                Console.WriteLine("Warning: Invalid painting variant entry for key: " + key);
                continue;
            }

            string objJsonStr = obj.ToString(Formatting.None);
            fileEntries.Add($"public static readonly IPaintingVariant {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"IPaintingVariant.FromNbt(\"{key}\", (CompoundTag)INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"), VanillaRegistry.Data);");

            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.PaintingVariants.Add(PaintingVariant.{CodeGenUtils.NamespacedIdToPascalName(key)});");
        }

        CodeGenUtils.CreateVanillaEntriesFile(
            "PaintingVariant",
            "PaintingVariant;\nusing NBT;\nusing NBT.Tags",
            fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }
}
