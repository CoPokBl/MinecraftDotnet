using Minecraft.Implementations.Client;
using Minecraft.Implementations.Client.Events;
using Minecraft.Implementations.Client.Tools;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Handshake;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using NBT;
using Newtonsoft.Json;

// ClientBoundStatusResponsePacket status = await ServerPinger.QueryServer("mc.emortal.dev");
// Console.WriteLine($"Description: {status.Description!.ToJsonString()}");

// Get resource pack URL
MicrosoftAuthenticator.MinecraftProfile profile;
if (File.Exists("profile.json")) {
    profile = JsonConvert.DeserializeObject<MicrosoftAuthenticator.MinecraftProfile>(File.ReadAllText("profile.json"))!;
    Console.WriteLine($"Got profile from file, using it to authenticate: {profile.Username}");
}
else {
    profile =
        await new MicrosoftAuthenticator().Authenticate(url => Console.WriteLine($"Pls auth: {url}"));
    File.WriteAllText("profile.json", JsonConvert.SerializeObject(profile, Formatting.Indented));
}
Console.WriteLine("Successfully authenticated as " + profile.Username);

const string serverUrl = "michael-endy";
const bool actuallyAuth = false;
const int maxAccounts = 2000;  // sim 50 players all queuing
const bool queue = false;  // otherwise they will play solo
const int joinDelay = 0;  // delay between joining players

