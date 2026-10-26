using System.Diagnostics;
using ManagedServer;
using ManagedServer.Commands;
using ManagedServer.Commands.Arguments;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Scheduling;
using ManagedServer.Terrain;
using ManagedServer.Terrain.Features;
using ManagedServer.Terrain.Structures;
using ManagedServer.Terrain.Structures.Templates;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Blocks;
using Minecraft.Data.Generated;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.Worldgen;

/// <summary>
/// Vanilla terrain generation demo: four worlds off one seed, one per noise settings preset.
/// </summary>
/// <remarks>
/// <see cref="VanillaTerrainGenerator"/> is a port of <c>NoiseBasedChunkGenerator</c>, and it is opt
/// in like everything else here: a world gets it because it was handed one, and a bare server still
/// generates nothing.
/// <p/>
/// A demo rather than a test because the thing worth checking is what it looks like. The conformance
/// fixture pins every number the noise router produces, which is what proves the density functions are
/// right; standing on a beach and seeing the sand stop at the water line is what proves the surface
/// rules were wired to them properly.
/// <p/>
/// Every optional pass is turned on here, which is what a demo wants and not what a consumer gets:
/// <c>WithCarvers</c>, <c>WithFeatures</c> and <c>WithStructures</c> are each asked for by name.
/// </remarks>
public static class WorldgenTest {
    private const long Seed = 1234567890L;

    /// <summary>How far <c>/tpbiome</c> looks, which is vanilla's <c>/locate biome</c> radius.</summary>
    private const int BiomeSearchRadius = 6400;

    /// <summary>
    /// How far <c>/tpstruct</c> looks, in rings of its structure's placement grid rather than in
    /// blocks, as vanilla's <c>/locate structure</c> counts it. A ring is one cell of the grid, so what
    /// this is worth in blocks is the set's own spacing: 32 chunks for an ocean monument and 1 for a
    /// buried treasure.
    /// </summary>
    private const int StructureSearchRings = 100;

    /// <summary>The nether's <c>coordinate_scale</c>: a block there is eight in the overworld.</summary>
    private const int NetherScale = 8;

    /// <summary>How far from the scaled position <c>/nether</c> looks for somewhere to stand.</summary>
    private const int NetherSpotRadius = 48;

