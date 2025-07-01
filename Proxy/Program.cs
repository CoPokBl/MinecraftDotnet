using Minecraft;
using Minecraft.Implementations.Client;
using Minecraft.Implementations.Client.Tools;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Vec;
using Newtonsoft.Json;
using Proxy;

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

ProxyServer server = new();

Tag<List<int>> fakeTeleportsTag = new("minecraftdotnet:proxy:faketeleports");
Tag<bool> antiKbTag = new("minecraftdotnet:proxy:antikb");
Tag<bool> instaMineTag = new("minecraftdotnet:proxy:instamine");


// some fun stuff
server.Events.AddListener<ServerPacketEvent>(void (e) => {
    try {
        switch (e.Packet) {
            case ClientBoundEncryptionRequestPacket er: {
                Console.WriteLine("GOT ENCRYPTION REQUEST FROM SERVER, should authenticate? " + er.ShouldAuthenticate);
                e.Connection.Server!.SharedSecret.ThrowIfNull();
                if (!er.ShouldAuthenticate) {
                    break;
                }
                MinecraftClientUtils.AuthenticateToJoin(profile.AccessToken, profile.Uuid, er.ServerId,
                    e.Connection.Server!.SharedSecret!, er.PublicKey).Wait();
                Console.WriteLine("Successfully authenticated to join the server!");
                break;
            }
        }
    }
    catch (Exception ex) {
        Console.WriteLine(ex);
    }
});

