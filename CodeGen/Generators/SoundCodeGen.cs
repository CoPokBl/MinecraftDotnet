using Newtonsoft.Json.Linq;

namespace CodeGen.Generators;

public static class SoundCodeGen {
    
    public static string CreateSoundEntries(JObject registriesJson) {
        return CodeGenUtils.CreateSimpleRegistryEntries(
            registriesJson, 
            "minecraft:sound_event", 
            "SimpleSoundType", 
            "SoundType",
            "SoundTypes",
            "Sounds",
            GetVariableName);
    }
    
    // they look like this: minecraft:ambient.basalt_deltas.additions
    internal static string GetVariableName(string key) {
        // first get rid of the namespace
        string name = key.Split(':')[1];
        // then get rid of category
        string[] catAndName = name.Split('.', 2);
        string prefix = catAndName[0] switch {
            "music_disc" => "Disc",
            _ => ""
        };
        name = prefix + CodeGenUtils.CapitaliseFirstLetter(catAndName[1]);
        // then replace dots with underscores
        name = name.Replace('.', '_');
        // finally, pascal case it
        return CodeGenUtils.NamespacedIdToPascalName(name);
    }
}
