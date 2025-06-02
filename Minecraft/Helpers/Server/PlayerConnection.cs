using System.Net.Sockets;
using Minecraft.NBT;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Schemas;
using Minecraft.Schemas.Chunks;
using Newtonsoft.Json;

namespace Minecraft.Helpers.Server;

public class PlayerConnection(NetworkStream stream, MinecraftServer server) {
    public PlayerConnectionState State = PlayerConnectionState.None;
    public string? Username = null;
    public string? ClientBrand = null;

    private static readonly MinecraftPacket[] DontLog = [
        new ServerBoundClientTickEndPacket(),
        new ServerBoundKeepAlivePacketPlay(),
        new ServerBoundSetPlayerPositionPacket(),
        new ServerBoundSetPlayerRotationPacket(),
        new ServerBoundSetPlayerPosAndRotPacket()
    ];

    private void Log(string s) {
        Console.WriteLine($"[{State}] {s}");
    }

    private ValueTask SendPacket(MinecraftPacket packet) {
        return stream.WriteAsync(packet.Serialise());
    }

    public async Task RunHeartbeats() {
        while (true) {
            await Task.Delay(server.Config.HeartbeatFrequency);
            
            if (State != PlayerConnectionState.Play) {
                continue;
            }

            await SendPacket(new ClientBoundKeepAlivePacketPlay(Random.Shared.Next()));
        }
    }

