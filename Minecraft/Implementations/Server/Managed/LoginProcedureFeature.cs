using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Server.Managed.Entities.Types;
using Minecraft.Implementations.Server.Managed.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using NBT;

namespace Minecraft.Implementations.Server.Managed;

internal class LoginProcedureFeature : IServerFeature {
    private const bool EncryptionEnabled = false;
    
    private static readonly Tag<(Guid, string)> LoginInfoTag = new("minecraftdotnet:loginprocfeat:logininfo");
    
    // We'll just say we know vanilla for now
    private readonly KnownDataPack[] _knownPacks = [ new("minecraft", "core", "1.21.5") ];
    
    // Defaults for the packet, more will be configurable later
    private readonly Func<PlayerConnection, ClientBoundLoginPacket> _loginPacketProvider = _ => new ClientBoundLoginPacket {
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
        PreviousGameMode = GameMode.Undefined,
        IsDebug = false,
        IsFlat = false,
        PortalCooldown = 4,
        SeaLevel = 64,
        EnforcesSecureChat = false
    };

    public void Register(MinecraftServer genericServer) {
        if (genericServer is not ManagedMinecraftServer server) {
            throw new ArgumentException("Feature may only be added to a ManagedMinecraftServer.");
        }
        
        server.Events.AddListener<PacketHandleEvent>(async void (e) => {
            try {
                switch (e.Packet) {
                    // LOGIN
                    case ServerBoundLoginStartPacket ls: {
                        e.Connection.SetTag(LoginInfoTag, (ls.Uuid, ls.Name));
                        await e.Connection.SetCompression(10);
                        if (EncryptionEnabled) {
                            await e.Connection.EnableEncryption();
                        }
                        else {
                            await e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
                                Uuid = ls.Uuid,
                                Username = ls.Name
                            });
                        }
                        break;
                    }

                    case ServerBoundEncryptionResponsePacket: {
                        (Guid, string) ls = e.Connection.GetTag(LoginInfoTag);
                        await e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
                            Uuid = ls.Item1,
                            Username = ls.Item2
                        });
                        break;
                    }
                
                    case ServerBoundLoginAcknowledgedPacket: {
                        await e.Connection.SendPacket(new ClientBoundKnownPacksPacket {
                            Packs = _knownPacks
                        });
                        break;
                    }
                
                    // CONFIG
                    case ServerBoundKnownPacksPacket: {
                        // for now just ignore their response, we can't handle other packs anyway
                        // in reality we don't use any packs at all this is just so that
                        // the client joins.
                    
                        _ = e.Connection.SendPackets(
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
                        PlayerPreLoginEvent preLoginEvent = new();  // should have reasonable defaults
                        e.Connection.Events.CallEvent(preLoginEvent);

                        if (preLoginEvent.World == null) {
                            throw new Exception("You must specify a spawn world for joining players in the PlayerPreLoginEvent.");
                        }

                        ClientBoundLoginPacket packet = _loginPacketProvider.Invoke(e.Connection);
                        packet.GameMode = preLoginEvent.GameMode;

                        int pEntityId = Random.Shared.Next();
                        packet.EntityId = pEntityId;
                    
                        // send the play login packet
                        await e.Connection.SendPacket(packet);
                    
                        // create a player object
                        PlayerEntity entity = new(e.Connection, PlayerInfoFeature.GetInfo(e.Connection).Username!) {
                            NetId = pEntityId
                        };
                        entity.SetWorld(preLoginEvent.World);
                        server.Players.Add(entity);
                        PlayerLoginEvent loginEvent = new() {
                            Player = entity
                        };
                        e.Connection.Events.CallEventCatchErrors(loginEvent);
                        break;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("An error occured while handling a packet in LoginProcedureFeature.");
                Console.WriteLine(ex);
            }
        });
    }
    
    public void Unregister() {
        
    }

    public Type[] GetDependencies() {
        return [];
    }
}