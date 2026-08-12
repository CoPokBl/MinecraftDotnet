using System.Diagnostics;
using System.IO.Compression;
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
using Minecraft.Schemas.Tags;
using Minecraft.Data.Blocks;
using Minecraft.Data.Items;
using Minecraft.Data.DimensionType;
using Minecraft.Data.DamageType;
using Minecraft.Data.PaintingVariant;
using Minecraft.Data.BannerPattern;
using Minecraft.Data.TrimPattern;
using Minecraft.Data.JukeboxSong;
using Minecraft.Data.Instrument;
using Minecraft.Data.CowSoundVariant;
using Minecraft.Data.CowVariant;
using Minecraft.Data.CatSoundVariant;
using Minecraft.Data.CatVariant;
using Minecraft.Data.ChickenSoundVariant;
using Minecraft.Data.ChickenVariant;
using Minecraft.Data.FrogVariant;
using Minecraft.Data.PigSoundVariant;
using Minecraft.Data.PigVariant;
using Minecraft.Data.WolfSoundVariant;
using Minecraft.Data.WolfVariant;
using Minecraft.Data.ZombieNautilusVariant;
using Minecraft.Data.Biomes;
using Minecraft.Data.ChatType;
using Minecraft.Data.Dialogs;
using Minecraft.Data.EnvironmentAttributes;
using Minecraft.Data.GameTests;
using Minecraft.Data.SulfurCubeArchetype;
using Minecraft.Data.TrimMaterial;
using Minecraft.Data.WorldClock;
using Minecraft.Data.Enchantments;
using Minecraft.Data.Entities;
using Minecraft.Data.Timelines;
using Minecraft.Registry;
using Minecraft.Data.Components.Types;
using Minecraft.Schemas.Blocks.BlockEnums;
using Minecraft.Data.Generated.BlockTypes;
using NBT;
using NBT.Tags;

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

// Get the target version
if (args.Length == 0) {
    Console.WriteLine("Usage: ./CodeGen <mc_version>");
    Console.WriteLine("Example: ./CodeGen 1.21.5");
    return 1;
}
string mcVersion = args[0];

// --------------------------------------------
// |         Vanilla Report Files             |
// --------------------------------------------

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

// --------------------------------------------
// |             Minestom Data                |
// --------------------------------------------
if (!Directory.Exists($"MinestomDataGenerator{mcVersion}")) {
    // Don't use git, download the release zip from GitHub
    // so we can choose a specific version
    const string urlTemplate = "https://github.com/Minestom/MinestomDataGenerator/archive/refs/tags/{mcver}-rv1.zip";
    string minestomUrl = urlTemplate.Replace("{mcver}", mcVersion);
    Console.WriteLine("Downloading MinestomDataGenerator from " + minestomUrl);
    using HttpClient client = new();
    HttpResponseMessage response = client.GetAsync(minestomUrl).Result;
    if (!response.IsSuccessStatusCode) {
        Console.WriteLine($"Failed to download MinestomDataGenerator: {response.StatusCode}");
        return 1;
    }
    Console.WriteLine("Extracting MinestomDataGenerator...");
    using MemoryStream stream = new(response.Content.ReadAsByteArrayAsync().Result);
    using ZipArchive archive = new(stream);
    archive.ExtractToDirectory($"MinestomDataGenerator{mcVersion}");
    
    // It extracts to MinestomDataGenerator/MinestomDataGenerator-<version>
    // so move it up one level
    string extractedDir = Directory.GetDirectories($"MinestomDataGenerator{mcVersion}").First();
    foreach (string dir in Directory.GetDirectories(extractedDir)) {
        string dirName = Path.GetFileName(dir);
        Directory.Move(dir, Path.Combine($"MinestomDataGenerator{mcVersion}", dirName));
    }
    foreach (string file in Directory.GetFiles(extractedDir)) {
        string fileName = Path.GetFileName(file);
        File.Move(file, Path.Combine($"MinestomDataGenerator{mcVersion}", fileName));
    }
    Directory.Delete(extractedDir);
    
    Console.WriteLine("Done!");
}

