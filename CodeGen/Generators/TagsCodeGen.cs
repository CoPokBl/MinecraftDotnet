using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class TagsCodeGen {
    private static readonly Dictionary<string, string> RegistryTypeMap = new() {
        { "block", "IBlock" },
        { "item", "IItem" },
        { "entity_type", "IEntityType" },
        { "enchantment", "IEnchantment" },
        { "timeline", "ITimeline" },
        { "damage_type", "IDamageType" },
        { "painting_variant", "IPaintingVariant" },
        { "banner_pattern", "IBannerPattern" },
        { "instrument", "IInstrument" },
        { "dialog", "IDialog" },
        { "worldgen/biome", "IBiome" },
    };

    /// <summary>
    /// Registries whose tag folder is nested a level down. The folder layout mirrors the registry
    /// id, so these are the ones whose id has a slash in it.
    /// </summary>
    private static readonly string[] NestedTagFolders = ["worldgen"];

    public static string CreateTagEntries(JObject registriesJson) {
        string tagsFolder = Path.Combine(CodeGenUtils.VanillaDataDir, "data", "minecraft", "tags");

        StringBuilder tagEntries = new("\n");

        void SearchDirectory(string regName, string rootDir, string dir) {
            if (!RegistryTypeMap.ContainsKey(regName)) {
                Console.WriteLine("Tags cannot be saved for registry: " + regName);
                return;  // Not a registry we have set up
            }

            foreach (string subDir in Directory.EnumerateDirectories(dir)) {
                SearchDirectory(regName, rootDir, subDir);
            }

            string regId = $"minecraft:{regName}";
            foreach (string file in Directory.EnumerateFiles(dir)) {
                // The tag id is the path below the registry's own folder, so
                // .../tags/block/mineable/axe.json becomes minecraft:mineable/axe
                string tagId = Path.GetRelativePath(rootDir, file).Replace(Path.DirectorySeparatorChar, '/');
                tagId = tagId[..^".json".Length];

                JObject tagData = JObject.Parse(File.ReadAllText(file));
                JArray values = tagData["values"]?.ToObject<JArray>() ?? [];

                string[] valueEntries = values
                    .Select(v => v.ToObject<string>()![0] == '#'
                        ? $"RegistryTagValue.Tag(\"{v.ToObject<string>()![1..]}\")"
                        : $"RegistryTagValue.Direct(\"{v}\")")
                    .ToArray();
                string valuesString = $"[{string.Join(", ", valueEntries)}]";

                string entry = $"{CodeGenUtils.GetIndentation(2)}Data[\"{regId}\"].Tags.Add(" +
                        $"new RegistryTag<{RegistryTypeMap[regName]}>(\"{regId}\", \"{tagId}\", {valuesString}));";
                tagEntries.AppendLine(entry);
            }
        }

        // each of these is a directory containing tag files for
        // the registry that the subfolder is called
        foreach (string regDir in Directory.EnumerateDirectories(tagsFolder)) {
            string name = regDir.Split(Path.DirectorySeparatorChar)[^1];

            if (NestedTagFolders.Contains(name)) {
                foreach (string nestedDir in Directory.EnumerateDirectories(regDir)) {
                    string nestedName = nestedDir.Split(Path.DirectorySeparatorChar)[^1];
                    SearchDirectory($"{name}/{nestedName}", nestedDir, nestedDir);
                }
                continue;
            }

            SearchDirectory(name, regDir, regDir);
        }

        return tagEntries.ToString();
    }
}
