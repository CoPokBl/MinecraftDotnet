using ManagedServer.Entities.Types;
using ManagedServer.Events;
using Minecraft.Implementations.Server.Events;
using Minecraft.Implementations.Tags;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Schemas;

namespace ManagedServer.Features.Basic;

public class PlayerSkinLayersFeature : ScopedFeature {
    private static readonly Tag<SkinParts> PreLoginSkinPartsTag = new("minecraftdotnet:skinlayersfeat:skinparts");
    
    public override void Register() {
        AddEventHandler<PacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClientInformationPacket packet) {
                return;
            }
            
            e.Connection.SetTag(PreLoginSkinPartsTag, packet.DisplayedSkinParts);
        });
        
        AddEventHandler<PlayerLoginEvent>(e => {
            if (!e.Player.Connection.HasTag(PreLoginSkinPartsTag)) {
                return;
            }
            
            SetSkinParts(e.Player, e.Player.Connection.GetTag(PreLoginSkinPartsTag));
        });
        
        AddEventHandler<PlayerPacketHandleEvent>(e => {
            if (e.Packet is not ServerBoundClientInformationPacket packet) {
                return;
            }

            SetSkinParts(e.Player, packet.DisplayedSkinParts);
        });
    }
    
    private static void SetSkinParts(PlayerEntity player, SkinParts skinParts) {
        player.Meta = player.Meta with {
            SkinFlags = skinParts
        };
    }
}