if (!Directory.Exists($"MinestomData{mcVersion}")) {
    // We need to run the project
    // to do that we need to run the gradle wrapper
    // but that is platform specific
    Console.WriteLine("Running MinestomDataGenerator...");
    
    string procName = Environment.OSVersion.Platform == PlatformID.Win32NT ? 
        "gradlew.bat" : 
        "./gradlew";
    
    Process process = new() {
        StartInfo = new ProcessStartInfo {
            Environment = { { "EULA", "true" } },
            WorkingDirectory = $"MinestomDataGenerator{mcVersion}",
            FileName = Path.Combine($"MinestomDataGenerator{mcVersion}", procName),
            Arguments = "run",
            RedirectStandardOutput = false,
            RedirectStandardError = false,
            UseShellExecute = false,
            CreateNoWindow = true
        }
    };
    process.Start();
    process.WaitForExit();
    
    if (process.ExitCode != 0) {
        Console.WriteLine("Failed to run MinestomDataGenerator. Check the output above for errors.");
        return 1;
    }
    
    // Move all the generated files to MinestomData for easier access.
    // Older generators wrote them to MinestomDataGenerator/MinestomData, newer
    // ones write them straight into the generator's resources directory.
    string[] candidateOutputDirs = [
        Path.Combine($"MinestomDataGenerator{mcVersion}", "MinestomData"),
        Path.Combine($"MinestomDataGenerator{mcVersion}", "src", "main", "resources", "net", "minestom", "data")
    ];
    string? generatedDir = candidateOutputDirs.FirstOrDefault(Directory.Exists);
    if (generatedDir == null) {
        Console.WriteLine("Could not find the MinestomDataGenerator output in any of: " +
                          string.Join(", ", candidateOutputDirs));
        return 1;
    }

    if (Directory.Exists($"MinestomData{mcVersion}")) {
        Directory.Delete($"MinestomData{mcVersion}", true);
        Console.WriteLine("Deleted existing MinestomData directory.");
    }
    Directory.Move(generatedDir, $"MinestomData{mcVersion}");
    
    Console.WriteLine("Done!");
}
CodeGenUtils.MinestomDataDir = Path.Combine(Directory.GetCurrentDirectory(), $"MinestomData{mcVersion}");

// --------------------------------------------
// |             Generate Code                |
// --------------------------------------------
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
RunStep("Potion Effects", PotionEffectTypeGen.CreatePotionEffectTypes);
RunStep("Consume Effects", ConsumeEffectGen.CreateConsumeEffects);
RunStep("Block Entity Types", BlockEntityTypeCodeGen.CreateBlockEntityTypes);
RunStep("Attributes", AttributeCodeGen.CreateAttributeEntries);
RunStep("Argument Types", ArgumentTypeCodeGen.CreateArgumentTypeEntries);
RunStep("Statistic Types", StatisticTypeCodeGen.CreateStatisticTypes);
RunStep("Custom Statistics", CustomStatisticCodeGen.CreateCustomStatistics);
RunStep("Environment Attributes", EnvironmentAttributeCodeGen.CreateEnvironmentAttributes);
RunStep("Tags", TagsCodeGen.CreateTagEntries);