    public async Task HandlePackets() {
        _ = RunHeartbeats();

        ServerBoundHandshakePacket? handshake = null;
        Log("Handling new client");

        byte[] buffer = new byte[short.MaxValue];
        try {
            while (true) {
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesRead == 0) {
                    // connection dropped
                    Log("Zero bytes, connection dropped");
                    return;
                }

                DataReader reader = new(buffer[..bytesRead]);
                while (reader.HasRemaining) {
                    int startPos = reader.Pos;
                    int packetLength = reader.ReadVarInt();
                    int lenOfPacketLen = reader.Pos - startPos;
                    int type = reader.ReadVarInt();

                    int neededBytes = packetLength - (bytesRead - lenOfPacketLen);
                    if (neededBytes > 0) {
                        Log($"partial packet, needed: {neededBytes}");
                        int bufferPos = bytesRead;
                        while (neededBytes > 0) {
                            int newBytes = await stream.ReadAsync(buffer, bufferPos, buffer.Length - bufferPos);
                            if (newBytes == 0) {
                                Log("No DATA");
                                return;
                            }

                            bytesRead += newBytes;
                            neededBytes -= newBytes;
                            bufferPos += newBytes;
                        }

                        reader.UpdateData(buffer[..bytesRead]);
                    }

                    reader.Pos = startPos;
                    MinecraftPacket packet;
                    try {
                        packet = MinecraftPacket.Deserialise(reader.Read(lenOfPacketLen + packetLength), false, State);
                    }
                    catch (Exception e) {
                        Log(e.ToString());
                        continue;
                    }

                    // _packets.Enqueue(packet);
                    if (!DontLog.Any(p => p.GetType().FullName!.Equals(packet.GetType().FullName))) {
                        Log($"Got full packet: {type}, {packet.GetType().FullName}");
                    }

                    switch (packet) {
                        // handshake
                        case ServerBoundHandshakePacket hs:
                            handshake = hs;
                            Log($"Got handshake from {hs.ProtocolVersion} client, intent: {hs.Intent}");

                            State = hs.Intent switch {
                                ServerBoundHandshakePacket.Intention.Status => PlayerConnectionState.Status,
                                ServerBoundHandshakePacket.Intention.Login => PlayerConnectionState.Login,
                                ServerBoundHandshakePacket.Intention.Transfer => throw new NotImplementedException(
                                    "Transfer is not yet supported"),
                                _ => throw new ArgumentOutOfRangeException()
                            };
                            break;

                        // status mode
                        case ServerBoundStatusRequestPacket: {
                            if (handshake == null) {
                                Log("Got ping without handshake");
                                return;
                            }

                            Log("Got valid ping from client");
                            await SendPacket(server.Config.PingResponseSupplier.Invoke(handshake));
                            // Log("WROTE LIST RESPONSE");
                            break;
                        }

                        case ServerBoundPingRequestPacket pr: {
                            await SendPacket(pr.CreateResponse());
                            Log("Wrote ping response");
                            break;
                        }

                        // login mode
                        case ServerBoundLoginStartPacket ls: {
                            Log($"{ls.Name} wants to login");
                            await SendPacket(new ClientBoundLoginSuccessPacket(ls.Uuid, ls.Name));
                            Username = ls.Name;
                            break;
                        }

                        case ServerBoundLoginAcknowledgedPacket: {
                            State = PlayerConnectionState.Configuration; // we are done login now
                            await SendPacket(
                                new ClientBoundKnownPacksPacket([new KnownDataPack("minecraft", "core", "1.21.5")]));
                            break;
                        }

                        // config mode
                        case ServerBoundKnownPacksPacket kp: {
                            Log(JsonConvert.SerializeObject(kp));

                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:dimension_type",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:overworld", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:cat_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:tabby", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:chicken_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:warm", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:cow_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:warm", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:frog_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:warm", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:painting_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:alban", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:pig_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:warm", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:wolf_sound_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:big", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:wolf_variant",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:ashen", null }
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:damage_type",
                                new Dictionary<string, ITag?> {
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
                                }));
                            await SendPacket(new ClientBoundRegistryDataPacket("minecraft:worldgen/biome",
                                new Dictionary<string, ITag?> {
                                    { "minecraft:plains", null }
                                }));

                            // Okay, now we can send the finish configuration packet
                            await SendPacket(new ClientBoundFinishConfigurationPacket());
                            break;
                        }

                        case ServerBoundClientInformationPacketConfig ci: {
                            Log(
                                $"Client information: Locale:{ci.Locale}, ViewDistance:{ci.ViewDistance}, ChatMode:{ci.TextChatMode}, ChatColours:{ci.ChatColors}, Hand:{ci.MainHand}");
                            break;
                        }

                        case ServerBoundPluginMessagePacketConfig pm: {
                            Log($"Plugin message, channel: {pm.Channel}");
                            if (pm.Channel == "minecraft:brand") {
                                string brand = new DataReader(pm.Data).ReadString();
                                Log($"CLIENT BRAND: {brand}");
                                ClientBrand = brand;
                            }

                            break;
                        }

                        case ServerBoundAcknowledgeFinishConfigurationPacket: {
                            // okay so they're ready to continue
                            Log("Client acknowledged finish configuration, switching to play state");
                            State = PlayerConnectionState.Play;
                            // await Task.Delay(2000);
                            await SendPacket(new ClientBoundLoginPacket(
                                1,
                                true,
                                ["minecraft:overworld"],
                                5,
                                8,
                                8,
                                false,
                                true,
                                false,
                                0,
                                "minecraft:overworld",
                                0,
                                0x01,
                                0x00,
                                false,
                                false,
                                null,
                                4,
                                64,
                                false
                            ));

                            await SendPacket(new ClientBoundSynchronisePlayerPositionPacket(
                                0,
                                new Vec3(0, 64, 0),
                                Vec3.Zero,
                                0,
                                0,
                                TeleportFlags.None));
                            
                            // Thread.Sleep(1000);

                            await SendPacket(new ClientBoundSetCenterChunkPacket(0, 0));
                            
                            await SendPacket(new ClientBoundGameEventPacket(GameEvent.StartWaitingForLevelChunks, 0));

                            await SendPacket(new ClientBoundChunkBatchStartPacket());
                            
                            int chunksSent = 0;
                            ChunkData chunkData = new();
                            for (int x = 0; x < 16; x++) {
                                for (int z = 0; z < 16; z++) {
                                    chunkData.SetBlock(x, 50, z, 11);
                                }
                            }
                            chunkData.SetBlock(0, 50, 8, 0);
                            
                            for (int i = -2; i < 2; i++) {
                                for (int j = -2; j < 2; j++) {
                                    await SendPacket(new ClientBoundChunkDataAndUpdateLightPacket(i, j, chunkData, new LightData()));
                                    chunksSent++;
                                }
                            }
                            await SendPacket(new ClientBoundChunkBatchFinishedPacket(chunksSent));

                            // await Task.Delay(2000);
                            // await SendPacket(new ClientBoundGameEventPacket(GameEvent.WinGame, 1));
                            // await SendPacket(new ClientBoundCombatDeathPacket(1,
                            //     TextComponent.Text("Hello World!").WithColor(TextColor.Aqua)));
                            break;
                        }

                        case ServerBoundClientStatusPacket cs: {
                            switch (cs.Action) {
                                case ServerBoundClientStatusPacket.StatusAction.Respawn:
                                    await SendPacket(new ClientBoundRespawnPacket(0,
                                        "minecraft:overworld",
                                        0,
                                        0x01,
                                        0x00,
                                        false,
                                        false,
                                        null,
                                        4,
                                        64, ClientBoundRespawnPacket.DataKeptTypes.All));

                                    await SendPacket(
                                        new ClientBoundGameEventPacket(GameEvent.StartWaitingForLevelChunks, 0));
                                    break;

                                case ServerBoundClientStatusPacket.StatusAction.RequestStats:
                                    break;

                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            break;
                        }

                        case ServerBoundSwingArmPacket: {
                            await SendPacket(
                                new ClientBoundSystemChatMessagePacket(
                                    TextComponent.Text("Swing").WithColor(TextColor.Green)
                                        .With(TextComponent.Content(TextContent.Text(" arm"))
                                            .WithColor(TextColor.Red)
                                            .WithBold(true)
                                            // .WithHoverEvent(HoverEvent.ShowEntity(
                                            //     TextComponent.Text("POTATO").WithColor(TextColor.Red), 
                                            //     "minecraft:cow", 
                                            //     "f81d4fae-7dec-11d0-a765-00a0c91e6bf6"))
                                            .WithHoverEvent(HoverEvent.ShowText(TextComponent.Text("Hey there")))
                                            .WithClickEvent(ClickEvent.OpenUrl("https://serble.net"))
                                            // .WithHoverEvent(HoverEvent.ShowText(TextComponent.Text("Do it pussy").WithColor(TextColor.Aqua)))
                                        ),
                                    false));

                            TextComponent thing = TextComponent.Text("Hello there potato")
                                .WithClickEvent(ClickEvent.OpenUrl("https://serble.net")).WithColor(TextColor.Red);
                            await SendPacket(new ClientBoundSystemChatMessagePacket(
                                thing, false));

                            for (int i = 0; i < 5; i++) {
                                for (int j = 0; j < 5; j++) {
                                    await SendPacket(new ClientBoundBlockUpdatePacket(new BlockPosition(i, 60, j), 11));
                                }
                            }
                            
                            break;
                        }

                        case ServerBoundSetPlayerPositionPacket setpos: {
                            int x = (int)(setpos.Position.X / 16);
                            int z = (int)(setpos.Position.Z / 16);
                            Log($"Setting center chunk to: {x}, {z}");
                            await SendPacket(new ClientBoundSetCenterChunkPacket(x, z));
                            break;
                        }

                        case ServerBoundSetHeldItemPacket shi: {
                            await SendPacket(
                                new ClientBoundSystemChatMessagePacket(TextComponent.Text($"Set held item to {shi.Slot}"),
                                    true));

                            if (shi.Slot == 8) {
                                await SendPacket(new ClientBoundDisconnectPacketPlay(TextComponent.Text("Cya later")));
                            }

                            break;
                        }

                        case ServerBoundChatMessagePacket cm: {
                            await SendPacket(
                                new ClientBoundSystemChatMessagePacket(TextComponent.Text($"{Username}: {cm.Message}"),
                                    false));
                            break;
                        }
                    }
                }
            }
        } catch (Exception e) {
            Log("Packet listener encountered exception:");
            Log(e.ToString());
            Log("Listening has now stopped");
        }
    }
}