using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Login;
using Minecraft;
using Minecraft.Data.Generated;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using NBT;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerPreLoginEvent), typeof(PlayerLoginEvent))]
public class LoginProcedureFeature(bool encryption = true, bool requestAuthentication = false) : ScopedFeature {
    public static readonly Tag<(Guid, string)> LoginInfoTag = new("minecraftdotnet:loginprocfeat:logininfo");
    
    // this tag is used to mark that the player is ready to login once all login steps are done
    private static readonly Tag<bool> BasicLoggedInTag = new("minecraftdotnet:loginprocfeat:basicloggedin");
    
    // We'll just say we know vanilla for now
    private readonly KnownDataPack[] _knownPacks = [ new("minecraft", "core", ProtocolConstants.CurrentVersionString) ];

    public override void Register() {
        if (Scope is not ManagedMinecraftServer) {
            throw new InvalidOperationException("LoginProcedureFeature can only be used in ManagedMinecraftServer.");
        }
        
        AddEventHandler<PacketHandleEvent>(void (e) => {
            try {
                switch (e.Connection.State) {
                    // If we're in login we need to do the following:
                    // 1. Enable compression
                    // 2. Enable encryption if configured
                    // 3. Process login steps
                    case ConnectionState.Login: {
                        HandleLogin(e);
                        break;
                    }

                    // For configuration just send the configuration packets
                    // and then call it a day.
                    case ConnectionState.Configuration: {
                        HandleConfig(e);
                        break;
                    }

                    case ConnectionState.Play: {
                        HandlePlay(e);
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

    private void HandleLogin(PacketHandleEvent e) {
        // Let the login steps process the packet first
        bool passedLogin = true;
        foreach (ILoginStep loginStep in Scope.Server.LoginSteps) {
            loginStep.HandleLoginPacket(e.Connection, (ServerBoundPacket)e.Packet);
            passedLogin &= loginStep.IsLoggedIn(e.Connection);
        }

        if (e.Connection.GetTagOrDefault(BasicLoggedInTag, false) && passedLogin) {
            CompleteLogin();
            return;
        }
        
        switch (e.Packet) {
            case ServerBoundLoginStartPacket ls: {
                e.Connection.SetTag(LoginInfoTag, (ls.Uuid, ls.Name));
                e.Connection.SetCompression(10);
                if (encryption) {
                    e.Connection.EnableEncryption(Scope.Server.ServerId, requestAuthentication);
                }
                else {
                    FinishedBasicLogin();
                }
                break;
            }

            case ServerBoundEncryptionResponsePacket: {
                FinishedBasicLogin();
                break;
            }
        }

        return;

        // LOGIN METHODS
        void FinishedBasicLogin() {
            e.Connection.SetTag(BasicLoggedInTag, true);
            foreach (ILoginStep loginStep in Scope.Server.LoginSteps) {
                loginStep.Process(e.Connection);
            }

            if (passedLogin) {
                CompleteLogin();
            }
        }

        void CompleteLogin() {
            (Guid, string) ls = e.Connection.GetTag(LoginInfoTag);
            e.Connection.SendPacket(new ClientBoundLoginSuccessPacket {
                Uuid = ls.Item1,
                Username = ls.Item2
            });
        }
    }
    
    private void HandleConfig(PacketHandleEvent e) {
        switch (e.Packet) {
            case ServerBoundLoginAcknowledgedPacket: {
                e.Connection.SendPacket(new ClientBoundFeatureFlagsPacket {
                    Flags = ["minecraft:vanilla"]
                });
                e.Connection.SendPacket(new ClientBoundKnownPacksPacket {
                    Packs = _knownPacks
                });
                break;
            }
            
            case ServerBoundKnownPacksPacket: {
                // compile all the registries that we actually have
                // and then manually send the other required ones
                // that aren't implemented yet
                
                // Turns out we have to send tags first
                List<ClientBoundUpdateTagsPacket.TagSet> tags = [];
                foreach (ISubRegistry subReg in Scope.Server.Registry.SubRegistries) {
                    tags.Add(new ClientBoundUpdateTagsPacket.TagSet(subReg.RegistryId, subReg.Tags.Tags
                        .Select(kvp => new ClientBoundUpdateTagsPacket.Tag(
                            kvp.Key, 
                            kvp.Value.GetValueRegistryIds(Scope.Server.Registry)))
                        .ToArray()));
                }
                ClientBoundUpdateTagsPacket tagsPacket = new() {
                    Tags = tags.ToArray()
                };
                e.Connection.SendPacket(tagsPacket);

                List<ClientBoundRegistryDataPacket> registryPackets = [];
                foreach (ISubRegistry reg in Scope.Server.Registry.SubRegistries) {
                    if (reg is not INbtSerialisableRegistry nbtReg) {
                        continue;
                    }
                    
                    registryPackets.Add(new ClientBoundRegistryDataPacket {
                        RegistryId = nbtReg.RegistryId,
                        Entries = nbtReg.ToNbt()!
                    });
                }
                e.Connection.SendPackets(registryPackets);
            
                e.Connection.SendPackets(
                    new ClientBoundRegistryDataPacket {
                        RegistryId = "minecraft:dimension_type",
                        Entries = new Dictionary<string, INbtTag?>(
                            Scope.Server.Dimensions
                                .Select(kvp => new KeyValuePair<string, INbtTag?>(kvp.Key, kvp.Value.ToNbt())))
                    },
                    new ClientBoundRegistryDataPacket {
                        RegistryId = "minecraft:zombie_nautilus_variant",
                        Entries = new Dictionary<string, INbtTag?> {
                            { "minecraft:warm", null }
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
        }
    }

    private void HandlePlay(PacketHandleEvent e) {
        switch (e.Packet) {
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

                int pEntityId = Random.Shared.Next();
                
                ClientBoundLoginPacket packet = new() {
                    DimensionName = preLoginEvent.World.DimensionId,
                    DimensionType = Scope.Server.Dimensions.Keys.ToList()
                        .IndexOf(preLoginEvent.World.DimensionId),
                    Dimensions = Scope.Server.Dimensions.Keys.Select(s => (Identifier)s)
                        .ToArray(),
                    DoLimitedCrafting = false,
                    EnableRespawnScreen = true,
                    EnforcesSecureChat = false,
                    EntityId = pEntityId,
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
                entity.PermissionContainer = Scope.Server.PermissionsProvider(entity);
                    
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
                break;
            }
        }
    }
}
