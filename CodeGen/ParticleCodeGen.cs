using System.Text;
using Newtonsoft.Json.Linq;

namespace CodeGen;

public static class ParticleCodeGen {
    private const string Header = 
"""
using Minecraft.Data.Particles;
using Minecraft.Data.Particles.Types;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: {date}
public static class Particle {

""";

    private const string Footer = "}\n";
    

    public static string CreateParticleEntries(JObject registriesJson) {
        JObject complexParticles = JObject.Parse(CodeGenUtils.ReadEmbeddedFile("complex_particles.json"));
        Dictionary<string, string> complexParticleTypes = complexParticles.ToObject<Dictionary<string, string>>()!;

        StringBuilder file = new(Header.Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd")));
        StringBuilder registryEntries = new();

        JObject entries = registriesJson["minecraft:particle_type"]!["entries"]!.ToObject<JObject>()!;

        foreach (KeyValuePair<string, JToken?> kvp in entries) {
            int protocolId = kvp.Value!["protocol_id"]!.Value<int>();
            string pascalName = CodeGenUtils.NamespacedIdToPascalName(kvp.Key);
            string key = kvp.Key;
            
            // Add to cs file
            if (!complexParticleTypes.TryGetValue(kvp.Key, out string? typeName)) {
                file.Append($"{CodeGenUtils.GetIndentation(1)}public static readonly SimpleParticle {pascalName} = new(\"{key}\", {protocolId});\n");
            }
            else {
                file.Append($"{CodeGenUtils.GetIndentation(1)}public static readonly {typeName} {pascalName} = new(\"{key}\", {protocolId});\n");
            }
            
            // Add to ParticleRegistry
            registryEntries.Append($"{CodeGenUtils.GetIndentation(2)}Data.Particles.Add(\"{key}\", {protocolId}, Particle.{pascalName});\n");
        }
        
        file.Append(Footer);
        File.WriteAllText("Particle.cs", file.ToString());

        return registryEntries.ToString();
    }
}
