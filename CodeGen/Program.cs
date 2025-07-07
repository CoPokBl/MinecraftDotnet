using System.Diagnostics;
using System.Text;
using CodeGen;
using Newtonsoft.Json.Linq;

Console.WriteLine("=================================================");
Console.WriteLine("Minecraft Dotnet Code Generator");
Console.WriteLine("=================================================");
Console.WriteLine();

const string registriesFileName = "registries.json";

const string vanillaRegistryFile = 
"""
using Minecraft.Schemas;
using Minecraft.Data.Blocks;
using Minecraft.Registry;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Generated.BlockTypes;

using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Packets.Handshake;

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

StringBuilder registryEntries = new();

RunStep("Particles", ParticleCodeGen.CreateParticleEntries);
RunStep("Blocks", BlockCodeGen.GenerateBlockCode);
RunStep("Packets", PacketCodeGen.CreatePacketEntries);
RunStep("Items", ItemCodeGen.CreateItemEntries);
RunStep("Data Components", DataComponentCodeGen.CreateComponentEntries);
RunStep("Entity Types", EntityTypeCodeGen.CreateEntityTypeEntries);
RunStep("Sounds", SoundCodeGen.CreateSoundEntries);

Console.WriteLine("Generating VanillaRegistry.cs...");
string vanillaRegistryCode = vanillaRegistryFile.Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"))
    .Replace("{data}", registryEntries.ToString());

File.WriteAllText("VanillaRegistry.cs", vanillaRegistryCode);
Console.WriteLine("Done! Generated VanillaRegistry.cs in " + codeDir);
return;

void RunStep(string name, Func<JObject, string> func) {
    Console.WriteLine($"{name}...");
    Stopwatch sw = Stopwatch.StartNew();
    registryEntries.Append(func(registriesJson)).Append('\n');
    Console.WriteLine($"{name} took {sw.Elapsed}");
}