server.Events.AddListener<PlayerPacketEvent>(e => {
    if (e.Packet is not ServerBoundChatMessagePacket chat) {
        switch (e.Packet) {
            case ServerBoundConfirmTeleportPacket ct: {
                List<int> fakeTps = e.Connection.GetTagOrDefault(fakeTeleportsTag, []);
                if (fakeTps.Contains(ct.TeleportId)) {
                    fakeTps.Remove(ct.TeleportId);
                    e.Cancelled = true;
                    e.Connection.SetTag(fakeTeleportsTag, fakeTps);
                }
                break;
            }

            case ServerBoundPlayerActionPacket ac: {
                if (ac.ActionStatus == ServerBoundPlayerActionPacket.Status.StartedDigging && e.Connection.GetTagOrDefault(instaMineTag, false)) {
                    e.Connection.Server!.SendPacket(new ServerBoundPlayerActionPacket {
                        ActionStatus = ServerBoundPlayerActionPacket.Status.FinishedDigging,
                        Face = ac.Face,
                        Location = ac.Location,
                        Sequence = Random.Shared.Next()
                    });
                }
                break;
            }
        }
        return;
    }
    
    e.Connection.Player.SendSystemMessage("You sent a chat message: " + chat.Message);

    if (!chat.Message.StartsWith('.')) {
        return;
    }
    
    // this is a command
    e.Cancelled = true;  // cancel the packet so it doesn't go to the server
    string[] parts = chat.Message[1..].Trim().Split(' ', 2);
    string command = parts[0];
    string argsString = parts.Length == 1 ? "" : parts[1].Trim();
    string[] args = argsString.Length > 0 ? argsString.Split(' ') : [];

    switch (command.ToLower()) {
        case "ping":
            // reply with pong
            e.Connection.Player.SendSystemMessage("Pong!");
            break;
        
        case "swingm":
            e.Connection.Server!.SendPacket(new ServerBoundSwingArmPacket {
                UsedHand = Hand.MainHand
            });
            break;
        
        case "swingo":
            e.Connection.Server!.SendPacket(new ServerBoundSwingArmPacket {
                UsedHand = Hand.OffHand
            });
            break;

        case "join": {
            string host = args[0];
            int port = args.Length > 1 ? int.Parse(args[1]) : 25565;
            e.Connection.JoinServer(host, port);
            break;
        }

        case "reach": {
            int reach = 3;
            if (args.Length > 0) {
                if (int.TryParse(args[0], out reach)) {
                } else {
                    e.Connection.Player.SendSystemMessage("Invalid reach value. Using default of 3.");
                }
            }

            e.Connection.Player.SendPacket(new ClientBoundUpdateAttributesPacket {
                EntityId = e.Connection.EntityId,
                Attributes = [
                    new ClientBoundUpdateAttributesPacket.AttributeValue(9, reach),
                    new ClientBoundUpdateAttributesPacket.AttributeValue(6, reach)
                ]
            });
            e.Connection.Player.SendSystemMessage($"Reach set to {reach} blocks. (EID: {e.Connection.EntityId})");
            break;
        }
        
        case "scale": {
            int scale = 1;
            if (args.Length > 0) {
                if (int.TryParse(args[0], out scale)) {
                } else {
                    e.Connection.Player.SendSystemMessage("Invalid scale value. Using default of 3.");
                }
            }

            e.Connection.Player.SendPacket(new ClientBoundUpdateAttributesPacket {
                EntityId = e.Connection.EntityId,
                Attributes = [
                    new ClientBoundUpdateAttributesPacket.AttributeValue(24, scale)
                ]
            });
            e.Connection.Player.SendSystemMessage($"Scale set to {scale}. (EID: {e.Connection.EntityId})");
            break;
        }
        
        case "jump": {
            int strength = 1;
            if (args.Length > 0) {
                if (int.TryParse(args[0], out strength)) {
                } else {
                    e.Connection.Player.SendSystemMessage("Invalid jump value. Using default of 3.");
                }
            }

            e.Connection.Player.SendPacket(new ClientBoundUpdateAttributesPacket {
                EntityId = e.Connection.EntityId,
                Attributes = [
                    new ClientBoundUpdateAttributesPacket.AttributeValue(14, strength)
                ]
            });
            e.Connection.Player.SendSystemMessage($"Jump set to {strength}. (EID: {e.Connection.EntityId})");
            break;
        }
        
        case "fly":
            // tell client they can fly
            e.Connection.Player.SendPacket(new ClientBoundPlayerAbilitiesPacket {
                Flags = ClientBoundPlayerAbilitiesPacket.Abilities.Flying | ClientBoundPlayerAbilitiesPacket.Abilities.AllowFlying,
                FlyingSpeed = 0.05f,
                FovModifier = 0.1f
            });
            e.Connection.Player.SendSystemMessage("You can now fly!");
            break;
        
        case "say":
            e.Connection.Server?.SendPacket(new ServerBoundChatMessagePacket {
                Message = argsString,
                Acknowledged = [0, 0, 0],
                Checksum = 0,  // checksum is not used in this case
                MessageCount = 0,
                Salt = 0,
                Signature = new byte[256],
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
            });
            break;

        case "tp": {
            int x = int.Parse(args[0]);
            int y = int.Parse(args[1]);
            int z = int.Parse(args[2]);
            int teleportId = Random.Shared.Next();
            e.Connection.Player.SendPacket(new ClientBoundSynchronisePlayerPositionPacket {
                Position = new Vec3(x, y, z),
                Yaw = 0f,
                Pitch = 0f,
                Velocity = Vec3.Zero,
                Flags = TeleportFlags.None,
                TeleportId = teleportId
            });
            
            List<int> fakeTps = e.Connection.GetTagOrDefault(fakeTeleportsTag, []);
            fakeTps.Add(teleportId);
            e.Connection.SetTag(fakeTeleportsTag, fakeTps);
            
            e.Connection.Player.SendSystemMessage($"Teleported to {x}, {y}, {z}");
            break;
        }

        case "antikb": {
            bool newState = e.Connection.GetTagOrDefault(antiKbTag, false);
            newState = !newState;  // toggle the state
            e.Connection.SetTag(antiKbTag, newState);
            
            e.Connection.Player.SendSystemMessage($"Anti-Knockback is now {(newState ? "enabled" : "disabled")}");
            break;
        }
        
        case "instamine": {
            bool newState = e.Connection.GetTagOrDefault(instaMineTag, false);
            newState = !newState;  // toggle the state
            e.Connection.SetTag(instaMineTag, newState);
            
            e.Connection.Player.SendSystemMessage($"InstaMine is now {(newState ? "enabled" : "disabled")}");
            break;
        }
        
        default:
            e.Connection.Player.SendSystemMessage($"Unknown command: {command}");
            break;
    }
});

server.Events.AddListener<ServerPacketEvent>(e => {
    bool antiKb = e.Connection.GetTagOrDefault(antiKbTag, false);
    
    switch (e.Packet) {
        case ClientBoundSynchronisePlayerPositionPacket sp: {
            if (antiKb) {
                sp.Velocity = Vec3.Zero;
                e.Connection.Player.SendSystemMessage("Anti-Knockback is enabled, velocity set to zero.");
            }
            break;
        }
    }
});

await server.Start();