// Do dynamic registries last because they might use other vanilla registries
RunDynamicRegistry("Enchantments", "enchantment.json", "IEnchantment", "Enchantment", "Enchantments", "Enchantments");
RunDynamicRegistry("Dimension Types", "dimension_type.json", "IDimensionType", "DimensionType", "DimensionTypes");
RunDynamicRegistry("Timelines", "timeline.json", "ITimeline", "Timeline", "Timelines", "Timelines");
RunDynamicRegistry("Damage Types", "damage_type.json", "IDamageType", "DamageType", "DamageTypes");
RunDynamicRegistry("Painting Variants", "painting_variant.json", "IPaintingVariant", "PaintingVariant", "PaintingVariants");
RunDynamicRegistry("Banner Patterns", "banner_pattern.json", "IBannerPattern", "BannerPattern", "BannerPatterns");
RunDynamicRegistry("Trim Patterns", "trim_pattern.json", "ITrimPattern", "TrimPattern", "TrimPatterns");
RunDynamicRegistry("Trim Materials", "trim_material.json", "ITrimMaterial", "TrimMaterial", "TrimMaterials");
RunDynamicRegistry("Jukebox Songs", "jukebox_song.json", "IJukeboxSong", "JukeboxSong", "JukeboxSongs");
RunDynamicRegistry("Instruments", "instrument.json", "IInstrument", "Instrument", "Instruments");
RunDynamicRegistry("World Clocks", "world_clock.json", "IWorldClock", "WorldClock", "WorldClocks");
RunDynamicRegistry("Chat Types", "chat_type.json", "IChatType", "ChatType", "ChatTypes");
RunDynamicRegistry("Cat Variants", "cat_variant.json", "ICatVariant", "CatVariant", "CatVariants");
RunDynamicRegistry("Cat Sound Variants", "cat_sound_variant.json", "ICatSoundVariant", "CatSoundVariant", "CatSoundVariants");
RunDynamicRegistry("Chicken Variants", "chicken_variant.json", "IChickenVariant", "ChickenVariant", "ChickenVariants");
RunDynamicRegistry("Chicken Sound Variants", "chicken_sound_variant.json", "IChickenSoundVariant", "ChickenSoundVariant", "ChickenSoundVariants");
RunDynamicRegistry("Cow Variants", "cow_variant.json", "ICowVariant", "CowVariant", "CowVariants");
RunDynamicRegistry("Cow Sound Variants", "cow_sound_variant.json", "ICowSoundVariant", "CowSoundVariant", "CowSoundVariants");
RunDynamicRegistry("Frog Variants", "frog_variant.json", "IFrogVariant", "FrogVariant", "FrogVariants");
RunDynamicRegistry("Pig Variants", "pig_variant.json", "IPigVariant", "PigVariant", "PigVariants");
RunDynamicRegistry("Pig Sound Variants", "pig_sound_variant.json", "IPigSoundVariant", "PigSoundVariant", "PigSoundVariants");
RunDynamicRegistry("Wolf Variants", "wolf_variant.json", "IWolfVariant", "WolfVariant", "WolfVariants");
RunDynamicRegistry("Wolf Sound Variants", "wolf_sound_variant.json", "IWolfSoundVariant", "WolfSoundVariant", "WolfSoundVariants");
RunDynamicRegistry("Zombie Nautilus Variants", "zombie_nautilus_variant.json", "IZombieNautilusVariant", "ZombieNautilusVariant", "ZombieNautilusVariants");
RunDynamicRegistry("Sulfur Cube Archetypes", "sulfur_cube_archetype.json", "ISulfurCubeArchetype", "SulfurCubeArchetype", "SulfurCubeArchetypes");
RunDynamicRegistry("Dialogs", "dialog.json", "IDialog", "Dialog", "Dialogs", "Dialogs");
RunDynamicRegistry("Test Environments", "test_environment.json", "ITestEnvironment", "TestEnvironment", "TestEnvironments", "GameTests");
RunDynamicRegistry("Test Instances", "test_instance.json", "ITestInstance", "TestInstance", "TestInstances", "GameTests");

// The client hard requires minecraft:plains to exist and our chunk sections default their biome
// palette to id 0, so plains goes first rather than wherever it lands alphabetically. The
// terrain generation half is dropped because Biome.NETWORK_CODEC doesn't read it.
RunDynamicRegistry("Biomes", "worldgen/biome.json", "IBiome", "Biome", "Biomes", "Biomes",
    "minecraft:plains", ["carvers", "features", "spawners", "spawn_costs"]);

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

void RunDynamicRegistry(string name, string dataFile, string interfaceName, string className,
    string registryProperty, string? typeNamespace = null, string? firstEntry = null,
    string[]? dropFields = null) {
    RunStep(name, _ => DynamicRegistryCodeGen.CreateEntries(dataFile, interfaceName, className,
        registryProperty, typeNamespace, firstEntry, dropFields));
}
