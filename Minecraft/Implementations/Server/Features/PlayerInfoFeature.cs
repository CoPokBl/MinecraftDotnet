using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets.Config.ServerBound;
using Minecraft.Packets.Login.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Features;

public class PlayerInfoFeature : IServerFeature {
    private const string DataId = "minecraftdotnet:playerinfofeature:info";
    
    public void Register(MinecraftServer server) {
        server.Events.AddListener<PacketHandleEvent>(e => {
            switch (e.Packet) {
                case ServerBoundPluginMessagePacket pm: {
                    switch (pm.Channel) {
                        case "minecraft:brand":
                            SetInfo(e.Connection, GetInfo(e.Connection) with {
                                Brand = new DataReader(pm.Data).ReadString()
                            });
                            break;
                    }
                    break;
                }
                
                case ServerBoundLoginStartPacket ls: {
                    SetInfo(e.Connection, GetInfo(e.Connection) with {
                        Username = ls.Name
                    });
                    break;
                }

                case ServerBoundClientInformationPacket ci: {
                    SetInfo(e.Connection, GetInfo(e.Connection) with {
                        Locale = ci.Locale,
                        AllowsServerListing = ci.AllowServerListing,
                        HasChatColours = ci.ChatColors,
                        HasTextFiltering = ci.EnableTextFiltering,
                        DominantHand = ci.MainHand,
                        ParticleStatus = ci.ParticleStatus,
                        ViewDistance = ci.ViewDistance,
                        SkinParts = ci.DisplayedSkinParts
                    });
                    break;
                }
            }
        });
    }
    
    public void Unregister() {
        
    }
    
    public Type[] GetDependencies() {
        return [];
    }

    public static PlayerInfo GetInfo(PlayerConnection connection) {
        if (!connection.Data.TryGetValue(DataId, out object? value)) {
            return new PlayerInfo();
        }
        return (PlayerInfo)(value ?? new PlayerInfo());
    }

    private void SetInfo(PlayerConnection connection, PlayerInfo info) {
        connection.Data[DataId] = info;
    }

    public record PlayerInfo(
        string? Username = null, 
        string? Brand = null, 
        string? Locale = null, 
        bool AllowsServerListing = true,
        bool HasChatColours = true,
        bool HasTextFiltering = false,
        DominantHand DominantHand = DominantHand.Right,
        ParticleStatus ParticleStatus = ParticleStatus.All,
        byte ViewDistance = 0x00,
        SkinParts SkinParts = SkinParts.All);
}