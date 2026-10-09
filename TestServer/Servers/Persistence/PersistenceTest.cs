using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Impl;
using ManagedServer.Worlds;
using ManagedServer.Viewables;
using ManagedServer.Worlds.Saving;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Implementations.Storage;
using Minecraft.Implementations.Storage.Stores;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using PolarWorlds;

namespace TestServer.Servers.Persistence;

/// <summary>
/// World saving demo: a flat world that remembers what was built in it across restarts.
/// </summary>
/// <remarks>
/// Storage is two independent choices here, and the demo makes both of them: a format
/// (<see cref="AnvilChunkCodec"/> or <see cref="PolarChunkCodec"/>) and somewhere to put it
/// (<see cref="AnvilRegionBlobStore"/>, a directory, a bundle). Either format goes in either place;
/// <c>FORMAT=polar</c> swaps one without touching the other.
/// <p/>
/// Nothing about this is on by default. A bare world holds no sink and never writes a byte, even one
/// loading from a store: the sink arrives because <see cref="WorldPersistenceFeature"/> was registered,
/// and saves happen because <see cref="AutosaveFeature"/> and <see cref="SaveOnShutdownFeature"/> were
/// each registered by name. Drop any of the three and what it brought goes with it.
/// </remarks>
public static class PersistenceTest {
    private const int Floor = 64;

    /// <summary>A world to build in, so what comes back after a restart is obviously what was left.</summary>
    private sealed class FlatTerrain : ITerrainProvider {
        public void GetChunk(ref ChunkData chunk) {
            for (int y = chunk.MinY; y < Floor; y++) {
                for (int z = 0; z < 16; z++) {
                    for (int x = 0; x < 16; x++) {
                        chunk.SetBlock(x, y - chunk.MinY, z, y == Floor - 1 ? Block.GrassBlock : Block.Stone);
                    }
                }
            }
        }
    }

    public static async Task Start() {
        string directory = Environment.GetEnvironmentVariable("WORLD") ?? "saved-world";
        bool polar = Environment.GetEnvironmentVariable("FORMAT")?.ToLowerInvariant() == "polar";

        ManagedMinecraftServer server = ManagedMinecraftServer.New(ManagedMinecraftServer.BasicsBundle);

        // The two halves of storage, chosen independently. A Polar bundle is one file for the whole
        // world; Anvil regions are a directory a vanilla client's server would also open.
        IChunkCodec codec = polar
            ? new PolarChunkCodec(server.Registry)
            : new AnvilChunkCodec(server.Registry);

        IChunkBlobStore blobs = polar
            ? new PolarBundle(384, -64) { Path = Path.Join(directory, "world.polar") }
            : new AnvilRegionBlobStore(Path.Join(directory, "region"));

        if (polar) {
            Directory.CreateDirectory(directory);
            string file = Path.Join(directory, "world.polar");
            if (File.Exists(file)) {
                blobs = PolarBundle.Open(file);
            }
        }

        CodecTerrainStore store = new(codec, blobs);

        // The store answers first and the generator fills in what it has never held, so a chunk that
        // was saved comes back as it was left and one that was not is made fresh.
        World world = server.CreateWorld(new PersistentTerrainProvider(store, new FlatTerrain()));

        // Where to save, and when, each asked for on its own.
        world.AddFeature(new WorldPersistenceFeature(store));
        AutosaveFeature autosave = new(TimeSpan.FromSeconds(30));
        server.AddFeature(autosave);
        world.AddFeature(new SaveOnShutdownFeature());

        autosave.Saved += (saved, report) => {
            if (report.Written > 0) {
                Console.WriteLine($"Autosave of {saved.DimensionId}: {report}");
            }
        };

        server.Events.AddListener<PlayerPreLoginEvent>(e => {
            e.World = world;
            e.GameMode = GameMode.Creative;
        });

        server.Events.AddListener<PlayerLoginEvent>(e => {
            e.Player.Teleport(new Vec3<double>(0.5, Floor, 0.5));
            e.Player.SendMessage(TextComponent.Text(
                $"Building here is kept in {directory} as {(polar ? "one Polar file" : "Anvil regions")}. " +
                "Say \"save\" to write now, or restart to see it come back.").WithColor(TextColor.Gray));
        });

        // A manual save, so the demo does not depend on waiting for the timer.
        server.Events.AddListener<PlayerChatEvent>(e => {
            if (e.RawMessage.Trim().ToLowerInvariant() != "save") {
                return;
            }

            e.Cancelled = true;
            Player player = e.Player;

            world.SaveAsync().ContinueWith(save => {
                SaveReport report = save.Result;
                player.SendMessage(TextComponent.Text(report.ToString())
                    .WithColor(report.Success ? TextColor.Green : TextColor.Red));
            }, TaskScheduler.Default);
        });

        Console.WriteLine($"Saving to {Path.GetFullPath(directory)} as {(polar ? "Polar" : "Anvil")}.");
        Console.WriteLine($"Chunks already stored: {store.EnumerateChunks().Count()}");

        server.Start();
        await server.ListenTcp(25565);
    }
}
