using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Packets.Play.ServerBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ServerBoundPlay { get; private set; } = null!;

    private static void InitializeServerBoundPlay() {
        ServerBoundPlay =  new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ServerBoundConfirmTeleportPacket), ServerBoundConfirmTeleportPacket.Deserialiser) },
            { 0x07, (typeof(ServerBoundChatMessagePacket), ServerBoundChatMessagePacket.Deserialiser) },
            { 0x09, (typeof(ServerBoundChunkBatchReceivedPacket), ServerBoundChunkBatchReceivedPacket.Deserialiser) },
            { 0x0A, (typeof(ServerBoundClientStatusPacket), ServerBoundClientStatusPacket.Deserialiser) },
            { 0x0B, (typeof(ServerBoundClientTickEndPacket), ServerBoundClientTickEndPacket.Deserialiser) },
            { 0x0C, (typeof(ServerBoundClientInformationPacket), ServerBoundClientInformationPacket.Deserialiser) },
            { 0x0E, (typeof(ServerBoundAcknowledgeConfigurationPacket), ServerBoundAcknowledgeConfigurationPacket.Deserialiser) },
            { 0x13, (typeof(ServerBoundCookieResponsePacket), ServerBoundCookieResponsePacket.Deserialiser) },
            { 0x14, (typeof(ServerBoundPluginMessagePacket), ServerBoundPluginMessagePacket.Deserialiser) },
            { 0x18, (typeof(ServerBoundInteractPacket), ServerBoundInteractPacket.Deserialiser) },
            { 0x1A, (typeof(ServerBoundKeepAlivePacket), ServerBoundKeepAlivePacket.Deserialiser) },
            { 0x1C, (typeof(ServerBoundSetPlayerPositionPacket), ServerBoundSetPlayerPositionPacket.Deserialiser) },
            { 0x1D, (typeof(ServerBoundSetPlayerPosAndRotPacket), ServerBoundSetPlayerPosAndRotPacket.Deserialiser) },
            { 0x1E, (typeof(ServerBoundSetPlayerRotationPacket), ServerBoundSetPlayerRotationPacket.Deserialiser) },
            { 0x1F, (typeof(ServerBoundSetMovementFlagsPacket), ServerBoundSetMovementFlagsPacket.Deserialiser) },
            { 0x22, (typeof(ServerBoundPickItemFromBlockPacket), ServerBoundPickItemFromBlockPacket.Deserialiser) },
            { 0x23, (typeof(ServerBoundPickItemFromEntityPacket), ServerBoundPickItemFromEntityPacket.Deserialiser) },
            { 0x27, (typeof(ServerBoundPlayerActionPacket), ServerBoundPlayerActionPacket.Deserialiser) },
            { 0x28, (typeof(ServerBoundPlayerCommandPacket), ServerBoundPlayerCommandPacket.Deserialiser) },
            { 0x29, (typeof(ServerBoundPlayerInputPacket), ServerBoundPlayerInputPacket.Deserialiser) },
            { 0x2A, (typeof(ServerBoundPlayerLoadedPacket), ServerBoundPlayerLoadedPacket.Deserialiser) },
            { 0x2C, (typeof(ServerBoundPongPacket), ServerBoundPongPacket.Deserialiser) },
            { 0x30, (typeof(ServerBoundResourcePackResponsePacket), ServerBoundResourcePackResponsePacket.Deserialiser) },
            { 0x33, (typeof(ServerBoundSetHeldItemPacket), ServerBoundSetHeldItemPacket.Deserialiser) },
            { 0x3B, (typeof(ServerBoundSwingArmPacket), ServerBoundSwingArmPacket.Deserialiser) },
            { 0x3E, (typeof(ServerBoundUseItemOnPacket), ServerBoundUseItemOnPacket.Deserialiser) },
            { 0x3F, (typeof(ServerBoundUseItemPacket), ServerBoundUseItemPacket.Deserialiser) },
            { 0x41, (typeof(ServerBoundCustomClickActionPacket), ServerBoundCustomClickActionPacket.Deserialiser) }
        };
    }
}
