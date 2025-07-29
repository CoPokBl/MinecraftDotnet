using System.Diagnostics;
using System.Text;
using CodeGen;
using CodeGen.Generators;
using Newtonsoft.Json.Linq;

Console.WriteLine("=================================================");
Console.WriteLine("Minecraft Dotnet Code Generator");
Console.WriteLine("=================================================");
Console.WriteLine();

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

// Download the vanilla jar
if (args.Length == 0) {
    Console.WriteLine("Usage: ./CodeGen <mc_version>");
    Console.WriteLine("Example: ./CodeGen 1.21.5");
    return 1;
}
string mcVersion = args[0];

if (!VanillaJarUrls.Urls.TryGetValue(mcVersion, out string? jarUrl)) {
    Console.WriteLine($"Unknown Minecraft version: {mcVersion}");
    Console.WriteLine("Available versions: " + string.Join(", ", VanillaJarUrls.Urls.Keys));
    return 1;
}

if (!File.Exists(mcVersion + ".jar")) {
    // download the jar file
    Console.WriteLine($"Downloading Minecraft {mcVersion} jar from {jarUrl}...");
    using HttpClient client = new();
    HttpResponseMessage response = client.GetAsync(jarUrl).Result;
    if (!response.IsSuccessStatusCode) {
        Console.WriteLine($"Failed to download jar: {response.StatusCode}");
        return 1;
    }
    File.WriteAllBytes(mcVersion + ".jar", response.Content.ReadAsByteArrayAsync().Result);
}
else {
    Console.WriteLine("Found existing jar file for Minecraft " + mcVersion + ". Skipping download.");
}

string vanillaDataDir = $"vanilladata{mcVersion}";

if (!Directory.Exists(vanillaDataDir)) {
    // Run the process
    string cmd = $"-DbundlerMainClass=\"net.minecraft.data.Main\" -jar {mcVersion}.jar --all --output {vanillaDataDir} --all";
    Process process = new() {
        StartInfo = new ProcessStartInfo {
            FileName = "java",
            Arguments = cmd,
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    process.Start();
    Console.WriteLine($"Generating data for Minecraft {mcVersion}...");
    process.WaitForExit();
    if (process.ExitCode != 0) {
        Console.WriteLine("Failed to generate data. Check the output above for errors.");
        return 1;
    }
    Console.WriteLine("Done!");
}
else {
    Console.WriteLine("Found existing vanilla data directory: " + vanillaDataDir + ". Skipping generation.");
}

CodeGenUtils.VanillaDataDir = Path.Combine(Directory.GetCurrentDirectory(), vanillaDataDir);

Console.WriteLine("Loading registries.json...");
JObject registriesJson = JObject.Parse(CodeGenUtils.ReadVanillaDataFile("reports", "registries.json"));

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
RunStep("Data Components", DataComponentCodeGen.CreateComponentEntries);
RunStep("Items", ItemCodeGen.CreateItemEntries);
RunStep("Entity Types", EntityTypeCodeGen.CreateEntityTypeEntries);
RunStep("Sounds", SoundCodeGen.CreateSoundEntries);
RunStep("Inventory Types", InventoryTypeCodeGen.CreateInventoryTypeEntries);
RunStep("Tags", TagsCodeGen.CreateTagEntries);
RunStep("Potion Effects", PotionEffectTypeGen.CreatePotionEffectTypes);
RunStep("Consume Effects", ConsumeEffectGen.CreateConsumeEffects);
RunStep("Block Entity Types", BlockEntityTypeCodeGen.CreateBlockEntityTypes);
RunStep("Attributes", AttributeCodeGen.CreateAttributeEntries);

Console.WriteLine("Generating VanillaRegistry.cs...");
string vanillaRegistryCode = vanillaRegistryFile.Replace("{date}", DateTime.Now.ToString("yyyy-MM-dd"))
    .Replace("{data}", registryEntries.ToString());

File.WriteAllText("VanillaRegistry.cs", vanillaRegistryCode);
Console.WriteLine("Done! Generated VanillaRegistry.cs in " + codeDir);
return 0;

void RunStep(string name, Func<JObject, string> func) {
    Console.WriteLine($"Generating {name} code...");
    Stopwatch sw = Stopwatch.StartNew();
    registryEntries.Append(func(registriesJson)).Append('\n');
    Console.WriteLine($"{name} took {sw.Elapsed}");
}
