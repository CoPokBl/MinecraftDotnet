using Minecraft.Packets.Config.ClientBound;
using Minecraft.Packets.Login.ClientBound;
using Minecraft.Packets.Play.ClientBound;

namespace Minecraft.Packets.Registry;

public static partial class PacketRegistry {
    public static Dictionary<int, (Type, PacketDataDeserialiser)> ClientBoundPlay { get; private set; } = null!;

    private static void InitializeClientBoundPlay() {
        ClientBoundPlay = new Dictionary<int, (Type, PacketDataDeserialiser)> {
            { 0x00, (typeof(ClientBoundBundleDelimiterPacket), ClientBoundBundleDelimiterPacket.Deserialiser) },
            { 0x01, (typeof(ClientBoundSpawnEntityPacket), ClientBoundSpawnEntityPacket.Deserialiser) },
            { 0x02, (typeof(ClientBoundEntityAnimationPacket), ClientBoundEntityAnimationPacket.Deserialiser) },
            { 0x04, (typeof(ClientBoundAcknowledgeBlockChangePacket), ClientBoundAcknowledgeBlockChangePacket.Deserialiser) },
            { 0x05, (typeof(ClientBoundSetBlockDestroyStagePacket), ClientBoundSetBlockDestroyStagePacket.Deserialiser) },
            { 0x08, (typeof(ClientBoundBlockUpdatePacket), ClientBoundBlockUpdatePacket.Deserialiser) },
            { 0x0B, (typeof(ClientBoundChunkBatchFinishedPacket), ClientBoundChunkBatchFinishedPacket.Deserialiser) },
            { 0x0C, (typeof(ClientBoundChunkBatchStartPacket), ClientBoundChunkBatchStartPacket.Deserialiser) },
            { 0x14, (typeof(ClientBoundSetContainerSlotPacket), ClientBoundSetContainerSlotPacket.Deserialiser) },
            { 0x18, (typeof(ClientBoundPluginMessagePacket), ClientBoundPluginMessagePacket.Deserialiser) },
            { 0x1C, (typeof(ClientBoundDisconnectPacket), ClientBoundDisconnectPacket.Deserialiser) },
            { 0x1E, (typeof(ClientBoundEntityEventPacket), ClientBoundEntityEventPacket.Deserialiser) },
            { 0x1F, (typeof(ClientBoundTeleportEntityPacket), ClientBoundTeleportEntityPacket.Deserialiser) },
            { 0x21, (typeof(ClientBoundUnloadChunkPacket), ClientBoundUnloadChunkPacket.Deserialiser) },
            { 0x22, (typeof(ClientBoundGameEventPacket), ClientBoundGameEventPacket.Deserialiser) },
            { 0x24, (typeof(ClientBoundHurtAnimationPacket), ClientBoundHurtAnimationPacket.Deserialiser) },
            { 0x26, (typeof(ClientBoundKeepAlivePacket), ClientBoundKeepAlivePacket.Deserialiser) },
            { 0x27, (typeof(ClientBoundChunkDataAndUpdateLightPacket), ClientBoundChunkDataAndUpdateLightPacket.Deserialiser) },
            { 0x2E, (typeof(ClientBoundUpdateEntityPositionPacket), ClientBoundUpdateEntityPositionPacket.Deserialiser) },
            { 0x2F, (typeof(ClientBoundUpdateEntityPosAndRotPacket), ClientBoundUpdateEntityPosAndRotPacket.Deserialiser) },
            { 0x2B, (typeof(ClientBoundLoginPacket), ClientBoundLoginPacket.Deserialiser) },
            { 0x31, (typeof(ClientBoundUpdateEntityRotationPacket), ClientBoundUpdateEntityRotationPacket.Deserialiser) },
            { 0x36, (typeof(ClientBoundPingPacket), ClientBoundPingPacket.Deserialiser) },
            { 0x3D, (typeof(ClientBoundCombatDeathPacket), ClientBoundCombatDeathPacket.Deserialiser) },
            { 0x3E, (typeof(ClientBoundPlayerInfoRemovePacket), ClientBoundPlayerInfoRemovePacket.Deserialiser) },
            { 0x3F, (typeof(ClientBoundPlayerInfoUpdatePacket), ClientBoundPlayerInfoUpdatePacket.Deserialiser) },
            { 0x41, (typeof(ClientBoundSynchronisePlayerPositionPacket), ClientBoundSynchronisePlayerPositionPacket.Deserialiser) },
            { 0x49, (typeof(ClientBoundRemoveResourcePackPacket), ClientBoundRemoveResourcePackPacket.Deserialiser) },
            { 0x4A, (typeof(ClientBoundAddResourcePackPacket), ClientBoundAddResourcePackPacket.Deserialiser) },
            { 0x4B, (typeof(ClientBoundRespawnPacket), ClientBoundRespawnPacket.Deserialiser) },
            { 0x4C, (typeof(ClientBoundSetHeadRotationPacket), ClientBoundSetHeadRotationPacket.Deserialiser) },
            { 0x50, (typeof(ClientBoundSetActionBarTextPacket), ClientBoundSetActionBarTextPacket.Deserialiser) },
            { 0x56, (typeof(ClientBoundSetCameraPacket), ClientBoundSetCameraPacket.Deserialiser) },
            { 0x57, (typeof(ClientBoundSetCenterChunkPacket), ClientBoundSetCenterChunkPacket.Deserialiser) },
            { 0x5C, (typeof(ClientBoundSetEntityMetadataPacket), ClientBoundSetEntityMetadataPacket.Deserialiser) },
            { 0x69, (typeof(ClientBoundSetSubtitleTextPacket), ClientBoundSetSubtitleTextPacket.Deserialiser) },
            { 0x6B, (typeof(ClientBoundSetTitleTextPacket), ClientBoundSetTitleTextPacket.Deserialiser) },
            { 0x6C, (typeof(ClientBoundSetTitleAnimationTimesPacket), ClientBoundSetTitleAnimationTimesPacket.Deserialiser) },
            { 0x6D, (typeof(ClientBoundEntitySoundEffectPacket), ClientBoundEntitySoundEffectPacket.Deserialiser) },
            { 0x6E, (typeof(ClientBoundSoundEffectPacket), ClientBoundSoundEffectPacket.Deserialiser) },
            { 0x71, (typeof(ClientBoundStoreCookiePacket), ClientBoundStoreCookiePacket.Deserialiser) },
            { 0x72, (typeof(ClientBoundSystemChatMessagePacket), ClientBoundSystemChatMessagePacket.Deserialiser) },
            { 0x73, (typeof(ClientBoundSetTabListHeaderFooterPacket), ClientBoundSetTabListHeaderFooterPacket.Deserialiser) },
            { 0x7A, (typeof(ClientBoundTransferPacket), ClientBoundTransferPacket.Deserialiser) },
            { 0x7F, (typeof(ClientBoundUpdateTagsPacket), ClientBoundUpdateTagsPacket.Deserialiser) },
            { 0x81, (typeof(ClientBoundCustomReportDetailsPacket), ClientBoundCustomReportDetailsPacket.Deserialiser) },
            { 0x82, (typeof(ClientBoundServerLinksPacket), ClientBoundServerLinksPacket.Deserialiser) },
            { 0x84, (typeof(ClientBoundClearDialogPacket), ClientBoundClearDialogPacket.Deserialiser) }
        };
    }
}
