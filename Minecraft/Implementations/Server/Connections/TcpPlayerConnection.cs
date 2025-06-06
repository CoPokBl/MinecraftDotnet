using System.Collections.Concurrent;
using System.Net.Sockets;
using Minecraft.NBT.Text;
using Minecraft.Packets;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Connections;

public class TcpPlayerConnection(TcpClient client, bool packetQueuing = false) : PlayerConnection {
    private readonly CancellationTokenSource _cts = new();
    private readonly ConcurrentQueue<MinecraftPacket> _packetQueue = new();
    private Stream Stream => client.GetStream();
    
    public override Task SendPacket(MinecraftPacket packet) {
        if (packetQueuing) {
            _packetQueue.Enqueue(packet);
            return Task.CompletedTask;
        }
        
        return Stream.WriteAsync(packet.Serialise(Compression), _cts.Token).AsTask();
    }

    private async Task PacketSending() {
        while (!_cts.IsCancellationRequested) {
            await Task.Yield();
            if (!_packetQueue.TryDequeue(out MinecraftPacket? packet)) {
                continue;
            }
            
            // Send it
            await Stream.WriteAsync(packet.Serialise(Compression), _cts.Token);
        }
    }
    
    public override async Task HandlePackets() {
        Log("Handling new client");
        _ = PacketSending();

        byte[] buffer = new byte[short.MaxValue];
        try {
            while (!_cts.IsCancellationRequested) {
                int bytesRead = await Stream.ReadAsync(buffer, _cts.Token);
                if (bytesRead == 0) {
                    // connection dropped
                    Log("Zero bytes, connection dropped");
                    throw new Exception("Received no data, broken connection?");
                }

                DataReader reader = new(buffer[..bytesRead]);
                while (reader.HasRemaining) {
                    int startPos = reader.Pos;
                    int packetLength = reader.ReadVarInt();
                    int lenOfPacketLen = reader.Pos - startPos;

                    int neededBytes = packetLength - (bytesRead - lenOfPacketLen);
                    if (neededBytes > 0) {
                        Log($"partial packet, needed: {neededBytes}");
                        int bufferPos = bytesRead;
                        while (neededBytes > 0) {
                            int newBytes = await Stream.ReadAsync(buffer.AsMemory(bufferPos, buffer.Length - bufferPos), _cts.Token);
                            if (newBytes == 0) {
                                Log("No DATA, dropping connection");
                                throw new Exception("Received no data, broken connection?");
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
                        bool compressed = lenOfPacketLen + packetLength > CompressionThreshold && CompressionThreshold >= 0;
                        packet = MinecraftPacket.Deserialise(reader.Read(lenOfPacketLen + packetLength), false, State, compressed);
                    }
                    catch (Exception e) {
                        Log(e.ToString());
                        continue;
                    }

                    if (!DontLog.Any(p => p.GetType().FullName!.Equals(packet.GetType().FullName))) {
                        Log($"Got full packet: {packet.GetPacketId()}, {packet.GetType().FullName}");
                    }
                    
                    HandlePacket(packet);

                    // DELETE ALL THIS EXCEPT HANDSHAKE:
                    
                    switch (packet) {
                        // handshake
                        case ServerBoundHandshakePacket hs:
                            Handshake = hs;
                            Log($"Got handshake from {hs.ProtocolVersion} client, intent: {hs.Intent}");

                            State = hs.Intent switch {
                                ServerBoundHandshakePacket.Intention.Status => PlayerConnectionState.Status,
                                ServerBoundHandshakePacket.Intention.Login => PlayerConnectionState.Login,
                                ServerBoundHandshakePacket.Intention.Transfer => throw new NotImplementedException(
                                    "Transfer is not yet supported"),
                                _ => throw new ArgumentOutOfRangeException()
                            };
                            break;

                        // LOGIN
                        case ServerBoundLoginAcknowledgedPacket: {
                            State = PlayerConnectionState.Configuration; // we are done login now
                            break;
                        }
                        
                        // CONFIG
                        case ServerBoundAcknowledgeFinishConfigurationPacket: {
                            // okay so they're ready to continue
                            Log("Client acknowledged finish configuration, switching to play state");
                            State = PlayerConnectionState.Play;
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
                            // Log($"Setting center chunk to: {x}, {z}");
                            await SendPacket(new ClientBoundSetCenterChunkPacket(x, z));
                            break;
                        }

                        case ServerBoundSetHeldItemPacket shi: {
                            await SendPacket(
                                new ClientBoundSystemChatMessagePacket(TextComponent.Text($"Set held item to {shi.Slot}"),
                                    true));

                            if (shi.Slot == 8) {
                                // await Kick(TextComponent.Text("Goodbye"));
                                await SendPacket(new ClientBoundPlayerInfoUpdatePacket(
                                    new ClientBoundPlayerInfoUpdatePacket.PlayerData(
                                            ClientBoundPlayerInfoUpdatePacket.PlayerActions.AddPlayer,
                                            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateDisplayName,
                                            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateGameMode,
                                            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateLatency,
                                            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListed,
                                            ClientBoundPlayerInfoUpdatePacket.PlayerActions.UpdateListPriority
                                            // ClientBoundPlayerInfoUpdatePacket.PlayerActions.InitializeChat
                                        )
                                        .WithPlayer(
                                            Guid.Empty, 
                                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateDisplayName {
                                                DisplayName = TextComponent.Text("Potato man").WithColor(TextColor.Red)
                                            },
                                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateGameMode {
                                                GameMode = 0
                                            },
                                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                                                Name = "Potato",
                                                Properties = []
                                            },
                                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateLatency {
                                                Latency = 200
                                            },
                                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListed {
                                                Listed = true
                                            },
                                            new ClientBoundPlayerInfoUpdatePacket.PlayerData.UpdateListPriority {
                                                Priority = 1
                                            }
                                            // new ClientBoundPlayerInfoUpdatePacket.PlayerData.InitializeChat {
                                            //     HasData = false
                                            // }
                                        )));
                            }
                            break;
                        }
                    }
                }
            }
            
            // Cancellation requested
            InvokeDisconnected();
        } catch (Exception e) {
            Log("Packet listener encountered exception:");
            Log(e.ToString());
            Log("Listening has now stopped");
            InvokeDisconnected();
        }
    }

    public override void Disconnect() {
        // disconnect the player
        _cts.Cancel();
    }
}