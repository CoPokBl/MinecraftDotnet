using System.Diagnostics;
using CodeGen;
using Newtonsoft.Json.Linq;

Console.WriteLine("=================================================");
Console.WriteLine("Minecraft Dotnet Code Generator");
Console.WriteLine("=================================================");
Console.WriteLine();

const string registriesFileName = "registries.json";

const string vanillaRegistryFile = 
"""
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Schemas.BlockEnums;
using Minecraft.Data.Generated.BlockTypes;

namespace Minecraft.Data.Generated;

// Generated using the CodeGen project. Do not edit manually.
//
// Last updated: {date}
public static class VanillaRegistry {
    public static readonly MinecraftRegistry Data = new();

    static VanillaRegistry() {
{data}    }
}

""";

Console.WriteLine("Loading registries...");
JObject registriesJson = JObject.Parse(CodeGenUtils.ReadEmbeddedFile(registriesFileName));

string codeDir = Directory.GetCurrentDirectory();

// go up until we are in the CodeGen directory
while (!Directory.Exists(Path.Combine(codeDir, "CodeGen"))) {
    codeDir = Directory.GetParent(codeDir)?.FullName ?? throw new DirectoryNotFoundException("Could not find CodeGen directory.");
}
codeDir = Path.Combine(codeDir, "Minecraft", "Data", "Generated");
Directory.SetCurrentDirectory(codeDir);

string registryEntries = "";

void RunStep(string name, Func<JObject, string> func) {
    Console.WriteLine($"{name}...");
    Stopwatch sw = Stopwatch.StartNew();
    registryEntries += func(registriesJson) + "\n";
    Console.WriteLine($"{name} took {sw.Elapsed}");
}

RunStep("Particles", ParticleCodeGen.CreateParticleEntries);
RunStep("Blocks", BlockCodeGen.GenerateBlockCode);

Console.WriteLine("Generating VanillaRegistry.cs...");
string vanillaRegistryCode = vanillaRegistryFile.Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"))
    .Replace("{data}", registryEntries);

File.WriteAllText("VanillaRegistry.cs", vanillaRegistryCode);
Console.WriteLine("Done! Generated VanillaRegistry.cs in " + codeDir);