int i = 0;
while (true) {
    int id = i++;
    if (id >= maxAccounts) {
        Console.WriteLine("Reached max accounts, stopping.");
        break;
    }
    Console.WriteLine($"Connecting to {serverUrl}... (id: {id})");
    ServerConnection connection = await MinecraftClientUtils.ConnectToServer(serverUrl);
    MinecraftPacket lastPacket = null!;
    MinecraftPacket lastSentPacket = null!;
    DateTime lastKeepAlive = DateTime.Now;
    connection.Disconnected += () => {
        Console.WriteLine($"[{id}] Disconnected from server, last keep alive: {DateTime.Now - lastKeepAlive}, last sent packet: {lastSentPacket.GetType().FullName}, last packet: " + lastPacket.GetType().FullName);
    };

    connection.SendPacket(new ServerBoundHandshakePacket(serverUrl, ServerBoundHandshakePacket.Intention.Login, protocolVersion:772));
    connection.State = ConnectionState.Login;
    connection.SendPacket(new ServerBoundLoginStartPacket {
        Uuid = actuallyAuth ? Guid.Parse(profile.Uuid) : Guid.NewGuid(),
        Name = actuallyAuth ? profile.Username : $"potato-{Random.Shared.Next() % 1000}",
    });

    connection.Events.AddListener<PacketSendingEvent>(e => {
        lastSentPacket = e.Packet;
    });

    Vec3 position = new(0, 100, 0);
    connection.Events.AddListener<PacketHandleEvent>(e => {
        // Console.WriteLine($"[{id}] Got packet: " + e.Packet.GetType().FullName);
        lastPacket = e.Packet;
        switch (e.Packet) {
            case ClientBoundEncryptionRequestPacket er: {
                if (er.ShouldAuthenticate) {
                    // actually authenticate to join the server
                    ServerBoundEncryptionResponsePacket pck = connection.EnableEncryption(er, false);
                    connection.EncryptionEnabled = false;
                    MinecraftClientUtils.AuthenticateToJoin(profile.AccessToken, profile.Uuid, er.ServerId, connection.SharedSecret!, er.PublicKey).Wait();
                    Console.WriteLine("Successfully authenticated to join the server!");
                    connection.SendPacket(pck);
                    connection.EncryptionEnabled = true;
                    break;
                }
                connection.EnableEncryption(er);
                break;
            }

            case ClientBoundLoginPluginRequestPacket lpr: {
                connection.SendPacket(new ServerBoundLoginPluginResponsePacket {
                    Data = null,
                    MessageId = lpr.MessageId
                });
                break;
            }

            case ClientBoundSetCompressionPacket sc: {
                connection.SetCompression(sc.Threshold);
                break;
            }

            case ClientBoundLoginSuccessPacket: {
                connection.SendPacket(new ServerBoundLoginAcknowledgedPacket());
                Console.WriteLine("We logged in successfully!");
                connection.State = ConnectionState.Configuration;
                break;
            }

            case ClientBoundKnownPacksPacket kp: {
                connection.SendPacket(new ServerBoundKnownPacksPacket {
                    Packs = kp.Packs
                });
                break;
            }

            case ClientBoundSystemChatMessagePacket sm: {
                if (sm.Content.ToJsonString().Contains("Sending you into the game...")) {
                    Console.WriteLine("Got game start message, starting to play...");
                    Task.Delay(TimeSpan.FromSeconds(5)).ContinueWith(_ => {
                        Console.WriteLine($"[{id}] Starting to play...");
                        connection.SendPacket(new ServerBoundSetHeldItemPacket {
                            Slot = 8
                        });
                        connection.SendPacket(new ServerBoundUseItemPacket {
                            Pitch = Angle.Zero,
                            Sequence = Random.Shared.Next(),
                            UsedHand = Hand.MainHand,
                            Yaw = Angle.Zero
                        });

                        Task.Run(() => {
                            int s = 0;
                            while (true) {
                                if (s % 50 == 0) {
                                    connection.SendPacket(new ServerBoundSetHeldItemPacket {
                                        Slot = (short)Random.Shared.Next(0, 4)  // use random weapon
                                    });
                                    connection.SendPacket(new ServerBoundUseItemPacket {
                                        Pitch = Angle.Zero,
                                        Sequence = Random.Shared.Next(),
                                        UsedHand = Hand.MainHand,
                                        Yaw = Angle.Zero
                                    });
                                }
                                position += new Vec3(Random.Shared.NextDouble() - 0.5, 0, Random.Shared.NextDouble() - 0.5);
                                connection.SendPacket(new ServerBoundSetPlayerPositionPacket {
                                    Position = position,
                                    Flags = MovePlayerFlags.None
                                });
                                s++;
                                Thread.Sleep(100);
                            }
                        });
                    });
                }
                break;
            }

            case ClientBoundFinishConfigurationPacket: {
                Console.WriteLine("Configuration finished.");
                connection.SendPacket(new ServerBoundAcknowledgeFinishConfigurationPacket());
                connection.State = ConnectionState.Play;
                
                connection.SendPacket(new ServerBoundSetHeldItemPacket {
                    Slot = queue ? 0 : 1
                });
                connection.SendPacket(new ServerBoundUseItemPacket {
                    Pitch = Angle.Zero,
                    Sequence = Random.Shared.Next(),
                    UsedHand = Hand.MainHand,
                    Yaw = Angle.Zero
                });
                break;
            }

            case ClientBoundSynchronisePlayerPositionPacket spp: {
                position = spp.Position;
                connection.SendPacket(new ServerBoundConfirmTeleportPacket {
                    TeleportId = spp.TeleportId
                });
                break;
            }

            case ClientBoundAddResourcePackPacket arp: {
                Console.WriteLine("Got resource pack: " + arp.Url);
                break;
            }

            case ClientBoundLoginDisconnectPacket ld: {
                Console.WriteLine(ld.Reason.ToJsonString());
                break;
            }
            
            case ClientBoundDisconnectPacket ld: {
                Console.WriteLine(ld.Reason.ToJsonString());
                break;
            }

            case ClientBoundChunkBatchFinishedPacket: {
                connection.SendPacket(new ServerBoundChunkBatchReceivedPacket {
                    ChunksPerTick = 1
                });
                break;
            }

            case ClientBoundKeepAlivePacket ka: {
                // Respond to keep-alive packets
                connection.SendPacket(new ServerBoundKeepAlivePacket {
                    Id = ka.Id
                });
                lastKeepAlive = DateTime.Now;
                break;
            }

            case ClientBoundPingPacket ping: {
                // Respond to ping packets
                connection.SendPacket(new ServerBoundPongPacket {
                    Id = ping.Id
                });
                break;
            }
        }
    });
    
    Thread.Sleep(joinDelay);
}

Thread.Sleep(-1);


// Console.WriteLine("Microsoft logging in");
// MicrosoftAuthenticator auth = new();
// await auth.Authenticate(u => {
//     Console.WriteLine(u);
// });

// Console.WriteLine(JsonConvert.SerializeObject(status));
