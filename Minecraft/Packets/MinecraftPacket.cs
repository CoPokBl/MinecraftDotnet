using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Packets.Status.ClientBound;
using Minecraft.Packets.Status.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Packets;

public abstract class MinecraftPacket {
    public abstract int GetPacketId();
    protected abstract byte[] GetData();
    protected abstract MinecraftPacket ParseData(byte[] data);

    protected void AssertLength<T>(T[] arr, int length) {
        if (arr.Length != length) {
            throw new ArgumentException($"Array size must be {length}", nameof(arr));
        }
    }

    public byte[] Serialise() {
        byte[] d = GetData();

        DataWriter typeD = new();
        typeD.WriteVarInt(GetPacketId());
        byte[] typeBytes = typeD.ToArray();

        DataWriter w = new();
        w.WriteVarInt(d.Length + typeBytes.Length);  // packet size
        w.WriteVarInt(GetPacketId());  // packet type
        w.Write(GetData());  // the data
        return w.ToArray();
    }

    // clientbound can help distinguish between packets
    public static MinecraftPacket Deserialise(byte[] packet, bool clientBound, PlayerConnectionState state) {
        DataReader r = new(packet);
        int packetSize = r.ReadVarInt();
        int packetType = r.ReadVarInt();
        byte[] data = r.ReadRemaining();
        
        switch (state) {
            case PlayerConnectionState.None:
                if (packetType != 0x00) {  // only handshake is allowed
                    throw new ArgumentException("Only handshake is allowed on stateless connection");
                }
                return new ServerBoundHandshakePacket().ParseData(data);
            
            case PlayerConnectionState.Status:
                switch (packetType) {
                    case 0x00:
                        return clientBound
                            ? new ClientBoundStatusResponsePacket().ParseData(data)
                            : new ServerBoundStatusRequestPacket().ParseData(data);
                    
                    case 0x01:
                        return clientBound
                            ? new ClientBoundPingResponsePacket().ParseData(data)
                            : new ServerBoundPingRequestPacket().ParseData(data);
                }
                break;
            
            case PlayerConnectionState.Login:
                switch (packetType) {
                    case 0x00:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundLoginStartPacket().ParseData(data);
                    
                    case 0x02:
                        return clientBound
                            ? new ClientBoundLoginSuccessPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x03:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundLoginAcknowledgedPacket().ParseData(data);
                }
                break;
            
            case PlayerConnectionState.Configuration:
                switch (packetType) {
                    case 0x00:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundClientInformationPacketConfig().ParseData(data);
                    
                    case 0x02:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundPluginMessagePacketConfig().ParseData(data);
                    
                    case 0x03:
                        return clientBound
                            ? new ClientBoundFinishConfigurationPacket().ParseData(data)
                            : new ServerBoundAcknowledgeFinishConfigurationPacket().ParseData(data);
                    
                    case 0x07:
                        return clientBound
                            ? new ClientBoundRegistryDataPacket().ParseData(data)
                            : new ServerBoundKnownPacksPacket().ParseData(data);
                    
                    case 0x0E:
                        return clientBound
                            ? new ClientBoundKnownPacksPacket().ParseData(data)
                            : throw new NotImplementedException();
                }
                break;
            
            case PlayerConnectionState.Play:
                switch (packetType) {
                    case 0x00:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundConfirmTeleportPacket().ParseData(data);
                    
                    case 0x07:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundChatMessagePacket().ParseData(data);
                    
                    case 0x08:
                        return clientBound
                            ? new ClientBoundBlockUpdatePacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x0A:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundClientStatusPacket().ParseData(data);
                    
                    case 0x0B:
                        return clientBound
                            ? new ClientBoundChunkBatchFinishedPacket().ParseData(data)
                            : new ServerBoundClientTickEndPacket().ParseData(data);
                    
                    case 0x0C:
                        return clientBound
                            ? new ClientBoundChunkBatchStartPacket().ParseData(data)
                            : new ServerBoundClientInformationPacketPlay().ParseData(data);
                    
                    case 0x14:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundPluginMessagePacketPlay().ParseData(data);
                    
                    case 0x1A:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundKeepAlivePacketPlay().ParseData(data);
                    
                    case 0x1C:
                        return clientBound
                            ? new ClientBoundDisconnectPacketPlay().ParseData(data)
                            : new ServerBoundSetPlayerPositionPacket().ParseData(data);
                    
                    case 0x1D:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundSetPlayerPosAndRotPacket().ParseData(data);
                    
                    case 0x1E:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundSetPlayerRotationPacket().ParseData(data);
                    
                    case 0x22:
                        return clientBound
                            ? new ClientBoundGameEventPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x26:
                        return clientBound
                            ? new ClientBoundKeepAlivePacketPlay().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x27:
                        return clientBound
                            ? new ClientBoundChunkDataAndUpdateLightPacket().ParseData(data)
                            : new ServerBoundPlayerActionPacket().ParseData(data);
                    
                    case 0x28:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundPlayerCommandPacket().ParseData(data);
                    
                    case 0x29:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundPlayerInputPacket().ParseData(data);
                    
                    case 0x2A:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundPlayerLoadedPacket().ParseData(data);
                    
                    case 0x2B:
                        return clientBound
                            ? new ClientBoundLoginPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x33:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundSetHeldItemPacket().ParseData(data);
                    
                    case 0x3B:
                        return clientBound
                            ? throw new NotImplementedException()
                            : new ServerBoundSwingArmPacket().ParseData(data);
                    
                    case 0x3D:
                        return clientBound
                            ? new ClientBoundCombatDeathPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x41:
                        return clientBound
                            ? new ClientBoundSynchronisePlayerPositionPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x4B:
                        return clientBound
                            ? new ClientBoundRespawnPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x57:
                        return clientBound
                            ? new ClientBoundSetCenterChunkPacket().ParseData(data)
                            : throw new NotImplementedException();
                    
                    case 0x72:
                        return clientBound
                            ? new ClientBoundSystemChatMessagePacket().ParseData(data)
                            : throw new NotImplementedException();
                }
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        
        throw new NotImplementedException($"Packet type {packetType} not implemented.");
    }
}