    public static async Task Start() {
        // BasicsBundle so a player can log in, walk around and fly. Nothing about terrain generation
        // is in it, or in any bundle: the generator is given to the world below.
        ManagedMinecraftServer server = ManagedMinecraftServer.New(ManagedMinecraftServer.BasicsBundle);

        // A world reads this when it is created, so it has to be set before CreateWorld. Far past
        // what a demo needs to prove a rule, because the shape of a continent is only visible from
        // a long way up and this is what the generator costs when asked for a lot at once.
        server.ViewDistance = 32;

        // One generator per world, sharing a seed. They are different noise settings, so the same
        // seed gives five different shapes, the first three over the same climate.
        Dictionary<string, VanillaTerrainGenerator> generators = new() {
            ["overworld"] = VanillaTerrainGenerator.Overworld(VanillaPack.Source, Seed),
            ["amplified"] = VanillaTerrainGenerator.Amplified(VanillaPack.Source, Seed),
            ["large"] = VanillaTerrainGenerator.LargeBiomes(VanillaPack.Source, Seed),
            ["nether"] = VanillaTerrainGenerator.Nether(VanillaPack.Source, Seed),
            ["end"] = VanillaTerrainGenerator.End(VanillaPack.Source, Seed)
        };

        Dictionary<string, World> worlds = [];

        // Kept the other way round as well, because the search commands are asked about the world the
        // player is standing in and have to get back to the generator that decided it.
        Dictionary<World, VanillaTerrainGenerator> byWorld = [];

        foreach ((string name, VanillaTerrainGenerator generator) in generators) {
            generator.WithCarvers().WithFeatures().WithStructures();

            World world = server.CreateWorld(generator.AsProvider(), name switch {
                "nether" => "minecraft:the_nether",
                "end" => "minecraft:the_end",
                _ => "minecraft:overworld"
            });

            worlds[name] = world;
            byWorld[world] = generator;
        }

        // What the decoration pass could not place, and why. Printed rather than hidden: a world with
        // no lakes in it should say so at startup instead of looking like a bug in the terrain.
        ReportSkippedFeatures();
        ReportSkippedStructures();

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = worlds["overworld"];

            // Creative, so the tour is about looking at terrain rather than surviving in it.
            e.GameMode = GameMode.Creative;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            // High above the terrain, since a spawn point inside a mountain is a poor first look.
            e.Player.Teleport(new Vec3<double>(0.5, 200, 0.5));
            Welcome(e.Player);
        });

        // Spectator is the one that matters here: it flies through terrain, so a cave system can be
        // followed from the inside rather than dug into.
        server.Commands.Add(GameModeCommand("gmc", GameMode.Creative));
        server.Commands.Add(GameModeCommand("gmsp", GameMode.Spectator));

        server.Commands.Add(new CommandBuilder("nether")
            .WithDefaultSyntax((player, _) => GoToNether(player, worlds["nether"]), _ => true)
            .Build());
        server.Commands.Add(new CommandBuilder("end")
            .WithDefaultSyntax((player, _) => GoToEnd(player, worlds["end"]), _ => true)
            .Build());
        server.Commands.Add(new CommandBuilder("overworld")
            .WithDefaultSyntax((player, _) => GoToOverworld(player, worlds), _ => true)
            .Build());

        server.Commands.Add(SearchCommand("tpbiome", byWorld, FindBiome,
            generator => generator.PossibleBiomes));
        server.Commands.Add(SearchCommand("tpstruct", byWorld, FindStructure,
            generator => generator.StructurePass?.Data.Structures.Keys ?? []));

        // Only a message the tour recognises is taken; anything else is left alone and
        // BasicChatFeature broadcasts it, so two people looking at the same seed can talk.
        server.Events.AddListener<PlayerChatEvent>(e => {
            e.Cancelled = HandleCommand(worlds, e.Player, e.RawMessage.Trim().ToLowerInvariant());
        });

        // PREGEN is a chunk radius around spawn, so PREGEN=64 fills the 129x129 around 0,0 before
        // anything can connect. Terrain that is already there is what makes a flight around the world
        // a look at the generator's output rather than at its throughput.
        string? pregen = Environment.GetEnvironmentVariable("PREGEN");
        if (!string.IsNullOrWhiteSpace(pregen)) {
            if (!int.TryParse(pregen, out int radius) || radius < 0) {
                Console.WriteLine($"PREGEN is a chunk radius around spawn, not \"{pregen}\".");
                return;
            }

            await Pregenerate(worlds["overworld"], radius);
        }

        server.Start();
        await server.ListenTcp(25565);
    }

    /// <summary>
    /// Says which vanilla feature types this build does not transcribe, and how many of the datapack's
    /// features were dropped because of each.
    /// </summary>
    private static void ReportSkippedFeatures() {
        IReadOnlyDictionary<string, List<Minecraft.Schemas.Identifier>> skipped =
            VanillaFeatureData.Load(VanillaPack.Source).Skipped;

        if (skipped.Count == 0) {
            Console.WriteLine("Every vanilla feature type is transcribed.");
            return;
        }

        int total = skipped.Sum(entry => entry.Value.Count);
        Console.WriteLine($"{skipped.Count} feature types are not transcribed, dropping {total} features:");

        foreach ((string type, List<Minecraft.Schemas.Identifier> features) in
            skipped.OrderByDescending(entry => entry.Value.Count)) {

            // A composite name is a feature whose nested feature could not be built, so it has no
            // entry of its own.
            string reason = FeatureParser.NotTranscribed.TryGetValue(type, out string? known)
                ? known
                : "a feature nested inside it is not transcribed";

            Console.WriteLine($"  {type,-28} {features.Count,3}  {reason}");
        }
    }

    /// <summary>
    /// Says which structures this build does not place, and what a pool lost, and why.
    /// </summary>
    /// <remarks>
    /// The pool half is the one worth printing even when nothing is skipped: a structure that is not
    /// placed is obvious once you look for it, while a pool that lost one element still generates and
    /// is simply missing a thing.
    /// </remarks>
    private static void ReportSkippedStructures() {
        VanillaStructureData data = VanillaStructureData.Load(VanillaPack.Source,
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data), VanillaRegistry.Data);

        if (data.Skipped.Count == 0) {
            Console.WriteLine("Every vanilla structure is transcribed.");
        } else {
            Console.WriteLine($"{data.Skipped.Count} structures are not placed:");

            foreach (string entry in data.Skipped) {
                Console.WriteLine($"  {entry}");
            }
        }

        IReadOnlyList<string> dropped = TemplatePools.Load(VanillaPack.Source,
            ProcessorLists.Load(VanillaPack.Source, VanillaRegistry.Data),
            VanillaFeatureData.Load(VanillaPack.Source, VanillaRegistry.Data),
            VanillaRegistry.Data).Dropped;

        if (dropped.Count == 0) {
            return;
        }

        Console.WriteLine($"{dropped.Count} jigsaw pool entries were dropped:");

        foreach (string entry in dropped) {
            Console.WriteLine($"  {entry}");
        }
    }

    /// <summary>
    /// Loads every chunk within <paramref name="radius"/> of the origin and waits for all of them.
    /// </summary>
    /// <remarks>
    /// Nearest first, because <c>ChunkGenerationQueue</c> starts work in the order it was posted, so a
    /// run stopped early leaves a filled circle around spawn rather than a scattering.
    /// <p/>
    /// The whole area stays resident: a chunk store evicts nothing, and each chunk holds its data and
    /// the packet built from it. A radius of 64 is 16641 chunks and several gigabytes.
    /// </remarks>
    private static async Task Pregenerate(World world, int radius) {
        List<Vec2<int>> chunks = [];
        for (int x = -radius; x <= radius; x++) {
            for (int z = -radius; z <= radius; z++) {
                chunks.Add(new Vec2<int>(x, z));
            }
        }

        chunks.Sort((a, b) => (a.X * a.X + a.Y * a.Y).CompareTo(b.X * b.X + b.Y * b.Y));

        Console.WriteLine($"Pregenerating {chunks.Count} chunks, radius {radius} around spawn.");

        Stopwatch elapsed = Stopwatch.StartNew();

        Task[] loads = new Task[chunks.Count];
        for (int i = 0; i < chunks.Count; i++) {
            loads[i] = world.LoadChunk(chunks[i]);
        }

        Task all = Task.WhenAll(loads);
        while (await Task.WhenAny(all, Task.Delay(5000)) != all) {
            int done = loads.Count(load => load.IsCompleted);
            Console.WriteLine($"  {elapsed.Elapsed.TotalSeconds,6:F0}s  {done,7}/{chunks.Count} chunks"
                + $"  {done / elapsed.Elapsed.TotalSeconds,6:F0}/s");
        }

        // Awaited rather than left, so a provider that threw is reported here instead of turning into
        // a chunk that never arrives once someone joins.
        await all;

        Console.WriteLine($"Pregenerated {chunks.Count} chunks in {elapsed.Elapsed.TotalSeconds:F1}s "
            + $"({elapsed.Elapsed.TotalMilliseconds / chunks.Count:F1} ms/chunk of wall time).");
    }

    private static Command GameModeCommand(string name, GameMode mode) {
        return new CommandBuilder(name)
            .WithDefaultSyntax((player, _) => {
                player.GameMode = mode;
                Tell(player, $"&aGame mode set to &f{mode}&a.");
            }, _ => true)
            .Build();
    }

    /// <summary>What a search does once it has the generator for the world the player is in.</summary>
    /// <remarks>
    /// Runs off the tick thread and is handed a scheduler to come back on, so it may take as long as
    /// it takes: a stronghold search pays for the whole world's ring positions the first time it is
    /// asked, which is 416,000 climate samples.
    /// </remarks>
    private delegate void Search(Player player, VanillaTerrainGenerator generator, string wanted,
        ServerScheduler scheduler);

    /// <summary>
    /// A command that takes one name, finds the nearest of it and moves the player there.
    /// </summary>
    /// <remarks>
    /// With no name it lists what there is instead, which is the two forms one command rather than two
    /// because the list a search would accept is the list it is worth printing.
    /// <p/>
    /// The name is one word, so it is an <see cref="Identifier"/> either spelled out or left to default
    /// its namespace to <c>minecraft</c>.
    /// </remarks>
    private static Command SearchCommand(string name,
        IReadOnlyDictionary<World, VanillaTerrainGenerator> byWorld, Search search,
        Func<VanillaTerrainGenerator, IEnumerable<Identifier>> names) {

        return new CommandBuilder(name)
            .WithDefaultSyntax((player, _) => {
                if (GeneratorFor(player, byWorld) is { } generator) {
                    Tell(player, "&7Try: " + string.Join("&7, ", names(generator)
                        .Select(available => "&f" + available.Key)
                        .Order(StringComparer.Ordinal)));
                }
            }, _ => true)
            .WithSyntax(new CommandSyntax((player, context) => {
                if (GeneratorFor(player, byWorld) is not { } generator) {
                    return;
                }

                string wanted = context.GetArgument<string>("name");
                ServerScheduler scheduler = player.Server.Scheduler;

                Tell(player, $"&7Looking for &f{wanted}&7...");

                // Off the tick thread, because a search is seconds rather than milliseconds and the
                // tick loop is what everyone else's movement is on.
                Task.Run(() => {
                    try {
                        search(player, generator, wanted, scheduler);
                    } catch (Exception error) {
                        // Reported to the player as well as the console: a search that threw and said
                        // nothing looks exactly like one that is still running.
                        Console.WriteLine($"/{name} {wanted} failed: {error}");
                        scheduler.ScheduleNextTick(() => Tell(player, $"&cSearch failed: {error.Message}"));
                    }
                });
            }, new Argument<string>("name", CommandArgumentType.String)))
            .Build();
    }

    /// <summary>The generator behind the world the player is standing in, or a complaint.</summary>
    private static VanillaTerrainGenerator? GeneratorFor(Player player,
        IReadOnlyDictionary<World, VanillaTerrainGenerator> byWorld) {

        if (player.World is not null && byWorld.TryGetValue(player.World, out
            VanillaTerrainGenerator? generator)) {

            return generator;
        }

        Tell(player, "&cThis world is not one of the tour's generated ones.");
        return null;
    }

    /// <summary>
    /// <c>/tpbiome</c>: the nearest position the climate calls the named biome.
    /// </summary>
    /// <remarks>
    /// The hit's own y is not where to stand: the climate is sampled at several heights up a column and
    /// answers a surface biome at most of them, so a hill's biome is as likely to be found at y 1 as at
    /// the ground. What decides is whether the <b>surface</b> of that column is the wanted biome too. If
    /// it is the player goes on the ground, and if it is not the biome only exists underground and the
    /// player goes to the position itself. Creative takes no suffocation damage, so landing inside stone
    /// is a look at a cave biome rather than a death.
    /// </remarks>
    private static void FindBiome(Player player, VanillaTerrainGenerator generator, string wanted,
        ServerScheduler scheduler) {

        Identifier biome = Identifier.Parse(wanted);

        if (generator.PossibleBiomes.All(possible => possible != biome)) {
            scheduler.ScheduleNextTick(() => {
                Tell(player, $"&c{biome} is not a biome this world's climate table can name.");
                Tell(player, "&7Try: " + string.Join("&7, ", generator.PossibleBiomes
                    .Select(possible => "&f" + possible.Key)
                    .Order(StringComparer.Ordinal)));
            });

            return;
        }

        WorldgenSearch.BiomeHit? hit = WorldgenSearch.FindBiome(generator, biome,
            (int)player.Position.X, (int)player.Position.Z, BiomeSearchRadius);

        scheduler.ScheduleNextTick(() => {
            if (hit is null) {
                Tell(player, $"&cNo {biome} within {BiomeSearchRadius} blocks.");
                return;
            }

            NoiseSettings noise = generator.Settings.NoiseSettings;

            int surface = generator.GetBaseHeight(hit.Position.X, hit.Position.Z,
                HeightmapType.WorldSurfaceWorldgen, noise.MinY, noise.Height);

            bool underground = generator.BiomeAt(hit.Position.X >> 2, surface >> 2,
                hit.Position.Z >> 2) != biome;

            int y = underground ? hit.Position.Y : surface;

            player.Teleport(new Vec3<double>(hit.Position.X + 0.5, y, hit.Position.Z + 0.5));

            Tell(player, $"&a{biome} &7at &f{hit.Position.X}, {y}, {hit.Position.Z}&7, "
                + $"{hit.Distance} blocks away.");

            if (underground) {
                Tell(player, "&7That one is underground. &f/gmsp&7 to fly through it.");
            }
        });
    }

    /// <summary>
    /// <c>/tpstruct</c>: the nearest chunk the named structure starts in.
    /// </summary>
    /// <remarks>
    /// The player is put above the first piece rather than inside it, so a temple is seen from outside
    /// and a mineshaft from the ground over its first room.
    /// </remarks>
    private static void FindStructure(Player player, VanillaTerrainGenerator generator, string wanted,
        ServerScheduler scheduler) {

        Identifier structure = Identifier.Parse(wanted);

        if (generator.StructurePass is not { } pass) {
            scheduler.ScheduleNextTick(() =>
                Tell(player, "&cThis world's generator was not asked for the structure pass."));

            return;
        }

        if (!pass.Data.Structures.ContainsKey(structure)) {
            scheduler.ScheduleNextTick(() => {
                // Told apart, because a structure this build skips and one that does not exist are
                // very different answers to "why can I not find it". A skipped entry is the id
                // followed by the reason, so the id is a prefix of it and not merely somewhere in it.
                Tell(player, pass.Data.Skipped.Any(entry => entry.StartsWith(structure.ToString()))
                    ? $"&c{structure} is a vanilla structure this build does not place."
                    : $"&c{structure} is not a structure.");

                Tell(player, "&7Try: " + string.Join("&7, ", pass.Data.Structures.Keys
                    .Select(placed => "&f" + placed.Key)
                    .Order(StringComparer.Ordinal)));
            });

            return;
        }

        WorldgenSearch.StructureHit? hit = WorldgenSearch.FindStructure(generator, structure,
            (int)player.Position.X, (int)player.Position.Z, StructureSearchRings);

        scheduler.ScheduleNextTick(() => {
            if (hit is null) {
                Tell(player, $"&cNo {structure} within {StructureSearchRings} cells of its placement.");
                return;
            }

            BoundingBox whole = hit.Start.BoundingBox;
            BoundingBox first = hit.Start.Pieces[0].BoundingBox;

            player.Teleport(new Vec3<double>(hit.Position.X + 0.5, first.MaxY + 2,
                hit.Position.Z + 0.5));

            Tell(player, $"&a{structure} &7at &f{hit.Position.X}, {hit.Position.Y}, {hit.Position.Z}&7, "
                + $"{hit.Distance} blocks away.");
            Tell(player, $"&7  {hit.Start.Pieces.Count} pieces, y &f{whole.MinY}&7 to &f{whole.MaxY}&7, "
                + $"starting in chunk &f{hit.Start.ChunkX}, {hit.Start.ChunkZ}&7.");

            if (first.MaxY < generator.SeaLevel) {
                Tell(player, "&7That one is underground. &f/gmsp&7 to fly through it.");
            }
        });
    }

    /// <summary>
    /// <c>/nether</c>: into the nether at the overworld position scaled down, standing in a cavern.
    /// </summary>
    /// <remarks>
    /// A place to stand rather than a height, because the nether has a bedrock roof at 127: the 200
    /// every other world drops a player at is on top of it, looking at nothing. The search runs off the
    /// tick thread since it has to generate the chunks it looks in.
    /// </remarks>
    private static void GoToNether(Player player, World nether) {
        int scale = ReferenceEquals(player.World, nether) ? 1 : NetherScale;
        int x = (int)Math.Floor(player.Position.X / scale);
        int z = (int)Math.Floor(player.Position.Z / scale);
        ServerScheduler scheduler = player.Server.Scheduler;

        Tell(player, $"&7Looking for somewhere to stand near &f{x}, {z}&7 in the nether...");

        Task.Run(async () => {
            try {
                Vec3<int>? spot = await FindNetherSpot(nether, x, z);

                scheduler.ScheduleNextTick(() => {
                    if (spot is not { } at) {
                        Tell(player, $"&cNo open floor within {NetherSpotRadius} blocks of {x}, {z}.");
                        return;
                    }

                    if (!ReferenceEquals(player.World, nether)) {
                        player.SetWorld(nether);
                    }

                    player.Teleport(new Vec3<double>(at.X + 0.5, at.Y, at.Z + 0.5));
                    Tell(player, $"&aIn the nether at &f{at.X}, {at.Y}, {at.Z}&a. "
                        + "&f/overworld&7 goes back.");
                });
            } catch (Exception error) {
                Console.WriteLine($"/nether failed: {error}");
                scheduler.ScheduleNextTick(() => Tell(player, $"&c/nether failed: {error.Message}"));
            }
        });
    }

    /// <summary>
    /// The nearest column with open floor above the lava sea: a block to stand on that is not lava or
    /// fire, and three blocks of air over it so the view is of a cavern rather than a crawlspace.
    /// </summary>
    /// <remarks>
    /// Outward in square rings and upward from the sea within a column, so the first hit is a floor
    /// near where the player asked rather than a ledge under the roof.
    /// </remarks>
    private static async Task<Vec3<int>?> FindNetherSpot(World nether, int centreX, int centreZ) {
        for (int ring = 0; ring <= NetherSpotRadius; ring++) {
            for (int x = centreX - ring; x <= centreX + ring; x++) {
                for (int z = centreZ - ring; z <= centreZ + ring; z++) {
                    if (Math.Max(Math.Abs(x - centreX), Math.Abs(z - centreZ)) != ring) {
                        continue;
                    }

                    await nether.LoadChunk(new Vec2<int>(x >> 4, z >> 4));

                    for (int y = 32; y < 124; y++) {
                        IBlock floor = nether.GetBlock(new Vec3<int>(x, y - 1, z));
                        if (!floor.Solid || floor.Identifier == Block.MagmaBlock.Identifier) {
                            continue;
                        }

                        if (nether.GetBlock(new Vec3<int>(x, y, z)).Air
                            && nether.GetBlock(new Vec3<int>(x, y + 1, z)).Air
                            && nether.GetBlock(new Vec3<int>(x, y + 2, z)).Air) {

                            return new Vec3<int>(x, y, z);
                        }
                    }
                }
            }
        }

        return null;
    }

    /// <summary>
    /// <c>/end</c>: onto the obsidian platform at 100 49 0, which is where vanilla puts an arriving
    /// player and where the end's feature pass builds it.
    /// </summary>
    private static void GoToEnd(Player player, World end) {
        if (!ReferenceEquals(player.World, end)) {
            player.SetWorld(end);
        }

        player.Teleport(new Vec3<double>(100.5, 49, 0.5));
        Tell(player, "&aOn the end's arrival platform. The spikes are around 0, 0.");
    }

    /// <summary>
    /// <c>/overworld</c>: back out at the nether position scaled up, high above the terrain as every
    /// other world is entered.
    /// </summary>
    private static void GoToOverworld(Player player, Dictionary<string, World> worlds) {
        World overworld = worlds["overworld"];
        bool scaled = ReferenceEquals(player.World, worlds["nether"]);
        double x = player.Position.X * (scaled ? NetherScale : 1);
        double z = player.Position.Z * (scaled ? NetherScale : 1);

        if (!ReferenceEquals(player.World, overworld)) {
            player.SetWorld(overworld);
        }

        player.Teleport(new Vec3<double>(x, 200, z));
        Tell(player, $"&aIn the overworld at &f{(int)x}, {(int)z}&a.");
    }

    /// <summary>Whether the message was one of the tour's, and so is not chat.</summary>
    private static bool HandleCommand(Dictionary<string, World> worlds, Player player, string message) {
        string[] parts = message.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) {
            return false;
        }

        switch (parts[0]) {
            case "world" when parts.Length > 1 && parts[1] == "nether":
                GoToNether(player, worlds["nether"]);
                return true;

            case "world" when parts.Length > 1 && parts[1] == "end":
                GoToEnd(player, worlds["end"]);
                return true;

            case "world" when parts.Length > 1 && worlds.TryGetValue(parts[1], out World? world):
                player.SetWorld(world);

                // Teleported high because the worlds have different terrain under the same position,
                // and dropping into the inside of a mountain is a poor demo.
                player.Teleport(new Vec3<double>(player.Position.X, 200, player.Position.Z));
                Tell(player, $"&aMoved to the &f{parts[1]}&a world.");
                return true;

            case "world":
                Tell(player, "&7Worlds: &foverworld&7, &famplified&7, &flarge&7, &fnether&7.");
                return true;

            case "tp" when parts.Length > 2
                && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int z):
                player.Teleport(new Vec3<double>(x, 200, z));
                Tell(player, $"&aMoved to &f{x}, {z}&a.");
                return true;

            case "where":
                Tell(player, $"&7You are at &f{(int)player.Position.X}, " +
                    $"{(int)player.Position.Y}, {(int)player.Position.Z}&7.");
                return true;

            case "help":
                Welcome(player);
                return true;

            default:
                return false;
        }
    }

    /// <summary>
    /// The tour. Each line says what to look at and which part of the port decided it, because
    /// terrain that looks like Minecraft is exactly what a subtly wrong port also produces.
    /// </summary>
    private static void Welcome(Player player) {
        Tell(player, $"&aVanilla terrain generation demo. &7Seed &f{Seed}&7.");
        Tell(player, "");
        Tell(player, "&e Commands");
        Tell(player, "&7  &fworld overworld|amplified|large|nether|end&7 - the five noise settings presets.");
        Tell(player, "&7  &f/nether&7 - into a nether cavern under where you stand. &f/end&7 - onto the end's");
        Tell(player, "&7  arrival platform. &f/overworld&7 - back.");
        Tell(player, "&7  &ftp <x> <z>&7 - move to a position. &fwhere&7 - where you are.");
        Tell(player, "&7  &f/tpbiome <biome>&7 - the nearest of a biome. &f/tpstruct <structure>&7 -");
        Tell(player, "&7  the nearest of a structure. Either with no name lists what there is.");
        Tell(player, "&7  &f/gmc&7 - creative. &f/gmsp&7 - spectator, which flies through terrain.");
        Tell(player, "");
        Tell(player, "&e What to look at");
        Tell(player, "&7  The shape of the land is the density function tree: continents, erosion and");
        Tell(player, "&7  ridges through a stack of splines. Fly out and watch the coastlines.");
        Tell(player, "&7  What is on top of it is the material rules. Grass on soil, sand at the water");
        Tell(player, "&7  line, gravel under deep water, snow above the snow line and stone on a cliff.");
        Tell(player, "&7  Dig down: dirt for a few blocks, then stone, then deepslate below zero,");
        Tell(player, "&7  then a ragged floor of bedrock. Each of those is a separate rule.");
        Tell(player, "&7  There are two kinds of cave down there. The wide open ones are the density");
        Tell(player, "&7  functions': cheese, spaghetti and noodle caves are all in final_density. The");
        Tell(player, "&7  round tunnels and the ravines are the carver pass on top of them.");
        Tell(player, "&7  Follow a tunnel across a chunk border in spectator: it lines up because both");
        Tell(player, "&7  chunks replayed the same walk from the same seed.");
        Tell(player, "&7  Underground lakes and their pockets of air are the aquifer, and the stone");
        Tell(player, "&7  between two of them at different levels is what keeps them apart. A tunnel cut");
        Tell(player, "&7  through one comes out flooded, because the aquifer decides what a carve leaves.");
        Tell(player, "&7  Bands of granite and tuff with ore in them are the ore veinifier.");
        Tell(player, "&7  Look for a badlands for the terracotta bands, and a frozen ocean for icebergs.");
        Tell(player, "&7  Trees, grass, flowers and scattered ores are the feature pass.");
        Tell(player, "&7  Every vanilla structure is the structure pass. &f/tpstruct&7 goes to one.");
        Tell(player, "&7  A stronghold is worth the trip, since its layout is drawn out of a weighted");
        Tell(player, "&7  table until something makes a portal room, and so is a village or a trial");
        Tell(player, "&7  chamber, which are grown piece by piece by joining jigsaw blocks.");
        Tell(player, "");
        Tell(player, "&e What is missing");
        Tell(player, "&7  Nothing is alive and no container has anything in it: mobs, villagers and");
        Tell(player, "&7  loot tables all live on entities and block entities, neither of which the");
        Tell(player, "&7  generator has. So a village is empty and its chests are real and bare. The");
        Tell(player, "&7  features this build cannot place are listed on the console at startup.");
        Tell(player, "");
        Tell(player, "&8Every number the noise router produces is pinned against the jar by");
        Tell(player, "&8Conformance/terrain.sh, so this should be the world vanilla generates.");
    }

    private static void Tell(Player player, string message) {
        player.SendMessage(TextComponent.FromLegacyString(message));
    }
}
