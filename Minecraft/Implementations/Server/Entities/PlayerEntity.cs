using Minecraft.Implementations.Server.Connections;
using Minecraft.Implementations.Server.Events;
using Minecraft.Packets;
using Minecraft.Packets.Play.ClientBound;
using Minecraft.Packets.Play.ServerBound;
using Minecraft.Schemas;

namespace Minecraft.Implementations.Server.Entities;

public class PlayerEntity : Entity {
    public string Name;

    private PlayerConnection _connection;
    public Func<PlayerConnection, bool> PlayerViewableRule { get; set; } = _ => true;
    
    // Listen to movement packets so we can do stuff
    public PlayerEntity(PlayerConnection connection, string name) : base(148) {
        Name = name;
        _connection = connection;
        ViewableRule = con => con != _connection && PlayerViewableRule(con);
        
        connection.Events.AddListener<PacketHandleEvent>(e => {
            switch (e.Packet) {
                case ServerBoundSetPlayerPositionPacket sp: {
                    Move(sp.Position);
                    break;
                }

                case ServerBoundSetPlayerPosAndRotPacket sp: {
                    Move(sp.Position, Angle.FromDegrees(sp.Yaw), Angle.FromDegrees(sp.Pitch));
                    break;
                }

                case ServerBoundSetPlayerRotationPacket sr: {
                    Move(Position, Angle.FromDegrees(sr.Yaw), Angle.FromDegrees(sr.Pitch));
                    break;
                }
            }
        });
    }

    public override MinecraftPacket[] GenerateSpawnEntityPackets() {
        MinecraftPacket[] arr = [
            new ClientBoundPlayerInfoUpdatePacket(
                new ClientBoundPlayerInfoUpdatePacket.PlayerData(ClientBoundPlayerInfoUpdatePacket.PlayerActions
                        .AddPlayer)
                    .WithPlayer(Uuid, new ClientBoundPlayerInfoUpdatePacket.PlayerData.AddPlayer {
                        Name = Name,
                        Properties = []
                    }))
        ];
        return arr.Combine(base.GenerateSpawnEntityPackets()).ToArray();
    }
}