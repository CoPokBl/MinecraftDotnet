using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Bundles;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.AnvilWorld;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsGame(ManagedMinecraftServer server, PlayerEntity[] players, Action gameEndCallback) {
    private const string MapFolder = "ramen";
    private static readonly ITerrainProvider GameMap = new AnvilLoader(MapFolder, VanillaRegistry.Data);
    
    private static readonly Vec3[] MapSpawns = [
        new(-20.5, 25, -24.5),
        new(23.5, 25, -24.5),
        new(29.5, 25, 0.5),
        new(21.5, 25, 25.5),
        new(-22.5, 25, 25.5),
        new(-28.5, 25, 0.5)
    ];
    
    private static readonly Vec3 SpecSpawn = new(0.5, 25, 0.5);
    private const int StartTimeSeconds = 5;
    
    public readonly List<PlayerEntity> RemainingPlayers = [];
    public World World { get; private set; } = null!;
    public bool HasEnded { get; private set; }
    
    private static FeatureBundle SkyWarsFeatures => new(
        new SkyWarsChestsFeature(),
        new DropItemsOnGroundFeature(),
        new ItemPickupFeature(),
        new LuckyBlocksFeature(),
        new SkyWarsItemsFeature(),
        new RespawnFeature()
    );

    internal static void LoadWorld() {
        GameMap.GetChunk(new ChunkData(384) {
            ChunkX = 0,
            ChunkZ = 0
        });
    }
    
    private static Queue<Vec3> CreateRandomSpawns() {
        Queue<Vec3> spawns = new();
        List<Vec3> spawnList = MapSpawns.ToList();
        
        while (spawnList.Count > 0) {
            int index = Random.Shared.Next(spawnList.Count);
            spawns.Enqueue(spawnList[index]);
            spawnList.RemoveAt(index);
        }
        
        return spawns;
    }
    
    private void Die(PlayerEntity player, string msg) {
        if (HasEnded) {
            return;
        }
        
        player.SendMessage(TextComponent.FromLegacyString($"&c{msg}"));
        player.GameMode = GameMode.Spectator;

        foreach (ItemStack item in player.Inventory.Items) {
            World.DropItem(player.Position, item);
        }
        
        player.Teleport(SpecSpawn);
        lock (RemainingPlayers) {
            RemainingPlayers.Remove(player);
            if (RemainingPlayers.Count != 1) return;
            
            // Winner
            HasEnded = true;
            PlayerEntity winner = RemainingPlayers[0];
            winner.SendMessage(TextComponent.FromLegacyString("&a&lYou won the game!"));
            
            World.SendTitle(
                TextComponent.FromLegacyString("&a&lGame Over!"),
                TextComponent.FromLegacyString("&7Winner: " + winner.Name), 10, 70, 20);

            World.Server.ScheduleTask(TimeSpan.FromSeconds(10), gameEndCallback.Invoke);
        }
    }

    public void Start() {
        World = server.CreateWorld(GameMap, "skywars:game");
        World.AddFeatures(SkyWarsFeatures);
        
        Queue<Vec3> spawns = CreateRandomSpawns();
        
        foreach (PlayerEntity player in players) {
            RemainingPlayers.Add(player);
            player.SetWorld(World);
            player.Teleport(spawns.Dequeue());
            player.SendMessage(TextComponent.FromLegacyString("&a&lGame Started! Good luck!"));
        }

        foreach (PlayerEntity player in players) {
            player.GameMode = GameMode.Survival;
        }
        
        World.AddFeature(new SkyWarsCombatFeature(p => Die(p, "You were killed!")));
        
        World.Events.AddListener<EntityMoveEvent>(e => {
            if (e.NewPos.Y > -10) {
                return;
            }

            // death
            if (e.Entity is not PlayerEntity player) {
                return;
            }

            Die(player, "You fell out of the world!");
        });
    }
}
