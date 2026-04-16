using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class TimelineCodeGen {

    public static string CreateTimelineEntries(JObject _) {
        JObject regJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("timeline.json"));

        List<string> fileEntries = [];
        List<string> regEntries = [];

        foreach ((string key, JToken? value) in regJson) {
            if (value is not JObject obj) {
                Console.WriteLine("Warning: Invalid timeline entry for key: " + key);
                continue;
            }

            string objJsonStr = obj.ToString(Formatting.None);
            fileEntries.Add($"public static readonly ITimeline {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"ITimeline.FromNbt(\"{key}\", (CompoundTag)INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"), VanillaRegistry.Data);");

            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.Timelines.Add(Timeline.{CodeGenUtils.NamespacedIdToPascalName(key)});");
        }

        CodeGenUtils.CreateVanillaEntriesFile(
            "Timeline",
            "Timelines;\nusing NBT;\nusing NBT.Tags",
            fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }
}
