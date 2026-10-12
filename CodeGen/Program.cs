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
using Minecraft.Data.Potions;
using Minecraft.Data.VillagerTypes;
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
// |              Vanilla Dump                |
// --------------------------------------------
// Block physics and shapes, entity dimensions and attribute ranges live as fields on objects the
// reports never touch, so they come out of a small Java program run against the server jar the
// bundler unpacked above. Everything else the generator needs is already a report.

string serverJar = Path.Combine("versions", mcVersion, $"server-{mcVersion}.jar");
if (!File.Exists(serverJar) || !Directory.Exists("libraries")) {
    Console.WriteLine($"The unpacked server jar or its libraries are missing ({serverJar}).");
    Console.WriteLine($"Delete {vanillaDataDir} and rerun so the bundler unpacks them again.");
    return 1;
}
CodeGenUtils.ServerJarPath = Path.GetFullPath(serverJar);

string dumpDir = $"dump{mcVersion}";
if (!Directory.Exists(dumpDir)) {
    string classpath = string.Join(Path.PathSeparator,
        Directory.EnumerateFiles("libraries", "*.jar", SearchOption.AllDirectories).Prepend(serverJar));

    // Staged so a failed run doesn't leave a half written dump that the next one takes for cached.
    string staging = dumpDir + "_partial";
    if (Directory.Exists(staging)) {
        Directory.Delete(staging, true);
    }
    Directory.CreateDirectory(staging);

    string source = Path.Combine(staging, "Dumper.java");
    File.WriteAllText(source, CodeGenUtils.ReadEmbeddedFile("Dumper.java"));

    Console.WriteLine("Compiling the dumper...");
    if (!RunJavaTool("javac", ["-nowarn", "-cp", classpath, "-d", staging, source])) {
        Console.WriteLine("Failed to compile Dumper.java. A JDK at least as new as the server jar " +
                          "needs to be on PATH.");
        return 1;
    }

    Console.WriteLine("Running the dumper...");
    if (!RunJavaTool("java", ["-cp", classpath + Path.PathSeparator + staging, "Dumper", staging])) {
        Console.WriteLine("Failed to run the dumper. Check the output above for errors.");
        return 1;
    }

    foreach (string leftover in Directory.EnumerateFiles(staging, "*.class").Append(source)) {
        File.Delete(leftover);
    }
    Directory.Move(staging, dumpDir);
    Console.WriteLine("Done!");
}
else {
    Console.WriteLine("Found existing dump directory: " + dumpDir + ". Skipping generation.");
}

CodeGenUtils.DumpDir = Path.Combine(Directory.GetCurrentDirectory(), dumpDir);

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

RunFileStep("Game Version", GameVersionCodeGen.GenerateGameVersionCode);
RunStep("Particles", ParticleCodeGen.CreateParticleEntries);
RunStep("Blocks", BlockCodeGen.GenerateBlockCode);
RunFileStep("Block Light", BlockLightCodeGen.GenerateBlockLightCode);
RunStep("Packets", PacketCodeGen.CreatePacketEntries);
RunStep("Data Components", DataComponentCodeGen.CreateComponentEntries);
RunStep("Items", ItemCodeGen.CreateItemEntries);
RunStep("Entity Types", EntityTypeCodeGen.CreateEntityTypeEntries);
RunFileStep("Entity Classes", ClassChainCodeGen.GenerateEntityClassCode);
RunFileStep("Block Classes", ClassChainCodeGen.GenerateBlockClassCode);
RunFileStep("Path Types", PathTypeCodeGen.GeneratePathTypeCode);
RunFileStep("Entity Data", EntityDataCodeGen.GenerateEntityDataCode);
RunFileStep("Block Sound Groups", BlockSoundGroupCodeGen.GenerateBlockSoundGroupCode);
RunStep("Sounds", SoundCodeGen.CreateSoundEntries);
RunStep("Inventory Types", InventoryTypeCodeGen.CreateInventoryTypeEntries);
RunStep("Potion Effects", PotionEffectTypeGen.CreatePotionEffectTypes);
RunStep("Potions", PotionCodeGen.CreatePotions);
RunStep("Villager Types", VillagerTypeCodeGen.CreateVillagerTypes);
RunStep("Consume Effects", ConsumeEffectGen.CreateConsumeEffects);
RunStep("Block Entity Types", BlockEntityTypeCodeGen.CreateBlockEntityTypes);
RunStep("Attributes", AttributeCodeGen.CreateAttributeEntries);
RunStep("Argument Types", ArgumentTypeCodeGen.CreateArgumentTypeEntries);
RunStep("Statistic Types", StatisticTypeCodeGen.CreateStatisticTypes);
RunStep("Custom Statistics", CustomStatisticCodeGen.CreateCustomStatistics);
RunStep("Debug Subscriptions", DebugSubscriptionCodeGen.CreateDebugSubscriptions);
RunStep("Map Decoration Types", MapDecorationTypeCodeGen.CreateMapDecorationTypes);
RunStep("Slot Display Types", SlotDisplayTypeCodeGen.CreateSlotDisplayTypes);
RunStep("Recipe Display Types", RecipeDisplayTypeCodeGen.CreateRecipeDisplayTypes);
RunStep("Recipe Book Categories", RecipeBookCategoryCodeGen.CreateRecipeBookCategories);
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

bool RunJavaTool(string tool, string[] arguments) {
    ProcessStartInfo startInfo = new() {
        FileName = tool,
        UseShellExecute = false,
        CreateNoWindow = true
    };
    foreach (string argument in arguments) {
        startInfo.ArgumentList.Add(argument);
    }

    try {
        using Process process = Process.Start(startInfo)!;
        process.WaitForExit();
        return process.ExitCode == 0;
    }
    catch (System.ComponentModel.Win32Exception) {
        Console.WriteLine($"Could not run '{tool}'. It comes with the JDK, which has to be on PATH.");
        return false;
    }
}

void RunStep(string name, Func<JObject, string> func) {
    Console.WriteLine($"Generating {name} code...");
    Stopwatch sw = Stopwatch.StartNew();
    registryEntries.Append(func(registriesJson)).Append('\n');
    Console.WriteLine($"{name} took {sw.Elapsed}");
}

/// <summary>For generators that write a file and add nothing to the vanilla registry.</summary>
void RunFileStep(string name, Action<JObject> action) {
    Console.WriteLine($"Generating {name} code...");
    Stopwatch sw = Stopwatch.StartNew();
    action(registriesJson);
    Console.WriteLine($"{name} took {sw.Elapsed}");
}

void RunDynamicRegistry(string name, string dataFile, string interfaceName, string className,
    string registryProperty, string? typeNamespace = null, string? firstEntry = null,
    string[]? dropFields = null) {
    RunStep(name, _ => DynamicRegistryCodeGen.CreateEntries(dataFile, interfaceName, className,
        registryProperty, typeNamespace, firstEntry, dropFields));
}
