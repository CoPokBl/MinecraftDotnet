using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Tags;
using Minecraft.Implementations.Utils;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Schemas;
using NBT;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerPreLoginEvent), typeof(PlayerLoginEvent))]
internal class LoginProcedureFeature : ScopedFeature {
    private const bool EncryptionEnabled = true;
    
    private static readonly Tag<(Guid, string)> LoginInfoTag = new("minecraftdotnet:loginprocfeat:logininfo");
    
    // We'll just say we know vanilla for now
    private readonly KnownDataPack[] _knownPacks = [ new("minecraft", "core", "1.21.7") ];

    public override void Register() {
        if (Scope is not ManagedMinecraftServer) {
            throw new InvalidOperationException("LoginProcedureFeature can only be used in ManagedMinecraftServer.");
        }
        
        AddEventHandler<PacketHandleEvent>(void (e) => {
            try {
                switch (e.Packet) {
                    // LOGIN
                    case ServerBoundLoginStartPacket ls: {
                        e.Connection.SetTag(LoginInfoTag, (ls.Uuid, ls.Name));
                        e.Connection.SetCompression(10);
                        if (EncryptionEnabled) {
                            e.Connection.EnableEncryption();
                        }
                        else {
                            e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
                                Uuid = ls.Uuid,
                                Username = ls.Name
                            });
                        }
                        break;
                    }

                    case ServerBoundEncryptionResponsePacket: {
                        (Guid, string) ls = e.Connection.GetTag(LoginInfoTag);
                        e.Connection.SendPackets(new ClientBoundLoginSuccessPacket {
                            Uuid = ls.Item1,
                            Username = ls.Item2
                        });
                        break;
                    }
                
                    case ServerBoundLoginAcknowledgedPacket: {
                        e.Connection.SendPacket(new ClientBoundFeatureFlagsPacket {
                            Flags = ["minecraft:vanilla"]
                        });
                        e.Connection.SendPacket(new ClientBoundKnownPacksPacket {
                            Packs = _knownPacks
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
                                Entries = new Dictionary<string, INbtTag?>(
                                    Scope.Server.Dimensions
                                        .Select(kvp => new KeyValuePair<string, INbtTag?>(kvp.Key, kvp.Value.ToNbt())))
                                // Entries = new Dictionary<string, INbtTag?> {
                                //     { "minecraft:overworld", null }
                                // }
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
                        PlayerPreLoginEvent preLoginEvent = new() {
                            Connection = e.Connection
                        };  // should have reasonable defaults
                        e.Connection.Events.CallEvent(preLoginEvent);

                        if (preLoginEvent.World == null) {
                            throw new Exception("You must specify a spawn world for joining players in the PlayerPreLoginEvent.");
                        }

                        ClientBoundLoginPacket packet = new() {
                            DimensionName = preLoginEvent.World.DimensionId,
                            DimensionType = Scope.Server.Dimensions.Keys.ToList()
                                .IndexOf(preLoginEvent.World.DimensionId),
                            Dimensions = Scope.Server.Dimensions.Keys.Select(s => (Identifier)s)
                                .ToArray(),
                            DoLimitedCrafting = false,
                            EnableRespawnScreen = true,
                            EnforcesSecureChat = false,
                            EntityId = 0,
                            GameMode = preLoginEvent.GameMode,
                            SeaLevel = 64,
                            PortalCooldown = 0,
                            IsFlat = false,
                            IsDebug = false,
                            PreviousGameMode = GameMode.Undefined,
                            HashedSeed = 0,
                            ReducedDebugInfo = false,
                            SimulationDistance = 0,
                            ViewDistance = Scope.Server.ViewDistance,
                            MaxPlayers = 0,
                            IsHardcore = false
                        };
                        //_loginPacketProvider.Invoke(e.Connection);
                        packet.GameMode = preLoginEvent.GameMode;

                        int pEntityId = Random.Shared.Next();
                        packet.EntityId = pEntityId;
                    
                        // send the play login packet
                        e.Connection.SendPacket(packet);
                        
                        (Guid, string) loginInfo = e.Connection.GetTag(LoginInfoTag);
                        
                        // create a player object
                        PlayerEntity entity = new(Scope.Server, e.Connection, PlayerInfoFeature.GetInfo(e.Connection).Username!) {
                            NetId = pEntityId,
                            GameMode = preLoginEvent.GameMode,
                            Uuid = loginInfo.Item1,
                            Skin = null
                        };
                            
                        entity.SetWorld(preLoginEvent.World);
                        Scope.Server.Players.Add(entity);
                                
                        e.Connection.Disconnected += () => {
                            Scope.Server.Players.Remove(entity);
                        };
                            
                        entity.SendPacket(entity.GetPlayerInfoPacket());
                        
                        PlayerLoginEvent loginEvent = new() {
                            Player = entity,
                            World = preLoginEvent.World
                        };
                        Scope.Server.HandleError(entity.Events.CallEventCatchErrors(loginEvent));
                        
                        // Load skin asynchronously
                        _ = SkinFetcher.GetPlayerSkin(loginInfo.Item1).ContinueWith(skin => {
                            try {
                                entity.Skin = skin.Result;
                            }
                            catch (Exception exception) {
                                Scope.Server.HandleError(exception);
                            }
                        });
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
}
