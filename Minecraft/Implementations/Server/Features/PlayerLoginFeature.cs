using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Implementations.Server.Features;

public class PlayerLoginFeature(
    KnownDataPack[]? knownPacks = null, 
    Func<PlayerConnection, ClientBoundLoginPacket>? loginPacketProvider = null, 
    Func<PlayerConnection, PlayerPosition>? spawnProvider = null) : IServerFeature {
    
    private readonly KnownDataPack[] _knownPacks = knownPacks ?? [new KnownDataPack("minecraft", "core", "1.21.5")];
    private readonly Func<PlayerConnection, ClientBoundLoginPacket> _loginPacketProvider = loginPacketProvider ?? (_ => new ClientBoundLoginPacket {
        EntityId = 1,
        IsHardcore = true,
        Dimensions = ["minecraft:overworld"],
        MaxPlayers = 5,
        ViewDistance = 32,
        SimulationDistance = 8,
        ReducedDebugInfo = false,
        EnableRespawnScreen = true,
        DoLimitedCrafting = false,
        DimensionType = 0,
        DimensionName = "minecraft:overworld",
        HashedSeed = 0L,
        GameMode = GameMode.Creative,
        PreviousGameMode = GameMode.Survival,
        IsDebug = false,
        IsFlat = false,
        PortalCooldown = 4,
        SeaLevel = 64,
        EnforcesSecureChat = false
    });

    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            switch (e.Packet) {
                // LOGIN
                case ServerBoundLoginStartPacket ls: {
                    e.Connection.SetCompression(1);
                    e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
                        Username = ls.Name,
                        Uuid = ls.Uuid
                    });
                    break;
                }
                
                case ServerBoundLoginAcknowledgedPacket: {
                    e.Connection.SendPacket(new ClientBoundKnownPacksPacket {
                        Packs = _knownPacks,
                    });
                    break;
                }
                
                // CONFIG
                case ServerBoundKnownPacksPacket: {
                    // for now just ignore their response, we can't handle other packs anyway
                    // in reality we don't use any packs at all this is just so that
                    // the client joins.
                    
                    e.Connection.SendPackets(
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:dimension_type",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:overworld", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:cat_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:tabby", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:chicken_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:warm", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:cow_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:warm", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:frog_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:warm", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:painting_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:alban", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:pig_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:warm", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:wolf_sound_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:big", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:wolf_variant",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:ashen", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:damage_type",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:arrow", null },
                                { "minecraft:bad_respawn_point", null },
                                { "minecraft:cactus", null },
                                { "minecraft:campfire", null },
                                { "minecraft:cramming", null },
                                { "minecraft:dragon_breath", null },
                                { "minecraft:drown", null },
                                { "minecraft:dry_out", null },
                                { "minecraft:explosion", null },
                                { "minecraft:fall", null },
                                { "minecraft:falling_anvil", null },
                                { "minecraft:falling_block", null },
                                { "minecraft:falling_stalactite", null },
                                { "minecraft:fireball", null },
                                { "minecraft:fireworks", null },
                                { "minecraft:fly_into_wall", null },
                                { "minecraft:freeze", null },
                                { "minecraft:generic", null },
                                { "minecraft:generic_kill", null },
                                { "minecraft:hot_floor", null },
                                { "minecraft:in_fire", null },
                                { "minecraft:in_wall", null },
                                { "minecraft:indirect_magic", null },
                                { "minecraft:lava", null },
                                { "minecraft:lightning_bolt", null },
                                { "minecraft:magic", null },
                                { "minecraft:mob_attack", null },
                                { "minecraft:mob_attack_no_aggro", null },
                                { "minecraft:mob_projectile", null },
                                { "minecraft:on_fire", null },
                                { "minecraft:out_of_world", null },
                                { "minecraft:outside_border", null },
                                { "minecraft:player_attack", null },
                                { "minecraft:player_explosion", null },
                                { "minecraft:sonic_boom", null },
                                { "minecraft:spit", null },
                                { "minecraft:stalagmite", null },
                                { "minecraft:starve", null },
                                { "minecraft:sting", null },
                                { "minecraft:sweet_berry_bush", null },
                                { "minecraft:thorns", null },
                                { "minecraft:thrown", null },
                                { "minecraft:trident", null },
                                { "minecraft:unattributed_fireball", null },
                                { "minecraft:wind_charge", null },
                                { "minecraft:wither", null },
                                { "minecraft:wither_skull", null },
                                { "minecraft:ender_pearl", null }
                            }
                        },
                        new ClientBoundRegistryDataPacket {
                            RegistryId = "minecraft:worldgen/biome",
                            Entries = new Dictionary<string, INbtTag?> {
                                { "minecraft:plains", null }
                            }
                        },
                        new ClientBoundFinishConfigurationPacket()
                    );
                    break;
                }

                case ServerBoundAcknowledgeFinishConfigurationPacket: {
                    // We are now done config and are in play
                    // the player has logged in (pending play login)
                    // send the play login packet
                    if (spawnProvider != null) {
                        PlayerPosition spawn = spawnProvider.Invoke(e.Connection);
                        e.Connection.SendPackets(
                            _loginPacketProvider.Invoke(e.Connection),
                            new ClientBoundSynchronisePlayerPositionPacket {
                                TeleportId = Random.Shared.Next(),
                                Pitch = spawn.Pitch,
                                Yaw = spawn.Yaw,
                                Velocity = spawn.Velocity,
                                Position = spawn.Position,
                                Flags = TeleportFlags.None
                            },
                            new ClientBoundSetCenterChunkPacket {
                                X = spawn.ChunkX,
                                Z = spawn.ChunkZ
                            }
                        );
                        PlayerLoginEvent loginEvent = new() {
                            Connection = e.Connection
                        };
                        e.Connection.Events.CallEventCatchErrors(loginEvent);
                    }
                    else {
                        e.Connection.SendPackets(
                            _loginPacketProvider.Invoke(e.Connection)
                        );
                        PlayerLoginEvent loginEvent = new() {
                            Connection = e.Connection
                        };
                        e.Connection.Events.CallEventCatchErrors(loginEvent);
                    }
                    break;
                }
            }
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }

    public class PlayerLoginEvent : IServerEvent {
        public required PlayerConnection Connection { get; init; }
    }
}