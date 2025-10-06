using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class EnchantmentCodeGen {
    
    public static string CreateEnchantmentEntries(JObject _) {
        JObject regJson = JObject.Parse(CodeGenUtils.ReadMinestomDataFile("enchantment.json"));
        
        List<string> fileEntries = [];
        List<string> regEntries = [];

        int cId = 0;
        foreach ((string key, JToken? value) in regJson) {
            //Identifier Identifier, int ProtocolId, TextComponent Description, int Weight, 
            // int MaxLevel, EnchantmentCost MinCost, EnchantmentCost MaxCost, int AnvilCost, EquipmentSlotGroup[] Slots

            if (value is not JObject obj) {
                Console.WriteLine("Warning: Invalid enchantment entry for key: " + key);
                continue;
            }
            
            // description is always a translatable component
            string descTransKey = obj["description"]!["translate"]!.Value<string>()!;
            int weight = obj["weight"]!.Value<int>();
            int maxLevel = obj["max_level"]!.Value<int>();

            string val = """ {asd = "h"} """;
            
            string objJsonStr = obj.ToString(Formatting.None);
            fileEntries.Add($"public static readonly IEnchantment {CodeGenUtils.NamespacedIdToPascalName(key)} = " +
                            $"IEnchantment.FromNbt(\"{key}\", {cId++}, (CompoundTag)INbtTag.FromJson(\"\"\" {objJsonStr} \"\"\"));");
            
            regEntries.Add($"{CodeGenUtils.GetIndentation(2)}Data.Enchantments.Add(Enchantment.{CodeGenUtils.NamespacedIdToPascalName(key)});");
        }
        
        CodeGenUtils.CreateVanillaEntriesFile(
            "Enchantment", 
            "Enchantments;\nusing NBT;\nusing NBT.Tags", 
            fileEntries.ToArray());
        return string.Join("\n", regEntries);
    }
}
