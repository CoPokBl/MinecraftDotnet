using ManagedServer;
using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Features;
using ManagedServer.Features.Basic;
using ManagedServer.Features.Bundles;
using ManagedServer.Features.Impl;
using ManagedServer.Viewables;
using ManagedServer.Worlds;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Terrain;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Minecraft.Schemas.Items;
using Minecraft.Schemas.Vec;
using Minecraft.Text;
using PolarWorlds;

using ManagedServer.Loot;

namespace TestServer.Servers.SkyWarsLuckyBlock;

public class SkyWarsGame(ManagedMinecraftServer server, Player[] players, Action gameEndCallback) {
    private static readonly ITerrainProvider[] Maps = [
        new PolarLoader(SkyWarsUtils.ReadPolarMap("ramen.polar"), VanillaRegistry.Data)
    ];
    
    private static readonly Vec3<double>[] MapSpawns = [
        new(-20.5, 25, -24.5),
        new(23.5, 25, -24.5),
        new(29.5, 25, 0.5),
        new(21.5, 25, 25.5),
        new(-22.5, 25, 25.5),
        new(-28.5, 25, 0.5)
    ];
    
    private static readonly Vec3<double> SpecSpawn = new(0.5, 25, 0.5);
    private const int StartTimeSeconds = 5;

    /// <summary>How long nothing can hurt anyone after the game starts.</summary>
    private const int SpawnGraceSeconds = 3;

    public readonly List<Player> RemainingPlayers = [];
    public World World { get; private set; } = null!;
    public bool HasEnded { get; private set; }

    /// <summary>The tick the spawn grace runs out on, counted from <see cref="Start"/>.</summary>
    private ulong _graceEndsAtTick;

    private static FeatureBundle SkyWarsFeatures => new(
        new SkyWarsChestsFeature(),
        new DropItemsOnGroundFeature(),
        new ItemPickupFeature(),
        new BlockDropsFeature(DatapackBlockLoot.Load(VanillaPack.Source)),
        new ItemEntityFeature(),
        new BlockExperienceFeature(),
        new ExperiencePickupFeature(),
        new LuckyBlocksFeature(),
        new SkyWarsItemsFeature(),
        new AttributeModifiersFeature(),
        new ArmourSlotEnforcementFeature(),
        // The lucky blocks hand out a real shield and the chests hand out axes to take it away. The
        // cosmetic shield has its blocks_attacks component removed, so this leaves it alone.
        new ShieldFeature()
    );

    internal static void LoadWorld() {
        ChunkData data = new(384) {
            ChunkX = 0,
            ChunkZ = 0
        };
        Maps[0].GetChunk(ref data);
    }
    
    private static Queue<Vec3<double>> CreateRandomSpawns() {
        Queue<Vec3<double>> spawns = new();
        List<Vec3<double>> spawnList = MapSpawns.ToList();
        
        while (spawnList.Count > 0) {
            int index = Random.Shared.Next(spawnList.Count);
            spawns.Enqueue(spawnList[index]);
            spawnList.RemoveAt(index);
        }
        
        return spawns;
    }
    
    public void Die(Player player) {
        // Death reaches here from several places (combat, falling, burning, the void, a disconnect), so
        // taking the player out of the running is what decides whose death this is to handle. Checking
        // any later counts one player twice and hands the win out a kill early.
        lock (RemainingPlayers) {
            if (HasEnded || !RemainingPlayers.Remove(player)) {
                return;
            }
        }

        World.SendMessage(TextComponent.FromLegacyString($"&6{player.Name} &chas been killed!"));
        player.GameMode = GameMode.Spectator;

        foreach (ItemStack item in player.Inventory.Items) {
            World.DropItem(player.Position, item);
        }
        
        player.Teleport(SpecSpawn);
        lock (RemainingPlayers) {
            if (RemainingPlayers.Count != 1) return;

            // Winner
            HasEnded = true;
            Player winner = RemainingPlayers[0];
            winner.SendMessage(TextComponent.FromLegacyString("&a&lYou won the game!"));
            
            World.SendTitle(
                TextComponent.FromLegacyString("&a&lGame Over!"),
                TextComponent.FromLegacyString("&7Winner: " + winner.Name), 10, 70, 20);

            World.Server.Scheduler.ScheduleTask(TimeSpan.FromSeconds(10), gameEndCallback.Invoke);
        }
    }

    public void Start() {
        World = server.CreateWorld(Maps[0], "skywars:game");
        World.AddFeatures(SkyWarsFeatures);

        Queue<Vec3<double>> spawns = CreateRandomSpawns();
        
        foreach (Player player in players) {
            RemainingPlayers.Add(player);
            player.SetWorld(World);
            player.Teleport(spawns.Dequeue());
            player.SendMessage(TextComponent.FromLegacyString("&a&lGame Started! Good luck!"));
        }

        foreach (Player player in players) {
            player.GameMode = GameMode.Survival;
        }
        
        World.AddFeature(new SkyWarsCombatFeature());
        World.AddFeature(new FallDamageFeature());

        // Nobody can be hurt for the first few seconds, so an island neighbour cannot be shot off theirs
        // while the map is still arriving. Cancelling EntityDamageEvent is what makes it whole rather
        // than a reduction: the hit never happened, so it leaves no invulnerable window behind and
        // nothing downstream reacts to it. It runs out on a tick rather than a wall clock so a lagging
        // server gives everyone the same three seconds of game.
        _graceEndsAtTick = server.CurrentTick + (ulong)(SpawnGraceSeconds * server.TargetTicksPerSecond);
        World.Events.AddListener<EntityDamageEvent>(e => {
            if (e.LivingEntity is Player && server.CurrentTick < _graceEndsAtTick) {
                e.Cancelled = true;
            }
        });

        // Whatever ran a player out of health (combat, a fall, lava, a lucky block) arrives here, so
        // there is nothing left for the individual damage sources to report. Cancelling drops the death
        // screen, since a dead player watches the rest of the game instead of respawning.
        World.Events.AddListener<PlayerDeathEvent>(e => {
            e.Cancelled = true;
            Die(e.Player);
        });

        World.Events.AddListener<EntityMoveEvent>(e => {
            if (e.NewPos.Y > -10) {
                return;
            }

            // death
            if (e.Entity is not Player player) {
                return;
            }

            Die(player);
        });

        World.Events.AddListener<PlayerDisconnectEvent>(e => {
            Die(e.Player);
        });
    }
}
