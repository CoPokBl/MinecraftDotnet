using ManagedServer.Entities.Types;
using ManagedServer.Events;
using ManagedServer.Events.Attributes;
using ManagedServer.Login;
using Minecraft;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Server.Features;
using Minecraft.Implementations.Tags;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Registry.Templates;
using Minecraft.Schemas;
using Minecraft.Text;
using NBT;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ManagedServer.Features.Basic;

[CallsEvent(typeof(PlayerPreLoginEvent), typeof(PlayerLoginEvent))]
public class LoginProcedureFeature(
    bool encryption = true,
    bool requestAuthentication = false,
    bool verifyProtocolVersion = true) : ScopedFeature {
    public static readonly Tag<(Guid, string)> LoginInfoTag = new("minecraftdotnet:loginprocfeat:logininfo");
    
    // this tag is used to mark that the player is ready to login once all login steps are done
    private static readonly Tag<bool> BasicLoggedInTag = new("minecraftdotnet:loginprocfeat:basicloggedin");
    
    // We'll just say we know vanilla for now
    private readonly KnownDataPack[] _knownPacks = [ new("minecraft", "core", ProtocolConstants.CurrentVersionString) ];

    // Vanilla generates this once per server start and sends the same one to every client,
    // and a feature instance is per server, so matching that is just a field
    private readonly Guid _sessionId = Guid.NewGuid();

    // Registries the client needs element data for that we can't produce ourselves yet. It
    // resolves individual elements by key, so these have to carry the real vanilla data.
    // Generated from the vanilla data by the CodeGen project, see ClientRegistryCodeGen.
    private static readonly Lazy<(ClientBoundRegistryDataPacket[] Registries,
        ClientBoundUpdateTagsPacket.TagSet[] Tags)> ClientSideRegistries = new(() => {
        using Stream stream = typeof(LoginProcedureFeature).Assembly
            .GetManifestResourceStream("ManagedServer.Resources.ClientRegistries.json")
            ?? throw new InvalidOperationException("ClientRegistries.json is missing from the assembly.");
        using StreamReader reader = new(stream);

        JObject registries = JObject.Parse(reader.ReadToEnd());
        List<ClientBoundRegistryDataPacket> packets = [];
        List<ClientBoundUpdateTagsPacket.TagSet> tagSets = [];
        List<string> unconvertible = [];

        foreach ((string registryId, JToken? registry) in registries) {
            JObject entries = (JObject)registry!["entries"]!;

            Dictionary<string, INbtTag?> data = [];
            List<string> order = [];
            foreach ((string entryId, JToken? element) in entries) {
                try {
                    data[entryId] = INbtTag.FromJson(element!.ToString(Formatting.None));
                    order.Add(entryId);
                }
                catch (Exception ex) {
                    // Some vanilla elements use mixed type arrays, which don't map onto an
                    // NBT list. Skip them rather than losing the whole registry, the client
                    // only complains if it actually looks the element up.
                    unconvertible.Add($"{registryId}/{entryId} ({ex.Message})");
                }
            }

            packets.Add(new ClientBoundRegistryDataPacket {
                RegistryId = registryId,
                Entries = data
            });

            JObject tags = (JObject)registry["tags"]!;
            if (tags.Count == 0) {
                continue;
            }

            // Tags are sent as indexes into the entries we just wrote out
            List<ClientBoundUpdateTagsPacket.Tag> registryTags = [];
            foreach ((string tagId, JToken? values) in tags) {
                registryTags.Add(new ClientBoundUpdateTagsPacket.Tag(
                    tagId, ResolveTagValues(values!, tags, order)));
            }
            tagSets.Add(new ClientBoundUpdateTagsPacket.TagSet(registryId, registryTags.ToArray()));
        }

        if (unconvertible.Count > 0) {
            Console.WriteLine($"Skipped {unconvertible.Count} registry entries that could not be " +
                              $"converted to NBT: {string.Join(", ", unconvertible)}");
        }

        return (packets.ToArray(), tagSets.ToArray());
    });

    /// <summary>
    /// Looks up the protocol id an element of one of the generated client side registries will
    /// have, which is just its position in the registry data packet we send.
    /// </summary>
    /// <returns>The id, or -1 if the registry or element isn't one we send.</returns>
    /// <remarks>
    /// Packets that reference these registries (world clocks in
    /// <see cref="ClientBoundUpdateTimePacket"/>, for instance) travel as ids, so they have to
    /// agree with the order used here rather than with any vanilla ordering.
    /// </remarks>
    public static int GetClientRegistryEntryId(Identifier registry, Identifier element) {
        ClientBoundRegistryDataPacket? packet = ClientSideRegistries.Value.Registries
            .FirstOrDefault(p => p.RegistryId == registry);
        if (packet == null) {
            return -1;
        }

        int id = 0;
        foreach (string entry in packet.Entries.Keys) {
            if (entry == element) {
                return id;
            }
            id++;
        }

        return -1;
    }

    private static int[] ResolveTagValues(JToken values, JObject allTags, List<string> order) {
        List<int> ids = [];
        foreach (JToken value in values) {
            string name = value.Value<string>()!;

            // Tags can pull in other tags, so flatten those into the same list
            if (name.StartsWith('#')) {
                if (allTags.TryGetValue(name[1..], out JToken? referenced)) {
                    ids.AddRange(ResolveTagValues(referenced, allTags, order));
                }
                continue;
            }

            int index = order.IndexOf(name);
            if (index != -1) {
                ids.Add(index);
            }
        }

        return ids.Distinct().ToArray();
    }


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
                // A client on the wrong version gets all the way through login and dies in
                // configuration instead, on whatever registry entry happens to be new this
                // version, so say it plainly here rather than letting that happen
                int protocolVersion = e.Connection.Handshake?.ProtocolVersion
                                      ?? ProtocolConstants.ProtocolVersion;
                if (verifyProtocolVersion && protocolVersion != ProtocolConstants.ProtocolVersion) {
                    e.Connection.Kick(TextComponent.FromLegacyString(
                        protocolVersion < ProtocolConstants.ProtocolVersion
                            ? $"&cOutdated client! Please use {ProtocolConstants.CurrentVersionString}"
                            : $"&cOutdated server! I'm still on {ProtocolConstants.CurrentVersionString}"));
                    break;
                }

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
                Username = ls.Item2,
                SessionId = _sessionId
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

                HashSet<Identifier> sentRegistries = [];
                List<ClientBoundRegistryDataPacket> registryPackets = [];
                foreach (ISubRegistry reg in Scope.Server.Registry.SubRegistries) {
                    sentRegistries.Add(reg.RegistryId);
                    if (reg is not INbtSerialisableRegistry nbtReg) {
                        continue;
                    }
                    
                    registryPackets.Add(new ClientBoundRegistryDataPacket(nbtReg));
                }
                e.Connection.SendPackets(registryPackets);
            
                // Fill in the rest from the generated vanilla data, skipping anything a real
                // registry already covered
                e.Connection.SendPackets(ClientSideRegistries.Value.Registries
                    .Where(packet => !sentRegistries.Contains(packet.RegistryId)));

                ClientBoundUpdateTagsPacket.TagSet[] extraTags = ClientSideRegistries.Value.Tags
                    .Where(set => !sentRegistries.Contains(set.Registry))
                    .ToArray();
                if (extraTags.Length > 0) {
                    e.Connection.SendPacket(new ClientBoundUpdateTagsPacket { Tags = extraTags });
                }
                e.Connection.SendPacket(new ClientBoundFinishConfigurationPacket());
                break;
            }
        }
    }

    private void HandlePlay(PacketHandleEvent e) {
        switch (e.Packet) {
            case ServerBoundAcknowledgeFinishConfigurationPacket: {
                // We are now done config and are in play
                // the player has logged in (pending play login)
                (Guid, string) loginInfo = e.Connection.GetTag(LoginInfoTag);
                
                PlayerPreLoginEvent preLoginEvent = new() {
                    Connection = e.Connection,
                    Uuid = loginInfo.Item1
                };  // should have reasonable defaults
                e.Connection.Events.CallEvent(preLoginEvent);

                if (preLoginEvent.World == null) {
                    throw new Exception("You must specify a spawn world for joining players in the PlayerPreLoginEvent.");
                }

                // Zero is vanilla's "id not assigned yet" and makes the client throw on sight
                int pEntityId = Random.Shared.Next(1, int.MaxValue);
                
                ClientBoundLoginPacket packet = new() {
                    DimensionName = preLoginEvent.World.DimensionId,
                    DimensionType = Scope.Server.Registry.DimensionTypes.GetProtocolId(preLoginEvent.World.DimensionId),
                    Dimensions = Scope.Server.Registry.DimensionTypes.Identifiers.ToArray(),
                    DoLimitedCrafting = false,
                    EnableRespawnScreen = true,
                    EnforcesSecureChat = false,
                    OnlineMode = requestAuthentication,
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
                
                // create a player object
                Player entity = new(Scope.Server, e.Connection, PlayerInfoFeature.GetInfo(e.Connection).Username!) {
                    NetId = pEntityId,
                    GameMode = preLoginEvent.GameMode,
                    Uuid = preLoginEvent.Uuid,
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
